namespace QLHD.Application.BaoCaos.DTOs;

/// <summary>
/// Search model for Ke Hoach Thang report with pagination
/// </summary>
public record KeHoachThangSearchModel : AggregateRootPagination {
    /// <summary>
    /// Từ tháng
    /// </summary>
    public MonthYear TuThang { get; set; }
    /// <summary>
    /// Đến tháng 
    /// </summary>
    public MonthYear DenThang { get; set; }
    /// <summary>
    /// Bộ phận
    /// </summary>
    public long? PhongBanPhuTrachChinhId { get; set; }
    /// <summary>
    /// ID kế hoạch tháng
    /// </summary>
    public int? KeHoachThangId { get; set; }
    /// <summary>
    /// Loại báo cáo
    /// </summary>
    public string LoaiBaoCao { get; set; } = string.Empty;
}
