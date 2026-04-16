using QLHD.Application.DoanhNghieps.DTOs;

namespace QLHD.Application.DoanhNghieps.Commands;

public record DoanhNghiepInsertCommand(DoanhNghiepInsertModel Model) : IRequest<DoanhNghiep>;

internal class DoanhNghiepInsertCommandHandler : IRequestHandler<DoanhNghiepInsertCommand, DoanhNghiep>
{
    private readonly IRepository<DoanhNghiep, Guid> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DoanhNghiepInsertCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DoanhNghiep, Guid>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<DoanhNghiep> Handle(DoanhNghiepInsertCommand request, CancellationToken cancellationToken = default)
    {
        if (_unitOfWork.HasTransaction)
        {
            return await InsertAsync(request, cancellationToken);
        }

        using var tx = await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);
        var entity = await InsertAsync(request, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync(cancellationToken);
        return entity;
    }

    private async Task<DoanhNghiep> InsertAsync(DoanhNghiepInsertCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Model.ToEntity();
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity;
    }
}