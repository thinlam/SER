using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Application.DmDonVis.Queries;

public record DmDonViGetEmailByIdQuery(long DonViId) : IRequest<object>;

internal class DmDonViGetEmailByIdQueryHandler(IRepository<DmDonVi, long> repository)
    : IRequestHandler<DmDonViGetEmailByIdQuery, object>
{
    private readonly IRepository<DmDonVi, long> _repository = repository;

    public async Task<object> Handle(DmDonViGetEmailByIdQuery request, CancellationToken cancellationToken)
    {
        return new
        {
            Email = await _repository.GetQueryableSet()
            .Where(x => x.Id == request.DonViId)
            .Select(x => x.Email)
            .FirstOrDefaultAsync(cancellationToken)
        };
    }
}
