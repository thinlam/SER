using Microsoft.EntityFrameworkCore;
using QLHD.Application.KeHoachKinhDoanhNams.DTOs;

namespace QLHD.Application.KeHoachKinhDoanhNams.Queries;

public record KeHoachKinhDoanhNamGetByIdQuery(Guid Id) : IRequest<KeHoachKinhDoanhNamDto>;

internal class KeHoachKinhDoanhNamGetByIdQueryHandler : IRequestHandler<KeHoachKinhDoanhNamGetByIdQuery, KeHoachKinhDoanhNamDto>
{
    private readonly IRepository<KeHoachKinhDoanhNam, Guid> _repository;

    public KeHoachKinhDoanhNamGetByIdQueryHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<KeHoachKinhDoanhNam, Guid>>();
    }

    public async Task<KeHoachKinhDoanhNamDto> Handle(KeHoachKinhDoanhNamGetByIdQuery request, CancellationToken cancellationToken = default)
    {
        // Use projection to filter out soft-deleted child records
        // GetQueryableSet() already filters IsDeleted=false on parent entity
        var dto = await _repository.GetQueryableSet()
            .Where(e => e.Id == request.Id)
            .Select(e => new KeHoachKinhDoanhNamDto
            {
                Id = e.Id,
                BatDau = e.BatDau,
                KetThuc = e.KetThuc,
                GhiChu = e.GhiChu,
                // Explicitly filter soft-deleted children in projection
                BoPhans = e.KeHoachKinhDoanhNam_BoPhans!
                    .Where(c => !c.IsDeleted)
                    .Select(c => c.ToDto())
                    .ToList(),
                CaNhans = e.KeHoachKinhDoanhNam_CaNhans!
                    .Where(c => !c.IsDeleted)
                    .Select(c => c.ToDto())
                    .ToList()
            })
            .FirstOrDefaultAsync(cancellationToken);

        ManagedException.ThrowIfNull(dto, "Không tìm thấy bản ghi");

        return dto;
    }
}