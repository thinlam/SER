using BuildingBlocks.Domain.ValueTypes;
using QLHD.Application.XuatHoaDons.DTOs;

namespace QLHD.Application.XuatHoaDons.Queries;

/// <summary>
/// Query lấy danh sách hợp đồng có kế hoạch xuất hóa đơn
/// </summary>
public record XuatHoaDonGetListQuery(XuatHoaDonSearchModel SearchModel) : IRequest<PaginatedList<HopDongXuatHoaDonDto>>;

internal class XuatHoaDonGetListQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<XuatHoaDonGetListQuery, PaginatedList<HopDongXuatHoaDonDto>> {
    private readonly IRepository<HopDong, Guid> _hopDongRepository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
    private readonly IRepository<DuAn_XuatHoaDon, Guid> _duAnXuatHoaDonRepository = serviceProvider.GetRequiredService<IRepository<DuAn_XuatHoaDon, Guid>>();
    private readonly IRepository<HopDong_XuatHoaDon, Guid> _hopDongXuatHoaDonRepository = serviceProvider.GetRequiredService<IRepository<HopDong_XuatHoaDon, Guid>>();

    public async Task<PaginatedList<HopDongXuatHoaDonDto>> Handle(XuatHoaDonGetListQuery request, CancellationToken cancellationToken = default) {
        var model = request.SearchModel;

        // Get DuAnIds that have KeHoachXuatHoaDon with optional date filters (DuAn_XuatHoaDon)
        var duAnKeHoachQuery = _duAnXuatHoaDonRepository.GetQueryableSet();
        if (model.TuNgayKeHoach.HasValue)
            duAnKeHoachQuery = duAnKeHoachQuery.Where(k => k.ThoiGianKeHoach >= model.TuNgayKeHoach.Value);
        if (model.DenNgayKeHoach.HasValue)
            duAnKeHoachQuery = duAnKeHoachQuery.Where(k => k.ThoiGianKeHoach <= model.DenNgayKeHoach.Value);
        var duAnIdsWithKeHoach = await duAnKeHoachQuery
            .Select(k => k.DuAnId)
            .Distinct()
            .ToListAsync(cancellationToken);

        // Get HopDongIds that have KeHoachXuatHoaDon with optional date filters (HopDong_XuatHoaDon - standalone contracts)
        var hopDongKeHoachQuery = _hopDongXuatHoaDonRepository.GetQueryableSet();
        if (model.TuNgayKeHoach.HasValue)
            hopDongKeHoachQuery = hopDongKeHoachQuery.Where(k => k.ThoiGianKeHoach >= model.TuNgayKeHoach.Value);
        if (model.DenNgayKeHoach.HasValue)
            hopDongKeHoachQuery = hopDongKeHoachQuery.Where(k => k.ThoiGianKeHoach <= model.DenNgayKeHoach.Value);
        var hopDongIdsWithKeHoach = await hopDongKeHoachQuery
            .Select(k => k.HopDongId)
            .Distinct()
            .ToListAsync(cancellationToken);

        // Query HopDong with routing logic for XuatHoaDon source
        var query = _hopDongRepository.GetQueryableSet()
            .Where(h =>
                // Standalone contract (no DuAnId): check HopDong_XuatHoaDon
                (!h.DuAnId.HasValue && hopDongIdsWithKeHoach.Contains(h.Id)) ||
                // Contract with DuAn: check DuAn_XuatHoaDon via DuAnId
                (h.DuAnId.HasValue && duAnIdsWithKeHoach.Contains(h.DuAnId.Value)))
            .WhereIf(model.HopDongId.HasValue, h => h.Id == model.HopDongId)
            .WhereIf(model.DuAnId.HasValue, h => h.DuAnId == model.DuAnId)
            .WhereIf(model.TuNgayHopDong.HasValue, h => h.NgayKy >= model.TuNgayHopDong)
            .WhereIf(model.DenNgayHopDong.HasValue, h => h.NgayKy <= model.DenNgayHopDong)
            .WhereIf(model.TrangThaiId.HasValue, h => h.TrangThaiId == model.TrangThaiId)
            .WhereIf(model.NguoiTheoDoiId.HasValue, h => h.NguoiTheoDoiId == model.NguoiTheoDoiId)
            .WhereIf(model.NguoiPhuTrachChinhId.HasValue, h => h.NguoiPhuTrachChinhId == model.NguoiPhuTrachChinhId)
            .WhereIf(model.PhongBanPhuTrachChinhId.HasValue, h => h.PhongBanPhuTrachChinhId == model.PhongBanPhuTrachChinhId)
            .WhereIf(model.KhachHangId.HasValue, h => h.KhachHangId == model.KhachHangId)
            .WhereIf(model.GiamDocId.HasValue, h => h.GiamDocId == model.GiamDocId)
            .WhereIf(!string.IsNullOrEmpty(model.SoHopDong), h => h.SoHopDong!.Contains(model.SoHopDong!))
            .WhereSearchString(model, h => h.SoHopDong, h => h.Ten)
            .Select(h => new HopDongXuatHoaDonDto {
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
                // Routing: DuAnId.HasValue → DuAn_XuatHoaDon, else → HopDong_XuatHoaDon
                KeHoach = h.DuAnId.HasValue
                    ? _duAnXuatHoaDonRepository.GetQueryableSet()
                        .Where(k => k.DuAnId == h.DuAnId)
                        .Select(k => new XuatHoaDonKeHoachSimpleDto {
                            ThoiGian = MonthYear.FromDateOnly(k.ThoiGianKeHoach),
                            GiaTri = k.GiaTriKeHoach
                        })
                        .ToList()
                    : _hopDongXuatHoaDonRepository.GetQueryableSet()
                        .Where(k => k.HopDongId == h.Id)
                        .Select(k => new XuatHoaDonKeHoachSimpleDto {
                            ThoiGian = MonthYear.FromDateOnly(k.ThoiGianKeHoach),
                            GiaTri = k.GiaTriKeHoach
                        })
                        .ToList(),
                // Routing: DuAnId.HasValue → DuAn_XuatHoaDon, else → HopDong_XuatHoaDon
                // Actual invoice issuance data (ThucTe)
                ThucTe = h.DuAnId.HasValue
                    ? _duAnXuatHoaDonRepository.GetQueryableSet()
                        .Where(t => t.DuAnId == h.DuAnId)
                        .Select(t => new XuatHoaDonThucTeSimpleDto {
                            ThoiGian = t.ThoiGianThucTe,
                            GiaTri = t.GiaTriThucTe,
                            SoHoaDon = t.SoHoaDon,
                            KyHieuHoaDon = t.KyHieuHoaDon,
                            NgayHoaDon = t.NgayHoaDon
                        })
                        .ToList()
                    : _hopDongXuatHoaDonRepository.GetQueryableSet()
                        .Where(t => t.HopDongId == h.Id)
                        .Select(t => new XuatHoaDonThucTeSimpleDto {
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