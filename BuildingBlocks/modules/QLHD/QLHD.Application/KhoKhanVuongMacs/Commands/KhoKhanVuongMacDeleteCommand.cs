namespace QLHD.Application.KhoKhanVuongMacs.Commands;

public record KhoKhanVuongMacDeleteCommand(Guid Id) : IRequest;

internal class KhoKhanVuongMacDeleteCommandHandler : IRequestHandler<KhoKhanVuongMacDeleteCommand>
{
    private readonly IRepository<KhoKhanVuongMac, Guid> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public KhoKhanVuongMacDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<KhoKhanVuongMac, Guid>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task Handle(KhoKhanVuongMacDeleteCommand request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(k => k.Id == request.Id, cancellationToken);
        ManagedException.ThrowIfNull(entity, "Không tìm thấy khó khăn vướng mắc");

        entity.IsDeleted = true;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}