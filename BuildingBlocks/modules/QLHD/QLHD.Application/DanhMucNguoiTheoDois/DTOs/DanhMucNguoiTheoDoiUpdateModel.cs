namespace QLHD.Application.DanhMucNguoiTheoDois.DTOs;

public class DanhMucNguoiTheoDoiUpdateModel
{
    public bool Used { get; set; }
    public long UserPortalId { get; set; }
    public long DonViId { get; set; }
    public long? PhongBanId { get; set; }
}