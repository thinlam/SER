
namespace BuildingBlocks.Application.UserMasters.DTOs;

public class UserMasterDto : ComboBoxDto<long>
{
    public long? DonViId { get; set; }
    public long? PhongBanId { get; set; }
}
