namespace QLDA.Application.DuAnBuocs.DTOs;

public class DuAnBuocUpdateDto {
    public int Id { get; set; }
    public string? TenBuoc { get; set; }
    public bool Used { get; set; }
    public DateTimeOffset? NgayDuKienBatDau { get; set; }
    public DateTimeOffset? NgayDuKienKetThuc { get; set; }
    public List<int>? DanhSachManHinh { get; set; } = [];
}