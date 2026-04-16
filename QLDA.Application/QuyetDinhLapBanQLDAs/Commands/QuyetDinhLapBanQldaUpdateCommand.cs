using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QLDA.Application.QuyetDinhLapBanQLDAs.DTOs;

namespace QLDA.Application.QuyetDinhLapBanQLDAs.Commands;

public record QuyetDinhLapBanQldaUpdateCommand(QuyetDinhLapBanQldaUpdateDto Dto) : IRequest<QuyetDinhLapBanQLDA>;

internal class QuyetDinhLapBanQldaUpdateCommandHandler : IRequestHandler<QuyetDinhLapBanQldaUpdateCommand, QuyetDinhLapBanQLDA> {
    private readonly IRepository<QuyetDinhLapBanQLDA, Guid> QuyetDinhLapBanQLDA;
    private readonly IRepository<ThanhVienBanQLDA, int> ThanhVienBanQLDA;
    private readonly IRepository<DuAn, Guid> DuAn;
    private readonly IRepository<DanhMucBuoc, int> DanhMucBuoc;
    private readonly IUnitOfWork UnitOfWork;
    private readonly ILogger<QuyetDinhLapBanQldaUpdateCommandHandler> Logger;

    public QuyetDinhLapBanQldaUpdateCommandHandler(IServiceProvider serviceProvider,
        ILogger<QuyetDinhLapBanQldaUpdateCommandHandler> logger) {
        QuyetDinhLapBanQLDA = serviceProvider.GetRequiredService<IRepository<QuyetDinhLapBanQLDA, Guid>>();
        ThanhVienBanQLDA = serviceProvider.GetRequiredService<IRepository<ThanhVienBanQLDA, int>>();
        DuAn = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        DanhMucBuoc = serviceProvider.GetRequiredService<IRepository<DanhMucBuoc, int>>();
        Logger = logger;
        UnitOfWork = QuyetDinhLapBanQLDA.UnitOfWork;
    }

    public async Task<QuyetDinhLapBanQLDA> Handle(QuyetDinhLapBanQldaUpdateCommand request, CancellationToken cancellationToken = default) {
        try {
            var entity = request.Dto.ToEntity();

            using (await UnitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken)) {
                await HandleThanhVien(entity, cancellationToken);
                await QuyetDinhLapBanQLDA.UpdateAsync(entity, cancellationToken);
                await UnitOfWork.SaveChangesAsync(cancellationToken);
                await UnitOfWork.CommitTransactionAsync(cancellationToken);
            }

            return entity;
        } catch (Exception ex) {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    private async Task HandleThanhVien(QuyetDinhLapBanQLDA entity, CancellationToken cancellationToken = default) {
        var requestObjs = entity.ThanhViens.ToList();
        entity.ThanhViens = [];

        // Lấy existing từ DB
        var existing = await ThanhVienBanQLDA.GetQueryableSet()
            .AsNoTracking()
            .Where(e => e.QuyetDinhId == entity.Id)
            .ToListAsync(cancellationToken);

        var newIds = requestObjs.Select(e => e.Id).ToList();
        var existingIds = existing.Select(e => e.Id).ToHashSet();

        // Thêm mới
        var toAdd = requestObjs
            .Where(e => !existingIds.Contains(e.Id))
            .Select(e => new ThanhVienBanQLDA {
                Id = e.Id,
                QuyetDinhId = entity.Id,
                Ten = e.Ten,
                ChucVu = e.ChucVu,
                VaiTro = e.VaiTro,
            })
            .ToList();
        if (toAdd.Count > 0)
            ThanhVienBanQLDA.BulkInsert(toAdd);

        // Xóa bỏ
        var toRemove = existing
            .Where(e => !newIds.Contains(e.Id))
            .ToList();
        if (toRemove.Count > 0)
            ThanhVienBanQLDA.BulkDelete(toRemove);

        // Cập nhật
        var toUpdate = existing
            .Where(e => newIds.Contains(e.Id))
            .ToList();
        if (toUpdate.Count > 0) {
            var updates = toUpdate
                .Select(item => {
                    var newData = requestObjs.First(e => e.Id == item.Id);
                    item.Ten = newData.Ten;
                    item.ChucVu = newData.ChucVu;
                    item.VaiTro = newData.VaiTro;
                    return item;
                })
                .ToList();

            ThanhVienBanQLDA.BulkUpdate(updates, e => new { e.Ten, e.VaiTro, e.ChucVu });
        }
    }
}