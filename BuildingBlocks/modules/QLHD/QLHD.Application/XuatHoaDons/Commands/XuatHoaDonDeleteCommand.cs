using MediatR;
using QLHD.Domain.Entities;

namespace QLHD.Application.XuatHoaDons.Commands;

/// <summary>
/// Command xóa xuất hóa đơn (unified routing)
/// - Nếu HopDong.DuAnId có giá trị → route đến DuAn_XuatHoaDon
/// - Nếu HopDong.DuAnId null → route đến HopDong_XuatHoaDon
/// </summary>
public record XuatHoaDonDeleteCommand(Guid Id, Guid HopDongId) : IRequest;

internal class XuatHoaDonDeleteCommandHandler : IRequestHandler<XuatHoaDonDeleteCommand>
{
    private readonly IRepository<HopDong, Guid> _hopDongRepository;
    private readonly IRepository<DuAn_XuatHoaDon, Guid> _duAnXuatHoaDonRepository;
    private readonly IRepository<HopDong_XuatHoaDon, Guid> _hopDongXuatHoaDonRepository;
    private readonly IUnitOfWork _unitOfWork;

    public XuatHoaDonDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _hopDongRepository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
        _duAnXuatHoaDonRepository = serviceProvider.GetRequiredService<IRepository<DuAn_XuatHoaDon, Guid>>();
        _hopDongXuatHoaDonRepository = serviceProvider.GetRequiredService<IRepository<HopDong_XuatHoaDon, Guid>>();
        _unitOfWork = _hopDongRepository.UnitOfWork;
    }

    public async Task Handle(XuatHoaDonDeleteCommand request, CancellationToken cancellationToken = default)
    {
        // Get HopDong to determine routing
        var hopDong = await _hopDongRepository.GetQueryableSet()
            .FirstOrDefaultAsync(h => h.Id == request.HopDongId, cancellationToken);
        ManagedException.ThrowIfNull(hopDong, "Không tìm thấy hợp đồng");

        // Routing: DuAn-linked vs Standalone
        if (hopDong.DuAnId.HasValue)
        {
            // Route to DuAn_XuatHoaDon
            var entity = await _duAnXuatHoaDonRepository.GetQueryableSet()
                .FirstOrDefaultAsync(e => e.Id == request.Id && e.DuAnId == hopDong.DuAnId.Value, cancellationToken);
            ManagedException.ThrowIfNull(entity, "Không tìm thấy bản ghi");

            entity.IsDeleted = true;
        }
        else
        {
            // Route to HopDong_XuatHoaDon
            var entity = await _hopDongXuatHoaDonRepository.GetQueryableSet()
                .FirstOrDefaultAsync(e => e.Id == request.Id && e.HopDongId == request.HopDongId, cancellationToken);
            ManagedException.ThrowIfNull(entity, "Không tìm thấy bản ghi");

            entity.IsDeleted = true;
        }

        if (_unitOfWork.HasTransaction)
        {
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return;
        }

        using var tx = await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync(cancellationToken);
    }
}