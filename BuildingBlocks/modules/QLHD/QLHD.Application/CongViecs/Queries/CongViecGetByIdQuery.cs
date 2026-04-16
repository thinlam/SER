using QLHD.Application.CongViecs.DTOs;

namespace QLHD.Application.CongViecs.Queries;

public record CongViecGetByIdQuery(Guid Id) : IRequest<CongViecDto>;

internal class CongViecGetByIdQueryHandler : IRequestHandler<CongViecGetByIdQuery, CongViecDto>
{
    private readonly IRepository<CongViec, Guid> _repository;

    public CongViecGetByIdQueryHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<CongViec, Guid>>();
    }

    public async Task<CongViecDto> Handle(CongViecGetByIdQuery request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .Where(e => e.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        ManagedException.ThrowIfNull(entity, "Không tìm thấy bản ghi");

        return entity.ToDto();
    }
}