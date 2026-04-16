namespace BuildingBlocks.Application.TepDinhKems.Commands;

public record TepDinhKemInsertCommand(List<TepDinhKem> Entities) : IRequest;

internal class TepDinhKemInsertCommandHandler(IRepository<TepDinhKem, Guid> repository) : IRequestHandler<TepDinhKemInsertCommand>
{
    private readonly IRepository<TepDinhKem, Guid> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = repository.UnitOfWork;

    public async Task Handle(TepDinhKemInsertCommand request, CancellationToken cancellationToken = default)
    {
        if (request.Entities.Count == 0) return;

        if (_unitOfWork.HasTransaction)
        {
            await _repository.AddRangeAsync(request.Entities, cancellationToken);
        }
        else
        {
            using var tx = await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
            await _repository.AddRangeAsync(request.Entities, cancellationToken);
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
    }
}
