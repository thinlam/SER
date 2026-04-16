using QLHD.Application.KeHoachThangs.DTOs;
using QLHD.Domain.Entities;

namespace QLHD.Application.KeHoachThangs.Queries;

public record KeHoachThangGetByIdQuery(int Id) : IRequest<KeHoachThangDto>;

internal class KeHoachThangGetByIdQueryHandler : IRequestHandler<KeHoachThangGetByIdQuery, KeHoachThangDto>
{
    private readonly IRepository<KeHoachThang, int> _repository;

    public KeHoachThangGetByIdQueryHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<KeHoachThang, int>>();
    }

    public async Task<KeHoachThangDto> Handle(KeHoachThangGetByIdQuery request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
        ManagedException.ThrowIfNull(entity, "Không tìm thấy bản ghi");

        return entity.ToDto();
    }
}