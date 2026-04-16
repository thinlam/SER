using QLDA.Application.UserMasters.DTOs;

namespace QLDA.Application.UserMasters.Queries {
    public record GetUserByRoleNameQuery(string RoleNames, long? DonViID = null, long? PhongBanID = null) : IRequest<List<UserByRoleDto>>;

    internal class GetUserByRoleNameQueryHandler(IDapperRepository dapperRepository)
    : IRequestHandler<GetUserByRoleNameQuery, List<UserByRoleDto>> {
        private readonly IDapperRepository _dapperRepository = dapperRepository;

        public async Task<List<UserByRoleDto>> Handle(GetUserByRoleNameQuery request, CancellationToken cancellationToken) {

            var storeName = "sp_GetUsersByRoleName"; // Assuming the stored procedure name
            var parameters = new {
                RoleNames = request.RoleNames,
                DonViID = request.DonViID,
                PhongBanID = request.PhongBanID,
            };

            return [.. await _dapperRepository.QueryStoredProcAsync<UserByRoleDto>(storeName, parameters)];
        }
    }
}
