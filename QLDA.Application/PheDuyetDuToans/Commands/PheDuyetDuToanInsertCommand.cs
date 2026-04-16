using System.Data;
using Microsoft.Extensions.Logging;
using QLDA.Application.PheDuyetDuToans.DTOs;

namespace QLDA.Application.PheDuyetDuToans.Commands;

public record PheDuyetDuToanInsertCommand(PheDuyetDuToanInsertDto Dto) : IRequest<PheDuyetDuToan>;

internal class PheDuyetDuToanInsertCommandHandler : IRequestHandler<PheDuyetDuToanInsertCommand, PheDuyetDuToan> {
    private readonly IRepository<PheDuyetDuToan, Guid> PheDuyetDuToan;
    private readonly IRepository<DuAn, Guid> DuAn;
    private readonly IRepository<DanhMucBuoc, int> DanhMucBuoc;
    private readonly IRepository<DanhMucChucVu, int> DanhMucChucVu;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<PheDuyetDuToanInsertCommandHandler> _logger;

    public PheDuyetDuToanInsertCommandHandler(IServiceProvider serviceProvider,
        ILogger<PheDuyetDuToanInsertCommandHandler> logger) {
        PheDuyetDuToan = serviceProvider.GetRequiredService<IRepository<PheDuyetDuToan, Guid>>();
        DuAn = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        DanhMucBuoc = serviceProvider.GetRequiredService<IRepository<DanhMucBuoc, int>>();
        DanhMucChucVu = serviceProvider.GetRequiredService<IRepository<DanhMucChucVu, int>>();
        _logger = logger;
        _unitOfWork = PheDuyetDuToan.UnitOfWork;
    }

    public async Task<PheDuyetDuToan> Handle(PheDuyetDuToanInsertCommand request, CancellationToken cancellationToken = default) {
        try {
            ManagedException.ThrowIf(!DuAn.GetQueryableSet().Any(e => e.Id == request.Dto.DuAnId),
                "Không tồn tại dự án");
            ManagedException.ThrowIf(
                request.Dto.ChucVuId > 0 &&
                !DanhMucChucVu.GetQueryableSet().Any(e => e.Id == request.Dto.ChucVuId),
                "Không tồn tại chức vụ này");

            var entity = request.Dto.ToEntity();

            using (await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken)) {
                await PheDuyetDuToan.AddAsync(entity, cancellationToken);
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