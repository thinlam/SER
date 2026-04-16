using BuildingBlocks.Domain.ValueTypes;
using QLHD.Application.ChiPhis.DTOs;

namespace QLHD.Application.ChiPhis.Queries;

/// <summary>
/// Query lấy danh sách hợp đồng có chi phí
/// </summary>
public record ChiPhiGetListQuery(ChiPhiSearchModel SearchModel) : IRequest<PaginatedList<HopDongCoChiPhiDto>>;

internal class ChiPhiGetListQueryHandler : IRequestHandler<ChiPhiGetListQuery, PaginatedList<HopDongCoChiPhiDto>> {
    private readonly IRepository<HopDong, Guid> _hopDongRepository;
    private readonly IRepository<HopDong_ChiPhi, Guid> _chiPhiRepository;

    public ChiPhiGetListQueryHandler(IServiceProvider serviceProvider) {
        _hopDongRepository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
        _chiPhiRepository = serviceProvider.GetRequiredService<IRepository<HopDong_ChiPhi, Guid>>();
    }

    public async Task<PaginatedList<HopDongCoChiPhiDto>> Handle(ChiPhiGetListQuery request, CancellationToken cancellationToken = default) {
        var model = request.SearchModel;

        // Get HopDongIds that have ChiPhi with optional date filters
        var chiPhiQuery = _chiPhiRepository.GetQueryableSet();

        if (model.TuNgayKeHoach.HasValue)
            chiPhiQuery = chiPhiQuery.Where(k => k.ThoiGianKeHoach >= model.TuNgayKeHoach.Value);
        if (model.DenNgayKeHoach.HasValue)
            chiPhiQuery = chiPhiQuery.Where(k => k.ThoiGianKeHoach <= model.DenNgayKeHoach.Value);
        if (model.LoaiChiPhiId.HasValue)
            chiPhiQuery = chiPhiQuery.Where(k => k.LoaiChiPhiId == model.LoaiChiPhiId.Value);

        var hopDongIdsWithChiPhi = await chiPhiQuery
            .Select(k => k.HopDongId)
            .Distinct()
            .ToListAsync(cancellationToken);

        // Query HopDong with subquery for ChiPhi
        var query = _hopDongRepository.GetQueryableSet()
            .Where(h => hopDongIdsWithChiPhi.Contains(h.Id))
            .WhereIf(model.HopDongId.HasValue, h => h.Id == model.HopDongId)
            .WhereIf(model.DuAnId.HasValue, h => h.DuAnId == model.DuAnId)
            .WhereIf(model.TuNgayHopDong.HasValue, h => h.NgayKy >= model.TuNgayHopDong!.Value)
            .WhereIf(model.DenNgayHopDong.HasValue, h => h.NgayKy <= model.DenNgayHopDong!.Value)
            .WhereIf(model.TrangThaiId.HasValue, h => h.TrangThaiId == model.TrangThaiId)
            .WhereIf(model.NguoiTheoDoiId.HasValue, h => h.DuAn!.NguoiTheoDoiId == model.NguoiTheoDoiId)
            .WhereIf(model.NguoiPhuTrachChinhId.HasValue, h => h.DuAn!.NguoiPhuTrachChinhId == model.NguoiPhuTrachChinhId)
            .WhereIf(model.PhongBanPhuTrachChinhId.HasValue, h => h.PhongBanPhuTrachChinhId == model.PhongBanPhuTrachChinhId)
            .WhereIf(model.KhachHangId.HasValue, h => h.KhachHangId == model.KhachHangId)
            .WhereIf(model.GiamDocId.HasValue, h => h.DuAn!.GiamDocId == model.GiamDocId)
            .WhereIf(!string.IsNullOrEmpty(model.SoHopDong), h => h.SoHopDong!.Contains(model.SoHopDong!))
            .WhereSearchString(model, h => h.SoHopDong, h => h.Ten)
            .Select(h => new HopDongCoChiPhiDto {
                Id = h.Id,
                SoHopDong = h.SoHopDong,
                NgayKy = h.NgayKy,
                Ten = h.Ten,
                DuAnId = h.DuAnId,
                TenDuAn = h.DuAn != null ? h.DuAn.Ten : null,
                KhachHangId = h.KhachHangId,
                TenKhachHang = h.KhachHang!.Ten,
                GiaTri = h.GiaTri,
                TrangThaiId = h.TrangThaiId,
                TenTrangThai = h.TrangThai!.Ten,
                // Subquery for ChiPhi (ke hoach summary)
                KeHoach = _chiPhiRepository.GetQueryableSet()
                    .Where(k => k.HopDongId == h.Id)
                    .Select(k => new ChiPhiKeHoachSimpleDto {
                        ThoiGian = MonthYear.FromDateOnly(k.ThoiGianKeHoach),
                        GiaTri = k.GiaTriKeHoach
                    })
                    .ToList(),
                // Subquery for ChiPhi (thuc te summary - actual cost data)
                ThucTe = _chiPhiRepository.GetQueryableSet()
                    .Where(k => k.HopDongId == h.Id)
                    .Select(k => new ChiPhiThucTeSimpleDto {
                        ThoiGian = MonthYear.FromDateOnly(k.ThoiGianThucTe!.Value),
                        GiaTri = k.GiaTriThucTe!.Value
                    })
                    .ToList()
            })
            .OrderByDescending(h => h.Id);

        return await query.PaginatedListAsync(model.Skip(), model.Take(), cancellationToken: cancellationToken);
    }
}