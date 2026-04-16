namespace QLHD.Application.DanhMucLoaiHopDongs.Commands;

public record DanhMucLoaiHopDongDeleteCommand(int Id) : IRequest;

internal class DanhMucLoaiHopDongDeleteCommandHandler : IRequestHandler<DanhMucLoaiHopDongDeleteCommand>
{
    private readonly IRepository<DanhMucLoaiHopDong, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucLoaiHopDongDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiHopDong, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task Handle(DanhMucLoaiHopDongDeleteCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException($"Không tìm thấy loại hợp đồng với ID: {request.Id}");

        entity.IsDeleted = true;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}