using QLHD.Application.DanhMucLoaiTrangThais.DTOs;

namespace QLHD.Application.DanhMucLoaiTrangThais.Commands;

public record DanhMucLoaiTrangThaiUpdateCommand(int Id, DanhMucLoaiTrangThaiUpdateModel Model) : IRequest<DanhMucLoaiTrangThai>;

internal class DanhMucLoaiTrangThaiUpdateCommandHandler : IRequestHandler<DanhMucLoaiTrangThaiUpdateCommand, DanhMucLoaiTrangThai>
{
    private readonly IRepository<DanhMucLoaiTrangThai, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucLoaiTrangThaiUpdateCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiTrangThai, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<DanhMucLoaiTrangThai> Handle(DanhMucLoaiTrangThaiUpdateCommand request, CancellationToken cancellationToken = default)
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

    private async Task<DanhMucLoaiTrangThai> UpdateAsync(DanhMucLoaiTrangThaiUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException($"Không tìm thấy loại trạng thái với ID: {request.Id}");

        entity.UpdateFrom(request.Model);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity;
    }
}