using System.Text.Json;
using BuildingBlocks.CrossCutting.DateTimes;
using BuildingBlocks.CrossCutting.ExtensionMethods;
using BuildingBlocks.Domain.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Persistence.Interceptors;

public class AuditInterceptor(IServiceProvider serviceProvider) : SaveChangesInterceptor
{
    private readonly IDateTimeProvider _dateTimeProvider = serviceProvider.GetRequiredService<IDateTimeProvider>();
    private readonly IUserProvider? _userProvider = serviceProvider.GetService<IUserProvider>();

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context != null)
        {
            UpdateAuditFields(eventData.Context);
            CreateAuditLogs(eventData.Context);
        }
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
    DbContextEventData eventData,
    InterceptionResult<int> result,
    CancellationToken cancellationToken = default)
    {
        if (eventData.Context != null)
        {
            UpdateAuditFields(eventData.Context);
            CreateAuditLogs(eventData.Context);
        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    #region Audit Fields (from AuditableEntityInterceptor)

    private void UpdateAuditFields(DbContext context)
    {
        if (_userProvider == null) return;

        var offsetUtcNow = _dateTimeProvider.OffsetUtcNow;

        // Handle full entity metadata entries (have all audit interfaces)
        var fullAuditEntries = context.ChangeTracker.Entries()
            .Where(e => e.Entity is IEntityMetadata &&
                       e.Entity is IMayHaveCreated &&
                       e.Entity is IMayHaveUpdate &&
                       e.Entity is IUnixTimeIndex &&
                       e.Entity is not AuditLog && // ✅ Exclude AuditLog from audit field updates
                       (e.State == EntityState.Added || e.State == EntityState.Modified ||
                        AuditExtensions.HasChangedOwnedEntities(e)));

        if (fullAuditEntries.Any())
        {
            var userId = _userProvider.Id.ToString(); foreach (var entry in fullAuditEntries)
            {
                var entity = entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (entity is IInheritanceEntity inheritance)
                    {
                        inheritance.Loai = entity.GetType().Name;
                    }

                    ((IMayHaveCreated)entity).CreatedBy = userId;
                    ((IMayHaveCreated)entity).CreatedAt = offsetUtcNow;
                    ((IUnixTimeIndex)entity).Index = offsetUtcNow.ToUnixTimeSeconds();
                }

                ((IMayHaveUpdate)entity).UpdatedBy = userId;
                ((IMayHaveUpdate)entity).UpdatedAt = offsetUtcNow;
            }
        }

        // Handle ICreatedAt entries (only need timestamp, no userId)
        var createdAtEntries = context.ChangeTracker.Entries()
            .Where(e => e.Entity is ICreatedAt &&
                       !(e.Entity is IEntityMetadata && e.Entity is IMayHaveCreated) &&
                       e.Entity is not AuditLog && // ✅ Exclude AuditLog from audit field updates
                       (e.State == EntityState.Added || e.State == EntityState.Modified ||
                        AuditExtensions.HasChangedOwnedEntities(e)));

        foreach (var entry in createdAtEntries)
        {
            var createdAtEntity = (ICreatedAt)entry.Entity;

            if (entry.State == EntityState.Added)
            {
                createdAtEntity.CreatedAt = offsetUtcNow;
            }
        }
    }

    #endregion

    #region Audit Logs
    private static string GetEntityId(EntityEntry entry)
    {
        var keyProperty = entry.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey());
        return keyProperty?.CurrentValue?.ToString() ?? string.Empty;
    }
    private static string SerializeEntity(PropertyValues values, List<string>? includedProperties = null)
    {
        var dict = new Dictionary<string, object?>();

        foreach (var property in values.Properties)
        {
            if (includedProperties != null && !includedProperties.Contains(property.Name))
                continue;

            var value = values[property];

            // Skip navigation properties (IEnumerable) except string
            if (value is System.Collections.IEnumerable enumerable && value is not string)
                continue;

            dict[property.Name] = value;
        }

        return JsonSerializer.Serialize(dict, new JsonSerializerOptions
        {
            WriteIndented = false,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        });
    }
    private void CreateAuditLogs(DbContext context)
    {

        if (_userProvider == null) return;

        var entries = context.ChangeTracker.Entries()
            .Where(e => e.State is EntityState.Added or EntityState.Modified or EntityState.Deleted)
            .Where(e => e.Entity is IAuditable) // ✅ Chỉ audit entities implement IAuditable
            .Where(e => e.Entity is not AuditLog) // ✅ Tránh audit chính AuditLog
            .Where(e => ShouldAuditEntity(e.Entity)) // ✅ Kiểm tra điều kiện audit từ IConditionalAuditable
            .ToList();

        var offsetUtcNow = _dateTimeProvider.OffsetUtcNow;
        var userId = _userProvider.Id.ToString();

        foreach (var entry in entries)
        {
            var auditLog = CreateAuditLog(entry);
            if (auditLog != null)
            {
                // ✅ Manually set audit fields for AuditLog (since it's excluded from UpdateAuditFields)
                auditLog.CreatedBy = userId;
                auditLog.CreatedAt = offsetUtcNow;
                context.Set<AuditLog>().Add(auditLog);
            }
        }
    }

    private static bool ShouldAuditEntity(object entity)
    {
        // Nếu entity implement IConditionalAuditable, kiểm tra điều kiện
        if (entity is IConditionalAuditable conditionalAuditable)
        {
            // Sử dụng method mặc định để kiểm tra điều kiện audit
            return conditionalAuditable.ShouldAudit();
        }

        // Mặc định audit tất cả entities implement IAuditable
        return true;
    }
    private static AuditLog? CreateAuditLog(EntityEntry entry)
    {
        var entityName = entry.Metadata.ClrType.Name;
        var entityId = GetEntityId(entry);

        if (string.IsNullOrEmpty(entityId))
            return null;

        var auditLog = new AuditLog
        {
            Id = GuidExtensions.GetSequentialGuidId(),
            EntityName = entityName,
            EntityId = entityId,
            Action = entry.State.ToString(),
        };

        switch (entry.State)
        {
            case EntityState.Added:
                auditLog.NewValues = SerializeEntity(entry.CurrentValues);
                break;

            case EntityState.Modified:
                var changedColumns = entry.Properties
                    .Where(p => p.IsModified)
                    .Where(p => p.Metadata.Name is not ("CreatedAt" or "CreatedBy" or "UpdatedAt" or "UpdatedBy")) // ✅ Bỏ qua audit fields
                    .Select(p => p.Metadata.Name)
                    .ToList();

                if (changedColumns.Count == 0)
                    return null;

                // Lấy danh sách tất cả các trường trừ audit fields (bao gồm cả đã thay đổi và chưa thay đổi)
                var allColumns = entry.Properties
                    .Where(p => p.Metadata.Name is not ("CreatedAt" or "CreatedBy" or "UpdatedAt" or "UpdatedBy"))
                    .Select(p => p.Metadata.Name)
                    .ToList();

                auditLog.OldValues = SerializeEntity(entry.OriginalValues, changedColumns);
                auditLog.NewValues = SerializeEntity(entry.CurrentValues, changedColumns);
                auditLog.CurrentValues = SerializeEntity(entry.CurrentValues, allColumns); // Tất cả các trường (snapshot đầy đủ)
                auditLog.ChangedColumns = JsonSerializer.Serialize(changedColumns);
                break;

            case EntityState.Deleted:
                auditLog.OldValues = SerializeEntity(entry.OriginalValues);
                break;
        }

        return auditLog;
    }

    #endregion
}

internal static class AuditExtensions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(r =>
            r.TargetEntry != null &&
            r.TargetEntry.Metadata.IsOwned() &&
            r.TargetEntry.State is EntityState.Added or EntityState.Modified);
}