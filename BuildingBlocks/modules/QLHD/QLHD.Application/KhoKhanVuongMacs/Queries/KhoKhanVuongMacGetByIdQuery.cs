using QLHD.Application.KhoKhanVuongMacs.DTOs;

namespace QLHD.Application.KhoKhanVuongMacs.Queries;

public record KhoKhanVuongMacGetByIdQuery(Guid Id) : IRequest<KhoKhanVuongMacDto>;

internal class KhoKhanVuongMacGetByIdQueryHandler : IRequestHandler<KhoKhanVuongMacGetByIdQuery, KhoKhanVuongMacDto>
{
    private readonly IRepository<KhoKhanVuongMac, Guid> _repository;

    public KhoKhanVuongMacGetByIdQueryHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<KhoKhanVuongMac, Guid>>();
    }

    public async Task<KhoKhanVuongMacDto> Handle(KhoKhanVuongMacGetByIdQuery request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .Include(k => k.TienDo)
            .Include(k => k.TrangThai)
            .FirstOrDefaultAsync(k => k.Id == request.Id, cancellationToken);
        ManagedException.ThrowIfNull(entity, "Không tìm thấy khó khăn vướng mắc");

        return entity.ToDto();
    }
}