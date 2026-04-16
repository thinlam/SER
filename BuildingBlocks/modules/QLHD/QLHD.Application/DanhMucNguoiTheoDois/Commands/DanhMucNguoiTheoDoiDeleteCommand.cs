namespace QLHD.Application.DanhMucNguoiTheoDois.Commands;

public record DanhMucNguoiTheoDoiDeleteCommand(int Id) : IRequest;

internal class DanhMucNguoiTheoDoiDeleteCommandHandler : IRequestHandler<DanhMucNguoiTheoDoiDeleteCommand>
{
    private readonly IRepository<DanhMucNguoiTheoDoi, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucNguoiTheoDoiDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucNguoiTheoDoi, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task Handle(DanhMucNguoiTheoDoiDeleteCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException($"Không tìm thấy bản ghi với ID: {request.Id}");

        entity.IsDeleted = true;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}