namespace QLHD.Application.TienDos.Commands;

public record TienDoDeleteCommand(Guid Id) : IRequest;

internal class TienDoDeleteCommandHandler : IRequestHandler<TienDoDeleteCommand>
{
    private readonly IRepository<TienDo, Guid> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public TienDoDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<TienDo, Guid>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task Handle(TienDoDeleteCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
        ManagedException.ThrowIfNull(entity, "Không tìm thấy tiến độ");

        entity.IsDeleted = true;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}