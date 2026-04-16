using BuildingBlocks.Domain.ValueTypes;
using QLHD.Domain.Interfaces;

namespace QLHD.Application.ChiPhis.DTOs;

/// <summary>
/// DTO cho hợp đồng có chi phí
/// </summary>
public class HopDongCoChiPhiDto : IHopDongBase,
    INgayHopDong
{
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
    /// Danh sách kế hoạch chi phí (summary)
    /// </summary>
    public List<ChiPhiKeHoachSimpleDto>? KeHoach { get; set; }

    /// <summary>
    /// Danh sách thực tế chi phí (summary)
    /// </summary>
    public List<ChiPhiThucTeSimpleDto>? ThucTe { get; set; }
}

/// <summary>
/// Simple DTO for ChiPhi in list subquery
/// </summary>
public class ChiPhiKeHoachSimpleDto {
    public MonthYear ThoiGian { get; set; }
    public decimal GiaTri { get; set; }
}
/// <summary>
/// Simple DTO for ChiPhi in list subquery
/// </summary>
public class ChiPhiThucTeSimpleDto {
    public MonthYear ThoiGian { get; set; }
    public decimal GiaTri { get; set; }
}