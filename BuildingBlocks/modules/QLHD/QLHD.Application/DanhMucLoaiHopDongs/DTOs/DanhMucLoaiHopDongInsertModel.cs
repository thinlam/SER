namespace QLHD.Application.DanhMucLoaiHopDongs.DTOs;

public class DanhMucLoaiHopDongInsertModel
{
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public bool Used { get; set; } = true;
    public string? Symbol { get; set; }
    public int Prefix { get; set; }
    public bool IsDefault { get; set; }
}