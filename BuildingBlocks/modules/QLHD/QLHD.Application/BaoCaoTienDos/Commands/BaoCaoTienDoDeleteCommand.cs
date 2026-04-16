namespace QLHD.Application.BaoCaoTienDos.Commands;

public record BaoCaoTienDoDeleteCommand(Guid Id) : IRequest;

internal class BaoCaoTienDoDeleteCommandHandler : IRequestHandler<BaoCaoTienDoDeleteCommand>
{
    private readonly IRepository<BaoCaoTienDo, Guid> _baoCaoRepository;
    private readonly IRepository<TienDo, Guid> _tienDoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BaoCaoTienDoDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _baoCaoRepository = serviceProvider.GetRequiredService<IRepository<BaoCaoTienDo, Guid>>();
        _tienDoRepository = serviceProvider.GetRequiredService<IRepository<TienDo, Guid>>();
        _unitOfWork = _baoCaoRepository.UnitOfWork;
    }

    public async Task Handle(BaoCaoTienDoDeleteCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _baoCaoRepository.GetQueryableSet()
            .FirstOrDefaultAsync(b => b.Id == request.Id && !b.IsDeleted, cancellationToken);
        ManagedException.ThrowIfNull(entity, "Không tìm thấy báo cáo tiến độ");

        var tienDoId = entity.TienDoId;
        entity.IsDeleted = true;

        // Recalculate denormalized fields
        await RecalculateTienDoDenormalizedFields(tienDoId, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
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
        else
        {
            tienDo.PhanTramThucTe = 0;
            tienDo.NgayCapNhatGanNhat = null;
        }
    }
}