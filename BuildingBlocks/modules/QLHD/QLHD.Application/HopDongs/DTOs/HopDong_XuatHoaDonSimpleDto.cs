using BuildingBlocks.Domain.ValueTypes;

namespace QLHD.Application.HopDongs.DTOs;

/// <summary>
/// DTO cho xuất hóa đơn theo hợp đồng độc lập (gộp kế hoạch + thực tế)
/// </summary>
public class HopDong_XuatHoaDonSimpleDto
{
    public Guid Id { get; set; }
    public int LoaiThanhToanId { get; set; }
    public string? TenLoaiThanhToan { get; set; }

    #region Kế hoạch

    public MonthYear ThoiGianKeHoach { get; set; }
    public decimal PhanTramKeHoach { get; set; }
    public decimal GiaTriKeHoach { get; set; }
    public string? GhiChuKeHoach { get; set; }

    #endregion

    #region Thực tế

    public DateOnly? ThoiGianThucTe { get; set; }
    public decimal? GiaTriThucTe { get; set; }
    public string? GhiChuThucTe { get; set; }
    public string? SoHoaDon { get; set; }
    public string? KyHieuHoaDon { get; set; }
    public DateOnly? NgayHoaDon { get; set; }

    #endregion
}