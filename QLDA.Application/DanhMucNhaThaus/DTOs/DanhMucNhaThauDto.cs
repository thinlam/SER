namespace QLDA.Application.DanhMucNhaThaus.DTOs;

public class DanhMucNhaThauDto : DanhMucDto<Guid> {
    public string? DiaChi { get; set; }
    public string? MaSoThue { get; set; }
    public string? Email { get; set; }
    public string? SoDienThoai { get; set; }
    public string? NguoiDaiDien { get; set; }
}