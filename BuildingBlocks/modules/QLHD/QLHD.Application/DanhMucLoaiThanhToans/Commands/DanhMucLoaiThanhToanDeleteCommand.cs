namespace QLHD.Application.DanhMucLoaiThanhToans.Commands;

public record DanhMucLoaiThanhToanDeleteCommand(int Id) : IRequest;

internal class DanhMucLoaiThanhToanDeleteCommandHandler : IRequestHandler<DanhMucLoaiThanhToanDeleteCommand>
{
    private readonly IRepository<DanhMucLoaiThanhToan, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucLoaiThanhToanDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiThanhToan, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task Handle(DanhMucLoaiThanhToanDeleteCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException($"Không tìm thấy loại thanh toán với ID: {request.Id}");

        entity.IsDeleted = true;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}