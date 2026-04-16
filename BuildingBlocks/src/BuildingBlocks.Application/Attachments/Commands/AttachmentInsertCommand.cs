namespace BuildingBlocks.Application.Attachments.Commands;

public record AttachmentInsertCommand(List<Attachment> Entities) : IRequest;

internal class AttachmentInsertCommandHandler(IRepository<Attachment, Guid> repository) : IRequestHandler<AttachmentInsertCommand>
{
    private readonly IRepository<Attachment, Guid> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = repository.UnitOfWork;

    public async Task Handle(AttachmentInsertCommand request, CancellationToken cancellationToken = default)
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