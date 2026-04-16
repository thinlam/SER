using Microsoft.EntityFrameworkCore;
using QLDA.Application.Common;

namespace QLDA.Application.QuyetDinhLapBenMoiThaus.Commands;

public record QuyetDinhLapBenMoiThauDeleteCommand(Guid Id) : IRequest<int> {
}

public record QuyetDinhLapBenMoiThauDeleteCommandHandler : IRequestHandler<QuyetDinhLapBenMoiThauDeleteCommand, int> {
    private readonly IRepository<QuyetDinhLapBenMoiThau, Guid> QuyetDinhLapBenMoiThau;
    private readonly IRepository<TepDinhKem, Guid> TepDinhKem;
    private readonly IUnitOfWork _unitOfWork;

    public QuyetDinhLapBenMoiThauDeleteCommandHandler(IServiceProvider serviceProvider) {
        QuyetDinhLapBenMoiThau = serviceProvider.GetRequiredService<IRepository<QuyetDinhLapBenMoiThau, Guid>>();
        TepDinhKem = serviceProvider.GetRequiredService<IRepository<TepDinhKem, Guid>>();
        _unitOfWork = QuyetDinhLapBenMoiThau.UnitOfWork;
    }

    public async Task<int> Handle(QuyetDinhLapBenMoiThauDeleteCommand request, CancellationToken cancellationToken) {
        var entity = await QuyetDinhLapBenMoiThau.GetOrderedSet()
            .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        ManagedException.ThrowIfNull(entity);
        
        entity.IsDeleted = true;

        await SyncHelper.SetDeleteWithRelatedFiles(TepDinhKem, [entity.Id.ToString()], cancellationToken);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}