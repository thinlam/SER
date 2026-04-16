using Microsoft.EntityFrameworkCore;
using QLDA.Application.Common;

namespace QLDA.Application.QuyetDinhLapHoiDongThamDinhs.Commands;

public record QuyetDinhLapHoiDongThamDinhDeleteCommand(Guid Id) : IRequest<int> {
}

public record QuyetDinhLapHoiDongThamDinhDeleteCommandHandler : IRequestHandler<QuyetDinhLapHoiDongThamDinhDeleteCommand, int> {
    private readonly IRepository<QuyetDinhLapHoiDongThamDinh, Guid> QuyetDinhLapHoiDongThamDinh;
    private readonly IRepository<TepDinhKem, Guid> TepDinhKem;
    private readonly IUnitOfWork _unitOfWork;

    public QuyetDinhLapHoiDongThamDinhDeleteCommandHandler(IServiceProvider serviceProvider) {
        QuyetDinhLapHoiDongThamDinh = serviceProvider.GetRequiredService<IRepository<QuyetDinhLapHoiDongThamDinh, Guid>>();
        TepDinhKem = serviceProvider.GetRequiredService<IRepository<TepDinhKem, Guid>>();
        _unitOfWork = QuyetDinhLapHoiDongThamDinh.UnitOfWork;
    }

    public async Task<int> Handle(QuyetDinhLapHoiDongThamDinhDeleteCommand request, CancellationToken cancellationToken) {
        var entity = await QuyetDinhLapHoiDongThamDinh.GetOrderedSet()
            .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        ManagedException.ThrowIfNull(entity);
        
        entity.IsDeleted = true;

        await SyncHelper.SetDeleteWithRelatedFiles(TepDinhKem, [entity.Id.ToString()], cancellationToken);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}