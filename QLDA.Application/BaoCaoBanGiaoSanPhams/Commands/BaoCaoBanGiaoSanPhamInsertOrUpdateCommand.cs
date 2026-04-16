using System.Data;
using Microsoft.Extensions.Logging;

namespace QLDA.Application.BaoCaoBanGiaoSanPhams.Commands;

public record BaoCaoBanGiaoSanPhamInsertOrUpdateCommand(BaoCaoBanGiaoSanPham Entity) : IRequest {
}

internal class
    BaoCaoBanGiaoSanPhamInsertOrUpdateCommandHandler : IRequestHandler<BaoCaoBanGiaoSanPhamInsertOrUpdateCommand> {
    private readonly IRepository<BaoCaoBanGiaoSanPham, Guid> BaoCaoBanGiaoSanPham;
    private readonly IRepository<DuAn, Guid> DuAn;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<BaoCaoBanGiaoSanPhamInsertOrUpdateCommandHandler> _logger;

    public BaoCaoBanGiaoSanPhamInsertOrUpdateCommandHandler(IServiceProvider serviceProvider,
        ILogger<BaoCaoBanGiaoSanPhamInsertOrUpdateCommandHandler> logger) {
        BaoCaoBanGiaoSanPham = serviceProvider.GetRequiredService<IRepository<BaoCaoBanGiaoSanPham, Guid>>();
        DuAn = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        _logger = logger;
        _unitOfWork = BaoCaoBanGiaoSanPham.UnitOfWork;
    }

    public async Task Handle(BaoCaoBanGiaoSanPhamInsertOrUpdateCommand request,
        CancellationToken cancellationToken = default) {
        try {
            ManagedException.ThrowIf(!DuAn.GetQueryableSet().Any(e => e.Id == request.Entity.DuAnId),
                "Không tồn tại dự án");

            using (await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken)) {
                var isExist = BaoCaoBanGiaoSanPham.GetQueryableSet().Any(o => o.Id == request.Entity.Id);
                if (isExist) {
                    await BaoCaoBanGiaoSanPham.UpdateAsync(request.Entity, cancellationToken);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                } else {
                    //Thêm dự án trước
                    await BaoCaoBanGiaoSanPham.AddAsync(request.Entity, cancellationToken);
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