using System.Data;
using Microsoft.Extensions.Logging;

namespace QLDA.Application.BaoCaoTienDos.Commands;

public record BaoCaoTienDoInsertOrUpdateCommand(BaoCaoTienDo Entity) : IRequest {
}

internal class BaoCaoTienDoInsertOrUpdateCommandHandler : IRequestHandler<BaoCaoTienDoInsertOrUpdateCommand> {
    private readonly IRepository<BaoCaoTienDo, Guid> BaoCaoTienDo;
    private readonly IRepository<DuAn, Guid> DuAn;
    private readonly IRepository<DanhMucBuoc, int> DanhMucBuoc;
    private readonly IRepository<DanhMucLoaiVanBan, int> DanhMucLoaiVanBan;
    private readonly IRepository<DanhMucChuDauTu, int> DanhMucChuDauTu;
    private readonly IRepository<DanhMucChucVu, int> DanhMucChucVu;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<BaoCaoTienDoInsertOrUpdateCommandHandler> _logger;

    public BaoCaoTienDoInsertOrUpdateCommandHandler(IServiceProvider serviceProvider,
        ILogger<BaoCaoTienDoInsertOrUpdateCommandHandler> logger) {
        BaoCaoTienDo = serviceProvider.GetRequiredService<IRepository<BaoCaoTienDo, Guid>>();
        DuAn = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        DanhMucBuoc = serviceProvider.GetRequiredService<IRepository<DanhMucBuoc, int>>();
        DanhMucLoaiVanBan = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiVanBan, int>>();
        DanhMucChuDauTu = serviceProvider.GetRequiredService<IRepository<DanhMucChuDauTu, int>>();
        DanhMucChucVu = serviceProvider.GetRequiredService<IRepository<DanhMucChucVu, int>>();
        _logger = logger;
        _unitOfWork = BaoCaoTienDo.UnitOfWork;
    }

    public async Task Handle(BaoCaoTienDoInsertOrUpdateCommand request, CancellationToken cancellationToken = default) {
        try {
            ManagedException.ThrowIf(!DuAn.GetQueryableSet().Any(e => e.Id == request.Entity.DuAnId),
                "Không tồn tại dự án");

            using (await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken)) {
                var isExist = BaoCaoTienDo.GetQueryableSet().Any(o => o.Id == request.Entity.Id);
                if (isExist) {
                    await BaoCaoTienDo.UpdateAsync(request.Entity, cancellationToken);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                } else {
                    //Thêm dự án trước
                    await BaoCaoTienDo.AddAsync(request.Entity, cancellationToken);
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