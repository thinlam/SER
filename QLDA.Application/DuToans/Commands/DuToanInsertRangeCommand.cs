
using System.Data;

namespace QLDA.Application.DuToans.Commands;

public record DuToanInsertRangeCommand(List<DuToan> Entities) : IRequest<DuToan?>;

internal class DuToanInsertRangeCommandHandler : IRequestHandler<DuToanInsertRangeCommand, DuToan?> {
    private readonly IRepository<DuToan, Guid> _duToanRepository;
    private readonly IRepository<DuAn, Guid> _duAnRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly Serilog.ILogger _logger = Serilog.Log.ForContext<DuToanInsertRangeCommandHandler>();

    public DuToanInsertRangeCommandHandler(IServiceProvider serviceProvider) {
        _duToanRepository = serviceProvider.GetRequiredService<IRepository<DuToan, Guid>>();
        _duAnRepository = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        _unitOfWork = _duToanRepository.UnitOfWork;
    }

    public async Task<DuToan?> Handle(DuToanInsertRangeCommand request, CancellationToken cancellationToken = default) {
        if (request.Entities.Count == 0) return null;

        if (_unitOfWork.HasTransaction) {
            await InsertAsync(request.Entities, cancellationToken);
        } else {
            using var tx = await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
            await InsertAsync(request.Entities, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        return request.Entities.LastOrDefault();
    }

    #region Private helper methods

    private async Task InsertAsync(List<DuToan> entities, CancellationToken cancellationToken) {
        await _duToanRepository.AddRangeAsync(entities, cancellationToken);
    }

    #endregion
}