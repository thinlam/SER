using System.Data;
using Microsoft.Extensions.Logging;
using QLDA.Application.QuyetDinhLapHoiDongThamDinhs.DTOs;

namespace QLDA.Application.QuyetDinhLapHoiDongThamDinhs.Commands;

public record QuyetDinhLapHoiDongThamDinhInsertCommand(QuyetDinhLapHoiDongThamDinhInsertDto Dto) : IRequest<QuyetDinhLapHoiDongThamDinh>;

internal class QuyetDinhLapHoiDongThamDinhInsertCommandHandler : IRequestHandler<QuyetDinhLapHoiDongThamDinhInsertCommand, QuyetDinhLapHoiDongThamDinh> {
    private readonly IRepository<QuyetDinhLapHoiDongThamDinh, Guid> QuyetDinhLapHoiDongThamDinh;
    private readonly IRepository<DuAn, Guid> DuAn;
    private readonly IRepository<DanhMucBuoc, int> DanhMucBuoc;
    private readonly IUnitOfWork UnitOfWork;
    private readonly ILogger<QuyetDinhLapHoiDongThamDinhInsertCommandHandler> Logger;

    public QuyetDinhLapHoiDongThamDinhInsertCommandHandler(IServiceProvider serviceProvider,
        ILogger<QuyetDinhLapHoiDongThamDinhInsertCommandHandler> logger) {
        QuyetDinhLapHoiDongThamDinh = serviceProvider.GetRequiredService<IRepository<QuyetDinhLapHoiDongThamDinh, Guid>>();
        DuAn = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        DanhMucBuoc = serviceProvider.GetRequiredService<IRepository<DanhMucBuoc, int>>();
        Logger = logger;
        UnitOfWork = QuyetDinhLapHoiDongThamDinh.UnitOfWork;
    }

    public async Task<QuyetDinhLapHoiDongThamDinh> Handle(QuyetDinhLapHoiDongThamDinhInsertCommand request, CancellationToken cancellationToken = default) {
        try {
            ManagedException.ThrowIf(!DuAn.GetQueryableSet().Any(e => e.Id == request.Dto.DuAnId),
                "Không tồn tại dự án");

            var entity = request.Dto.ToEntity();

            using (await UnitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken)) {
                await QuyetDinhLapHoiDongThamDinh.AddAsync(entity, cancellationToken);
                await UnitOfWork.SaveChangesAsync(cancellationToken);
                await UnitOfWork.CommitTransactionAsync(cancellationToken);
            }

            return entity;
        } catch (Exception ex) {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }
}