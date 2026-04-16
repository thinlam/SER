using QLHD.Application.XuatHoaDons.DTOs;
namespace QLHD.Application.XuatHoaDons.Commands;

/// <summary>
/// Command thêm mới/cập nhật xuất hóa đơn (unified routing).
/// <para>
/// DuAn và HopDong thực chất là 1 thực thể kinh doanh (DuAn = Kế hoạch, HopDong = Thực tế).
/// Routing logic dựa trên DuAnId của HopDong:
///   - DuAnId có giá trị → prefix "DuAn_" → lưu vào DuAn_XuatHoaDon (theo kế hoạch/DuAn)
///   - DuAnId null → prefix "HopDong_" → lưu vào HopDong_XuatHoaDon (hợp đồng độc lập)
/// </para>
/// </summary>
public record XuatHoaDonInsertOrUpdateCommand(XuatHoaDonInsertOrUpdateModel Model) : IRequest<XuatHoaDonDto>;

internal class XuatHoaDonInsertOrUpdateCommandHandler : IRequestHandler<XuatHoaDonInsertOrUpdateCommand, XuatHoaDonDto> {
    private readonly IRepository<HopDong, Guid> _hopDongRepository;
    private readonly IRepository<DuAn_XuatHoaDon, Guid> _duAnXuatHoaDonRepository;
    private readonly IRepository<HopDong_XuatHoaDon, Guid> _hopDongXuatHoaDonRepository;
    private readonly IUnitOfWork _unitOfWork;

    public XuatHoaDonInsertOrUpdateCommandHandler(IServiceProvider serviceProvider) {
        _hopDongRepository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
        _duAnXuatHoaDonRepository = serviceProvider.GetRequiredService<IRepository<DuAn_XuatHoaDon, Guid>>();
        _hopDongXuatHoaDonRepository = serviceProvider.GetRequiredService<IRepository<HopDong_XuatHoaDon, Guid>>();
        _unitOfWork = _hopDongRepository.UnitOfWork;
    }

    public async Task<XuatHoaDonDto> Handle(XuatHoaDonInsertOrUpdateCommand request, CancellationToken cancellationToken) {
        var model = request.Model;

        // Get HopDong to determine routing
        var hopDong = await _hopDongRepository.GetQueryableSet()
            .FirstAsync(h => h.Id == model.HopDongId, cancellationToken);

        // Routing: DuAn-linked vs Standalone
        if (hopDong.DuAnId.HasValue) {
            // Route to DuAn_XuatHoaDon
            return await HandleDuAnXuatHoaDon(model, hopDong.DuAnId.Value, hopDong.Id, cancellationToken);
        } else {
            // Route to HopDong_XuatHoaDon
            return await HandleHopDongXuatHoaDon(model, hopDong.Id, cancellationToken);
        }
    }

    private async Task<XuatHoaDonDto> HandleDuAnXuatHoaDon(
        XuatHoaDonInsertOrUpdateModel model,
        Guid duAnId,
        Guid hopDongId,
        CancellationToken cancellationToken) {
        DuAn_XuatHoaDon entity;

        if (model.Id.HasValue && model.Id != Guid.Empty) {
            // Update existing
            entity = await _duAnXuatHoaDonRepository.GetQueryableSet()
                .FirstAsync(e => e.Id == model.Id.Value, cancellationToken);

            entity.LoaiThanhToanId = model.LoaiThanhToanId;
            entity.ThoiGianKeHoach = model.ThoiGianKeHoach.ToDateOnly();
            entity.PhanTramKeHoach = model.PhanTramKeHoach;
            entity.GiaTriKeHoach = model.GiaTriKeHoach;
            entity.GhiChuKeHoach = model.GhiChuKeHoach;
            entity.GhiChuThucTe = model.GhiChuThucTe;

            // Update actual fields if provided
            if (model.GiaTriThucTe.HasValue) {
                entity.HopDongId = hopDongId;
                entity.ThoiGianThucTe = model.ThoiGianThucTe;
                entity.GiaTriThucTe = model.GiaTriThucTe;
                entity.SoHoaDon = model.SoHoaDon;
                entity.KyHieuHoaDon = model.KyHieuHoaDon;
                entity.NgayHoaDon = model.NgayHoaDon;
            }
        } else {
            // Insert new
            entity = new DuAn_XuatHoaDon {
                DuAnId = duAnId,
                LoaiThanhToanId = model.LoaiThanhToanId,
                ThoiGianKeHoach = model.ThoiGianKeHoach.ToDateOnly(),
                PhanTramKeHoach = model.PhanTramKeHoach,
                GiaTriKeHoach = model.GiaTriKeHoach,
                GhiChuKeHoach = model.GhiChuKeHoach,
                GhiChuThucTe = model.GhiChuThucTe
            };

            // Set actual fields if provided
            if (model.GiaTriThucTe.HasValue) {
                entity.HopDongId = hopDongId;
                entity.ThoiGianThucTe = model.ThoiGianThucTe;
                entity.GiaTriThucTe = model.GiaTriThucTe;
                entity.SoHoaDon = model.SoHoaDon;
                entity.KyHieuHoaDon = model.KyHieuHoaDon;
                entity.NgayHoaDon = model.NgayHoaDon;
            }

            await _duAnXuatHoaDonRepository.AddAsync(entity, cancellationToken);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.ToDto();
    }

    private async Task<XuatHoaDonDto> HandleHopDongXuatHoaDon(
        XuatHoaDonInsertOrUpdateModel model,
        Guid hopDongId,
        CancellationToken cancellationToken) {
        HopDong_XuatHoaDon entity;

        if (model.Id.HasValue && model.Id != Guid.Empty) {
            // Update existing
            entity = await _hopDongXuatHoaDonRepository.GetQueryableSet()
                .FirstAsync(e => e.Id == model.Id.Value, cancellationToken);

            entity.LoaiThanhToanId = model.LoaiThanhToanId;
            entity.ThoiGianKeHoach = model.ThoiGianKeHoach.ToDateOnly();
            entity.PhanTramKeHoach = model.PhanTramKeHoach;
            entity.GiaTriKeHoach = model.GiaTriKeHoach;
            entity.GhiChuKeHoach = model.GhiChuKeHoach;
            entity.GhiChuThucTe = model.GhiChuThucTe;

            // Update actual fields if provided
            if (model.GiaTriThucTe.HasValue) {
                entity.ThoiGianThucTe = model.ThoiGianThucTe;
                entity.GiaTriThucTe = model.GiaTriThucTe;
                entity.SoHoaDon = model.SoHoaDon;
                entity.KyHieuHoaDon = model.KyHieuHoaDon;
                entity.NgayHoaDon = model.NgayHoaDon;
            }
        } else {
            // Insert new
            entity = new HopDong_XuatHoaDon {
                HopDongId = hopDongId,
                LoaiThanhToanId = model.LoaiThanhToanId,
                ThoiGianKeHoach = model.ThoiGianKeHoach.ToDateOnly(),
                PhanTramKeHoach = model.PhanTramKeHoach,
                GiaTriKeHoach = model.GiaTriKeHoach,
                GhiChuKeHoach = model.GhiChuKeHoach,
                GhiChuThucTe = model.GhiChuThucTe
            };

            // Set actual fields if provided
            if (model.GiaTriThucTe.HasValue) {
                entity.ThoiGianThucTe = model.ThoiGianThucTe;
                entity.GiaTriThucTe = model.GiaTriThucTe;
                entity.SoHoaDon = model.SoHoaDon;
                entity.KyHieuHoaDon = model.KyHieuHoaDon;
                entity.NgayHoaDon = model.NgayHoaDon;
            }

            await _hopDongXuatHoaDonRepository.AddAsync(entity, cancellationToken);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.ToDto();
    }
}