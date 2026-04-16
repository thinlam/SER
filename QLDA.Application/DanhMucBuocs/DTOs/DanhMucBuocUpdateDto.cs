namespace QLDA.Application.DanhMucBuocs.DTOs;

public class DanhMucBuocUpdateDto : IHasKey<int> {
    public int Id { get; set; }
    public string? Ma { get; set; }
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public int? Stt { get; set; }
    public bool Used { get; set; } = true;
    public int QuyTrinhId { get; set; }
    public int? GiaiDoanId { get; set; }
    public int SoNgayThucHien { get; set; }
    [DefaultValue(null)] public int? ParentId { get; set; }
    public List<int>? DanhSachManHinh { get; set; } = [];
}