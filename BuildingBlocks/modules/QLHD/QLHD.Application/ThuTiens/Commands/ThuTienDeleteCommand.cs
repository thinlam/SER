namespace QLHD.Application.ThuTiens.Commands;

/// <summary>
/// Command xóa thu tiền (merged entity - soft delete entire record)
/// Routing: Nếu HopDong có DuAnId → dùng DuAn_ThuTien, ngược lại dùng HopDong_ThuTien
/// </summary>
public record ThuTienDeleteCommand(Guid Id) : IRequest;

internal class ThuTienDeleteCommandHandler : IRequestHandler<ThuTienDeleteCommand> {
    private readonly IRepository<HopDong, Guid> _hopDongRepository;
    private readonly IRepository<DuAn_ThuTien, Guid> _duAnThuTienRepository;
    private readonly IRepository<HopDong_ThuTien, Guid> _hopDongThuTienRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ThuTienDeleteCommandHandler(IServiceProvider serviceProvider) {
        _hopDongRepository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
        _duAnThuTienRepository = serviceProvider.GetRequiredService<IRepository<DuAn_ThuTien, Guid>>();
        _hopDongThuTienRepository = serviceProvider.GetRequiredService<IRepository<HopDong_ThuTien, Guid>>();
        _unitOfWork = _hopDongRepository.UnitOfWork;
    }

    public async Task Handle(ThuTienDeleteCommand request, CancellationToken cancellationToken = default) {

        if (_unitOfWork.HasTransaction) {
            await DeleteThuTien(request.Id, cancellationToken);
            return;
        }

        using var tx = await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);
        await DeleteThuTien(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync(cancellationToken);
    }

    private async Task DeleteThuTien(Guid Id, CancellationToken cancellationToken) {
        // Try find in DuAn_ThuTien first (project-level)
        var duAnThuTien = await _duAnThuTienRepository.GetQueryableSet()
        .FirstOrDefaultAsync(t => t.Id == Id, cancellationToken);
        if (duAnThuTien != null) {
            duAnThuTien.IsDeleted = true;
        } else {
            var hopDongThuTien = await _hopDongThuTienRepository.GetQueryableSet()
            .FirstOrDefaultAsync(t => t.Id == Id, cancellationToken);
            ManagedException.ThrowIfNull(hopDongThuTien, "Không tìm thấy bản ghi thu tiền");
            hopDongThuTien.IsDeleted = true;
        }
    }
}