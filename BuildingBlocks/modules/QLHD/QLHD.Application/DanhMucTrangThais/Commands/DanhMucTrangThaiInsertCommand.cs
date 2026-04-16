using QLHD.Application.DanhMucTrangThais.DTOs;

namespace QLHD.Application.DanhMucTrangThais.Commands;

public record DanhMucTrangThaiInsertCommand(DanhMucTrangThaiInsertModel Model) : IRequest<DanhMucTrangThai>;

internal class DanhMucTrangThaiInsertCommandHandler : IRequestHandler<DanhMucTrangThaiInsertCommand, DanhMucTrangThai>
{
    private readonly IRepository<DanhMucTrangThai, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucTrangThaiInsertCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucTrangThai, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<DanhMucTrangThai> Handle(DanhMucTrangThaiInsertCommand request, CancellationToken cancellationToken = default)
    {
        if (_unitOfWork.HasTransaction)
        {
            return await InsertAsync(request, cancellationToken);
        }

        using var tx = await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        var entity = await InsertAsync(request, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync(cancellationToken);
        return entity;
    }

    private async Task<DanhMucTrangThai> InsertAsync(DanhMucTrangThaiInsertCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Model.ToEntity();

        // If setting IsDefault to true, reset all others in same LoaiTrangThaiId to false first
        if (entity.IsDefault && entity.LoaiTrangThaiId.HasValue)
        {
            await ResetIsDefaultAsync(entity.LoaiTrangThaiId.Value, cancellationToken);
        }

        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity;
    }

    private async Task ResetIsDefaultAsync(int loaiTrangThaiId, CancellationToken cancellationToken)
    {
        var defaultEntities = await _repository.GetQueryableSet()
            .Where(e => e.IsDefault && e.LoaiTrangThaiId == loaiTrangThaiId)
            .ToListAsync(cancellationToken);

        foreach (var d in defaultEntities)
        {
            d.IsDefault = false;
        }
    }
}