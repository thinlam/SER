using BuildingBlocks.Application.History.Extensions;
using BuildingBlocks.Application.History.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Application.History;

/// <summary>
/// Implementation của IHistoryQueryService
/// </summary>
public class HistoryQueryService(
    IRepository<AuditLog, Guid> auditLogRepository,
    IRepository<UserMaster, long> userMasterRepository)
    : IHistoryQueryService
{
    private readonly IRepository<AuditLog, Guid> _auditLogRepository = auditLogRepository;
    private readonly IRepository<UserMaster, long> _userMasterRepository = userMasterRepository;

    public async Task<List<AuditLog>> GetCapMoiLogsAsync(
        HistoryFilterCriteria criteria,
        CancellationToken ct = default)
    {
        return await _auditLogRepository
            .GetOriginalSet()
            .WhereCapMoi(criteria.CapPhatEntityName, criteria.EntityIds)
            .ToListAsync(ct);
    }

    public async Task<List<AuditLog>> GetDieuChinhLogsAsync(
        HistoryFilterCriteria criteria,
        CancellationToken ct = default)
    {
        if (string.IsNullOrEmpty(criteria.DetailEntityName) ||
            criteria.DetailEntityIds == null ||
            criteria.DetailEntityIds.Count == 0)
        {
            return [];
        }

        return await _auditLogRepository
            .GetOriginalSet()
            .WhereDieuChinh(criteria.DetailEntityName, criteria.DetailEntityIds)
            .ToListAsync(ct);
    }

    public async Task<List<AuditLog>> GetThuHoiLogsAsync(
        HistoryFilterCriteria criteria,
        CancellationToken ct = default)
    {
        return await _auditLogRepository
            .GetOriginalSet()
            .WhereThuHoi(criteria.CapPhatEntityName, criteria.EntityIds)
            .ToListAsync(ct);
    }

    public async Task<Dictionary<DateTimeOffset, string?>> GetLyDoMapAsync(
        string parentEntityName,
        string parentEntityId,
        string lyDoPropertyName,
        CancellationToken ct = default)
    {
        return await _auditLogRepository
            .GetOriginalSet()
            .GetLyDoMapAsync(parentEntityName, parentEntityId, lyDoPropertyName, ct);
    }

    public async Task<Dictionary<string, string>> GetUserDictionaryAsync(
        List<string> userIds,
        CancellationToken ct = default)
    {
        return await _userMasterRepository
            .GetOriginalSet()
            .Where(u => u.UserPortalId.HasValue && userIds.Contains(u.UserPortalId.Value.ToString()))
            .ToDictionaryAsync(u => u.UserPortalId!.Value.ToString(), u => u.HoTen ?? string.Empty, ct);
    }
}
