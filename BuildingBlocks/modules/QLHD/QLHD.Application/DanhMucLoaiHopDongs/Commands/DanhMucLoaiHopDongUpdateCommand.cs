using QLHD.Application.DanhMucLoaiHopDongs.DTOs;

namespace QLHD.Application.DanhMucLoaiHopDongs.Commands;

public record DanhMucLoaiHopDongUpdateCommand(int Id, DanhMucLoaiHopDongUpdateModel Model) : IRequest<DanhMucLoaiHopDong>;

internal class DanhMucLoaiHopDongUpdateCommandHandler : IRequestHandler<DanhMucLoaiHopDongUpdateCommand, DanhMucLoaiHopDong>
{
    private readonly IRepository<DanhMucLoaiHopDong, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucLoaiHopDongUpdateCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiHopDong, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<DanhMucLoaiHopDong> Handle(DanhMucLoaiHopDongUpdateCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException($"Không tìm thấy loại hợp đồng với ID: {request.Id}");

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