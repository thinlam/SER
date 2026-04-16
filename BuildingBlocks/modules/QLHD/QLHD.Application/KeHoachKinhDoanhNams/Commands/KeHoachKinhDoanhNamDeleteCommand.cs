namespace QLHD.Application.KeHoachKinhDoanhNams.Commands;

public record KeHoachKinhDoanhNamDeleteCommand(Guid Id) : IRequest;

internal class KeHoachKinhDoanhNamDeleteCommandHandler : IRequestHandler<KeHoachKinhDoanhNamDeleteCommand>
{
    private readonly IRepository<KeHoachKinhDoanhNam, Guid> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public KeHoachKinhDoanhNamDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<KeHoachKinhDoanhNam, Guid>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task Handle(KeHoachKinhDoanhNamDeleteCommand request, CancellationToken cancellationToken = default)
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