using QLHD.Application.KeHoachThangs.DTOs;
using QLHD.Domain.Entities;

namespace QLHD.Application.KeHoachThangs.Commands;

public record KeHoachThangUpdateCommand(int Id, KeHoachThangUpdateModel Model) : IRequest<KeHoachThang>;

internal class KeHoachThangUpdateCommandHandler : IRequestHandler<KeHoachThangUpdateCommand, KeHoachThang>
{
    private readonly IRepository<KeHoachThang, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public KeHoachThangUpdateCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<KeHoachThang, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<KeHoachThang> Handle(KeHoachThangUpdateCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
        ManagedException.ThrowIfNull(entity, "Không tìm thấy bản ghi");

        entity.UpdateFrom(request.Model);

        if (_unitOfWork.HasTransaction)
        {
            await _repository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity;
        }

        using var tx = await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync(cancellationToken);
        return entity;
    }
}