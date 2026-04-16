namespace QLHD.Application.DuAns.Commands;

public record DuAnDeleteCommand(Guid Id) : IRequest;

internal class DuAnDeleteCommandHandler : IRequestHandler<DuAnDeleteCommand>
{
    private readonly IRepository<DuAn, Guid> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DuAnDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task Handle(DuAnDeleteCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException($"Không tìm thấy dự án với ID: {request.Id}");

        entity.IsDeleted = true;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}