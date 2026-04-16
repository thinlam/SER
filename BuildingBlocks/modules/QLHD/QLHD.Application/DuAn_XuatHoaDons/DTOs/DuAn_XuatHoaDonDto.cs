using BuildingBlocks.Domain.ValueTypes;

namespace QLHD.Application.DuAn_XuatHoaDons.DTOs;

/// <summary>
/// DTO cho xuất hóa đơn theo dự án (gộp kế hoạch + thực tế)
/// </summary>
public class DuAn_XuatHoaDonDto
{
    public Guid Id { get; set; }
    public Guid DuAnId { get; set; }
    public Guid? HopDongId { get; set; }
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

public static class DuAn_XuatHoaDonMapping
{
    public static DuAn_XuatHoaDonDto ToDto(this DuAn_XuatHoaDon entity)
    {
        return new DuAn_XuatHoaDonDto
        {
            Id = entity.Id,
            DuAnId = entity.DuAnId,
            HopDongId = entity.HopDongId,
            LoaiThanhToanId = entity.LoaiThanhToanId,
            TenLoaiThanhToan = entity.LoaiThanhToan?.Ten,
            ThoiGianKeHoach = MonthYear.FromDateOnly(entity.ThoiGianKeHoach),
            PhanTramKeHoach = entity.PhanTramKeHoach,
            GiaTriKeHoach = entity.GiaTriKeHoach,
            GhiChuKeHoach = entity.GhiChuKeHoach,
            ThoiGianThucTe = entity.ThoiGianThucTe,
            GiaTriThucTe = entity.GiaTriThucTe,
            GhiChuThucTe = entity.GhiChuThucTe,
            SoHoaDon = entity.SoHoaDon,
            KyHieuHoaDon = entity.KyHieuHoaDon,
            NgayHoaDon = entity.NgayHoaDon
        };
    }
}