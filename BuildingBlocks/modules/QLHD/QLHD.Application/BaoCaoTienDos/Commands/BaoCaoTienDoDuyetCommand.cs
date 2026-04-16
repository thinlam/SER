using QLHD.Application.BaoCaoTienDos.DTOs;

namespace QLHD.Application.BaoCaoTienDos.Commands;

public record BaoCaoTienDoDuyetCommand(Guid Id, long NguoiDuyetId, bool Duyet) : IRequest<BaoCaoTienDoDto>;

internal class BaoCaoTienDoDuyetCommandHandler : IRequestHandler<BaoCaoTienDoDuyetCommand, BaoCaoTienDoDto>
{
    private readonly IRepository<BaoCaoTienDo, Guid> _baoCaoRepository;
    private readonly IRepository<TienDo, Guid> _tienDoRepository;
    private readonly IRepository<UserMaster, long> _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BaoCaoTienDoDuyetCommandHandler(IServiceProvider serviceProvider)
    {
        _baoCaoRepository = serviceProvider.GetRequiredService<IRepository<BaoCaoTienDo, Guid>>();
        _tienDoRepository = serviceProvider.GetRequiredService<IRepository<TienDo, Guid>>();
        _userRepository = serviceProvider.GetRequiredService<IRepository<UserMaster, long>>();
        _unitOfWork = _baoCaoRepository.UnitOfWork;
    }

    public async Task<BaoCaoTienDoDto> Handle(BaoCaoTienDoDuyetCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _baoCaoRepository.GetQueryableSet()
            .Include(b => b.TienDo)
            .FirstOrDefaultAsync(b => b.Id == request.Id && !b.IsDeleted, cancellationToken);
        ManagedException.ThrowIfNull(entity, "Không tìm thấy báo cáo tiến độ");

        // Validate approval requirements
        ManagedException.ThrowIf(!entity.CanDuyet, "Báo cáo này không yêu cầu duyệt");
        ManagedException.ThrowIf(entity.DaDuyet, "Báo cáo đã được duyệt");
        ManagedException.ThrowIf(entity.NguoiDuyetId != request.NguoiDuyetId,
            "Bạn không phải là người được chỉ định duyệt báo cáo này");

        // Fetch approver name from USER_MASTER
        var nguoiDuyet = await _userRepository.GetQueryableSet()
            .FirstOrDefaultAsync(u => u.Id == request.NguoiDuyetId, cancellationToken);
        var tenNguoiDuyet = nguoiDuyet?.HoTen ?? "Người duyệt";

        if (request.Duyet)
        {
            // Approve
            entity.DaDuyet = true;
            entity.TenNguoiDuyet = tenNguoiDuyet;
            entity.NgayDuyet = DateOnly.FromDateTime(DateTime.UtcNow);

            // Update TienDo denormalized fields (now that report is approved)
            UpdateTienDoDenormalizedFields(entity.TienDo!, entity.PhanTramThucTe, entity.NgayBaoCao);
        }
        else
        {
            // Reject - mark as processed but not approved
            entity.DaDuyet = false;
            entity.TenNguoiDuyet = tenNguoiDuyet;
            entity.NgayDuyet = DateOnly.FromDateTime(DateTime.UtcNow);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.ToDto();
    }

    private static void UpdateTienDoDenormalizedFields(TienDo tienDo, decimal phanTramThucTe, DateOnly ngayBaoCao)
    {
        if (phanTramThucTe > tienDo.PhanTramThucTe)
        {
            tienDo.PhanTramThucTe = phanTramThucTe;
        }

        if (!tienDo.NgayCapNhatGanNhat.HasValue || ngayBaoCao > tienDo.NgayCapNhatGanNhat)
        {
            tienDo.NgayCapNhatGanNhat = ngayBaoCao;
        }
    }
}