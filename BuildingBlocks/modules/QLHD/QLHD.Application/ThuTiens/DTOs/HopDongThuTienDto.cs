using BuildingBlocks.Domain.ValueTypes;
using QLHD.Domain.Interfaces;

namespace QLHD.Application.ThuTiens.DTOs;

/// <summary>
/// DTO cho hợp đồng có thu tiền (merged entity)
/// </summary>
public class HopDongThuTienDto : IHopDongBase,
    INgayHopDong {
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
    /// Danh sách kế hoạch thu tiền (from merged entity)
    /// </summary>
    public List<ThuTienKeHoachSimpleDto>? KeHoach { get; set; }

    /// <summary>
    /// Danh sách thực tế thu tiền (from merged entity - where ThoiGianThucTe has value)
    /// </summary>
    public List<ThuTienThucTeSimpleDto>? ThucTe { get; set; }
}


/// <summary>
/// DTO đơn giản cho kế hoạch thu tiền trong danh sách
/// </summary>

public class ThuTienKeHoachSimpleDto {
    public MonthYear ThoiGian { get; set; }
    public decimal GiaTri { get; set; }
}

/// <summary>
/// DTO đơn giản cho thực tế thu tiền trong danh sách
/// </summary>
public class ThuTienThucTeSimpleDto {
    public DateOnly? ThoiGian { get; set; }
    public decimal? GiaTri { get; set; }
    public string? SoHoaDon { get; set; }
    public string? KyHieuHoaDon { get; set; }
    public DateOnly? NgayHoaDon { get; set; }
}