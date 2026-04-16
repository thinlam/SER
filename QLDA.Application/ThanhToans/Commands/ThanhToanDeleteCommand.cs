using Microsoft.EntityFrameworkCore;
using QLDA.Application.Common;

namespace QLDA.Application.ThanhToans.Commands;

public record ThanhToanDeleteCommand(Guid Id) : IRequest;

public record ThanhToanDeleteCommandHandler : IRequestHandler<ThanhToanDeleteCommand> {
    private readonly IRepository<ThanhToan, Guid> ThanhToan;
    private readonly IRepository<TepDinhKem, Guid> TepDinhKem;
    private readonly IUnitOfWork _unitOfWork;

    public ThanhToanDeleteCommandHandler(IServiceProvider serviceProvider) {
        ThanhToan = serviceProvider.GetRequiredService<IRepository<ThanhToan, Guid>>();
        TepDinhKem = serviceProvider.GetRequiredService<IRepository<TepDinhKem, Guid>>();
        _unitOfWork = ThanhToan.UnitOfWork;
    }

    public async Task Handle(ThanhToanDeleteCommand request, CancellationToken cancellationToken) {
        var entity = await ThanhToan.GetOrderedSet()
           .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        ManagedException.ThrowIfNull(entity);

        entity.IsDeleted = true;

        await SyncHelper.SetDeleteWithRelatedFiles(TepDinhKem, [entity.Id.ToString()], cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}