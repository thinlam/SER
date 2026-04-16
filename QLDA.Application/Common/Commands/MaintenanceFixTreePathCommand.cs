
using System.Data;
using Microsoft.EntityFrameworkCore;
using QLDA.Domain.Enums;

namespace QLDA.Application.Common.Commands;

/// <summary>
/// Mục đích tối thượng của lệnh này là reset lại path của tree đã bị làm sai <br/>
/// Tại thời điểm viết hàm này lỗi nó là : Child.Id: 2, Child.ParentId: 1, Parent.Path: /1/ => Child.Path: /1/1/ (đúng phải là /1/2/)
/// </summary>
/// <param name="QuyTrinhId"></param>
public record MaintenanceFixTreePathCommand(int? QuyTrinhId = null, List<EMaterializedPathEntity>? Types = null) : IRequest {

}

internal class MaintenanceFixTreePathCommandHandler : IRequestHandler<MaintenanceFixTreePathCommand> {

    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<DanhMucBuoc, int> _danhMucBuoc;
    private readonly IRepository<DuAn, Guid> _duAn;
    private readonly Serilog.ILogger _logger = Serilog.Log.ForContext<MaintenanceFixTreePathCommandHandler>();

    public MaintenanceFixTreePathCommandHandler(IServiceProvider serviceProvider) {
        _danhMucBuoc = serviceProvider.GetRequiredService<IRepository<DanhMucBuoc, int>>();
        _duAn = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        _unitOfWork = _danhMucBuoc.UnitOfWork;
    }

    public async Task Handle(MaintenanceFixTreePathCommand request, CancellationToken cancellationToken) {
        await ValidateAsync(request, cancellationToken);
        if (_unitOfWork.HasTransaction) {
            await RebuildAsync(request, cancellationToken);
        } else {
            using var tx = await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
            await RebuildAsync(request, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }

    }

    #region Private helper methods
    private async Task ValidateAsync(MaintenanceFixTreePathCommand request, CancellationToken cancellationToken = default) {
        ManagedException.ThrowIf(
            when: request.QuyTrinhId.HasValue && !await _danhMucBuoc.GetQueryableSet().AnyAsync(e => e.QuyTrinh!.Id == request.QuyTrinhId, cancellationToken),
            message: "Quy trình không tồn tại!"
        );
    }
    private async Task RebuildAsync(MaintenanceFixTreePathCommand request, CancellationToken cancellationToken) {
        if (request.Types?.Contains(EMaterializedPathEntity.DanhMucBuoc) ?? false) {
            var danhMucBuocs = await _danhMucBuoc.GetOrderedSet()
                    .Where(e => !e.IsDeleted)
                    .WhereIf(request.QuyTrinhId.HasValue, e => e.QuyTrinh!.Id == request.QuyTrinhId)
                    .ToListAsync(cancellationToken);

            _danhMucBuoc.ResetMaterializedPathsInMemory(
                danhMucBuocs,
                getId: x => x.Id,
                getParentId: x => x.ParentId ?? 0,
                setPath: (x, path) => x.Path = path,
                setLevel: (x, level) => x.Level = level,
                setParentId: (x, pid) => x.ParentId = pid
            );
        }

        if (request.Types?.Contains(EMaterializedPathEntity.DuAn) ?? false) {
            var duAns = await _duAn.GetOrderedSet()
                        .Where(e => !e.IsDeleted)
                        .WhereIf(request.QuyTrinhId.HasValue, e => e.QuyTrinh!.Id == request.QuyTrinhId)
                        .ToListAsync(cancellationToken);

            _duAn.ResetMaterializedPathsInMemory(
                duAns,
                getId: x => x.Id,
                getParentId: x => x.ParentId ?? Guid.Empty,
                setPath: (x, path) => x.Path = path,
                setLevel: (x, level) => x.Level = level,
                setParentId: (x, pid) => x.ParentId = pid
            );
        }
    }
    #endregion
}