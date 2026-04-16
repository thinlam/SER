namespace BuildingBlocks.Application.UserMasters.DTOs;

public class UserMasterCboDto : ComboBoxDto<long>
{
    public string? RoleName { get; set; }
}
