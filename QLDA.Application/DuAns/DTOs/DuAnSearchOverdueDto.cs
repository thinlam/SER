namespace QLDA.WebApi.Models.DuAns;

/// <summary>
/// Danh sách dự án đang trễ hạn thực hiện tại  bước có thời hạn
/// </summary>
public record DuAnSearchOverdueDto : AggregateRootPagination, IMayHaveGlobalFilter {
    /// <summary>
    /// Ngày dự kiến bắt đầu hoặc kết thúc - từ ngày
    /// </summary>
    /// <example>2000-01-01</example>
    public DateOnly? DuKienTuNgay { get; init; }

    /// <summary>
    /// Ngày dự kiến hoặc kết thúc - đến ngày <br/>
    /// NgayBatDau
    /// </summary>
    /// <example>2222-01-01</example>
    public DateOnly? DuKienDenNgay { get; init; }

    /// <summary>
    /// Tìm đơn vị phụ trách chính <br/>
    /// DonViPhuTrachChinhId > 0
    /// </summary>
    /// <example>-1</example>
    public long? DonViPhuTrachChinhId { get; init; }

    /// <summary>
    /// Tìm theo bước dự án <br/>
    /// BuocId > 0
    /// </summary>
    /// <example>-1</example>
    public int? BuocId { get; init; }

    /// <summary>
    /// Tìm trong toàn bộ danh sách giá trị gần giống
    /// </summary>
    /// <example>TLTP.Test</example>
    public string? GlobalFilter { get; set; }
}