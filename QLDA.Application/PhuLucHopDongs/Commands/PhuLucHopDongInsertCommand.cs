using System.Data;
using Microsoft.Extensions.Logging;
using QLDA.Application.PhuLucHopDongs.DTOs;

namespace QLDA.Application.PhuLucHopDongs.Commands;

public record PhuLucHopDongInsertCommand(PhuLucHopDongInsertDto Dto) : IRequest<PhuLucHopDong>;

internal class PhuLucHopDongInsertCommandHandler : IRequestHandler<PhuLucHopDongInsertCommand, PhuLucHopDong> {
    private readonly IRepository<PhuLucHopDong, Guid> PhuLucHopDong;
    private readonly IRepository<DuAn, Guid> DuAn;
    private readonly IRepository<DanhMucBuoc, int> DanhMucBuoc;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<PhuLucHopDongInsertCommandHandler> _logger;

    public PhuLucHopDongInsertCommandHandler(IServiceProvider serviceProvider,
        ILogger<PhuLucHopDongInsertCommandHandler> logger) {
        PhuLucHopDong = serviceProvider.GetRequiredService<IRepository<PhuLucHopDong, Guid>>();
        DuAn = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        DanhMucBuoc = serviceProvider.GetRequiredService<IRepository<DanhMucBuoc, int>>();
        _logger = logger;
        _unitOfWork = PhuLucHopDong.UnitOfWork;
    }

    public async Task<PhuLucHopDong> Handle(PhuLucHopDongInsertCommand request, CancellationToken cancellationToken = default) {
        try {
            ManagedException.ThrowIf(!DuAn.GetQueryableSet().Any(e => e.Id == request.Dto.DuAnId),
                "Không tồn tại dự án");

            var entity = request.Dto.ToEntity();

            using (await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken)) {
                await PhuLucHopDong.AddAsync(entity, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                await _unitOfWork.CommitTransactionAsync(cancellationToken);
            }

            return entity;
        } catch (Exception ex) {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
}