using QLHD.Application.KhachHangs.DTOs;

namespace QLHD.Application.KhachHangs.Commands;

public record KhachHangUpdateCommand(Guid Id, KhachHangUpdateModel Model) : IRequest<KhachHang>;

internal class KhachHangUpdateCommandHandler : IRequestHandler<KhachHangUpdateCommand, KhachHang>
{
    private readonly IRepository<KhachHang, Guid> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public KhachHangUpdateCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<KhachHang, Guid>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<KhachHang> Handle(KhachHangUpdateCommand request, CancellationToken cancellationToken = default)
    {
        if (_unitOfWork.HasTransaction)
        {
            return await UpdateAsync(request, cancellationToken);
        }

        using var tx = await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);
        var entity = await UpdateAsync(request, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync(cancellationToken);
        return entity;
    }

    private async Task<KhachHang> UpdateAsync(KhachHangUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException("Không tìm thấy khách hàng");

        // Check duplicate Ma (exclude current record)
        if (!string.IsNullOrEmpty(request.Model.Ma))
        {
            var exists = await _repository.GetQueryableSet()
                .AnyAsync(e => e.Ma == request.Model.Ma && e.Id != request.Id, cancellationToken);
            ManagedException.ThrowIf(exists, $"Mã khách hàng '{request.Model.Ma}' đã tồn tại");
        }

        entity.UpdateFrom(request.Model);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity;
    }
}