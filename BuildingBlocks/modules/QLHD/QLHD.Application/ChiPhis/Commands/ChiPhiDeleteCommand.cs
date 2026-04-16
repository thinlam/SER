namespace QLHD.Application.ChiPhis.Commands;

/// <summary>
/// Command xóa chi phí
/// </summary>
public record ChiPhiDeleteCommand(Guid Id) : IRequest;

internal class ChiPhiDeleteCommandHandler : IRequestHandler<ChiPhiDeleteCommand>
{
    private readonly IRepository<HopDong_ChiPhi, Guid> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public ChiPhiDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<HopDong_ChiPhi, Guid>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task Handle(ChiPhiDeleteCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
        ManagedException.ThrowIfNull(entity, "Không tìm thấy bản ghi");

        // Soft delete
        entity.IsDeleted = true;

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