using QLHD.Application.DanhMucLoaiLais.DTOs;
using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Application.DanhMucLoaiLais.Commands;

public record DanhMucLoaiLaiUpdateCommand(int Id, DanhMucLoaiLaiUpdateModel Model) : IRequest<DanhMucLoaiLai>;

internal class DanhMucLoaiLaiUpdateCommandHandler : IRequestHandler<DanhMucLoaiLaiUpdateCommand, DanhMucLoaiLai>
{
    private readonly IRepository<DanhMucLoaiLai, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucLoaiLaiUpdateCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiLai, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<DanhMucLoaiLai> Handle(DanhMucLoaiLaiUpdateCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException($"Không tìm thấy loại lãi với ID: {request.Id}");

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