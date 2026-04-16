namespace QLHD.Application.DanhMucLoaiTrangThais.DTOs;

public class DanhMucLoaiTrangThaiDto : IHasKey<int>
{
    public int Id { get; set; }
    public string? Ma { get; set; }
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public bool Used { get; set; }
}