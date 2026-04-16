using BuildingBlocks.Application.History.Models;

namespace BuildingBlocks.Application.History;

/// <summary>
/// Service truy vấn lịch sử từ AuditLog
/// </summary>
public interface IHistoryQueryService
{
    /// <summary>
    /// Get audit logs cho Cấp Mới (CM) - bản ghi cấp phát mới
    /// </summary>
    Task<List<AuditLog>> GetCapMoiLogsAsync(
        HistoryFilterCriteria criteria,
        CancellationToken ct = default);

    /// <summary>
    /// Get audit logs cho Điều Chỉnh (DC) - bản ghi điều chỉnh
    /// </summary>
    Task<List<AuditLog>> GetDieuChinhLogsAsync(
        HistoryFilterCriteria criteria,
        CancellationToken ct = default);

    /// <summary>
    /// Get audit logs cho Thu Hồi (TH) - bản ghi thu hồi
    /// </summary>
    Task<List<AuditLog>> GetThuHoiLogsAsync(
        HistoryFilterCriteria criteria,
        CancellationToken ct = default);

    /// <summary>
    /// Get map LyDo (lý do) từ entity cha
    /// </summary>
    Task<Dictionary<DateTimeOffset, string?>> GetLyDoMapAsync(
        string parentEntityName,
        string parentEntityId,
        string lyDoPropertyName,
        CancellationToken ct = default);

    /// <summary>
    /// Get dictionary user từ UserMaster
    /// </summary>
    Task<Dictionary<string, string>> GetUserDictionaryAsync(
        List<string> userIds,
        CancellationToken ct = default);
}
