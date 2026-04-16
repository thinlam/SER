using System.Data;
using Microsoft.Extensions.Logging;

namespace QLDA.Application.PhuLucHopDongs.Commands;

public record PhuLucHopDongInsertOrUpdateCommand(PhuLucHopDong Entity) : IRequest {
}

internal class PhuLucHopDongInsertOrUpdateCommandHandler : IRequestHandler<PhuLucHopDongInsertOrUpdateCommand> {
    private readonly IRepository<PhuLucHopDong, Guid> PhuLucHopDong;
    private readonly IRepository<DuAn, Guid> DuAn;
    private readonly IRepository<DanhMucBuoc, int> DanhMucBuoc;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<PhuLucHopDongInsertOrUpdateCommandHandler> _logger;

    public PhuLucHopDongInsertOrUpdateCommandHandler(IServiceProvider serviceProvider,
        ILogger<PhuLucHopDongInsertOrUpdateCommandHandler> logger) {
        PhuLucHopDong = serviceProvider.GetRequiredService<IRepository<PhuLucHopDong, Guid>>();
        DuAn = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        DanhMucBuoc = serviceProvider.GetRequiredService<IRepository<DanhMucBuoc, int>>();
        _logger = logger;
        _unitOfWork = PhuLucHopDong.UnitOfWork;
    }

    public async Task Handle(PhuLucHopDongInsertOrUpdateCommand request, CancellationToken cancellationToken = default) {
        try {
            ManagedException.ThrowIf(!DuAn.GetQueryableSet().Any(e => e.Id == request.Entity.DuAnId),
                "Không tồn tại dự án");

            using (await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken)) {
                var isExist = PhuLucHopDong.GetQueryableSet().Any(o => o.Id == request.Entity.Id);
                if (isExist) {
                    await PhuLucHopDong.UpdateAsync(request.Entity, cancellationToken);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                } else {
                    //Thêm dự án trước
                    await PhuLucHopDong.AddAsync(request.Entity, cancellationToken);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                }

                //Cập nhật quy trình
                await _unitOfWork.CommitTransactionAsync(cancellationToken);
            }
        } catch (Exception ex) {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
}