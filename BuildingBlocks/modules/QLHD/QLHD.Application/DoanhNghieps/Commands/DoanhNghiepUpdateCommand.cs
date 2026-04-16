using QLHD.Application.DoanhNghieps.DTOs;

namespace QLHD.Application.DoanhNghieps.Commands;

public record DoanhNghiepUpdateCommand(DoanhNghiepUpdateModel Model) : IRequest<DoanhNghiep>;

internal class DoanhNghiepUpdateCommandHandler : IRequestHandler<DoanhNghiepUpdateCommand, DoanhNghiep>
{
    private readonly IRepository<DoanhNghiep, Guid> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DoanhNghiepUpdateCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DoanhNghiep, Guid>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<DoanhNghiep> Handle(DoanhNghiepUpdateCommand request, CancellationToken cancellationToken = default)
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

    private async Task<DoanhNghiep> UpdateAsync(DoanhNghiepUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = (await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Model.Id, cancellationToken))!;

        entity.UpdateFrom(request.Model);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity;
    }
}