namespace QLHD.Application.DanhMucLoaiThanhToans.DTOs;

public class DanhMucLoaiThanhToanUpdateModel
{
    public string? Ma { get; set; }
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public bool Used { get; set; }
    public bool IsDefault { get; set; }
}