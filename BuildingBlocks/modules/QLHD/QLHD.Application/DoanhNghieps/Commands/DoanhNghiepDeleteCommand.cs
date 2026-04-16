namespace QLHD.Application.DoanhNghieps.Commands;

public record DoanhNghiepDeleteCommand(Guid Id) : IRequest<bool>;

internal class DoanhNghiepDeleteCommandHandler : IRequestHandler<DoanhNghiepDeleteCommand, bool>
{
    private readonly IRepository<DoanhNghiep, Guid> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DoanhNghiepDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DoanhNghiep, Guid>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<bool> Handle(DoanhNghiepDeleteCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
        ManagedException.ThrowIfNull(entity, "Doanh nghiệp không tồn tại");

        entity.IsDeleted = true;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}