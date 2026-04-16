namespace QLHD.Application.DanhMucGiamDocs.DTOs;

public class DanhMucGiamDocDto : IHasKey<int>
{
    public int Id { get; set; }
    public string? Ma { get; set; }
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public bool Used { get; set; }
    public long UserPortalId { get; set; }
    public long DonViId { get; set; }
    public long? PhongBanId { get; set; }
    public string? UserHoTen { get; set; }
    public string? UserUserName { get; set; }
}