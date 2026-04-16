using BuildingBlocks.Domain.Constants;
using BuildingBlocks.Domain.Providers;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Application.DmDonVis.Queries;

public record DmDonViGetComboboxQuery(string? Loai, long? DonViId) : IRequest<List<ComboBoxDto<long>>>;
internal class DmDonViGetComboboxQueryHandler(IRepository<DmDonVi, long> repository, IUserProvider userProvider) : IRequestHandler<DmDonViGetComboboxQuery, List<ComboBoxDto<long>>>
{
    private readonly IRepository<DmDonVi, long> _repository = repository;
    private readonly IUserProvider _userProvider = userProvider;

    public async Task<List<ComboBoxDto<long>>> Handle(DmDonViGetComboboxQuery request, CancellationToken cancellationToken)
    {
        IQueryable<ComboBoxDto<long>> query = _repository.GetQueryableSet()
            .WhereIf(request.Loai == RequestProcessingConstants.DONVI_SBN, e => e.DonViCapChaId == 1 && e.LoaiDonViId == 1)
            .WhereFunc(request.Loai == RequestProcessingConstants.DONVI_PB, q => q
                .Where(e => e.DonViCapChaId != null)
                .WhereIf(request.DonViId > 0, e => e.DonViCapChaId == request.DonViId)
            )
            .OrderBy(e => e.DonViCapChaId).ThenBy(e => e.CapDonViId)
            .Select(e => new ComboBoxDto<long>
            {
                Id = e.Id,
                Ten = e.TenDonVi
            });

        return await query.ToListAsync(cancellationToken);


    }
}
