namespace QLHD.Application.DanhMucTrangThais.DTOs;

public class DanhMucTrangThaiUpdateModel
{
    public string? Ma { get; set; }
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public bool Used { get; set; }
    public int? LoaiTrangThaiId { get; set; }
    public int ThuTu { get; set; }
    public bool IsDefault { get; set; }
}