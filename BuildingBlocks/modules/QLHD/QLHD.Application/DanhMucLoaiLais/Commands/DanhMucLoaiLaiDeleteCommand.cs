using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Application.DanhMucLoaiLais.Commands;

public record DanhMucLoaiLaiDeleteCommand(int Id) : IRequest;

internal class DanhMucLoaiLaiDeleteCommandHandler : IRequestHandler<DanhMucLoaiLaiDeleteCommand>
{
    private readonly IRepository<DanhMucLoaiLai, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucLoaiLaiDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiLai, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task Handle(DanhMucLoaiLaiDeleteCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException($"Không tìm thấy loại lãi với ID: {request.Id}");

        entity.IsDeleted = true;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}