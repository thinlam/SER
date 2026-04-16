namespace QLHD.Application.DanhMucNguoiPhuTrachs.DTOs;

public class DanhMucNguoiPhuTrachUpdateModel
{
    public bool Used { get; set; }
    public long UserPortalId { get; set; }
    public long DonViId { get; set; }
    public long? PhongBanId { get; set; }
}