namespace QLDA.Application.DuAnBuocs.DTOs;

public class DuAnBuocCreateDto {
    public Guid DuAnId { get; init; }
    public int BuocId { get; init; }
    public string? TenBuoc { get; init; }
    public DateTimeOffset? NgayDuKienBatDau { get; init; }
    public DateTimeOffset? NgayDuKienKetThuc { get; init; }
    public string? GhiChu { get; init; }
    public string? TrachNhiemThucHien { get; init; }
    public List<int>? DanhSachManHinh { get; init; } = [];
}
