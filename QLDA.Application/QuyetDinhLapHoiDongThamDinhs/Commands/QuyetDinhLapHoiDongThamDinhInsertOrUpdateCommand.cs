using System.Data;
using Microsoft.Extensions.Logging;

namespace QLDA.Application.QuyetDinhLapHoiDongThamDinhs.Commands;

public record QuyetDinhLapHoiDongThamDinhInsertOrUpdateCommand(QuyetDinhLapHoiDongThamDinh Entity) : IRequest {
}

internal class
    QuyetDinhLapHoiDongThamDinhInsertOrUpdateCommandHandler : IRequestHandler<QuyetDinhLapHoiDongThamDinhInsertOrUpdateCommand> {
    private readonly IRepository<QuyetDinhLapHoiDongThamDinh, Guid> QuyetDinhLapHoiDongThamDinh;
    private readonly IRepository<DuAn, Guid> DuAn;
    private readonly IRepository<DanhMucBuoc, int> DanhMucBuoc;
    private readonly IUnitOfWork UnitOfWork;
    private readonly ILogger<QuyetDinhLapHoiDongThamDinhInsertOrUpdateCommandHandler> Logger;

    public QuyetDinhLapHoiDongThamDinhInsertOrUpdateCommandHandler(IServiceProvider serviceProvider,
        ILogger<QuyetDinhLapHoiDongThamDinhInsertOrUpdateCommandHandler> logger) {
        QuyetDinhLapHoiDongThamDinh = serviceProvider.GetRequiredService<IRepository<QuyetDinhLapHoiDongThamDinh, Guid>>();
        DuAn = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        DanhMucBuoc = serviceProvider.GetRequiredService<IRepository<DanhMucBuoc, int>>();
        Logger = logger;
        UnitOfWork = QuyetDinhLapHoiDongThamDinh.UnitOfWork;
    }

    public async Task Handle(QuyetDinhLapHoiDongThamDinhInsertOrUpdateCommand request,
        CancellationToken cancellationToken = default) {
        try {
            ManagedException.ThrowIf(!DuAn.GetQueryableSet().Any(e => e.Id == request.Entity.DuAnId),
                "Không tồn tại dự án");

            using (await UnitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken)) {
                var isExist = QuyetDinhLapHoiDongThamDinh.GetQueryableSet().Any(o => o.Id == request.Entity.Id);
                if (isExist) {
                } else {
                    await QuyetDinhLapHoiDongThamDinh.AddAsync(request.Entity, cancellationToken);
                    await UnitOfWork.SaveChangesAsync(cancellationToken);
                }

                await UnitOfWork.SaveChangesAsync(cancellationToken);
                await UnitOfWork.CommitTransactionAsync(cancellationToken);
            }
        } catch (Exception ex) {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }
}