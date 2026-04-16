using BuildingBlocks.Domain.ValueTypes;
using QLHD.Domain.Interfaces;

namespace QLHD.Application.ThuTiens.DTOs;

/// <summary>
/// DTO cho thu tiền (kế hoạch + thực tế) - flat structure matching merged entity
/// Used for: GetDetail, GetByHopDong, InsertOrUpdate result
/// </summary>
public class ThuTienDto : IHasKey<Guid>,
    IThucTe, IHoaDon
{
    public Guid Id { get; set; }

    // Owner routing (DuAn-linked vs standalone HopDong)
    public Guid? DuAnId { get; set; }
    public Guid? HopDongId { get; set; }
    public bool IsDuAnOwned { get; set; }

    // FK
    public int LoaiThanhToanId { get; set; }
    public string? TenLoaiThanhToan { get; set; }

    #region Kế hoạch

    public MonthYear ThoiGianKeHoach { get; set; }
    public decimal PhanTramKeHoach { get; set; }
    public decimal GiaTriKeHoach { get; set; }
    public string? GhiChuKeHoach { get; set; }

    #endregion

    #region Thực tế (nullable - filled when executed)

    public DateOnly? ThoiGianThucTe { get; set; }
    public decimal? GiaTriThucTe { get; set; }
    public string? GhiChuThucTe { get; set; }

    #region Hoá đơn

    public string? SoHoaDon { get; set; }
    public string? KyHieuHoaDon { get; set; }
    public DateOnly? NgayHoaDon { get; set; }

    #endregion

    #endregion

    #region Thông tin chung (for detail view)

    public string? TenHopDong { get; set; }
    public string? SoHopDong { get; set; }
    public string? TenDuAn { get; set; }
    public string? TenKhachHang { get; set; }

    #endregion
}