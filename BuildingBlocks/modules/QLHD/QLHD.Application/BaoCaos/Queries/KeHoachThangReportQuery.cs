using BuildingBlocks.CrossCutting.ExtensionMethods;
using BuildingBlocks.Domain.Constants;
using QLHD.Application.BaoCaos.DTOs;
using QLHD.Domain.Constants;

namespace QLHD.Application.BaoCaos.Queries;

/// <summary>
/// Query for Ke Hoach Thang report - grouped by PhongBanPhuTrachChinhId
/// HopDong is highest level. Each DuAn_ThuTien/HopDong_ThuTien has its own KeHoach and ThucTe.
/// DuAn/HopDong split is about ownership (with DuAn vs standalone), not plan vs actual.
/// ThuTien/XuatHoaDon/ChiPhi are child records with N cardinality.
///
/// IMPORTANT: Query starts from DmDonVi as base to ensure all departments appear
/// regardless of whether they have DuAn, HopDong, or both.
/// </summary>
public record KeHoachThangReportQuery(KeHoachThangSearchModel SearchModel) : IRequest<List<KeHoachThang_BaoCaoThangDto>>;

internal class KeHoachThangReportQueryHandler : IRequestHandler<KeHoachThangReportQuery, List<KeHoachThang_BaoCaoThangDto>> {
    private readonly IRepository<KeHoachThang, int> _keHoachThangRepo;
    // Source entity repositories (new - for LEFT JOIN pattern)
    private readonly IRepository<DuAn_ThuTien, Guid> _duAnThuTienRepo;
    private readonly IRepository<DuAn_XuatHoaDon, Guid> _duAnXuatHoaDonRepo;
    private readonly IRepository<HopDong_ThuTien, Guid> _hopDongThuTienRepo;
    private readonly IRepository<HopDong_XuatHoaDon, Guid> _hopDongXuatHoaDonRepo;
    private readonly IRepository<HopDong_ChiPhi, Guid> _hopDongChiPhiRepo;
    // Version entity repositories (for LEFT JOIN target)
    private readonly IRepository<DuAn_ThuTien_Version, Guid> _duAnThuTienVersionRepo;
    private readonly IRepository<DuAn_XuatHoaDon_Version, Guid> _duAnXuatHoaDonVersionRepo;
    private readonly IRepository<HopDong_ThuTien_Version, Guid> _hopDongThuTienVersionRepo;
    private readonly IRepository<HopDong_XuatHoaDon_Version, Guid> _hopDongXuatHoaDonVersionRepo;
    private readonly IRepository<HopDong_ChiPhi_Version, Guid> _hopDongChiPhiVersionRepo;
    private readonly IRepository<DmDonVi, long> _dmDonViRepo;

    public KeHoachThangReportQueryHandler(IServiceProvider serviceProvider) {
        _keHoachThangRepo = serviceProvider.GetRequiredService<IRepository<KeHoachThang, int>>();
        // Source entities
        _duAnThuTienRepo = serviceProvider.GetRequiredService<IRepository<DuAn_ThuTien, Guid>>();
        _duAnXuatHoaDonRepo = serviceProvider.GetRequiredService<IRepository<DuAn_XuatHoaDon, Guid>>();
        _hopDongThuTienRepo = serviceProvider.GetRequiredService<IRepository<HopDong_ThuTien, Guid>>();
        _hopDongXuatHoaDonRepo = serviceProvider.GetRequiredService<IRepository<HopDong_XuatHoaDon, Guid>>();
        _hopDongChiPhiRepo = serviceProvider.GetRequiredService<IRepository<HopDong_ChiPhi, Guid>>();
        // Version entities
        _duAnThuTienVersionRepo = serviceProvider.GetRequiredService<IRepository<DuAn_ThuTien_Version, Guid>>();
        _duAnXuatHoaDonVersionRepo = serviceProvider.GetRequiredService<IRepository<DuAn_XuatHoaDon_Version, Guid>>();
        _hopDongThuTienVersionRepo = serviceProvider.GetRequiredService<IRepository<HopDong_ThuTien_Version, Guid>>();
        _hopDongXuatHoaDonVersionRepo = serviceProvider.GetRequiredService<IRepository<HopDong_XuatHoaDon_Version, Guid>>();
        _hopDongChiPhiVersionRepo = serviceProvider.GetRequiredService<IRepository<HopDong_ChiPhi_Version, Guid>>();
        _dmDonViRepo = serviceProvider.GetRequiredService<IRepository<DmDonVi, long>>();
    }

    public async Task<List<KeHoachThang_BaoCaoThangDto>> Handle(
        KeHoachThangReportQuery request,
        CancellationToken cancellationToken) {
        var model = request.SearchModel;

        // ====== BASE: ALL PHONG BAN FROM DMDONVI ======
        var dmDonViQuery = _dmDonViRepo.GetQueryableSet();

        // Filters
        var isBoPhanFilter = model.PhongBanPhuTrachChinhId > 0;
        var isKeHoachFilter = model.KeHoachThangId > 0;
        var filterBoPhan = model.PhongBanPhuTrachChinhId;
        var filterKeHoach = model.KeHoachThangId;
        var filterTuThang = model.TuThang.ToDateOnly(1);
        var filterDenThang = model.DenThang.ToDateOnly(1);

        // ====== VERSION QUERIES (date filter only for LEFT JOIN matching) ======
        var duAnThuTienVersions = _duAnThuTienVersionRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= filterTuThang)
            .Where(e => e.ThoiGianKeHoach <= filterDenThang);
        var hopDongThuTienVersions = _hopDongThuTienVersionRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= filterTuThang)
            .Where(e => e.ThoiGianKeHoach <= filterDenThang)
            .Where(e => e.HopDong!.DuAnId == null);
        var duAnXuatHoaDonVersions = _duAnXuatHoaDonVersionRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= filterTuThang)
            .Where(e => e.ThoiGianKeHoach <= filterDenThang);
        var hopDongXuatHoaDonVersions = _hopDongXuatHoaDonVersionRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= filterTuThang)
            .Where(e => e.ThoiGianKeHoach <= filterDenThang)
            .Where(e => e.HopDong!.DuAnId == null);
        var hopDongChiPhiVersions = _hopDongChiPhiVersionRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= filterTuThang)
            .Where(e => e.ThoiGianKeHoach <= filterDenThang);

        // ====== SOURCE ENTITY QUERIES (date + PhongBan filters) ======
        var duAnThuTienSource = _duAnThuTienRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= filterTuThang)
            .Where(e => e.ThoiGianKeHoach <= filterDenThang)
            .WhereIf(isBoPhanFilter, e => e.DuAn!.PhongBanPhuTrachChinhId == filterBoPhan);
        var hopDongThuTienSource = _hopDongThuTienRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= filterTuThang)
            .Where(e => e.ThoiGianKeHoach <= filterDenThang)
            .Where(e => e.HopDong!.DuAnId == null)
            .WhereIf(isBoPhanFilter, e => e.HopDong!.PhongBanPhuTrachChinhId == filterBoPhan);
        var duAnXuatHoaDonSource = _duAnXuatHoaDonRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= filterTuThang)
            .Where(e => e.ThoiGianKeHoach <= filterDenThang)
            .WhereIf(isBoPhanFilter, e => e.DuAn!.PhongBanPhuTrachChinhId == filterBoPhan);
        var hopDongXuatHoaDonSource = _hopDongXuatHoaDonRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= filterTuThang)
            .Where(e => e.ThoiGianKeHoach <= filterDenThang)
            .Where(e => e.HopDong!.DuAnId == null)
            .WhereIf(isBoPhanFilter, e => e.HopDong!.PhongBanPhuTrachChinhId == filterBoPhan);
        var hopDongChiPhiSource = _hopDongChiPhiRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= filterTuThang)
            .Where(e => e.ThoiGianKeHoach <= filterDenThang)
            .WhereIf(isBoPhanFilter, e => e.HopDong!.PhongBanPhuTrachChinhId == filterBoPhan);

        // ====== DOANH SO KY (unique per DuAn/HopDong) ======
        // Unified: each contract provides BOTH KeHoach and ThucTe from the same source
        // DuAn-based: KeHoach from DuAn.GiaTriDuKien, ThucTe from associated HopDong.GiaTri
        // Standalone HopDong: both from HopDong.GiaTri

        var doanhSoKyDuAn = dmDonViQuery
            .LeftOuterJoin(duAnThuTienVersions, pb => pb.Id, v => v.DuAn!.PhongBanPhuTrachChinhId, (pb, v) => new {
                PhongBanId = pb.Id,
                TenPhongBan = pb.TenDonVi ?? DefaultConstants.UNKNOWN,
                Id = v != null ? v.DuAn!.Id : Guid.Empty,
                KeHoach = v != null ? v.DuAn!.GiaTriDuKien : 0m,
                ThucTe = (v != null && v.DuAn!.HopDong != null) ? v.DuAn!.HopDong!.GiaTri : 0m
            });

        var doanhSoKyHopDong = dmDonViQuery
            .LeftOuterJoin(hopDongThuTienVersions, pb => pb.Id, v => v.HopDong!.PhongBanPhuTrachChinhId, (pb, v) => new {
                PhongBanId = pb.Id,
                TenPhongBan = pb.TenDonVi ?? DefaultConstants.UNKNOWN,
                Id = v != null ? v.HopDong!.Id : Guid.Empty,
                KeHoach = v != null ? v.HopDong!.GiaTri : 0m,
                ThucTe = v != null ? v.HopDong!.GiaTri : 0m
            });

        // ====== INVERTED QUERY: Source LEFT JOIN Version ======
        // ThucTe from source, KeHoach from version (0 if null - NO fallback)

        // ThuTien DuAn: Source → LEFT JOIN Version → Join DmDonVi
        var thuTienDuAn = duAnThuTienSource
            .LeftOuterJoin(duAnThuTienVersions, s => s.Id, v => v.SourceEntityId, (s, v) => new { Source = s, Version = v })
            .WhereIf(isKeHoachFilter, x => x.Version != null && x.Version.KeHoachThangId == filterKeHoach)
            .Join(dmDonViQuery, x => x.Source.DuAn!.PhongBanPhuTrachChinhId, pb => pb.Id, (x, pb) => new PhongBanReportDto {
                PhongBanId = pb.Id,
                TenPhongBan = pb.TenDonVi ?? DefaultConstants.UNKNOWN,
                Id = x.Source.DuAnId,
                KeHoach = x.Version != null ? x.Version.GiaTriKeHoach : 0m, // NO fallback to source
                ThucTe = x.Source.GiaTriThucTe ?? 0m,
                Type = PhongBanReportTypeConstants.ThuTien
            });

        // ThuTien HopDong: Source → LEFT JOIN Version → Join DmDonVi
        var thuTienHopDong = hopDongThuTienSource
            .LeftOuterJoin(hopDongThuTienVersions, s => s.Id, v => v.SourceEntityId, (s, v) => new { Source = s, Version = v })
            .WhereIf(isKeHoachFilter, x => x.Version != null && x.Version.KeHoachThangId == filterKeHoach)
            .Join(dmDonViQuery, x => x.Source.HopDong!.PhongBanPhuTrachChinhId, pb => pb.Id, (x, pb) => new PhongBanReportDto {
                PhongBanId = pb.Id,
                TenPhongBan = pb.TenDonVi ?? DefaultConstants.UNKNOWN,
                Id = x.Source.HopDongId,
                KeHoach = x.Version != null ? x.Version.GiaTriKeHoach : 0m, // NO fallback to source
                ThucTe = x.Source.GiaTriThucTe ?? 0m,
                Type = PhongBanReportTypeConstants.ThuTien
            });

        var thuTienCombined = thuTienDuAn.Concat(thuTienHopDong);

        // XuatHoaDon DuAn: Source → LEFT JOIN Version → Join DmDonVi
        var xuatHoaDonDuAn = duAnXuatHoaDonSource
            .LeftOuterJoin(duAnXuatHoaDonVersions, s => s.Id, v => v.SourceEntityId, (s, v) => new { Source = s, Version = v })
            .WhereIf(isKeHoachFilter, x => x.Version != null && x.Version.KeHoachThangId == filterKeHoach)
            .Join(dmDonViQuery, x => x.Source.DuAn!.PhongBanPhuTrachChinhId, pb => pb.Id, (x, pb) => new PhongBanReportDto {
                PhongBanId = pb.Id,
                TenPhongBan = pb.TenDonVi ?? DefaultConstants.UNKNOWN,
                Id = x.Source.DuAnId,
                KeHoach = x.Version != null ? x.Version.GiaTriKeHoach : 0m,
                ThucTe = x.Source.GiaTriThucTe ?? 0m,
                Type = PhongBanReportTypeConstants.XuatHoaDon
            });

        // XuatHoaDon HopDong: Source → LEFT JOIN Version → Join DmDonVi
        var xuatHoaDonHopDong = hopDongXuatHoaDonSource
            .LeftOuterJoin(hopDongXuatHoaDonVersions, s => s.Id, v => v.SourceEntityId, (s, v) => new { Source = s, Version = v })
            .WhereIf(isKeHoachFilter, x => x.Version != null && x.Version.KeHoachThangId == filterKeHoach)
            .Join(dmDonViQuery, x => x.Source.HopDong!.PhongBanPhuTrachChinhId, pb => pb.Id, (x, pb) => new PhongBanReportDto {
                PhongBanId = pb.Id,
                TenPhongBan = pb.TenDonVi ?? DefaultConstants.UNKNOWN,
                Id = x.Source.HopDongId,
                KeHoach = x.Version != null ? x.Version.GiaTriKeHoach : 0m,
                ThucTe = x.Source.GiaTriThucTe ?? 0m,
                Type = PhongBanReportTypeConstants.XuatHoaDon
            });

        var xuatHoaDonCombined = xuatHoaDonDuAn.Concat(xuatHoaDonHopDong);

        // ChiPhi HopDong: Source → LEFT JOIN Version → Join DmDonVi
        var chiPhiHopDong = hopDongChiPhiSource
            .LeftOuterJoin(hopDongChiPhiVersions, s => s.Id, v => v.SourceEntityId, (s, v) => new { Source = s, Version = v })
            .WhereIf(isKeHoachFilter, x => x.Version != null && x.Version.KeHoachThangId == filterKeHoach)
            .Join(dmDonViQuery, x => x.Source.HopDong!.PhongBanPhuTrachChinhId, pb => pb.Id, (x, pb) => new PhongBanReportDto {
                PhongBanId = pb.Id,
                TenPhongBan = pb.TenDonVi ?? DefaultConstants.UNKNOWN,
                Id = x.Source.HopDongId,
                KeHoach = x.Version != null ? x.Version.GiaTriKeHoach : 0m,
                ThucTe = x.Source.GiaTriThucTe ?? 0m,
                Type = PhongBanReportTypeConstants.ChiPhi
            });

        // ====== AGGREGATE BY PHONGBAN ======
        var doanhSoKyAgg = doanhSoKyDuAn.Concat(doanhSoKyHopDong)
            .GroupBy(x => new { x.PhongBanId, x.TenPhongBan, x.Id })
            .Select(g => new { g.Key.PhongBanId, g.Key.TenPhongBan,
                KeHoach = g.FirstOrDefault()!.KeHoach, ThucTe = g.FirstOrDefault()!.ThucTe })
            .GroupBy(x => new { x.PhongBanId, x.TenPhongBan })
            .Select(g => new { g.Key.PhongBanId, g.Key.TenPhongBan,
                DoanhSoKyKeHoach = g.Sum(x => x.KeHoach), DoanhSoKyThucTe = g.Sum(x => x.ThucTe) });

        var thuTienAgg = thuTienCombined
            .GroupBy(x => x.PhongBanId)
            .Select(g => new { PhongBanId = g.Key, ThuTienKeHoach = g.Sum(x => x.KeHoach), ThuTienThucTe = g.Sum(x => x.ThucTe) });

        var xuatHoaDonAgg = xuatHoaDonCombined
            .GroupBy(x => x.PhongBanId)
            .Select(g => new { PhongBanId = g.Key, XuatHoaDonKeHoach = g.Sum(x => x.KeHoach), XuatHoaDonThucTe = g.Sum(x => x.ThucTe) });

        var chiPhiAgg = chiPhiHopDong
            .GroupBy(x => x.PhongBanId)
            .Select(g => new { PhongBanId = g.Key, ChiPhiKeHoach = g.Sum(x => x.KeHoach), ChiPhiThucTe = g.Sum(x => x.ThucTe) });

        // ====== GET ALL PHONG BAN IDs ======
        var allPhongBanIds = await dmDonViQuery
            .WhereIf(isBoPhanFilter, e => e.Id == filterBoPhan)
            .Select(pb => new { PhongBanId = pb.Id, TenPhongBan = pb.TenDonVi })
            .ToListAsync(cancellationToken);

        // Execute aggregations
        var doanhSoKyList = await doanhSoKyAgg.ToListAsync(cancellationToken);
        var thuTienList = await thuTienAgg.ToListAsync(cancellationToken);
        var xuatHoaDonList = await xuatHoaDonAgg.ToListAsync(cancellationToken);
        var chiPhiList = await chiPhiAgg.ToListAsync(cancellationToken);

        // Merge results
        var merged = allPhongBanIds.Select(pb => new KeHoachThang_BaoCaoThangDto {
            PhongBanId = pb.PhongBanId,
            TenPhongBan = pb.TenPhongBan,
            DoanhSoKyKeHoach = doanhSoKyList.FirstOrDefault(x => x.PhongBanId == pb.PhongBanId)?.DoanhSoKyKeHoach ?? 0m,
            DoanhSoKyThucTe = doanhSoKyList.FirstOrDefault(x => x.PhongBanId == pb.PhongBanId)?.DoanhSoKyThucTe ?? 0m,
            ThuTienKeHoach = thuTienList.FirstOrDefault(x => x.PhongBanId == pb.PhongBanId)?.ThuTienKeHoach ?? 0m,
            ThuTienThucTe = thuTienList.FirstOrDefault(x => x.PhongBanId == pb.PhongBanId)?.ThuTienThucTe ?? 0m,
            XuatHoaDonKeHoach = xuatHoaDonList.FirstOrDefault(x => x.PhongBanId == pb.PhongBanId)?.XuatHoaDonKeHoach ?? 0m,
            XuatHoaDonThucTe = xuatHoaDonList.FirstOrDefault(x => x.PhongBanId == pb.PhongBanId)?.XuatHoaDonThucTe ?? 0m,
            ChiPhiKeHoach = chiPhiList.FirstOrDefault(x => x.PhongBanId == pb.PhongBanId)?.ChiPhiKeHoach ?? 0m,
            ChiPhiThucTe = chiPhiList.FirstOrDefault(x => x.PhongBanId == pb.PhongBanId)?.ChiPhiThucTe ?? 0m
        })
        // Filter out records with all zero values
        .Where(x =>
            x.DoanhSoKyKeHoach != 0 || x.DoanhSoKyThucTe != 0 ||
            x.ThuTienKeHoach != 0 || x.ThuTienThucTe != 0 ||
            x.XuatHoaDonKeHoach != 0 || x.XuatHoaDonThucTe != 0 ||
            x.ChiPhiKeHoach != 0 || x.ChiPhiThucTe != 0
        )
        .OrderByDescending(x => x.DoanhSoKyThucTe)
        .ToList();

        return merged;
    }
}