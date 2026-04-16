namespace QLHD.Application.DuAns.Queries;

public record DuAnGetListQuery(DuAnSearchModel SearchModel) : IRequest<PaginatedList<DuAnDto>>;

public record DuAnSearchModel : AggregateRootSearch, ISearchString {
    /// <summary>
    /// Filter by expected completion date range (ThoiGianDuKien) - from date
    /// </summary>
    public DateOnly? TuNgayDuKien { get; set; }

    /// <summary>
    /// Filter by expected completion date range (ThoiGianDuKien) - to date
    /// </summary>
    public DateOnly? DenNgayDuKien { get; set; }

    /// <summary>
    /// Filter by GiamDoc (Director)
    /// </summary>
    public int? GiamDocId { get; set; }

    /// <summary>
    /// Filter by PhongBan - matches PhongBanPhuTrachChinhId OR any PhongBanPhoiHops
    /// </summary>
    public List<long>? PhongBanIds { get; set; }

    /// <summary>
    /// Filter by NguoiPhuTrach (Person in charge)
    /// </summary>
    public int? NguoiPhuTrachId { get; set; }

    /// <summary>
    /// Filter by NguoiTheoDoi (Supervisor)
    /// </summary>
    public int? NguoiTheoDoiId { get; set; }

    /// <summary>
    /// Filter by KhachHang (Customer)
    /// </summary>
    public Guid? KhachHangId { get; set; }

    /// <summary>
    /// Filter by TrangThai (Status) - maps to TrangThaiId
    /// </summary>
    public int? TrangThaiId { get; set; }
    /// <summary>
    /// Tên dự án
    /// </summary>
    public string? TenDuAn { get; set; }


    /// <summary>
    /// Filter by PhongBanPhuTrachChinhId
    /// </summary>
    public long? PhongBanPhuTrachChinhId { get; set; }
}

internal class DuAnGetListQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DuAnGetListQuery, PaginatedList<DuAnDto>> {
    private readonly IRepository<DuAn, Guid> _repository = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();

    public async Task<PaginatedList<DuAnDto>> Handle(DuAnGetListQuery request, CancellationToken cancellationToken = default) {
        var model = request.SearchModel;

        var query = _repository.GetQueryableSet()
            .Include(e => e.PhongBanPhoiHops)
            .Where(e => !e.HasHopDong) // Hide DuAn that already have HopDong
            .WhereIf(!string.IsNullOrWhiteSpace(model.TenDuAn), e => e.Ten!.Contains(model.TenDuAn!))

            // Date range filters for ThoiGianDuKien
            .WhereIf(model.TuNgayDuKien.HasValue, e => e.ThoiGianDuKien >= model.TuNgayDuKien)
            .WhereIf(model.DenNgayDuKien.HasValue, e => e.ThoiGianDuKien <= model.DenNgayDuKien)

            // FK filters
            .WhereIf(model.GiamDocId.HasValue, e => e.GiamDocId == model.GiamDocId!.Value)
            .WhereIf(model.NguoiPhuTrachId.HasValue, e => e.NguoiPhuTrachChinhId == model.NguoiPhuTrachId!.Value)
            .WhereIf(model.NguoiTheoDoiId.HasValue, e => e.NguoiTheoDoiId == model.NguoiTheoDoiId!.Value)
            .WhereIf(model.KhachHangId.HasValue, e => e.KhachHangId == model.KhachHangId!.Value)
            .WhereIf(model.TrangThaiId.HasValue, e => e.TrangThaiId == model.TrangThaiId!.Value)
            .WhereIf(model.PhongBanPhuTrachChinhId.HasValue, e => e.PhongBanPhuTrachChinhId == model.PhongBanPhuTrachChinhId!.Value)

            // PhongBanIds: match PhongBanPhuTrachChinhId OR any PhongBanPhoiHops
            .WhereIf(model.PhongBanIds != null && model.PhongBanIds.Count > 0, e => e.PhongBanPhoiHops != null && e.PhongBanPhoiHops.Any(p => model.PhongBanIds!.Contains(p.RightId)))

            // Text search
            .WhereSearchString(model, e => e.Ten, e => e.KhachHang != null ? e.KhachHang.Ten : null)
            .OrderByDescending(e => e.CreatedAt)
            .Select(e => new DuAnDto {
                Id = e.Id,
                Ten = e.Ten,
                KhachHangId = e.KhachHangId,
                TenKhachHang = e.KhachHang!.Ten,
                NgayLap = e.NgayLap,
                GiaTriDuKien = e.GiaTriDuKien,
                ThoiGianDuKien = e.ThoiGianDuKien,
                PhongBanPhuTrachChinhId = e.PhongBanPhuTrachChinhId,
                NguoiPhuTrachChinhId = e.NguoiPhuTrachChinhId,
                NguoiTheoDoiId = e.NguoiTheoDoiId,
                GiamDocId = e.GiamDocId,
                GiaVon = e.GiaVon,
                ThanhTien = e.ThanhTien,
                TrangThaiId = e.TrangThaiId,
                HasHopDong = e.HasHopDong,
                GhiChu = e.GhiChu,
                TenNguoiPhuTrach = e.NguoiPhuTrach!.Ten,
                TenNguoiTheoDoi = e.NguoiTheoDoi != null ? e.NguoiTheoDoi.Ten : null,
                TenGiamDoc = e.GiamDoc != null ? e.GiamDoc.Ten : null,
                TenTrangThai = e.TrangThai != null ? e.TrangThai.Ten : null,
                PhongBanPhoiHopIds = e.PhongBanPhoiHops != null ? e.PhongBanPhoiHops.Select(p => p.RightId).ToList() : null
            });

        return await query.PaginatedListAsync(model.Skip(), model.Take(), cancellationToken: cancellationToken);
    }
}