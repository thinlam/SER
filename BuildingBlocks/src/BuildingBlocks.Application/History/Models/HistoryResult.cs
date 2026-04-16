namespace BuildingBlocks.Application.History.Models;

/// <summary>
/// Kết quả truy vấn lịch sử có phân trang
/// </summary>
/// <typeparam name="T">Loại DTO trả về</typeparam>
public class HistoryResult<T>
{
    /// <summary>
    /// Danh sách kết quả
    /// </summary>
    public List<T> Items { get; set; } = [];

    /// <summary>
    /// Tổng số bản ghi
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// Số trang hiện tại
    /// </summary>
    public int PageIndex { get; set; }

    /// <summary>
    /// Số bản ghi mỗi trang
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Ctor mặc định
    /// </summary>
    public HistoryResult()
    {
    }

    /// <summary>
    /// Ctor đầy đủ
    /// </summary>
    public HistoryResult(List<T> items, int totalCount, int pageIndex, int pageSize)
    {
        Items = items;
        TotalCount = totalCount;
        PageIndex = pageIndex;
        PageSize = pageSize;
    }
}
