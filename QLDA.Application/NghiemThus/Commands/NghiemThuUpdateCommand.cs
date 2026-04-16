using System.Data;
using Microsoft.EntityFrameworkCore;
using QLDA.Application.NghiemThus.DTOs;

namespace QLDA.Application.NghiemThus.Commands;

public record NghiemThuUpdateCommand(NghiemThuUpdateDto Dto, List<Guid>? PhuLucHopDongIds = null) : IRequest<NghiemThu>;

internal class NghiemThuUpdateCommandHandler : IRequestHandler<NghiemThuUpdateCommand, NghiemThu> {
    private readonly IRepository<NghiemThu, Guid> NghiemThu;
    private readonly IRepository<HopDong, Guid> HopDong;
    private readonly IUnitOfWork _unitOfWork;
    private readonly Serilog.ILogger _logger = Serilog.Log.ForContext<NghiemThuUpdateCommandHandler>();

    public NghiemThuUpdateCommandHandler(IServiceProvider serviceProvider) {
        NghiemThu = serviceProvider.GetRequiredService<IRepository<NghiemThu, Guid>>();
        HopDong = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
        _unitOfWork = NghiemThu.UnitOfWork;
    }

    public async Task<NghiemThu> Handle(NghiemThuUpdateCommand request, CancellationToken cancellationToken = default) {
        await ValidateAsync(request, cancellationToken);

        var entity = await NghiemThu.GetQueryableSet()
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

    private async Task ValidateAsync(NghiemThuUpdateCommand request, CancellationToken cancellationToken) {

        ManagedException.ThrowIf(
            when: !await HopDong.GetQueryableSet().AnyAsync(e => e.Id == request.Dto.HopDongId, cancellationToken),
            message: "Không tồn tại hợp đồng"
        );
        var query = NghiemThu.GetQueryableSet()
           .Where(e => e.HopDongId == request.Dto.HopDongId);

        ManagedException.ThrowIf(
             when: request.Dto.SoBienBan.IsNotNullOrWhitespace() && await query.AnyAsync(e => e.Id != request.Dto.Id && e.SoBienBan!.ToLower() == request.Dto.SoBienBan!.ToLower(), cancellationToken),
             message: "Số biên bản đã tồn tại"
         );

        ManagedException.ThrowIf(
            when: await query.AnyAsync(e => e.Id != request.Dto.Id && e.Dot!.ToLower() == request.Dto.Dot!.ToLower(), cancellationToken),
            message: "Đợt nghiệm thu đã tồn tại"
        );

    }
    private async Task UpdateAsync(NghiemThu entity, CancellationToken cancellationToken) {
        await NghiemThu.UpdateAsync(entity, cancellationToken);
    }

    #endregion
}