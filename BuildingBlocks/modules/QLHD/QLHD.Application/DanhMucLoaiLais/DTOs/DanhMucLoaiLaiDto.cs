namespace QLHD.Application.DanhMucLoaiLais.DTOs;

/// <summary>
/// DTO cho loại lãi
/// </summary>
public class DanhMucLoaiLaiDto : IHasKey<int>
{
    public int Id { get; set; }
    public string? Ma { get; set; }
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public bool Used { get; set; }
    public bool IsDefault { get; set; }
}