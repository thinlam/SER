using BuildingBlocks.Domain.ValueTypes;
using QLHD.Domain.Interfaces;

namespace QLHD.Application.ChiPhis.DTOs;

/// <summary>
/// DTO chi phí - gom kế hoạch và thực tế trong một bản ghi
/// Unified DTO for: GetByHopDong, GetDetail, InsertOrUpdate result
/// </summary>
public class ChiPhiDto : IHasKey<Guid>,
    IThucTe
{
    public Guid Id { get; set; }
    public Guid HopDongId { get; set; }
    public int LoaiChiPhiId { get; set; }
    public string? TenLoaiChiPhi { get; set; }

    /// <summary>
    /// Năm chi phí (ví dụ: 2024)
    /// </summary>
    public short Nam { get; set; }

    /// <summary>
    /// Lần chi phí (ví dụ: 1, 2, 3...)
    /// </summary>
    public byte LanChi { get; set; }

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

    /// <summary>
    /// Đã có thực tế chi phí hay chưa
    /// </summary>
    public bool HasThucTe => ThoiGianThucTe.HasValue;

    #endregion

    #region Thông tin chung (for detail view)

    public string? TenHopDong { get; set; }
    public string? SoHopDong { get; set; }
    public string? TenDuAn { get; set; }
    public string? TenKhachHang { get; set; }

    #endregion
}