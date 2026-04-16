using System.Data;
using Microsoft.EntityFrameworkCore;
using QLDA.Application.ThanhToans.DTOs;

namespace QLDA.Application.ThanhToans.Commands;

public record ThanhToanUpdateCommand(ThanhToanUpdateDto Dto) : IRequest<ThanhToan> {
    public List<Guid> NghiemThuIds { get; set; } = [];
}

internal class ThanhToanUpdateCommandHandler : IRequestHandler<ThanhToanUpdateCommand, ThanhToan> {
    private readonly IRepository<ThanhToan, Guid> ThanhToan;
    private readonly IRepository<DuAn, Guid> DuAn;
    private readonly IUnitOfWork _unitOfWork;
    private readonly Serilog.ILogger _logger = Serilog.Log.ForContext<ThanhToanUpdateCommandHandler>();

    public ThanhToanUpdateCommandHandler(IServiceProvider serviceProvider) {
        ThanhToan = serviceProvider.GetRequiredService<IRepository<ThanhToan, Guid>>();
        DuAn = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        _unitOfWork = ThanhToan.UnitOfWork;
    }

    public async Task<ThanhToan> Handle(ThanhToanUpdateCommand request, CancellationToken cancellationToken = default) {
        await ValidateAsync(request, cancellationToken);

        var entity = await ThanhToan.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Dto.Id, cancellationToken);
        ManagedException.ThrowIfNull(entity);

        entity.Update(request.Dto);

        if (_unitOfWork.HasTransaction) {
            await UpdateAsync(entity, cancellationToken);
        } else {
            using var tx = await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
            await UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        return entity;
    }
    #region  Private helper methods

    private async Task ValidateAsync(ThanhToanUpdateCommand request, CancellationToken cancellationToken) {
        ManagedException.ThrowIf(
            when: await ThanhToan.GetQueryableSet().AnyAsync(e => e.Id != request.Dto.Id && e.SoHoaDon!.ToLower() == request.Dto.SoHoaDon!.ToLower(), cancellationToken: cancellationToken),
            message: "Số hóa đơn đã tồn tại"
        );
    }
    private async Task UpdateAsync(ThanhToan entity, CancellationToken cancellationToken) {
        await ThanhToan.UpdateAsync(entity, cancellationToken);
    }

    #endregion
}