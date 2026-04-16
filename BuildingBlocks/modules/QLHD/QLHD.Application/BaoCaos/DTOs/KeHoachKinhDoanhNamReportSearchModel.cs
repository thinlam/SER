
namespace QLHD.Application.BaoCaos.DTOs;

/// <summary>
/// Search model for ke hoach kinh doanh nam report
/// </summary>
public record KeHoachKinhDoanhNamReportSearchModel
{
    /// <summary>
    /// Từ tháng (required)
    /// </summary>
    public MonthYear TuThang { get; set; }

    /// <summary>
    /// Đến tháng (required)
    /// </summary>
    public MonthYear DenThang { get; set; }

    /// <summary>
    /// Bộ phận (optional)
    /// </summary>
    public long? PhongBanPhuTrachChinhId { get; set; }

    /// <summary>
    /// Người phụ trách chính (optional)
    /// </summary>
    public long? NguoiPhuTrachChinhId { get; set; }

    /// <summary>
    /// ID kế hoạch kinh doanh năm (required)
    /// </summary>
    public Guid KeHoachKinhDoanhNamId { get; set; }

    /// <summary>
    /// Loại lãi (optional) - references DanhMucLoaiLai
    /// </summary>
    public int? LoaiLaiId { get; set; }

    /// <summary>
    /// Năm báo cáo (optional)
    /// </summary>
    public int? NamBaoCao { get; set; }

    /// <summary>
    /// Loại báo cáo - determines response DTO type
    /// Use LoaiBaoCaoConstants.TongHop or LoaiBaoCaoConstants.ChiTiet
    /// </summary>
    public string LoaiBaoCao { get; set; } = string.Empty;
}