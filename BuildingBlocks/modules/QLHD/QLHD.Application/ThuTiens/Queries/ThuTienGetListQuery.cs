using BuildingBlocks.Domain.ValueTypes;
using QLHD.Application.ThuTiens.DTOs;

namespace QLHD.Application.ThuTiens.Queries;

/// <summary>
/// Query lấy danh sách hợp đồng có thu tiền (merged entity routing)
/// </summary>
public record ThuTienGetListQuery(ThuTienSearchModel SearchModel) : IRequest<PaginatedList<HopDongThuTienDto>>;

internal class ThuTienGetListQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<ThuTienGetListQuery, PaginatedList<HopDongThuTienDto>> {
    private readonly IRepository<HopDong, Guid> _hopDongRepository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
    private readonly IRepository<DuAn_ThuTien, Guid> _duAnThuTienRepository = serviceProvider.GetRequiredService<IRepository<DuAn_ThuTien, Guid>>();
    private readonly IRepository<HopDong_ThuTien, Guid> _hopDongThuTienRepository = serviceProvider.GetRequiredService<IRepository<HopDong_ThuTien, Guid>>();

    public async Task<PaginatedList<HopDongThuTienDto>> Handle(ThuTienGetListQuery request, CancellationToken cancellationToken = default) {
        var model = request.SearchModel;

        // Get DuAnIds that have ThuTien with optional date filters (DuAn_ThuTien)
        var duAnThuTienQuery = _duAnThuTienRepository.GetQueryableSet();
        if (model.TuNgayKeHoach.HasValue)
            duAnThuTienQuery = duAnThuTienQuery.Where(k => k.ThoiGianKeHoach >= model.TuNgayKeHoach.Value);
        if (model.DenNgayKeHoach.HasValue)
            duAnThuTienQuery = duAnThuTienQuery.Where(k => k.ThoiGianKeHoach <= model.DenNgayKeHoach.Value);
        var duAnIdsWithThuTien = await duAnThuTienQuery
            .Select(k => k.DuAnId)
            .Distinct()
            .ToListAsync(cancellationToken);

        // Get HopDongIds that have ThuTien with optional date filters (HopDong_ThuTien - standalone contracts)
        var hopDongThuTienQuery = _hopDongThuTienRepository.GetQueryableSet();
        if (model.TuNgayKeHoach.HasValue)
            hopDongThuTienQuery = hopDongThuTienQuery.Where(k => k.ThoiGianKeHoach >= model.TuNgayKeHoach.Value);
        if (model.DenNgayKeHoach.HasValue)
            hopDongThuTienQuery = hopDongThuTienQuery.Where(k => k.ThoiGianKeHoach <= model.DenNgayKeHoach.Value);
        var hopDongIdsWithThuTien = await hopDongThuTienQuery
            .Select(k => k.HopDongId)
            .Distinct()
            .ToListAsync(cancellationToken);

        // Query HopDong with routing logic for ThuTien source
        var query = _hopDongRepository.GetQueryableSet()
            .Where(h =>
                // Standalone contract (no DuAnId): check HopDong_ThuTien
                (!h.DuAnId.HasValue && hopDongIdsWithThuTien.Contains(h.Id)) ||
                // Contract with DuAn: check DuAn_ThuTien via DuAnId
                (h.DuAnId.HasValue && duAnIdsWithThuTien.Contains(h.DuAnId.Value)))
            .WhereIf(model.HopDongId.HasValue, h => h.Id == model.HopDongId)
            .WhereIf(model.DuAnId.HasValue, h => h.DuAnId == model.DuAnId)
            .WhereIf(model.TuNgayHopDong.HasValue, h => h.NgayKy >= model.TuNgayHopDong!.Value)
            .WhereIf(model.DenNgayHopDong.HasValue, h => h.NgayKy <= model.DenNgayHopDong!.Value)
            .WhereIf(model.TrangThaiId.HasValue, h => h.TrangThaiId == model.TrangThaiId)
            .WhereIf(model.NguoiTheoDoiId.HasValue, h => h.NguoiTheoDoiId == model.NguoiTheoDoiId)
            .WhereIf(model.NguoiPhuTrachChinhId.HasValue, h => h.NguoiPhuTrachChinhId == model.NguoiPhuTrachChinhId)
            .WhereIf(model.PhongBanPhuTrachChinhId.HasValue, h => h.PhongBanPhuTrachChinhId == model.PhongBanPhuTrachChinhId)
            .WhereIf(model.KhachHangId.HasValue, h => h.KhachHangId == model.KhachHangId)
            .WhereIf(model.GiamDocId.HasValue, h => h.GiamDocId == model.GiamDocId)
            .WhereIf(!string.IsNullOrEmpty(model.SoHopDong), h => h.SoHopDong!.Contains(model.SoHopDong!))
            .WhereSearchString(model, h => h.SoHopDong, h => h.Ten)
            .Select(h => new HopDongThuTienDto {
                Id = h.Id,
                SoHopDong = h.SoHopDong,
                NgayKy = h.NgayKy,
                Ten = h.Ten,
                DuAnId = h.DuAnId,
                TenDuAn = h.DuAn!.Ten,
                KhachHangId = h.KhachHangId,
                TenKhachHang = h.KhachHang!.Ten,
                GiaTri = h.GiaTri,
                TrangThaiId = h.TrangThaiId,
                TenTrangThai = h.TrangThai!.Ten,
                // Routing: DuAnId.HasValue → DuAn_ThuTien, else → HopDong_ThuTien
                KeHoach = h.DuAnId.HasValue
                    ? _duAnThuTienRepository.GetQueryableSet()
                        .Where(k => k.DuAnId == h.DuAnId)
                        .Select(k => new ThuTienKeHoachSimpleDto {
                            ThoiGian = MonthYear.FromDateOnly(k.ThoiGianKeHoach),
                            GiaTri = k.GiaTriKeHoach
                        })
                        .ToList()
                    : _hopDongThuTienRepository.GetQueryableSet()
                        .Where(k => k.HopDongId == h.Id)
                        .Select(k => new ThuTienKeHoachSimpleDto {
                            ThoiGian = MonthYear.FromDateOnly(k.ThoiGianKeHoach),
                            GiaTri = k.GiaTriKeHoach
                        })
                        .ToList(),
                // Routing: DuAnId.HasValue → DuAn_ThuTien, else → HopDong_ThuTien
                // Actual payment data (ThucTe)
                ThucTe = h.DuAnId.HasValue
                    ? _duAnThuTienRepository.GetQueryableSet()
                        .Where(t => t.DuAnId == h.DuAnId)
                        .Select(t => new ThuTienThucTeSimpleDto {
                            ThoiGian = t.ThoiGianThucTe,
                            GiaTri = t.GiaTriThucTe,
                            SoHoaDon = t.SoHoaDon,
                            KyHieuHoaDon = t.KyHieuHoaDon,
                            NgayHoaDon = t.NgayHoaDon
                        })
                        .ToList()
                    : _hopDongThuTienRepository.GetQueryableSet()
                        .Where(t => t.HopDongId == h.Id)
                        .Select(t => new ThuTienThucTeSimpleDto {
                            ThoiGian = t.ThoiGianThucTe,
                            GiaTri = t.GiaTriThucTe,
                            SoHoaDon = t.SoHoaDon,
                            KyHieuHoaDon = t.KyHieuHoaDon,
                            NgayHoaDon = t.NgayHoaDon
                        })
                        .ToList()
            })
            .OrderByDescending(h => h.Id);

        return await query.PaginatedListAsync(model.Skip(), model.Take(), cancellationToken: cancellationToken);
    }
}