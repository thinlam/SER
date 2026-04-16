using QLHD.Application.KeHoachThangs.DTOs;
using QLHD.Domain.Entities;

namespace QLHD.Application.KeHoachThangs.Commands;

public record KeHoachThangInsertCommand(KeHoachThangInsertModel Model) : IRequest<KeHoachThang>;

internal class KeHoachThangInsertCommandHandler : IRequestHandler<KeHoachThangInsertCommand, KeHoachThang>
{
    private readonly IRepository<KeHoachThang, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public KeHoachThangInsertCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<KeHoachThang, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<KeHoachThang> Handle(KeHoachThangInsertCommand request, CancellationToken cancellationToken = default)
    {
        var entity = request.Model.ToEntity();

        if (_unitOfWork.HasTransaction)
        {
            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity;
        }

        using var tx = await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync(cancellationToken);
        return entity;
    }
}