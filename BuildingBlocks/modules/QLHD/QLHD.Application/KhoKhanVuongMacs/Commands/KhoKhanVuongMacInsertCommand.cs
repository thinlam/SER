using QLHD.Application.KhoKhanVuongMacs.DTOs;

namespace QLHD.Application.KhoKhanVuongMacs.Commands;

public record KhoKhanVuongMacInsertCommand(KhoKhanVuongMacInsertModel Model) : IRequest<KhoKhanVuongMacDto>;

internal class KhoKhanVuongMacInsertCommandHandler : IRequestHandler<KhoKhanVuongMacInsertCommand, KhoKhanVuongMacDto>
{
    private readonly IRepository<KhoKhanVuongMac, Guid> _khoKhanRepository;
    private readonly IRepository<HopDong, Guid> _hopDongRepository;
    private readonly IRepository<TienDo, Guid> _tienDoRepository;
    private readonly IRepository<DanhMucTrangThai, int> _trangThaiRepository;
    private readonly IUnitOfWork _unitOfWork;

    public KhoKhanVuongMacInsertCommandHandler(IServiceProvider serviceProvider)
    {
        _khoKhanRepository = serviceProvider.GetRequiredService<IRepository<KhoKhanVuongMac, Guid>>();
        _hopDongRepository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
        _tienDoRepository = serviceProvider.GetRequiredService<IRepository<TienDo, Guid>>();
        _trangThaiRepository = serviceProvider.GetRequiredService<IRepository<DanhMucTrangThai, int>>();
        _unitOfWork = _khoKhanRepository.UnitOfWork;
    }

    public async Task<KhoKhanVuongMacDto> Handle(KhoKhanVuongMacInsertCommand request, CancellationToken cancellationToken = default)
    {
        var model = request.Model;

        // Validate HopDong exists
        var hopDong = await _hopDongRepository.GetQueryableSet()
            .FirstOrDefaultAsync(h => h.Id == model.HopDongId, cancellationToken);
        ManagedException.ThrowIfNull(hopDong, "Không tìm thấy hợp đồng");

        // Validate TienDoId belongs to same HopDong (if provided)
        if (model.TienDoId.HasValue)
        {
            var tienDo = await _tienDoRepository.GetQueryableSet()
                .FirstOrDefaultAsync(t => t.Id == model.TienDoId.Value, cancellationToken);
            ManagedException.ThrowIfNull(tienDo, "Không tìm thấy tiến độ");
            ManagedException.ThrowIf(tienDo.HopDongId != model.HopDongId,
                "Tiến độ không thuộc hợp đồng này");
        }

        // Get default status for KKHUAN_VUONG_MAC
        var defaultStatus = await _trangThaiRepository.GetQueryableSet()
            .FirstOrDefaultAsync(t => t.MaLoaiTrangThai == "KKHUAN_VUONG_MAC" && t.IsDefault, cancellationToken);
        ManagedException.ThrowIfNull(defaultStatus, "Không tìm thấy trạng thái mặc định");

        var entity = model.ToEntity(defaultStatus.Id);

        await _khoKhanRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Reload to get navigation properties
        var savedEntity = await _khoKhanRepository.GetQueryableSet()
            .Include(k => k.TienDo)
            .Include(k => k.TrangThai)
            .FirstAsync(k => k.Id == entity.Id, cancellationToken);

        return savedEntity.ToDto();
    }
}