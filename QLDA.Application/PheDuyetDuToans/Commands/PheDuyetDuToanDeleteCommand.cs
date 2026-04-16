using Microsoft.EntityFrameworkCore;
using QLDA.Application.Common;

namespace QLDA.Application.PheDuyetDuToans.Commands;

public record PheDuyetDuToanDeleteCommand(Guid Id) : IRequest<int>
{
}

public record PheDuyetDuToanDeleteCommandHandler : IRequestHandler<PheDuyetDuToanDeleteCommand, int>
{
    private readonly IRepository<PheDuyetDuToan, Guid> PheDuyetDuToan;
    private readonly IRepository<TepDinhKem, Guid> TepDinhKem;
    private readonly IUnitOfWork _unitOfWork;

    public PheDuyetDuToanDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        PheDuyetDuToan =serviceProvider.GetRequiredService<IRepository<PheDuyetDuToan, Guid>>();
        TepDinhKem = serviceProvider.GetRequiredService<IRepository<TepDinhKem, Guid>>();
        _unitOfWork = PheDuyetDuToan.UnitOfWork;
    }

    public async Task<int> Handle(PheDuyetDuToanDeleteCommand request, CancellationToken cancellationToken)
    {
        var entity = await PheDuyetDuToan.GetOrderedSet()
            // .Include(o => o.DanhSachToTrinh)
            .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        ManagedException.ThrowIfNull(entity);
        
        entity.IsDeleted = true;

        await SyncHelper.SetDeleteWithRelatedFiles(TepDinhKem, [entity.Id.ToString()], cancellationToken);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}