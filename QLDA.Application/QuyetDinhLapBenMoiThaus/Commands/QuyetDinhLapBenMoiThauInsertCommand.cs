using System.Data;
using Microsoft.Extensions.Logging;
using QLDA.Application.QuyetDinhLapBenMoiThaus.DTOs;

namespace QLDA.Application.QuyetDinhLapBenMoiThaus.Commands;

public record QuyetDinhLapBenMoiThauInsertCommand(QuyetDinhLapBenMoiThauInsertDto Dto) : IRequest<QuyetDinhLapBenMoiThau>;

internal class QuyetDinhLapBenMoiThauInsertCommandHandler : IRequestHandler<QuyetDinhLapBenMoiThauInsertCommand, QuyetDinhLapBenMoiThau> {
    private readonly IRepository<QuyetDinhLapBenMoiThau, Guid> QuyetDinhLapBenMoiThau;
    private readonly IRepository<DuAn, Guid> DuAn;
    private readonly IRepository<DanhMucBuoc, int> DanhMucBuoc;
    private readonly IUnitOfWork UnitOfWork;
    private readonly ILogger<QuyetDinhLapBenMoiThauInsertCommandHandler> Logger;

    public QuyetDinhLapBenMoiThauInsertCommandHandler(IServiceProvider serviceProvider,
        ILogger<QuyetDinhLapBenMoiThauInsertCommandHandler> logger) {
        QuyetDinhLapBenMoiThau = serviceProvider.GetRequiredService<IRepository<QuyetDinhLapBenMoiThau, Guid>>();
        DuAn = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        DanhMucBuoc = serviceProvider.GetRequiredService<IRepository<DanhMucBuoc, int>>();
        Logger = logger;
        UnitOfWork = QuyetDinhLapBenMoiThau.UnitOfWork;
    }

    public async Task<QuyetDinhLapBenMoiThau> Handle(QuyetDinhLapBenMoiThauInsertCommand request, CancellationToken cancellationToken = default) {
        try {
            ManagedException.ThrowIf(!DuAn.GetQueryableSet().Any(e => e.Id == request.Dto.DuAnId),
                "Không tồn tại dự án");

            var entity = request.Dto.ToEntity();

            using (await UnitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken)) {
                await QuyetDinhLapBenMoiThau.AddAsync(entity, cancellationToken);
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