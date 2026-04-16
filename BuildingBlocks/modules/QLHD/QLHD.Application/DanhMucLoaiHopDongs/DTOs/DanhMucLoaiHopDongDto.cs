namespace QLHD.Application.DanhMucLoaiHopDongs.DTOs;

/// <summary>
/// DTO cho loại hợp đồng
/// </summary>
public class DanhMucLoaiHopDongDto : IHasKey<int>
{
    public int Id { get; set; }
    public string? Ma { get; set; }
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public bool Used { get; set; }
    public string? Symbol { get; set; }
    public int Prefix { get; set; }
    public bool IsDefault { get; set; }
}