using Microsoft.EntityFrameworkCore;
using QLDA.Application.Common;

namespace QLDA.Application.QuyetDinhLapBanQLDAs.Commands;

public record QuyetDinhLapBanQldaDeleteCommand(Guid Id) : IRequest<int> {
}

public record QuyetDinhLapBanQldaDeleteCommandHandler : IRequestHandler<QuyetDinhLapBanQldaDeleteCommand, int> {
    private readonly IRepository<QuyetDinhLapBanQLDA, Guid> QuyetDinhLapBanQLDA;
    private readonly IRepository<TepDinhKem, Guid> TepDinhKem;
    private readonly IUnitOfWork _unitOfWork;

    public QuyetDinhLapBanQldaDeleteCommandHandler(IServiceProvider serviceProvider) {
        QuyetDinhLapBanQLDA = serviceProvider.GetRequiredService<IRepository<QuyetDinhLapBanQLDA, Guid>>();
        TepDinhKem = serviceProvider.GetRequiredService<IRepository<TepDinhKem, Guid>>();
        _unitOfWork = QuyetDinhLapBanQLDA.UnitOfWork;
    }

    public async Task<int> Handle(QuyetDinhLapBanQldaDeleteCommand request, CancellationToken cancellationToken) {
        var entity = await QuyetDinhLapBanQLDA.GetOrderedSet()
            .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        ManagedException.ThrowIfNull(entity);
        
        entity.IsDeleted = true;

        await SyncHelper.SetDeleteWithRelatedFiles(TepDinhKem, [entity.Id.ToString()], cancellationToken);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}