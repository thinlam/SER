namespace QLHD.Application.DanhMucLoaiThanhToans.DTOs;

public class DanhMucLoaiThanhToanInsertModel
{
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public bool Used { get; set; } = true;
    public bool IsDefault { get; set; }
}