
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace QLDA.Application.DuAns.Commands;

public record DuAnUpdatePhaseCommand(Guid DuAnId, DuAnBuoc? DuAnBuoc) : IRequest;


internal class DuAnUpdatePhaseCommandHandler : IRequestHandler<DuAnUpdatePhaseCommand> {
    private readonly IRepository<DuAn, Guid> DuAn;
    private readonly IRepository<DanhMucGiaiDoan, int> DanhMucGiaiDoan;
    private readonly IUnitOfWork _unitOfWork;

    public DuAnUpdatePhaseCommandHandler(IServiceProvider serviceProvider) {
        DuAn = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        DanhMucGiaiDoan = serviceProvider.GetRequiredService<IRepository<DanhMucGiaiDoan, int>>();
        _unitOfWork = DanhMucGiaiDoan.UnitOfWork;
    }

    public async Task Handle(DuAnUpdatePhaseCommand request, CancellationToken cancellationToken) {
        if (request.DuAnBuoc is null)
            return;

        // Validate tồn tại dự án và bước
        if (_unitOfWork.HasTransaction) {
            await UpdateCurrentPhaseAsync(request, cancellationToken);
        } else {
            using var tx = await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
            await UpdateCurrentPhaseAsync(request, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
    }
    #region Private helper methods
    private async Task UpdateCurrentPhaseAsync(DuAnUpdatePhaseCommand request, CancellationToken cancellationToken) {
        var currentPhase = await DuAn.GetQueryableSet()
            .Include(e => e.GiaiDoanHienTai)
            .Where(e => e.Id == request.DuAnId)
            .Select(e => e.GiaiDoanHienTai)
            .FirstOrDefaultAsync(cancellationToken);

        var latestPhase = request.DuAnBuoc?.Buoc?.GiaiDoan;

        if (latestPhase == null) return;

        if (currentPhase == null || currentPhase.Stt < latestPhase.Stt) {
            await SetPhase(request, cancellationToken);
        }
    }
    private async Task SetPhase(DuAnUpdatePhaseCommand request, CancellationToken cancellationToken = default) {
        await DuAn.GetQueryableSet()
            .Where(e => e.Id == request.DuAnId)
            .ExecuteUpdateAsync(setCall => setCall.SetProperty(e => e.GiaiDoanHienTaiId, request.DuAnBuoc!.Buoc!.GiaiDoanId),
                cancellationToken);
    }

    #endregion
}