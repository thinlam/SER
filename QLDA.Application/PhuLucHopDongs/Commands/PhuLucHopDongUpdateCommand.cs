using System.Data;
using Microsoft.Extensions.Logging;
using QLDA.Application.PhuLucHopDongs.DTOs;

namespace QLDA.Application.PhuLucHopDongs.Commands;

public record PhuLucHopDongUpdateCommand(PhuLucHopDongUpdateDto Dto) : IRequest<PhuLucHopDong>;

internal class PhuLucHopDongUpdateCommandHandler : IRequestHandler<PhuLucHopDongUpdateCommand, PhuLucHopDong> {
    private readonly IRepository<PhuLucHopDong, Guid> PhuLucHopDong;
    private readonly IRepository<DuAn, Guid> DuAn;
    private readonly IRepository<DanhMucBuoc, int> DanhMucBuoc;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<PhuLucHopDongUpdateCommandHandler> _logger;

    public PhuLucHopDongUpdateCommandHandler(IServiceProvider serviceProvider,
        ILogger<PhuLucHopDongUpdateCommandHandler> logger) {
        PhuLucHopDong = serviceProvider.GetRequiredService<IRepository<PhuLucHopDong, Guid>>();
        DuAn = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        DanhMucBuoc = serviceProvider.GetRequiredService<IRepository<DanhMucBuoc, int>>();
        _logger = logger;
        _unitOfWork = PhuLucHopDong.UnitOfWork;
    }

    public async Task<PhuLucHopDong> Handle(PhuLucHopDongUpdateCommand request, CancellationToken cancellationToken = default) {
        try {
            var entity = request.Dto.ToEntity();

            using (await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken)) {
                await PhuLucHopDong.UpdateAsync(entity, cancellationToken);
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