namespace QLHD.Application.DanhMucLoaiTrangThais.Commands;

public record DanhMucLoaiTrangThaiDeleteCommand(int Id) : IRequest;

internal class DanhMucLoaiTrangThaiDeleteCommandHandler : IRequestHandler<DanhMucLoaiTrangThaiDeleteCommand>
{
    private readonly IRepository<DanhMucLoaiTrangThai, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucLoaiTrangThaiDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiTrangThai, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task Handle(DanhMucLoaiTrangThaiDeleteCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException($"Không tìm thấy loại trạng thái với ID: {request.Id}");

        _repository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}