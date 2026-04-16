using QLHD.Application.DanhMucLoaiThanhToans.DTOs;

namespace QLHD.Application.DanhMucLoaiThanhToans.Commands;

public record DanhMucLoaiThanhToanUpdateCommand(int Id, DanhMucLoaiThanhToanUpdateModel Model) : IRequest<DanhMucLoaiThanhToan>;

internal class DanhMucLoaiThanhToanUpdateCommandHandler : IRequestHandler<DanhMucLoaiThanhToanUpdateCommand, DanhMucLoaiThanhToan>
{
    private readonly IRepository<DanhMucLoaiThanhToan, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucLoaiThanhToanUpdateCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiThanhToan, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<DanhMucLoaiThanhToan> Handle(DanhMucLoaiThanhToanUpdateCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException($"Không tìm thấy loại thanh toán với ID: {request.Id}");

        // If setting IsDefault to true, reset all others to false first
        if (request.Model.IsDefault && !entity.IsDefault)
        {
            await ResetIsDefaultAsync(cancellationToken);
        }

        entity.UpdateFrom(request.Model);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity;
    }

    private async Task ResetIsDefaultAsync(CancellationToken cancellationToken)
    {
        var defaultEntities = await _repository.GetQueryableSet()
            .Where(e => e.IsDefault)
            .ToListAsync(cancellationToken);

        foreach (var d in defaultEntities)
        {
            d.IsDefault = false;
        }
    }
}