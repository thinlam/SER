using QLHD.Application.TienDos.DTOs;

namespace QLHD.Application.TienDos.Commands;

public record TienDoInsertCommand(TienDoInsertModel Model) : IRequest<TienDoDto>;

internal class TienDoInsertCommandHandler : IRequestHandler<TienDoInsertCommand, TienDoDto> {
    private readonly IRepository<TienDo, Guid> _tienDoRepository;
    private readonly IRepository<HopDong, Guid> _hopDongRepository;
    private readonly IRepository<DanhMucTrangThai, int> _trangThaiRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TienDoInsertCommandHandler(IServiceProvider serviceProvider) {
        _tienDoRepository = serviceProvider.GetRequiredService<IRepository<TienDo, Guid>>();
        _hopDongRepository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
        _trangThaiRepository = serviceProvider.GetRequiredService<IRepository<DanhMucTrangThai, int>>();
        _unitOfWork = _tienDoRepository.UnitOfWork;
    }

    public async Task<TienDoDto> Handle(TienDoInsertCommand request, CancellationToken cancellationToken = default) {
        var model = request.Model;

        // Validate HopDong exists
        var hopDong = await _hopDongRepository.GetQueryableSet()
            .FirstAsync(h => h.Id == model.HopDongId, cancellationToken);

        // Get default status for TIENDO
        var defaultStatus = await _trangThaiRepository.GetQueryableSet()
            .FirstOrDefaultAsync(t => t.MaLoaiTrangThai == LoaiTrangThaiConstants.TienDo && t.IsDefault, cancellationToken);
        ManagedException.ThrowIfNull(defaultStatus, "Không tìm thấy trạng thái mặc định");

        var entity = model.ToEntity(defaultStatus.Id);

        await _tienDoRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Reload to get navigation properties
        var savedEntity = await _tienDoRepository.GetQueryableSet()
            .Include(t => t.TrangThai)
            .FirstAsync(t => t.Id == entity.Id, cancellationToken);

        return savedEntity.ToDto();
    }
}