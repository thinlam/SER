using QLHD.Application.BaoCaoTienDos.DTOs;

namespace QLHD.Application.BaoCaoTienDos.Commands;

public record BaoCaoTienDoInsertCommand(BaoCaoTienDoInsertModel Model) : IRequest<BaoCaoTienDoDto>;

internal class BaoCaoTienDoInsertCommandHandler : IRequestHandler<BaoCaoTienDoInsertCommand, BaoCaoTienDoDto>
{
    private readonly IRepository<BaoCaoTienDo, Guid> _baoCaoRepository;
    private readonly IRepository<TienDo, Guid> _tienDoRepository;
    private readonly IRepository<UserMaster, long> _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BaoCaoTienDoInsertCommandHandler(IServiceProvider serviceProvider)
    {
        _baoCaoRepository = serviceProvider.GetRequiredService<IRepository<BaoCaoTienDo, Guid>>();
        _tienDoRepository = serviceProvider.GetRequiredService<IRepository<TienDo, Guid>>();
        _userRepository = serviceProvider.GetRequiredService<IRepository<UserMaster, long>>();
        _unitOfWork = _baoCaoRepository.UnitOfWork;
    }

    public async Task<BaoCaoTienDoDto> Handle(BaoCaoTienDoInsertCommand request, CancellationToken cancellationToken = default)
    {
        var model = request.Model;

        // Validate TienDo exists
        var tienDo = await _tienDoRepository.GetQueryableSet()
            .FirstOrDefaultAsync(t => t.Id == model.TienDoId, cancellationToken);
        ManagedException.ThrowIfNull(tienDo, "Không tìm thấy tiến độ");

        // Fetch reporter name from USER_MASTER
        var nguoiBaoCao = await _userRepository.GetQueryableSet()
            .FirstOrDefaultAsync(u => u.Id == model.NguoiBaoCaoId, cancellationToken);
        ManagedException.ThrowIfNull(nguoiBaoCao, "Không tìm thấy người báo cáo");
        var tenNguoiBaoCao = nguoiBaoCao.HoTen ?? "Người dùng";

        // Fetch approver name if approval required
        string? tenNguoiDuyet = null;
        if (model.CanDuyet)
        {
            ManagedException.ThrowIf(!model.NguoiDuyetId.HasValue,
                "Phải chọn người duyệt khi bật yêu cầu duyệt");

            var nguoiDuyet = await _userRepository.GetQueryableSet()
                .FirstOrDefaultAsync(u => u.Id == model.NguoiDuyetId.Value, cancellationToken);
            ManagedException.ThrowIfNull(nguoiDuyet, "Không tìm thấy người duyệt");
            tenNguoiDuyet = nguoiDuyet.HoTen ?? "Người duyệt";
        }

        var entity = model.ToEntity(tenNguoiBaoCao, tenNguoiDuyet);

        await _baoCaoRepository.AddAsync(entity, cancellationToken);

        // Update TienDo denormalized fields (only if auto-approved)
        if (!model.CanDuyet)
        {
            UpdateTienDoDenormalizedFields(tienDo, entity.PhanTramThucTe, entity.NgayBaoCao);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Reload to get navigation properties
        var savedEntity = await _baoCaoRepository.GetQueryableSet()
            .Include(b => b.TienDo)
            .FirstAsync(b => b.Id == entity.Id, cancellationToken);

        return savedEntity.ToDto();
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