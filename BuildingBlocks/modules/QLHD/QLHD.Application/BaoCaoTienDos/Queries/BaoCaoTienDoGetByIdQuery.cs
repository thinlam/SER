using QLHD.Application.BaoCaoTienDos.DTOs;

namespace QLHD.Application.BaoCaoTienDos.Queries;

public record BaoCaoTienDoGetByIdQuery(Guid Id) : IRequest<BaoCaoTienDoDto>;

internal class BaoCaoTienDoGetByIdQueryHandler : IRequestHandler<BaoCaoTienDoGetByIdQuery, BaoCaoTienDoDto>
{
    private readonly IRepository<BaoCaoTienDo, Guid> _repository;

    public BaoCaoTienDoGetByIdQueryHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<BaoCaoTienDo, Guid>>();
    }

    public async Task<BaoCaoTienDoDto> Handle(BaoCaoTienDoGetByIdQuery request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .Include(b => b.TienDo)
            .FirstOrDefaultAsync(b => b.Id == request.Id && !b.IsDeleted, cancellationToken);
        ManagedException.ThrowIfNull(entity, "Không tìm thấy báo cáo tiến độ");

        return entity.ToDto();
    }
}