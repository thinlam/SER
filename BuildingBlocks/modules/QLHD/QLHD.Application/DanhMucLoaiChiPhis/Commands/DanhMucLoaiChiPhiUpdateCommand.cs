using QLHD.Application.DanhMucLoaiChiPhis.DTOs;

namespace QLHD.Application.DanhMucLoaiChiPhis.Commands;

public record DanhMucLoaiChiPhiUpdateCommand(int Id, DanhMucLoaiChiPhiUpdateModel Model) : IRequest<DanhMucLoaiChiPhi>;

internal class DanhMucLoaiChiPhiUpdateCommandHandler : IRequestHandler<DanhMucLoaiChiPhiUpdateCommand, DanhMucLoaiChiPhi>
{
    private readonly IRepository<DanhMucLoaiChiPhi, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucLoaiChiPhiUpdateCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiChiPhi, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<DanhMucLoaiChiPhi> Handle(DanhMucLoaiChiPhiUpdateCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException($"Không tìm thấy loại chi phí với ID: {request.Id}");

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