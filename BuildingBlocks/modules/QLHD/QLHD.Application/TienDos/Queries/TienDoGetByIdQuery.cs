using QLHD.Application.TienDos.DTOs;

namespace QLHD.Application.TienDos.Queries;

public record TienDoGetByIdQuery(Guid Id) : IRequest<TienDoDto>;

internal class TienDoGetByIdQueryHandler : IRequestHandler<TienDoGetByIdQuery, TienDoDto>
{
    private readonly IRepository<TienDo, Guid> _repository;

    public TienDoGetByIdQueryHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<TienDo, Guid>>();
    }

    public async Task<TienDoDto> Handle(TienDoGetByIdQuery request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .Include(t => t.TrangThai)
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
        ManagedException.ThrowIfNull(entity, "Không tìm thấy tiến độ");

        return entity.ToDto();
    }
}