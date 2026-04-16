using BuildingBlocks.Domain.ValueTypes;
using QLHD.Application.ThuTiens.DTOs;
using QLHD.Domain.Entities;

namespace QLHD.Application.ThuTiens.Commands;

/// <summary>
/// Command thêm mới/cập nhật thu tiền (unified routing).
/// <para>
/// DuAn và HopDong thực chất là 1 thực thể kinh doanh (DuAn = Kế hoạch, HopDong = Thực tế).
/// Routing logic dựa trên DuAnId của HopDong:
///   - DuAnId có giá trị → prefix "DuAn_" → lưu vào DuAn_ThuTien (theo kế hoạch/DuAn)
///   - DuAnId null → prefix "HopDong_" → lưu vào HopDong_ThuTien (hợp đồng độc lập)
/// </para>
/// </summary>
public record ThuTienInsertOrUpdateCommand(ThuTienInsertOrUpdateModel Model) : IRequest<ThuTienDto>;


internal class ThuTienInsertOrUpdateCommandHandler : IRequestHandler<ThuTienInsertOrUpdateCommand, ThuTienDto> {
    private readonly IRepository<HopDong, Guid> _hopDongRepository;
    private readonly IRepository<DuAn_ThuTien, Guid> _duAnThuTienRepository;
    private readonly IRepository<HopDong_ThuTien, Guid> _hopDongThuTienRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ThuTienInsertOrUpdateCommandHandler(IServiceProvider serviceProvider) {
        _hopDongRepository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
        _duAnThuTienRepository = serviceProvider.GetRequiredService<IRepository<DuAn_ThuTien, Guid>>();
        _hopDongThuTienRepository = serviceProvider.GetRequiredService<IRepository<HopDong_ThuTien, Guid>>();
        _unitOfWork = _hopDongRepository.UnitOfWork;
    }

    public async Task<ThuTienDto> Handle(ThuTienInsertOrUpdateCommand request, CancellationToken cancellationToken) {
        var model = request.Model;

        // Get HopDong to determine routing
        var hopDong = await _hopDongRepository.GetQueryableSet()
            .FirstAsync(h => h.Id == model.HopDongId, cancellationToken);

        // Routing: DuAn-linked vs Standalone
        if (hopDong.DuAnId.HasValue) {
            // Route to DuAn_ThuTien
            return await HandleDuAnThuTien(model, hopDong, cancellationToken);
        } else {
            // Route to HopDong_ThuTien
            return await HandleHopDongThuTien(model, hopDong, cancellationToken);
        }
    }

    private async Task<ThuTienDto> HandleDuAnThuTien(
        ThuTienInsertOrUpdateModel model,
        HopDong hopDong,
        CancellationToken cancellationToken) {
        DuAn_ThuTien entity;

        if (model.Id.HasValue && model.Id != Guid.Empty) {
            // Update existing
            entity = await _duAnThuTienRepository.GetQueryableSet()
                .FirstAsync(e => e.Id == model.Id.Value, cancellationToken);

            entity.LoaiThanhToanId = model.LoaiThanhToanId;
            entity.ThoiGianKeHoach = model.ThoiGianKeHoach.ToDateOnly();
            entity.PhanTramKeHoach = model.PhanTramKeHoach;
            entity.GiaTriKeHoach = model.GiaTriKeHoach;
            entity.GhiChuKeHoach = model.GhiChuKeHoach;
            entity.GhiChuThucTe = model.GhiChuThucTe;

            // Update actual fields if provided
            if (model.GiaTriThucTe.HasValue) {
                entity.HopDongId = hopDong.Id;
                entity.ThoiGianThucTe = model.ThoiGianThucTe;
                entity.GiaTriThucTe = model.GiaTriThucTe;
                entity.SoHoaDon = model.SoHoaDon;
                entity.KyHieuHoaDon = model.KyHieuHoaDon;
                entity.NgayHoaDon = model.NgayHoaDon;
            }
        } else {
            // Insert new
            entity = new DuAn_ThuTien {
                DuAnId = hopDong.DuAnId!.Value,
                LoaiThanhToanId = model.LoaiThanhToanId,
                ThoiGianKeHoach = model.ThoiGianKeHoach.ToDateOnly(),
                PhanTramKeHoach = model.PhanTramKeHoach,
                GiaTriKeHoach = model.GiaTriKeHoach,
                GhiChuKeHoach = model.GhiChuKeHoach,
                GhiChuThucTe = model.GhiChuThucTe
            };

            // Set actual fields if provided
            if (model.GiaTriThucTe.HasValue) {
                entity.HopDongId = hopDong.Id;
                entity.ThoiGianThucTe = model.ThoiGianThucTe;
                entity.GiaTriThucTe = model.GiaTriThucTe;
                entity.SoHoaDon = model.SoHoaDon;
                entity.KyHieuHoaDon = model.KyHieuHoaDon;
                entity.NgayHoaDon = model.NgayHoaDon;
            }

            await _duAnThuTienRepository.AddAsync(entity, cancellationToken);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.ToDto();
    }

    private async Task<ThuTienDto> HandleHopDongThuTien(
        ThuTienInsertOrUpdateModel model,
        HopDong hopDong,
        CancellationToken cancellationToken) {
        HopDong_ThuTien entity;

        if (model.Id.HasValue && model.Id != Guid.Empty) {
            // Update existing
            entity = await _hopDongThuTienRepository.GetQueryableSet()
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
            entity = new HopDong_ThuTien {
                HopDongId = hopDong.Id,
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

            await _hopDongThuTienRepository.AddAsync(entity, cancellationToken);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.ToDto();
    }
}