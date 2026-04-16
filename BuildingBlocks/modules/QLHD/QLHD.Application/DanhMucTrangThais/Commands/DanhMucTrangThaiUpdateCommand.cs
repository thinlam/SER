using QLHD.Application.DanhMucTrangThais.DTOs;

namespace QLHD.Application.DanhMucTrangThais.Commands;

public record DanhMucTrangThaiUpdateCommand(int Id, DanhMucTrangThaiUpdateModel Model) : IRequest<DanhMucTrangThai>;

internal class DanhMucTrangThaiUpdateCommandHandler : IRequestHandler<DanhMucTrangThaiUpdateCommand, DanhMucTrangThai>
{
    private readonly IRepository<DanhMucTrangThai, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucTrangThaiUpdateCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucTrangThai, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<DanhMucTrangThai> Handle(DanhMucTrangThaiUpdateCommand request, CancellationToken cancellationToken = default)
    {
        if (_unitOfWork.HasTransaction)
        {
            return await UpdateAsync(request, cancellationToken);
        }

        using var tx = await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        var entity = await UpdateAsync(request, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync(cancellationToken);
        return entity;
    }

    private async Task<DanhMucTrangThai> UpdateAsync(DanhMucTrangThaiUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException($"Không tìm thấy trạng thái với ID: {request.Id}");

        // If setting IsDefault to true, reset all others in same LoaiTrangThaiId to false first
        if (request.Model.IsDefault && !entity.IsDefault)
        {
            await ResetIsDefaultAsync(request.Model.LoaiTrangThaiId ?? entity.LoaiTrangThaiId ?? 0, cancellationToken);
        }

        entity.UpdateFrom(request.Model);
        await _repository.UpdateAsync(entity, cancellationToken);
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