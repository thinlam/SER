namespace BuildingBlocks.Domain.Constants;

/// <summary>
/// Constants cho phân trang và giới hạn dữ liệu
/// </summary>
public static class PaginationConstants
{
    /// <summary>
    /// Kích thước phân trang tối đa là 100 record
    /// </summary>
    public const int MAX_PAGE_SIZE = 1000;

    /// <summary>
    /// Kích thước phân trang mặc định
    /// </summary>
    public const int DEFAULT_PAGE_SIZE = 10;

    /// <summary>
    /// Trang đầu tiên
    /// </summary>
    public const int FIRST_PAGE = 1;
}
