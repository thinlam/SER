using BuildingBlocks.Application.Common.DTOs;
using BuildingBlocks.CrossCutting.ExtensionMethods;
using BuildingBlocks.Domain.Constants;
using QLHD.Application.BaoCaos.DTOs;
using QLHD.Domain.Constants;

namespace QLHD.Application.BaoCaos.Queries;

/// <summary>
/// Query for Chi Tiet Bo Phan report - grouped by PhongBanId + DuAn/HopDong with pagination.
/// HopDong is highest level. DuAn-based contracts: KeHoach from DuAn, ThucTe from associated HopDong.
/// Standalone HopDong: both KeHoach and ThucTe from HopDong.
/// All aggregation done via IQueryable chained LeftOuterJoin (SQL-side).
/// </summary>
public record ChiTietBoPhanReportQuery(KeHoachThangSearchModel SearchModel) : IRequest<PaginatedList<ChiTietBoPhanDto>>;

internal class ChiTietBoPhanReportQueryHandler : IRequestHandler<ChiTietBoPhanReportQuery, PaginatedList<ChiTietBoPhanDto>>
{
    private readonly IRepository<DuAn_ThuTien, Guid> _duAnThuTienRepo;
    private readonly IRepository<DuAn_XuatHoaDon, Guid> _duAnXuatHoaDonRepo;
    private readonly IRepository<HopDong_ThuTien, Guid> _hopDongThuTienRepo;
    private readonly IRepository<HopDong_XuatHoaDon, Guid> _hopDongXuatHoaDonRepo;
    private readonly IRepository<HopDong_ChiPhi, Guid> _hopDongChiPhiRepo;
    private readonly IRepository<DuAn_ThuTien_Version, Guid> _duAnThuTienVersionRepo;
    private readonly IRepository<DuAn_XuatHoaDon_Version, Guid> _duAnXuatHoaDonVersionRepo;
    private readonly IRepository<HopDong_ThuTien_Version, Guid> _hopDongThuTienVersionRepo;
    private readonly IRepository<HopDong_XuatHoaDon_Version, Guid> _hopDongXuatHoaDonVersionRepo;
    private readonly IRepository<HopDong_ChiPhi_Version, Guid> _hopDongChiPhiVersionRepo;
    private readonly IRepository<DmDonVi, long> _dmDonViRepo;

    public ChiTietBoPhanReportQueryHandler(IServiceProvider serviceProvider)
    {
        _duAnThuTienRepo = serviceProvider.GetRequiredService<IRepository<DuAn_ThuTien, Guid>>();
        _duAnXuatHoaDonRepo = serviceProvider.GetRequiredService<IRepository<DuAn_XuatHoaDon, Guid>>();
        _hopDongThuTienRepo = serviceProvider.GetRequiredService<IRepository<HopDong_ThuTien, Guid>>();
        _hopDongXuatHoaDonRepo = serviceProvider.GetRequiredService<IRepository<HopDong_XuatHoaDon, Guid>>();
        _hopDongChiPhiRepo = serviceProvider.GetRequiredService<IRepository<HopDong_ChiPhi, Guid>>();
        _duAnThuTienVersionRepo = serviceProvider.GetRequiredService<IRepository<DuAn_ThuTien_Version, Guid>>();
        _duAnXuatHoaDonVersionRepo = serviceProvider.GetRequiredService<IRepository<DuAn_XuatHoaDon_Version, Guid>>();
        _hopDongThuTienVersionRepo = serviceProvider.GetRequiredService<IRepository<HopDong_ThuTien_Version, Guid>>();
        _hopDongXuatHoaDonVersionRepo = serviceProvider.GetRequiredService<IRepository<HopDong_XuatHoaDon_Version, Guid>>();
        _hopDongChiPhiVersionRepo = serviceProvider.GetRequiredService<IRepository<HopDong_ChiPhi_Version, Guid>>();
        _dmDonViRepo = serviceProvider.GetRequiredService<IRepository<DmDonVi, long>>();
    }

    public async Task<PaginatedList<ChiTietBoPhanDto>> Handle(
        ChiTietBoPhanReportQuery request,
        CancellationToken cancellationToken)
    {
        var model = request.SearchModel;
        var isBoPhanFilter = model.PhongBanPhuTrachChinhId > 0;
        var isKeHoachFilter = model.KeHoachThangId > 0;
        var filterBoPhan = model.PhongBanPhuTrachChinhId;
        var filterKeHoach = model.KeHoachThangId;
        var filterTuThang = model.TuThang.ToDateOnly(1);
        var filterDenThang = model.DenThang.ToDateOnly(1);

        // ====== VERSION QUERIES (date filter only) ======
        var duAnThuTienVersions = _duAnThuTienVersionRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= filterTuThang)
            .Where(e => e.ThoiGianKeHoach <= filterDenThang);
        var hopDongThuTienVersions = _hopDongThuTienVersionRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= filterTuThang)
            .Where(e => e.ThoiGianKeHoach <= filterDenThang);
        var duAnXuatHoaDonVersions = _duAnXuatHoaDonVersionRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= filterTuThang)
            .Where(e => e.ThoiGianKeHoach <= filterDenThang);
        var hopDongXuatHoaDonVersions = _hopDongXuatHoaDonVersionRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= filterTuThang)
            .Where(e => e.ThoiGianKeHoach <= filterDenThang);
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
            .WhereIf(isBoPhanFilter, e => e.HopDong!.PhongBanPhuTrachChinhId == filterBoPhan);
        var duAnXuatHoaDonSource = _duAnXuatHoaDonRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= filterTuThang)
            .Where(e => e.ThoiGianKeHoach <= filterDenThang)
            .WhereIf(isBoPhanFilter, e => e.DuAn!.PhongBanPhuTrachChinhId == filterBoPhan);
        var hopDongXuatHoaDonSource = _hopDongXuatHoaDonRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= filterTuThang)
            .Where(e => e.ThoiGianKeHoach <= filterDenThang)
            .WhereIf(isBoPhanFilter, e => e.HopDong!.PhongBanPhuTrachChinhId == filterBoPhan);
        var hopDongChiPhiSource = _hopDongChiPhiRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= filterTuThang)
            .Where(e => e.ThoiGianKeHoach <= filterDenThang)
            .WhereIf(isBoPhanFilter, e => e.HopDong!.PhongBanPhuTrachChinhId == filterBoPhan);
        var dmDonViQuery = _dmDonViRepo.GetQueryableSet();

        // ====== PRE-AGGREGATES (IQueryable, NOT materialized) ======
        // Combined: both KeHoach (from Version) and ThucTe (from Source) per entity

        // DuAn ThuTien: KeHoach from Version, ThucTe from Source
        var daThuTienAgg = duAnThuTienSource
            .LeftOuterJoin(duAnThuTienVersions, s => s.Id, v => v.SourceEntityId,
                (s, v) => new { Source = s, Version = v })
            .WhereIf(isKeHoachFilter, x => x.Version != null && x.Version.KeHoachThangId == filterKeHoach)
            .GroupBy(x => x.Source.DuAnId)
            .Select(g => new { DuAnId = g.Key, KeHoach = g.Sum(x => x.Version != null ? x.Version.GiaTriKeHoach : 0m), ThucTe = g.Sum(x => x.Source.GiaTriThucTe ?? 0m) });

        // HopDong ThuTien: KeHoach from Version, ThucTe from Source
        var hdThuTienAgg = hopDongThuTienSource
            .LeftOuterJoin(hopDongThuTienVersions, s => s.Id, v => v.SourceEntityId,
                (s, v) => new { Source = s, Version = v })
            .WhereIf(isKeHoachFilter, x => x.Version != null && x.Version.KeHoachThangId == filterKeHoach)
            .GroupBy(x => x.Source.HopDongId)
            .Select(g => new { HopDongId = g.Key, KeHoach = g.Sum(x => x.Version != null ? x.Version.GiaTriKeHoach : 0m), ThucTe = g.Sum(x => x.Source.GiaTriThucTe ?? 0m) });

        // DuAn XuatHoaDon
        var daXhdAgg = duAnXuatHoaDonSource
            .LeftOuterJoin(duAnXuatHoaDonVersions, s => s.Id, v => v.SourceEntityId,
                (s, v) => new { Source = s, Version = v })
            .WhereIf(isKeHoachFilter, x => x.Version != null && x.Version.KeHoachThangId == filterKeHoach)
            .GroupBy(x => x.Source.DuAnId)
            .Select(g => new { DuAnId = g.Key, KeHoach = g.Sum(x => x.Version != null ? x.Version.GiaTriKeHoach : 0m), ThucTe = g.Sum(x => x.Source.GiaTriThucTe ?? 0m) });

        // HopDong XuatHoaDon
        var hdXhdAgg = hopDongXuatHoaDonSource
            .LeftOuterJoin(hopDongXuatHoaDonVersions, s => s.Id, v => v.SourceEntityId,
                (s, v) => new { Source = s, Version = v })
            .WhereIf(isKeHoachFilter, x => x.Version != null && x.Version.KeHoachThangId == filterKeHoach)
            .GroupBy(x => x.Source.HopDongId)
            .Select(g => new { HopDongId = g.Key, KeHoach = g.Sum(x => x.Version != null ? x.Version.GiaTriKeHoach : 0m), ThucTe = g.Sum(x => x.Source.GiaTriThucTe ?? 0m) });

        // HopDong ChiPhi (HopDong only)
        var hdCpAgg = hopDongChiPhiSource
            .LeftOuterJoin(hopDongChiPhiVersions, s => s.Id, v => v.SourceEntityId,
                (s, v) => new { Source = s, Version = v })
            .WhereIf(isKeHoachFilter, x => x.Version != null && x.Version.KeHoachThangId == filterKeHoach)
            .GroupBy(x => x.Source.HopDongId)
            .Select(g => new { HopDongId = g.Key, KeHoach = g.Sum(x => x.Version != null ? x.Version.GiaTriKeHoach : 0m), ThucTe = g.Sum(x => x.Source.GiaTriThucTe ?? 0m) });

        // ====== BASE ROWS: DuAn with HopDong pairing ======
        var duAnBase = duAnThuTienVersions
            .WhereIf(isBoPhanFilter, v => v.DuAn!.PhongBanPhuTrachChinhId == filterBoPhan)
            .Select(v => new
            {
                v.DuAnId,
                DuAnTen = v.DuAn!.Ten,
                PhongBanId = v.DuAn!.PhongBanPhuTrachChinhId,
                GiaTriDuKien = v.DuAn!.GiaTriDuKien,
                HopDongId = (Guid?)v.DuAn!.HopDong!.Id,
                HopDongTen = v.DuAn!.HopDong!.Ten,
                HopDongGiaTri = (decimal?)v.DuAn!.HopDong!.GiaTri
            })
            .Distinct();

        // Standalone HopDong (DuAnId is null)
        var standaloneHopDongBase = hopDongThuTienVersions
            .Where(v => v.HopDong!.DuAnId == null)
            .WhereIf(isBoPhanFilter, v => v.HopDong!.PhongBanPhuTrachChinhId == filterBoPhan)
            .Select(v => new
            {
                v.HopDongId,
                HopDongTen = v.HopDong!.Ten,
                PhongBanId = v.HopDong!.PhongBanPhuTrachChinhId,
                HopDongGiaTri = v.HopDong!.GiaTri
            })
            .Distinct();

        // ====== DUAN ROWS: Intermediate projection (anonymous type for Concat) ======
        var duAnIntermediate = duAnBase
            .LeftOuterJoin(daThuTienAgg, b => b.DuAnId, a => a.DuAnId,
                (b, a) => new { Base = b, DA_TT = a })
            .LeftOuterJoin(hdThuTienAgg, x => x.Base.HopDongId, a => (Guid?)a.HopDongId,
                (x, a) => new { x.Base, x.DA_TT, HD_TT = a })
            .LeftOuterJoin(daXhdAgg, x => x.Base.DuAnId, a => a.DuAnId,
                (x, a) => new { x.Base, x.DA_TT, x.HD_TT, DA_XHD = a })
            .LeftOuterJoin(hdXhdAgg, x => x.Base.HopDongId, a => (Guid?)a.HopDongId,
                (x, a) => new { x.Base, x.DA_TT, x.HD_TT, x.DA_XHD, HD_XHD = a })
            .LeftOuterJoin(hdCpAgg, x => x.Base.HopDongId, a => (Guid?)a.HopDongId,
                (x, a) => new { x.Base, x.DA_TT, x.HD_TT, x.DA_XHD, x.HD_XHD, HD_CP = a })
            .LeftOuterJoin(dmDonViQuery, x => x.Base.PhongBanId, d => d.Id,
                (x, d) => new
                {
                    PhongBanId = x.Base.PhongBanId,
                    TenPhongBan = d.TenDonVi,
                    DuAnId = x.Base.DuAnId,
                    DuAnTen = x.Base.DuAnTen,
                    GiaTriDuKien = x.Base.GiaTriDuKien,
                    HopDongId = x.Base.HopDongId,
                    HopDongTen = x.Base.HopDongTen,
                    HopDongGiaTri = x.Base.HopDongGiaTri,
                    DA_TT_KeHoach = x.DA_TT != null ? x.DA_TT.KeHoach : 0m,
                    DA_TT_ThucTe = x.DA_TT != null ? x.DA_TT.ThucTe : 0m,
                    HD_TT_KeHoach = x.HD_TT != null ? x.HD_TT.KeHoach : 0m,
                    HD_TT_ThucTe = x.HD_TT != null ? x.HD_TT.ThucTe : 0m,
                    DA_XHD_KeHoach = x.DA_XHD != null ? x.DA_XHD.KeHoach : 0m,
                    DA_XHD_ThucTe = x.DA_XHD != null ? x.DA_XHD.ThucTe : 0m,
                    HD_XHD_KeHoach = x.HD_XHD != null ? x.HD_XHD.KeHoach : 0m,
                    HD_XHD_ThucTe = x.HD_XHD != null ? x.HD_XHD.ThucTe : 0m,
                    HD_CP_KeHoach = x.HD_CP != null ? x.HD_CP.KeHoach : 0m,
                    HD_CP_ThucTe = x.HD_CP != null ? x.HD_CP.ThucTe : 0m
                });

        // ====== STANDALONE HOPDONG ROWS: Same intermediate shape ======
        var standaloneHopDongIntermediate = standaloneHopDongBase
            .LeftOuterJoin(hdThuTienAgg, b => b.HopDongId, a => a.HopDongId,
                (b, a) => new { Base = b, TT = a })
            .LeftOuterJoin(hdXhdAgg, x => x.Base.HopDongId, a => a.HopDongId,
                (x, a) => new { x.Base, x.TT, XHD = a })
            .LeftOuterJoin(hdCpAgg, x => x.Base.HopDongId, a => a.HopDongId,
                (x, a) => new { x.Base, x.TT, x.XHD, CP = a })
            .LeftOuterJoin(dmDonViQuery, x => x.Base.PhongBanId, d => d.Id,
                (x, d) => new
                {
                    PhongBanId = x.Base.PhongBanId,
                    TenPhongBan = d.TenDonVi,
                    DuAnId = Guid.Empty,
                    DuAnTen = "",
                    GiaTriDuKien = 0m,
                    HopDongId = (Guid?)x.Base.HopDongId,
                    HopDongTen = x.Base.HopDongTen,
                    HopDongGiaTri = (decimal?)x.Base.HopDongGiaTri,
                    DA_TT_KeHoach = 0m,
                    DA_TT_ThucTe = 0m,
                    HD_TT_KeHoach = x.TT != null ? x.TT.KeHoach : 0m,
                    HD_TT_ThucTe = x.TT != null ? x.TT.ThucTe : 0m,
                    DA_XHD_KeHoach = 0m,
                    DA_XHD_ThucTe = 0m,
                    HD_XHD_KeHoach = x.XHD != null ? x.XHD.KeHoach : 0m,
                    HD_XHD_ThucTe = x.XHD != null ? x.XHD.ThucTe : 0m,
                    HD_CP_KeHoach = x.CP != null ? x.CP.KeHoach : 0m,
                    HD_CP_ThucTe = x.CP != null ? x.CP.ThucTe : 0m
                });

        // ====== MATERIALIZE + CONCAT → FINAL PROJECTION → FILTER → SORT → PAGINATE ======
        // EF Core cannot translate Concat/Union across complex GroupJoin projections.
        // Materialize both sides first (pre-aggregated = small result set), then combine in memory.
        var duAnData = await duAnIntermediate.ToListAsync(cancellationToken);
        var standaloneData = await standaloneHopDongIntermediate.ToListAsync(cancellationToken);

        var allRows = duAnData.Concat(standaloneData)
            .Select(x => new ChiTietBoPhanDto
            {
                PhongBanId = x.PhongBanId,
                TenPhongBan = x.TenPhongBan ?? DefaultConstants.UNKNOWN,
                Id = x.HopDongId ?? x.DuAnId,
                Ten = x.HopDongId != null ? x.HopDongTen : x.DuAnTen,
                Loai = x.HopDongId != null ? LoaiDuAnHopDongConstants.HopDong : LoaiDuAnHopDongConstants.DuAn,
                DoanhSoKyKeHoach = x.GiaTriDuKien,
                DoanhSoKyThucTe = x.HopDongGiaTri ?? 0m,
                ThuTienKeHoach = x.DA_TT_KeHoach,
                ThuTienThucTe = x.HopDongId != null ? x.HD_TT_ThucTe : x.DA_TT_ThucTe,
                XuatHoaDonKeHoach = x.DA_XHD_KeHoach,
                XuatHoaDonThucTe = x.HopDongId != null ? x.HD_XHD_ThucTe : x.DA_XHD_ThucTe,
                ChiPhiKeHoach = x.HopDongId != null ? x.HD_CP_KeHoach : 0m,
                ChiPhiThucTe = x.HopDongId != null ? x.HD_CP_ThucTe : 0m
            })
            .Where(x =>
                x.DoanhSoKyKeHoach != 0 || x.DoanhSoKyThucTe != 0 ||
                x.ThuTienKeHoach != 0 || x.ThuTienThucTe != 0 ||
                x.XuatHoaDonKeHoach != 0 || x.XuatHoaDonThucTe != 0 ||
                x.ChiPhiKeHoach != 0 || x.ChiPhiThucTe != 0)
            .OrderByDescending(x => x.DoanhSoKyThucTe);

        return PaginatedList<ChiTietBoPhanDto>.Create(allRows, model.Skip(), model.Take());
    }
}
