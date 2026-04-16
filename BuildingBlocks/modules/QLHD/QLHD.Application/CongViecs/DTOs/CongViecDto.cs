using BuildingBlocks.Domain.ValueTypes;

namespace QLHD.Application.CongViecs.DTOs;

public class CongViecDto : IHasKey<Guid> {
    public Guid Id { get; set; }
    public Guid DuAnId { get; set; }
    public MonthYear ThoiGian { get; set; }
    public long UserPortalId { get; set; }
    public string NguoiThucHien { get; set; } = string.Empty;
    public long DonViId { get; set; }
    public string TenDonVi { get; set; } = string.Empty;
    public long? PhongBanId { get; set; }
    public string? TenPhongBan { get; set; }
    public string KeHoachCongViec { get; set; } = string.Empty;
    public DateOnly? NgayHoanThanh { get; set; }
    public string? ThucTe { get; set; }
    public int TrangThaiId { get; set; }
    public string TenTrangThai { get; set; } = string.Empty;

    // Display name
    public string? TenDuAn { get; set; }
}