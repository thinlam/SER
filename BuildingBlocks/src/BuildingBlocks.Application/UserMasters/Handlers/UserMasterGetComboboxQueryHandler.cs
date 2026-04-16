using BuildingBlocks.Application.UserMasters.DTOs;
using BuildingBlocks.Application.UserMasters.Queries;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Application.UserMasters.Handlers;

public class UserMasterGetComboboxQueryHandler(IRepository<UserMaster, long> repository) : IRequestHandler<UserMasterGetComboboxQuery, List<UserMasterDto>>
{
    private readonly IRepository<UserMaster, long> _repository = repository;

    public async Task<List<UserMasterDto>> Handle(UserMasterGetComboboxQuery request, CancellationToken cancellationToken)
    {
        var query = _repository.GetQueryableSet()
        .WhereIf(request.DonViId > 0, e => e.DonViId == request.DonViId)
        .WhereIf(request.PhongBanId > 0, e => e.PhongBanId == request.PhongBanId)
        .Select(e => new UserMasterDto
        {
            Id = e.UserPortalId ?? 0,
            Ten = e.HoTen,
            DonViId = e.DonViId,
            PhongBanId = e.PhongBanId
        });
        return await query.ToListAsync(cancellationToken);


    }
}
