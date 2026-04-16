namespace QLHD.Application.BaoCaos.DTOs;

/// <summary>
/// Kế hoạch tháng - báo cáo tháng
/// </summary>
public class KeHoachThang_BaoCaoThangDto {

    /// <summary>
    /// Bộ phận id
    /// </summary>
    public long PhongBanId { get; init; }
    /// <summary>
    /// Tên bộ phận
    /// </summary>
    public string? TenPhongBan { get; init; }

    /// <summary>
    /// Doanh số ký kế hoạch (DuAn.GiaTriDuKien)
    /// </summary>
    public decimal DoanhSoKyKeHoach { get; init; }
    /// <summary>
    /// Doanh số ký thực tế (HopDong.GiaTri)
    /// </summary>
    public decimal DoanhSoKyThucTe { get; init; }
    /// <summary>
    /// Phần trăm ký (Thực tế / Kế hoạch * 100)
    /// </summary>
    public decimal PhanTramKy => DoanhSoKyKeHoach == 0 ? 0 : Math.Round(DoanhSoKyThucTe / DoanhSoKyKeHoach * 100, 2);

    /// <summary>
    /// Thu tiền kế hoạch
    /// </summary>
    public decimal ThuTienKeHoach { get; init; }
    /// <summary>
    /// Thu tiền thực tế
    /// </summary>
    public decimal ThuTienThucTe { get; init; }

    /// <summary>
    /// Phần trăm thu tiền (Thực tế / Kế hoạch * 100)
    /// </summary>
    public decimal PhanTramThuTien => ThuTienKeHoach == 0 ? 0 : Math.Round(ThuTienThucTe / ThuTienKeHoach * 100, 2);

    /// <summary>
    /// Xuất hoá đơn kế hoạch
    /// </summary>
    public decimal XuatHoaDonKeHoach { get; init; }
    /// <summary>
    /// Xuất hoá đơn thực tế
    /// </summary>
    public decimal XuatHoaDonThucTe { get; init; }

    /// <summary>
    /// Phần trăm xuất hoá đơn (Thực tế / Kế hoạch * 100)
    /// </summary>
    public decimal PhanTramXuatHoaDon => XuatHoaDonKeHoach == 0 ? 0 : Math.Round(XuatHoaDonThucTe / XuatHoaDonKeHoach * 100, 2);

    /// <summary>
    /// Chi phí kế hoạch
    /// </summary>
    public decimal ChiPhiKeHoach { get; init; }
    /// <summary>
    /// Chi phí thực tế
    /// </summary>
    public decimal ChiPhiThucTe { get; init; }

    /// <summary>
    /// Phần trăm chi phí (Thực tế / Kế hoạch * 100)
    /// </summary>
    public decimal PhanTramChiPhi => ChiPhiKeHoach == 0 ? 0 : Math.Round(ChiPhiThucTe / ChiPhiKeHoach * 100, 2);

}
