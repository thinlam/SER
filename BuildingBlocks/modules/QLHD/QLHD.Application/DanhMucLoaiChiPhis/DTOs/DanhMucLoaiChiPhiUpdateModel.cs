namespace QLHD.Application.DanhMucLoaiChiPhis.DTOs;

public class DanhMucLoaiChiPhiUpdateModel
{
    public string? Ma { get; set; }
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public bool Used { get; set; }
    public bool IsDefault { get; set; }
    public bool IsMajor { get; set; }
}