namespace BuildingBlocks.Domain.Interfaces;

/// <summary>
/// Interface để entity tự quyết định có audit hay không
/// </summary>
public interface IConditionalAuditable
{
    /// <summary>
    /// Kiểm tra xem entity có cần audit hay không dựa trên logic bên trong
    /// </summary>
    bool ShouldAudit();

    /// <summary>
    /// Kiểm tra xem entity có cần audit hay không với khả năng override từ bên ngoài
    /// </summary>
    /// <param name="forceAudit">true: buộc audit, false: buộc không audit, null: sử dụng logic bên trong</param>
    bool ShouldAudit(bool? forceAudit);

    /// <summary>
    /// Tắt audit cho entity này
    /// </summary>
    void DisableAudit();

    /// <summary>
    /// Bật lại audit cho entity này
    /// </summary>
    void EnableAudit();
}
