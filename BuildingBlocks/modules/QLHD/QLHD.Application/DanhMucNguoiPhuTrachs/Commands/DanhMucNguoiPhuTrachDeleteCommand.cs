namespace QLHD.Application.DanhMucNguoiPhuTrachs.Commands;

public record DanhMucNguoiPhuTrachDeleteCommand(int Id) : IRequest;

internal class DanhMucNguoiPhuTrachDeleteCommandHandler : IRequestHandler<DanhMucNguoiPhuTrachDeleteCommand>
{
    private readonly IRepository<DanhMucNguoiPhuTrach, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucNguoiPhuTrachDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucNguoiPhuTrach, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task Handle(DanhMucNguoiPhuTrachDeleteCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException($"Không tìm thấy bản ghi với ID: {request.Id}");

        entity.IsDeleted = true;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}