using System.Data;
using Microsoft.Extensions.Logging;

namespace QLDA.Application.BaoCaoBaoHanhSanPhams.Commands;

public record BaoCaoBaoHanhSanPhamInsertOrUpdateCommand(BaoCaoBaoHanhSanPham Entity) : IRequest {
}

internal class
    BaoCaoBaoHanhSanPhamInsertOrUpdateCommandHandler : IRequestHandler<BaoCaoBaoHanhSanPhamInsertOrUpdateCommand> {
    private readonly IRepository<BaoCaoBaoHanhSanPham, Guid> BaoCaoBaoHanhSanPham;
    private readonly IRepository<DuAn, Guid> DuAn;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<BaoCaoBaoHanhSanPhamInsertOrUpdateCommandHandler> _logger;

    public BaoCaoBaoHanhSanPhamInsertOrUpdateCommandHandler(IServiceProvider serviceProvider,
        ILogger<BaoCaoBaoHanhSanPhamInsertOrUpdateCommandHandler> logger) {
        BaoCaoBaoHanhSanPham = serviceProvider.GetRequiredService<IRepository<BaoCaoBaoHanhSanPham, Guid>>();
        DuAn = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        _logger = logger;
        _unitOfWork = BaoCaoBaoHanhSanPham.UnitOfWork;
    }

    public async Task Handle(BaoCaoBaoHanhSanPhamInsertOrUpdateCommand request,
        CancellationToken cancellationToken = default) {
        try {
            ManagedException.ThrowIf(!DuAn.GetQueryableSet().Any(e => e.Id == request.Entity.DuAnId),
                "Không tồn tại dự án");

            using (await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken)) {
                var isExist = BaoCaoBaoHanhSanPham.GetQueryableSet().Any(o => o.Id == request.Entity.Id);
                if (isExist) {
                    await BaoCaoBaoHanhSanPham.UpdateAsync(request.Entity, cancellationToken);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                } else {
                    //Thêm dự án trước
                    await BaoCaoBaoHanhSanPham.AddAsync(request.Entity, cancellationToken);
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