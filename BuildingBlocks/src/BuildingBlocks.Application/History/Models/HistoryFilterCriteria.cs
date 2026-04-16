namespace BuildingBlocks.Application.History.Models;

/// <summary>
/// Tiêu chí lọc lịch sử từ AuditLog
/// </summary>
public class HistoryFilterCriteria
{
    /// <summary>
    /// ID của root entity (ví dụ: HaTangId hoặc CapPhatDuongTruyenId)
    /// </summary>
    public string RootEntityId { get; set; } = string.Empty;

    /// <summary>
    /// Danh sách ID của entity CapPhat để lọc
    /// </summary>
    public List<string> EntityIds { get; set; } = [];

    /// <summary>
    /// Tên entity cha để lookup LyDo (ví dụ: nameof(HaTang))
    /// </summary>
    public string? ParentEntityName { get; set; }

    /// <summary>
    /// Tên entity CapPhat (ví dụ: nameof(CapPhatHaTang))
    /// </summary>
    public string CapPhatEntityName { get; set; } = string.Empty;

    /// <summary>
    /// Tên entity ChiTiet (ví dụ: nameof(ChiTietHaTang))
    /// </summary>
    public string? DetailEntityName { get; set; }

    /// <summary>
    /// Danh sách ID của entity ChiTiet cho query Điều chỉnh
    /// </summary>
    public List<string>? DetailEntityIds { get; set; }

    /// <summary>
    /// Số trang hiện tại
    /// </summary>
    public int PageIndex { get; set; } = 1;

    /// <summary>
    /// Số bản ghi mỗi trang
    /// </summary>
    public int PageSize { get; set; } = 10;
}
