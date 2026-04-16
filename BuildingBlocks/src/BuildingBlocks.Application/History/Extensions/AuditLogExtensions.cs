using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Application.History.Extensions;

/// <summary>
/// Extension methods cho AuditLog queries
/// </summary>
public static class AuditLogExtensions
{
    /// <summary>
    /// Filter audit logs cho Cấp Mới (Added, không có OldValues)
    /// </summary>
    public static IQueryable<AuditLog> WhereCapMoi(
        this IQueryable<AuditLog> query,
        string entityName,
        List<string> entityIds)
    {
        return query.Where(a =>
            a.EntityName == entityName &&
            a.Action == EntityState.Added.ToString() &&
            entityIds.Contains(a.EntityId) &&
            a.OldValues == null);
    }

    /// <summary>
    /// Filter audit logs cho Điều Chỉnh (Modified, có OldValues)
    /// </summary>
    public static IQueryable<AuditLog> WhereDieuChinh(
        this IQueryable<AuditLog> query,
        string entityName,
        List<string> entityIds)
    {
        return query.Where(a =>
            a.EntityName == entityName &&
            a.Action == EntityState.Modified.ToString() &&
            entityIds.Contains(a.EntityId) &&
            a.OldValues != null);
    }

    /// <summary>
    /// Filter audit logs cho Thu Hồi (có ThuHoi trong ChangedColumns)
    /// </summary>
    public static IQueryable<AuditLog> WhereThuHoi(
        this IQueryable<AuditLog> query,
        string entityName,
        List<string> entityIds)
    {
        return query.Where(a =>
            a.EntityName == entityName &&
            entityIds.Contains(a.EntityId) &&
            a.ChangedColumns != null &&
            a.ChangedColumns.Contains("ThuHoi"));
    }

    /// <summary>
    /// Get LyDo (lý do) từ audit logs của entity cha
    /// </summary>
    public static async Task<Dictionary<DateTimeOffset, string?>> GetLyDoMapAsync(
        this IQueryable<AuditLog> query,
        string parentEntityName,
        string parentEntityId,
        string lyDoPropertyName,
        CancellationToken ct = default)
    {
        var auditLogs = await query
            .Where(a =>
                a.EntityName == parentEntityName &&
                a.EntityId == parentEntityId &&
                a.ChangedColumns != null &&
                a.ChangedColumns.Contains(lyDoPropertyName))
            .OrderByDescending(a => a.Index)
            .ToListAsync(ct);

        var lyDoMap = new Dictionary<DateTimeOffset, string?>();
        foreach (var audit in auditLogs)
        {
            try
            {
                var newValues = string.IsNullOrEmpty(audit.NewValues)
                    ? (JsonElement?)null
                    : JsonSerializer.Deserialize<JsonElement>(audit.NewValues);

                var lyDo = newValues?.GetProperty(lyDoPropertyName).GetString();
                if (!lyDoMap.ContainsKey(audit.CreatedAt))
                {
                    lyDoMap[audit.CreatedAt] = lyDo;
                }
            }
            catch
            {
                continue;
            }
        }
        return lyDoMap;
    }

    /// <summary>
    /// Parse JSON element thành object
    /// </summary>
    public static object? ParseJsonValue(JsonElement element)
    {
        return element.ValueKind switch
        {
            JsonValueKind.String => element.TryGetDateTimeOffset(out var dto)
                ? dto
                : element.GetString(),
            JsonValueKind.Number => element.TryGetInt64(out var longVal)
                ? longVal
                : element.TryGetInt32(out var intVal)
                    ? intVal
                    : element.GetDouble(),
            JsonValueKind.True => true,
            JsonValueKind.False => false,
            JsonValueKind.Null => null,
            _ => element.ToString()
        };
    }
}
