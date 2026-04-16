using System.Data;
using Microsoft.Extensions.Logging;
using QLDA.Application.QuyetDinhLapBanQLDAs.DTOs;

namespace QLDA.Application.QuyetDinhLapBanQLDAs.Commands;

public record QuyetDinhLapBanQldaInsertCommand(QuyetDinhLapBanQldaInsertDto Dto) : IRequest<QuyetDinhLapBanQLDA>;

internal class QuyetDinhLapBanQldaInsertCommandHandler : IRequestHandler<QuyetDinhLapBanQldaInsertCommand, QuyetDinhLapBanQLDA> {
    private readonly IRepository<QuyetDinhLapBanQLDA, Guid> QuyetDinhLapBanQLDA;
    private readonly IRepository<ThanhVienBanQLDA, int> ThanhVienBanQLDA;
    private readonly IRepository<DuAn, Guid> DuAn;
    private readonly IRepository<DanhMucBuoc, int> DanhMucBuoc;
    private readonly IUnitOfWork UnitOfWork;
    private readonly ILogger<QuyetDinhLapBanQldaInsertCommandHandler> Logger;

    public QuyetDinhLapBanQldaInsertCommandHandler(IServiceProvider serviceProvider,
        ILogger<QuyetDinhLapBanQldaInsertCommandHandler> logger) {
        QuyetDinhLapBanQLDA = serviceProvider.GetRequiredService<IRepository<QuyetDinhLapBanQLDA, Guid>>();
        ThanhVienBanQLDA = serviceProvider.GetRequiredService<IRepository<ThanhVienBanQLDA, int>>();
        DuAn = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        DanhMucBuoc = serviceProvider.GetRequiredService<IRepository<DanhMucBuoc, int>>();
        Logger = logger;
        UnitOfWork = QuyetDinhLapBanQLDA.UnitOfWork;
    }

    public async Task<QuyetDinhLapBanQLDA> Handle(QuyetDinhLapBanQldaInsertCommand request, CancellationToken cancellationToken = default) {
        try {
            ManagedException.ThrowIf(!DuAn.GetQueryableSet().Any(e => e.Id == request.Dto.DuAnId),
                "Không tồn tại dự án");

            var entity = request.Dto.ToEntity();

            using (await UnitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken)) {
                await QuyetDinhLapBanQLDA.AddAsync(entity, cancellationToken);
                await UnitOfWork.SaveChangesAsync(cancellationToken);

                // Handle ThanhVienBanQlda
                if (entity.ThanhViens != null && entity.ThanhViens.Count > 0) {
                    foreach (var tv in entity.ThanhViens) {
                        tv.QuyetDinhId = entity.Id;
                    }
                    ThanhVienBanQLDA.BulkInsert(entity.ThanhViens);
                }

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