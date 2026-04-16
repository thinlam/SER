namespace QLHD.Application.CongViecs.Commands;

public record CongViecDeleteCommand(Guid Id) : IRequest;

internal class CongViecDeleteCommandHandler : IRequestHandler<CongViecDeleteCommand>
{
    private readonly IRepository<CongViec, Guid> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CongViecDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<CongViec, Guid>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task Handle(CongViecDeleteCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
        ManagedException.ThrowIfNull(entity, "Không tìm thấy bản ghi");

        _repository.Delete(entity);

        if (_unitOfWork.HasTransaction)
        {
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return;
        }

        using var tx = await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync(cancellationToken);
    }
}