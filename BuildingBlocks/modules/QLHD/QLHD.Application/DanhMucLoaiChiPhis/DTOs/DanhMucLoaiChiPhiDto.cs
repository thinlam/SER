namespace QLHD.Application.DanhMucLoaiChiPhis.DTOs;

/// <summary>
/// DTO cho loại chi phí
/// </summary>
public class DanhMucLoaiChiPhiDto : IHasKey<int>
{
    public int Id { get; set; }
    public string? Ma { get; set; }
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public bool Used { get; set; }
    public bool IsDefault { get; set; }
    public bool IsMajor { get; set; }
}