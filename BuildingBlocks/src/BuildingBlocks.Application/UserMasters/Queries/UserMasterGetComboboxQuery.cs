using BuildingBlocks.Application.UserMasters.DTOs;

namespace BuildingBlocks.Application.UserMasters.Queries;

public record UserMasterGetComboboxQuery(int? DonViId = null, int? PhongBanId = null) : IRequest<List<UserMasterDto>>;
