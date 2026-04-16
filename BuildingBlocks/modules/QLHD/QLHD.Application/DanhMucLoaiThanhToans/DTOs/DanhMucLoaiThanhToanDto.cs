namespace QLHD.Application.DanhMucLoaiThanhToans.DTOs;

/// <summary>
/// DTO cho loại thanh toán
/// </summary>
public class DanhMucLoaiThanhToanDto : IHasKey<int>
{
    public int Id { get; set; }
    public string? Ma { get; set; }
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public bool Used { get; set; }
    public bool IsDefault { get; set; }
}