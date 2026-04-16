namespace QLHD.Application.DanhMucGiamDocs.DTOs;

public class DanhMucGiamDocUpdateModel {
    public bool Used { get; set; }
    public long UserPortalId { get; set; }
    public long DonViId { get; set; }
    public long? PhongBanId { get; set; }
}