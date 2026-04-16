using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace QLDA.Application.QuyetDinhDuyetDuAnHangMucs.Commands;

public record QuyetDinhDuyetDuAnHangMucInsertOrUpdateCommand() : IRequest {
    public Guid QuyetDinhDuyetDuAnId { get; set; }
    public List<QuyetDinhDuyetDuAnHangMuc> Entities { get; set; } = [];
}

internal class
    QuyetDinhDuyetDuAnHangMucInsertOrUpdateCommandHandler : IRequestHandler<
    QuyetDinhDuyetDuAnHangMucInsertOrUpdateCommand> {
    private readonly IRepository<QuyetDinhDuyetDuAnHangMuc, int> QuyetDinhDuyetDuAnHangMuc;
    private readonly IRepository<QuyetDinhDuyetDuAnNguonVon, Guid> QuyetDinhDuyetDuAnNguonVon;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<QuyetDinhDuyetDuAnHangMucInsertOrUpdateCommandHandler> _logger;

    public QuyetDinhDuyetDuAnHangMucInsertOrUpdateCommandHandler(IServiceProvider serviceProvider,
        ILogger<QuyetDinhDuyetDuAnHangMucInsertOrUpdateCommandHandler> logger) {
        QuyetDinhDuyetDuAnHangMuc = serviceProvider.GetRequiredService<IRepository<QuyetDinhDuyetDuAnHangMuc, int>>();
        QuyetDinhDuyetDuAnNguonVon =
            serviceProvider.GetRequiredService<IRepository<QuyetDinhDuyetDuAnNguonVon, Guid>>();
        _logger = logger;
        _unitOfWork = QuyetDinhDuyetDuAnHangMuc.UnitOfWork;
    }

    public async Task Handle(QuyetDinhDuyetDuAnHangMucInsertOrUpdateCommand request,
        CancellationToken cancellationToken = default) {
        try {
            var requestObjs = request.Entities;

            var requestIds = requestObjs.Select(e => e.Id).ToList();
            // Lấy existing từ DB
            var existing = await QuyetDinhDuyetDuAnNguonVon.GetQueryableSet()
                .AsNoTracking()
                .Where(e => e.QuyetDinhDuyetDuAnId == request.QuyetDinhDuyetDuAnId)
                .SelectMany(e => e.QuyetDinhDuyetDuAnHangMucs!)
                .ToListAsync(cancellationToken);

            // Thêm mới
            var toAdd = requestObjs
                .Where(e => e.Id == 0)
                .Select(e => new QuyetDinhDuyetDuAnHangMuc {
                    QuyetDinhDuyetDuAnNguonVonId = e.QuyetDinhDuyetDuAnNguonVonId,
                    TenHangMuc = e.TenHangMuc,
                    QuyMoHangMuc = e.QuyMoHangMuc,
                    TongMucDauTu = e.TongMucDauTu
                })
                .ToList();
            if (toAdd.Count > 0)
                QuyetDinhDuyetDuAnHangMuc.BulkInsert(toAdd);

            // Xóa bỏ
            var toRemove = existing
                .Where(e => !requestIds.Contains(e.Id))
                .ToList();
            if (toRemove.Count > 0)
                QuyetDinhDuyetDuAnHangMuc.BulkDelete(toRemove);

            // Cập nhật
            var toUpdate = existing
                .Where(e => requestIds.Contains(e.Id))
                .ToList();
            if (toUpdate.Count > 0) {
                var updates = toUpdate
                    .Select(item => {
                        var value = requestObjs.First(e => e.Id == item.Id);
                        item.TenHangMuc = value.TenHangMuc;
                        item.QuyMoHangMuc = value.QuyMoHangMuc;
                        item.TongMucDauTu = value.TongMucDauTu;

                        return item;
                    })
                    .ToList();

                QuyetDinhDuyetDuAnHangMuc.BulkUpdate(updates,
                    e => new { e.TenHangMuc, e.QuyMoHangMuc, e.TongMucDauTu });
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        } catch (Exception ex) {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
}