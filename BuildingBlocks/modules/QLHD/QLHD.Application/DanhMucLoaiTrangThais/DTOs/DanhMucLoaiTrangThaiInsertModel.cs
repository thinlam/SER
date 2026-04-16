namespace QLHD.Application.DanhMucLoaiTrangThais.DTOs;

public class DanhMucLoaiTrangThaiInsertModel
{
    public string? Ma { get; set; }
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public bool Used { get; set; } = true;
}