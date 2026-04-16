using QLHD.Application.BaoCaoTienDos.DTOs;

namespace QLHD.Application.BaoCaoTienDos.Queries;

public record BaoCaoTienDoGetListQuery(Guid TienDoId) : IRequest<List<BaoCaoTienDoDto>>;

internal class BaoCaoTienDoGetListQueryHandler : IRequestHandler<BaoCaoTienDoGetListQuery, List<BaoCaoTienDoDto>>
{
    private readonly IRepository<BaoCaoTienDo, Guid> _repository;

    public BaoCaoTienDoGetListQueryHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<BaoCaoTienDo, Guid>>();
    }

    public async Task<List<BaoCaoTienDoDto>> Handle(BaoCaoTienDoGetListQuery request, CancellationToken cancellationToken = default)
    {
        return await _repository.GetQueryableSet()
            .Where(b => b.TienDoId == request.TienDoId && !b.IsDeleted)
            .Include(b => b.TienDo)
            .OrderByDescending(b => b.NgayBaoCao)
            .Select(b => b.ToDto())
            .ToListAsync(cancellationToken);
    }
}