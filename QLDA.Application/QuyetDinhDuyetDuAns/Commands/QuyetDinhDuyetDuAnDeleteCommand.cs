using Microsoft.EntityFrameworkCore;
using QLDA.Application.Common;

namespace QLDA.Application.QuyetDinhDuyetDuAns.Commands;

public record QuyetDinhDuyetDuAnDeleteCommand(Guid Id) : IRequest<int>
{
}

public record QuyetDinhDuyetDuAnDeleteCommandHandler : IRequestHandler<QuyetDinhDuyetDuAnDeleteCommand, int>
{
    private readonly IRepository<QuyetDinhDuyetDuAn, Guid> QuyetDinhDuyetDuAn;
    private readonly IRepository<TepDinhKem, Guid> TepDinhKem;
    private readonly IUnitOfWork _unitOfWork;

    public QuyetDinhDuyetDuAnDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        QuyetDinhDuyetDuAn =serviceProvider.GetRequiredService<IRepository<QuyetDinhDuyetDuAn, Guid>>();
        TepDinhKem = serviceProvider.GetRequiredService<IRepository<TepDinhKem, Guid>>();
        _unitOfWork = QuyetDinhDuyetDuAn.UnitOfWork;
    }

    public async Task<int> Handle(QuyetDinhDuyetDuAnDeleteCommand request, CancellationToken cancellationToken)
    {
        var entity = await QuyetDinhDuyetDuAn.GetOrderedSet()
            // .Include(o => o.DanhSachToTrinh)
            .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        ManagedException.ThrowIfNull(entity);
        
        entity.IsDeleted = true;

        await SyncHelper.SetDeleteWithRelatedFiles(TepDinhKem, [entity.Id.ToString()], cancellationToken);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}