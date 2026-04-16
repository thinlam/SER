namespace QLHD.Application.DanhMucLoaiChiPhis.Commands;

public record DanhMucLoaiChiPhiDeleteCommand(int Id) : IRequest;

internal class DanhMucLoaiChiPhiDeleteCommandHandler : IRequestHandler<DanhMucLoaiChiPhiDeleteCommand>
{
    private readonly IRepository<DanhMucLoaiChiPhi, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucLoaiChiPhiDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiChiPhi, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task Handle(DanhMucLoaiChiPhiDeleteCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException($"Không tìm thấy loại chi phí với ID: {request.Id}");

        entity.IsDeleted = true;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}