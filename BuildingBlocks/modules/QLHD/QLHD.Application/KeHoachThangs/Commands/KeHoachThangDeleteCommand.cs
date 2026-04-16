using QLHD.Domain.Entities;

namespace QLHD.Application.KeHoachThangs.Commands;

public record KeHoachThangDeleteCommand(int Id) : IRequest;

internal class KeHoachThangDeleteCommandHandler : IRequestHandler<KeHoachThangDeleteCommand>
{
    private readonly IRepository<KeHoachThang, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public KeHoachThangDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<KeHoachThang, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task Handle(KeHoachThangDeleteCommand request, CancellationToken cancellationToken = default)
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