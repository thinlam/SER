namespace QLHD.Application.DanhMucLoaiLais.DTOs;

public class DanhMucLoaiLaiUpdateModel
{
    public string? Ma { get; set; }
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public bool Used { get; set; }
    public bool IsDefault { get; set; }
}