using QLHD.Application.DanhMucLoaiTrangThais.DTOs;

namespace QLHD.Application.DanhMucLoaiTrangThais.Commands;

public record DanhMucLoaiTrangThaiInsertCommand(DanhMucLoaiTrangThaiInsertModel Model) : IRequest<DanhMucLoaiTrangThai>;

internal class DanhMucLoaiTrangThaiInsertCommandHandler : IRequestHandler<DanhMucLoaiTrangThaiInsertCommand, DanhMucLoaiTrangThai>
{
    private readonly IRepository<DanhMucLoaiTrangThai, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucLoaiTrangThaiInsertCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiTrangThai, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<DanhMucLoaiTrangThai> Handle(DanhMucLoaiTrangThaiInsertCommand request, CancellationToken cancellationToken = default)
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

    private async Task<DanhMucLoaiTrangThai> InsertAsync(DanhMucLoaiTrangThaiInsertCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Model.ToEntity();
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity;
    }
}