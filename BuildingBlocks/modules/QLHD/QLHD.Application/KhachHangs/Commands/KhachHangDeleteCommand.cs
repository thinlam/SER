namespace QLHD.Application.KhachHangs.Commands;

public record KhachHangDeleteCommand(Guid Id) : IRequest;

internal class KhachHangDeleteCommandHandler : IRequestHandler<KhachHangDeleteCommand>
{
    private readonly IRepository<KhachHang, Guid> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public KhachHangDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<KhachHang, Guid>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task Handle(KhachHangDeleteCommand request, CancellationToken cancellationToken = default)
    {
        if (_unitOfWork.HasTransaction)
        {
            await DeleteAsync(request, cancellationToken);
            return;
        }

        using var tx = await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);
        await DeleteAsync(request, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync(cancellationToken);
    }

    private async Task DeleteAsync(KhachHangDeleteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException("Không tìm thấy khách hàng");

        entity.IsDeleted = true;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}