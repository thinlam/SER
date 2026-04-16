namespace BuildingBlocks.Application.History.Factories;

/// <summary>
/// Factory interface để tạo DTO lịch sử từ AuditLog
/// </summary>
/// <typeparam name="TDto">Loại DTO trả về</typeparam>
public interface IHistoryDtoFactory<TDto>
{
    /// <summary>
    /// Tạo DTO cho Cấp Mới (CM)
    /// </summary>
    Task<TDto> CreateCapMoiAsync(
        AuditLog auditLog,
        string? entityName,
        Dictionary<string, string> users,
        CancellationToken ct = default);

    /// <summary>
    /// Tạo DTO cho Điều Chỉnh (DC)
    /// </summary>
    Task<TDto> CreateDieuChinhAsync(
        DateTimeOffset createdAt,
        string createdBy,
        Dictionary<string, string> users,
        string? lyDo,
        List<AuditLog> detailAuditLogs,
        CancellationToken ct = default);

    /// <summary>
    /// Tạo DTO cho Thu Hồi (TH)
    /// </summary>
    Task<TDto> CreateThuHoiAsync(
        AuditLog auditLog,
        Dictionary<string, string> users,
        string? lyDo,
        CancellationToken ct = default);
}
