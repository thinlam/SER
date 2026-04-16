namespace QLHD.Application.DanhMucTrangThais.DTOs;

public class DanhMucTrangThaiDto : IHasKey<int>
{
    public int Id { get; set; }
    public string? Ma { get; set; }
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public bool Used { get; set; }
    public int? LoaiTrangThaiId { get; set; }
    public string? MaLoaiTrangThai { get; set; }
    public string? TenLoaiTrangThai { get; set; }
}