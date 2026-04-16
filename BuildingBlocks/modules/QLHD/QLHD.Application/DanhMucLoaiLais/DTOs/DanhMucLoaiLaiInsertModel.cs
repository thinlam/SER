namespace QLHD.Application.DanhMucLoaiLais.DTOs;

public class DanhMucLoaiLaiInsertModel
{
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public bool Used { get; set; } = true;
    public bool IsDefault { get; set; }
}