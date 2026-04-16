using BuildingBlocks.Domain.ValueTypes;
using QLHD.Domain.Interfaces;

namespace QLHD.Application.XuatHoaDons.DTOs;

/// <summary>
/// DTO cho hợp đồng có kế hoạch xuất hóa đơn
/// </summary>
public class HopDongXuatHoaDonDto : IHopDongBase {
    public Guid Id { get; set; }
    public string? SoHopDong { get; set; }
    public DateOnly NgayKy { get; set; }
    public string? Ten { get; set; }
    public Guid? DuAnId { get; set; }
    public string? TenDuAn { get; set; }
    public Guid KhachHangId { get; set; }
    public string? TenKhachHang { get; set; }
    public decimal GiaTri { get; set; }
    public int TrangThaiId { get; set; }
    public string? TenTrangThai { get; set; }

    /// <summary>
    /// Danh sách kế hoạch xuất hóa đơn
    /// </summary>
    public List<XuatHoaDonKeHoachSimpleDto>? KeHoach { get; set; }

    /// <summary>
    /// Danh sách thực tế xuất hóa đơn
    /// </summary>
    public List<XuatHoaDonThucTeSimpleDto>? ThucTe { get; set; }
}

/// <summary>
/// DTO đơn giản cho kế hoạch xuất hóa đơn trong danh sách
/// </summary>
public class XuatHoaDonKeHoachSimpleDto {
    public MonthYear ThoiGian { get; set; }
    public decimal GiaTri { get; set; }
}
/// <summary>
/// DTO đơn giản cho thực tế xuất hóa đơn trong danh sách
/// </summary>
public class XuatHoaDonThucTeSimpleDto {
    public DateOnly? ThoiGian { get; set; }
    public decimal? GiaTri { get; set; }
    public string? SoHoaDon { get; set; }
    public string? KyHieuHoaDon { get; set; }
    public DateOnly? NgayHoaDon { get; set; }
}