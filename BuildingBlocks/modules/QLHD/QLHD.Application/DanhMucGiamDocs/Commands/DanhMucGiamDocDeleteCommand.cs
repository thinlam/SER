namespace QLHD.Application.DanhMucGiamDocs.Commands;

public record DanhMucGiamDocDeleteCommand(int Id) : IRequest;

internal class DanhMucGiamDocDeleteCommandHandler : IRequestHandler<DanhMucGiamDocDeleteCommand>
{
    private readonly IRepository<DanhMucGiamDoc, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucGiamDocDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucGiamDoc, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task Handle(DanhMucGiamDocDeleteCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException($"Không tìm thấy bản ghi với ID: {request.Id}");

        entity.IsDeleted = true;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}