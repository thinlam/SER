using System.Data;
using Microsoft.Extensions.Logging;

namespace QLDA.Application.GoiThaus.Commands;

public record GoiThauInsertOrUpdateCommand(GoiThau Entity) : IRequest {
}

internal class GoiThauInsertOrUpdateCommandHandler : IRequestHandler<GoiThauInsertOrUpdateCommand> {
    private readonly IRepository<GoiThau, Guid> GoiThau;
    private readonly IRepository<DuAn, Guid> DuAn;
    private readonly IRepository<DanhMucBuoc, int> DanhMucBuoc;
    private readonly IRepository<DanhMucLoaiGoiThau, int> DanhMucLoaiGoiThau;
    private readonly IRepository<DanhMucPhuongThucLuaChonNhaThau, int> DanhMucPhuongThucLuaChonNhaThau;
    private readonly IRepository<DanhMucHinhThucLuaChonNhaThau, int> DanhMucHinhThucLuaChonNhaThau;
    private readonly IRepository<DanhMucLoaiHopDong, int> DanhMucLoaiHopDong;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<GoiThauInsertOrUpdateCommandHandler> _logger;

    public GoiThauInsertOrUpdateCommandHandler(IServiceProvider serviceProvider,
        ILogger<GoiThauInsertOrUpdateCommandHandler> logger) {
        GoiThau = serviceProvider.GetRequiredService<IRepository<GoiThau, Guid>>();
        DuAn = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        DanhMucBuoc = serviceProvider.GetRequiredService<IRepository<DanhMucBuoc, int>>();
        DanhMucLoaiGoiThau = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiGoiThau, int>>();
        DanhMucPhuongThucLuaChonNhaThau =
            serviceProvider.GetRequiredService<IRepository<DanhMucPhuongThucLuaChonNhaThau, int>>();
        DanhMucHinhThucLuaChonNhaThau = serviceProvider.GetRequiredService<IRepository<DanhMucHinhThucLuaChonNhaThau, int>>();
        DanhMucLoaiHopDong = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiHopDong, int>>();
        _logger = logger;
        _unitOfWork = GoiThau.UnitOfWork;
    }

    public async Task Handle(GoiThauInsertOrUpdateCommand request, CancellationToken cancellationToken = default) {
        try {
            ManagedException.ThrowIf(!DuAn.GetQueryableSet().Any(e => e.Id == request.Entity.DuAnId),
                "Không tồn tại dự án");
            ManagedException.ThrowIf(
                request.Entity.LoaiHopDongId > 0 && !DanhMucLoaiHopDong.GetQueryableSet()
                    .Any(e => e.Id == request.Entity.LoaiHopDongId),
                "Không tồn tại loại gói thầu này");
            ManagedException.ThrowIf(
                request.Entity.HinhThucLuaChonNhaThauId > 0 && !DanhMucHinhThucLuaChonNhaThau.GetQueryableSet()
                    .Any(e => e.Id == request.Entity.HinhThucLuaChonNhaThauId),
                "Không tồn tại hình thức chọn gói thầu này");
            ManagedException.ThrowIf(
                request.Entity.PhuongThucLuaChonNhaThauId > 0 && !DanhMucPhuongThucLuaChonNhaThau.GetQueryableSet()
                    .Any(e => e.Id == request.Entity.PhuongThucLuaChonNhaThauId),
                "Không tồn tại phương thức chọn gói thầu này");
            // ManagedException.ThrowIf(
            //     !DuAnNguonVon.GetQueryableSet().Any(e =>
            //         e.DuAnId == request.Entity.DuAnId && e.NguonVonId == request.Entity.NguonVonId),
            //     "Nguồn vốn phải thuộc dự án");

            using (await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken)) {
                var isExist = GoiThau.GetQueryableSet().Any(o => o.Id == request.Entity.Id);
                if (isExist) {
                    await GoiThau.UpdateAsync(request.Entity, cancellationToken);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                } else {
                    //Thêm dự án trước
                    request.Entity.DaDuyet = true;
                    await GoiThau.AddAsync(request.Entity, cancellationToken);
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