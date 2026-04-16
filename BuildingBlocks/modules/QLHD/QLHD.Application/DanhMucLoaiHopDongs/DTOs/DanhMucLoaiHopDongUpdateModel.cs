namespace QLHD.Application.DanhMucLoaiHopDongs.DTOs;

public class DanhMucLoaiHopDongUpdateModel
{
    public string? Ma { get; set; }
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public bool Used { get; set; }
    public string? Symbol { get; set; }
    public int Prefix { get; set; }
    public bool IsDefault { get; set; }
}