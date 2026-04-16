namespace QLDA.Application.UserMasters.DTOs;

public class UserMasterDto {
    public long? UserId { get; set; }
    public long? DonViId { get; set; }
    public long? PhongBanId { get; set; }
    public string? HoTen { get; set; }
}
public class UserByRoleDto {
    private long Id { get; set; }
    public long? UserId => Id;
    public string? Ten { get; set; }
    public long? DonViId { get; set; }
    public long? PhongBanId { get; set; }
}