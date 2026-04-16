using QLHD.Application.BaoCaoTienDos.DTOs;

namespace QLHD.Application.BaoCaoTienDos.Commands;

public record BaoCaoTienDoUpdateCommand(Guid Id, BaoCaoTienDoUpdateModel Model) : IRequest<BaoCaoTienDoDto>;

internal class BaoCaoTienDoUpdateCommandHandler : IRequestHandler<BaoCaoTienDoUpdateCommand, BaoCaoTienDoDto>
{
    private readonly IRepository<BaoCaoTienDo, Guid> _baoCaoRepository;
    private readonly IRepository<TienDo, Guid> _tienDoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BaoCaoTienDoUpdateCommandHandler(IServiceProvider serviceProvider)
    {
        _baoCaoRepository = serviceProvider.GetRequiredService<IRepository<BaoCaoTienDo, Guid>>();
        _tienDoRepository = serviceProvider.GetRequiredService<IRepository<TienDo, Guid>>();
        _unitOfWork = _baoCaoRepository.UnitOfWork;
    }

    public async Task<BaoCaoTienDoDto> Handle(BaoCaoTienDoUpdateCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _baoCaoRepository.GetQueryableSet()
            .Include(b => b.TienDo)
            .FirstOrDefaultAsync(b => b.Id == request.Id && !b.IsDeleted, cancellationToken);
        ManagedException.ThrowIfNull(entity, "Không tìm thấy báo cáo tiến độ");

        // Check if already approved
        ManagedException.ThrowIf(entity.DaDuyet, "Không thể cập nhật báo cáo đã duyệt");

        entity.UpdateFrom(request.Model);

        // Recalculate denormalized fields
        await RecalculateTienDoDenormalizedFields(entity.TienDoId, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.ToDto();
    }

    private async Task RecalculateTienDoDenormalizedFields(Guid tienDoId, CancellationToken cancellationToken)
    {
        var tienDo = await _tienDoRepository.GetQueryableSet()
            .Include(t => t.BaoCaoTienDos)
            .FirstOrDefaultAsync(t => t.Id == tienDoId, cancellationToken);

        if (tienDo?.BaoCaoTienDos != null)
        {
            var activeReports = tienDo.BaoCaoTienDos.Where(b => !b.IsDeleted && (!b.CanDuyet || b.DaDuyet)).ToList();
            tienDo.PhanTramThucTe = activeReports.Any() ? activeReports.Max(b => b.PhanTramThucTe) : 0;
            tienDo.NgayCapNhatGanNhat = activeReports.Any() ? activeReports.Max(b => (DateOnly?)b.NgayBaoCao) : null;
        }
    }
}