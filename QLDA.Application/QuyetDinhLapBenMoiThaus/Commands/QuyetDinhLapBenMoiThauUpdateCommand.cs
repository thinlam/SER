using System.Data;
using Microsoft.Extensions.Logging;
using QLDA.Application.QuyetDinhLapBenMoiThaus.DTOs;

namespace QLDA.Application.QuyetDinhLapBenMoiThaus.Commands;

public record QuyetDinhLapBenMoiThauUpdateCommand(QuyetDinhLapBenMoiThauUpdateDto Dto) : IRequest<QuyetDinhLapBenMoiThau>;

internal class QuyetDinhLapBenMoiThauUpdateCommandHandler : IRequestHandler<QuyetDinhLapBenMoiThauUpdateCommand, QuyetDinhLapBenMoiThau> {
    private readonly IRepository<QuyetDinhLapBenMoiThau, Guid> QuyetDinhLapBenMoiThau;
    private readonly IRepository<DuAn, Guid> DuAn;
    private readonly IRepository<DanhMucBuoc, int> DanhMucBuoc;
    private readonly IUnitOfWork UnitOfWork;
    private readonly ILogger<QuyetDinhLapBenMoiThauUpdateCommandHandler> Logger;

    public QuyetDinhLapBenMoiThauUpdateCommandHandler(IServiceProvider serviceProvider,
        ILogger<QuyetDinhLapBenMoiThauUpdateCommandHandler> logger) {
        QuyetDinhLapBenMoiThau = serviceProvider.GetRequiredService<IRepository<QuyetDinhLapBenMoiThau, Guid>>();
        DuAn = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        DanhMucBuoc = serviceProvider.GetRequiredService<IRepository<DanhMucBuoc, int>>();
        Logger = logger;
        UnitOfWork = QuyetDinhLapBenMoiThau.UnitOfWork;
    }

    public async Task<QuyetDinhLapBenMoiThau> Handle(QuyetDinhLapBenMoiThauUpdateCommand request, CancellationToken cancellationToken = default) {
        try {
            var entity = request.Dto.ToEntity();

            using (await UnitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken)) {
                await QuyetDinhLapBenMoiThau.UpdateAsync(entity, cancellationToken);
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