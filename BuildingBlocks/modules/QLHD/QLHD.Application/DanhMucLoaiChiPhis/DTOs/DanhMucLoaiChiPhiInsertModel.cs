namespace QLHD.Application.DanhMucLoaiChiPhis.DTOs;

public class DanhMucLoaiChiPhiInsertModel
{
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public bool Used { get; set; } = true;
    public bool IsDefault { get; set; }
    public bool IsMajor { get; set; }
}