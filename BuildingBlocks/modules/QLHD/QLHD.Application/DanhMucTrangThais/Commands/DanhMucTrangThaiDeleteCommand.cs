namespace QLHD.Application.DanhMucTrangThais.Commands;

public record DanhMucTrangThaiDeleteCommand(int Id) : IRequest;

internal class DanhMucTrangThaiDeleteCommandHandler : IRequestHandler<DanhMucTrangThaiDeleteCommand>
{
    private readonly IRepository<DanhMucTrangThai, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucTrangThaiDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucTrangThai, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task Handle(DanhMucTrangThaiDeleteCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException($"Không tìm thấy trạng thái với ID: {request.Id}");

        _repository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}