using QLHD.Application.TienDos.DTOs;

namespace QLHD.Application.TienDos.Queries;

public record TienDoGetListQuery(Guid HopDongId) : IRequest<List<TienDoDto>>;

internal class TienDoGetListQueryHandler : IRequestHandler<TienDoGetListQuery, List<TienDoDto>>
{
    private readonly IRepository<TienDo, Guid> _repository;

    public TienDoGetListQueryHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<TienDo, Guid>>();
    }

    public async Task<List<TienDoDto>> Handle(TienDoGetListQuery request, CancellationToken cancellationToken = default)
    {
        return await _repository.GetQueryableSet()
            .Where(t => t.HopDongId == request.HopDongId)
            .Include(t => t.TrangThai)
            .OrderBy(t => t.NgayBatDauKeHoach)
            .Select(t => t.ToDto())
            .ToListAsync(cancellationToken);
    }
}