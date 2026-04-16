namespace QLHD.Application.HopDongs.Commands;

public record HopDongDeleteCommand(Guid Id) : IRequest;

internal class HopDongDeleteCommandHandler : IRequestHandler<HopDongDeleteCommand> {
    private readonly IRepository<HopDong, Guid> _repository;
    private readonly IRepository<DuAn, Guid> _duAnRepository;
    private readonly IRepository<Attachment, Guid> _attachmentRepository;
    private readonly IRepository<HopDong_ThuTien, Guid> _hopDongThuTienRepository;
    private readonly IRepository<HopDong_XuatHoaDon, Guid> _hopDongXuatHoaDonRepository;
    private readonly IRepository<DuAn_ThuTien, Guid> _duAnThuTienRepository;
    private readonly IRepository<DuAn_XuatHoaDon, Guid> _duAnXuatHoaDonRepository;
    private readonly IRepository<HopDong_ChiPhi, Guid> _hopDongChiPhiRepository;
    private readonly IUnitOfWork _unitOfWork;

    public HopDongDeleteCommandHandler(IServiceProvider serviceProvider) {
        _repository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
        _duAnRepository = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        _attachmentRepository = serviceProvider.GetRequiredService<IRepository<Attachment, Guid>>();
        _duAnThuTienRepository = serviceProvider.GetRequiredService<IRepository<DuAn_ThuTien, Guid>>();
        _duAnXuatHoaDonRepository = serviceProvider.GetRequiredService<IRepository<DuAn_XuatHoaDon, Guid>>();
        _hopDongThuTienRepository = serviceProvider.GetRequiredService<IRepository<HopDong_ThuTien, Guid>>();
        _hopDongXuatHoaDonRepository = serviceProvider.GetRequiredService<IRepository<HopDong_XuatHoaDon, Guid>>();
        _hopDongChiPhiRepository = serviceProvider.GetRequiredService<IRepository<HopDong_ChiPhi, Guid>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task Handle(HopDongDeleteCommand request, CancellationToken cancellationToken = default) {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException($"Không tìm thấy hợp đồng với ID: {request.Id}");

        entity.IsDeleted = true;

        // Soft-delete related Attachment files
        await SyncHelper.SetDeleteWithRelatedFiles(
            _attachmentRepository,
            [entity.Id.ToString()],
            cancellationToken: cancellationToken);

        if (entity.DuAnId.HasValue) {
            // Soft-delete related DuAn_ThuTien records
            var duAnThuTiens = await _duAnThuTienRepository.GetQueryableSet()
                .Where(e => e.DuAnId == entity.DuAnId.Value)
                .ToListAsync(cancellationToken);
            foreach (var item in duAnThuTiens) {
                item.IsDeleted = true;
            }

            // Soft-delete related DuAn_XuatHoaDon records
            var duAnXuatHoaDons = await _duAnXuatHoaDonRepository.GetQueryableSet()
                .Where(e => e.DuAnId == entity.DuAnId.Value)
                .ToListAsync(cancellationToken);
            foreach (var item in duAnXuatHoaDons) {
                item.IsDeleted = true;
            }
        } else {
            // Soft-delete related HopDong_ThuTien records
            var hopDongThuTiens = await _hopDongThuTienRepository.GetQueryableSet()
                .Where(e => e.HopDongId == entity.Id)
                .ToListAsync(cancellationToken);
            foreach (var item in hopDongThuTiens) {
                item.IsDeleted = true;
            }

            // Soft-delete related HopDong_XuatHoaDon records
            var hopDongXuatHoaDons = await _hopDongXuatHoaDonRepository.GetQueryableSet()
                .Where(e => e.HopDongId == entity.Id)
                .ToListAsync(cancellationToken);
            foreach (var item in hopDongXuatHoaDons) {
                item.IsDeleted = true;
            }

            // Soft-delete related HopDong_ChiPhi records
            var chiPhis = await _hopDongChiPhiRepository.GetQueryableSet()
                .Where(e => e.HopDongId == entity.Id)
                .ToListAsync(cancellationToken);
            foreach (var item in chiPhis) {
                item.IsDeleted = true;
            }
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}