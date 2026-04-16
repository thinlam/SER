namespace QLHD.Application.BaoCaos.DTOs;

/// <summary>
/// Báo cáo chi tiết bộ phận - dữ liệu theo từng dự án/hợp đồng trong phòng ban
/// </summary>
public class ChiTietBoPhanDto
{
    /// <summary>
    /// ID phòng ban
    /// </summary>
    public long PhongBanId { get; init; }

    /// <summary>
    /// Tên phòng ban
    /// </summary>
    public string? TenPhongBan { get; init; }

    /// <summary>
    /// ID dự án hoặc hợp đồng
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Loại: DU_AN hoặc HOP_DONG (use LoaiDuAnHopDongConstants)
    /// </summary>
    public string Loai { get; init; } = string.Empty;

    /// <summary>
    /// Tên dự án hoặc hợp đồng
    /// </summary>
    public string? Ten { get; init; }

    /// <summary>
    /// Doanh số kỳ kế hoạch (from DuAn.GiaTriDuKien)
    /// </summary>
    public decimal DoanhSoKyKeHoach { get; init; }

    /// <summary>
    /// Doanh số kỳ thực tế (from HopDong.GiaTri)
    /// </summary>
    public decimal DoanhSoKyThucTe { get; init; }

    /// <summary>
    /// Thu tiền kế hoạch
    /// </summary>
    public decimal ThuTienKeHoach { get; init; }

    /// <summary>
    /// Thu tiền thực tế
    /// </summary>
    public decimal ThuTienThucTe { get; init; }

    /// <summary>
    /// Xuất hoá đơn kế hoạch
    /// </summary>
    public decimal XuatHoaDonKeHoach { get; init; }

    /// <summary>
    /// Xuất hoá đơn thực tế
    /// </summary>
    public decimal XuatHoaDonThucTe { get; init; }

    /// <summary>
    /// Chi phí kế hoạch
    /// </summary>
    public decimal ChiPhiKeHoach { get; init; }

    /// <summary>
    /// Chi phí thực tế
    /// </summary>
    public decimal ChiPhiThucTe { get; init; }

    /// <summary>
    /// Phần trăm doanh số kỳ (ThucTe/KeHoach * 100)
    /// </summary>
    public decimal PhanTramKy => DoanhSoKyKeHoach == 0 ? 0 : Math.Round(DoanhSoKyThucTe / DoanhSoKyKeHoach * 100, 2);

    /// <summary>
    /// Phần trăm thu tiền (ThucTe/KeHoach * 100)
    /// </summary>
    public decimal PhanTramThuTien => ThuTienKeHoach == 0 ? 0 : Math.Round(ThuTienThucTe / ThuTienKeHoach * 100, 2);

    /// <summary>
    /// Phần trăm xuất hoá đơn (ThucTe/KeHoach * 100)
    /// </summary>
    public decimal PhanTramXuatHoaDon => XuatHoaDonKeHoach == 0 ? 0 : Math.Round(XuatHoaDonThucTe / XuatHoaDonKeHoach * 100, 2);

    /// <summary>
    /// Phần trăm chi phí (ThucTe/KeHoach * 100)
    /// </summary>
    public decimal PhanTramChiPhi => ChiPhiKeHoach == 0 ? 0 : Math.Round(ChiPhiThucTe / ChiPhiKeHoach * 100, 2);
}