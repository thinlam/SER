using System.Text.Json.Serialization;
using BuildingBlocks.Domain.ValueTypes;
using QLHD.Domain.Interfaces;

namespace QLHD.Application.XuatHoaDons.DTOs;

/// <summary>
/// DTO chi tiết xuất hóa đơn - flat structure matching merged entity
/// </summary>
public class XuatHoaDonDto : IHasKey<Guid>,
    IThucTe, IHoaDon
{
    public Guid Id { get; set; }

    // Owner routing
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Guid? DuAnId { get; set; }
    public Guid? HopDongId { get; set; }
    public bool IsDuAnOwned { get; set; }

    // FK
    public int LoaiThanhToanId { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TenLoaiThanhToan { get; set; }

    #region Plan fields

    public MonthYear ThoiGianKeHoach { get; set; }
    public decimal PhanTramKeHoach { get; set; }
    public decimal GiaTriKeHoach { get; set; }
    public string? GhiChuKeHoach { get; set; }

    #endregion

    #region Actual fields (nullable)

    public DateOnly? ThoiGianThucTe { get; set; }
    public decimal? GiaTriThucTe { get; set; }
    public string? GhiChuThucTe { get; set; }
    public string? SoHoaDon { get; set; }
    public string? KyHieuHoaDon { get; set; }
    public DateOnly? NgayHoaDon { get; set; }

    #endregion

    #region Thong tin chung

    public string? TenHopDong { get; set; }
    public string? SoHopDong { get; set; }
    public string? TenDuAn { get; set; }
    public string? TenKhachHang { get; set; }

    #endregion
}