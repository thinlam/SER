using QLHD.Application.KhoKhanVuongMacs.DTOs;

namespace QLHD.Application.KhoKhanVuongMacs.Commands;

public record KhoKhanVuongMacUpdateCommand(Guid Id, KhoKhanVuongMacUpdateModel Model) : IRequest<KhoKhanVuongMacDto>;

internal class KhoKhanVuongMacUpdateCommandHandler : IRequestHandler<KhoKhanVuongMacUpdateCommand, KhoKhanVuongMacDto>
{
    private readonly IRepository<KhoKhanVuongMac, Guid> _repository;
    private readonly IRepository<TienDo, Guid> _tienDoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public KhoKhanVuongMacUpdateCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<KhoKhanVuongMac, Guid>>();
        _tienDoRepository = serviceProvider.GetRequiredService<IRepository<TienDo, Guid>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<KhoKhanVuongMacDto> Handle(KhoKhanVuongMacUpdateCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .Include(k => k.TienDo)
            .Include(k => k.TrangThai)
            .FirstOrDefaultAsync(k => k.Id == request.Id, cancellationToken);
        ManagedException.ThrowIfNull(entity, "Không tìm thấy khó khăn vướng mắc");

        // Validate TienDoId belongs to same HopDong (if provided)
        if (request.Model.TienDoId.HasValue)
        {
            var tienDo = await _tienDoRepository.GetQueryableSet()
                .FirstOrDefaultAsync(t => t.Id == request.Model.TienDoId.Value, cancellationToken);
            ManagedException.ThrowIfNull(tienDo, "Không tìm thấy tiến độ");
            ManagedException.ThrowIf(tienDo.HopDongId != entity.HopDongId,
                "Tiến độ không thuộc hợp đồng này");
        }

        entity.UpdateFrom(request.Model);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.ToDto();
    }
}