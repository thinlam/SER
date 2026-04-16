using BuildingBlocks.Application.Attachments.DTOs;
using QLHD.Application.HopDongs.DTOs;

namespace QLHD.Application.HopDongs.Queries;

public record HopDongGetListQuery(HopDongSearchModel SearchModel) : IRequest<PaginatedList<HopDongDto>>;

public record HopDongSearchModel : AggregateRootSearch, ISearchString {
    /// <summary>
    /// Filter by signing date range (NgayKy) - from date
    /// </summary>
    public DateOnly? TuNgayKy { get; set; }

    /// <summary>
    /// Filter by signing date range (NgayKy) - to date
    /// </summary>
    public DateOnly? DenNgayKy { get; set; }

    /// <summary>
    /// Filter by acceptance date range (NgayNghiemThu) - from date
    /// </summary>
    public DateOnly? TuNgayNghiemThu { get; set; }

    /// <summary>
    /// Filter by acceptance date range (NgayNghiemThu) - to date
    /// </summary>
    public DateOnly? DenNgayNghiemThu { get; set; }

    /// <summary>
    /// Filter by KhachHang (Customer)
    /// </summary>
    public Guid? KhachHangId { get; set; }

    /// <summary>
    /// Filter by LoaiHopDong (Contract type)
    /// </summary>
    public int? LoaiHopDongId { get; set; }

    /// <summary>
    /// Filter by TrangThai (Status)
    /// </summary>
    public int? TrangThaiId { get; set; }

    /// <summary>
    /// Filter by NguoiPhuTrach (Person in charge)
    /// </summary>
    public int? NguoiPhuTrachId { get; set; }

    /// <summary>
    /// Filter by NguoiTheoDoi (Supervisor)
    /// </summary>
    public int? NguoiTheoDoiId { get; set; }

    /// <summary>
    /// Filter by GiamDoc (Director)
    /// </summary>
    public int? GiamDocId { get; set; }

    /// <summary>
    /// Filter by PhongBan - matches PhongBanPhuTrachChinhId OR any PhongBanPhoiHops
    /// </summary>
    public List<long>? PhongBanIds { get; set; }


    /// <summary>
    /// Tên hợp đồng
    /// </summary>
    public string? TenHopDong { get; set; }


    /// <summary>
    /// Filter by PhongBanPhuTrachChinhId
    /// </summary>
    public long? PhongBanPhuTrachChinhId { get; set; }
}

internal class HopDongGetListQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<HopDongGetListQuery, PaginatedList<HopDongDto>> {
    private readonly IRepository<HopDong, Guid> _repository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
    private readonly IRepository<Attachment, Guid> _attachmentRepository = serviceProvider.GetRequiredService<IRepository<Attachment, Guid>>();

    public async Task<PaginatedList<HopDongDto>> Handle(HopDongGetListQuery request, CancellationToken cancellationToken = default) {
        var model = request.SearchModel;

        var query = _repository.GetQueryableSet()
            .Include(e => e.KhachHang)
            .Include(e => e.PhongBanPhoiHops)

            .WhereIf(!string.IsNullOrWhiteSpace(model.TenHopDong), e => e.Ten!.Contains(model.TenHopDong!))


            // Date range filters for NgayKy
            .WhereIf(model.TuNgayKy.HasValue, e => e.NgayKy >= model.TuNgayKy)
            .WhereIf(model.DenNgayKy.HasValue, e => e.NgayKy <= model.DenNgayKy)

            // Date range filters for NgayNghiemThu
            .WhereIf(model.TuNgayNghiemThu.HasValue, e => e.NgayNghiemThu >= model.TuNgayNghiemThu)
            .WhereIf(model.DenNgayNghiemThu.HasValue, e => e.NgayNghiemThu <= model.DenNgayNghiemThu)

            // FK filters
            .WhereIf(model.KhachHangId.HasValue, e => e.KhachHangId == model.KhachHangId!.Value)
            .WhereIf(model.LoaiHopDongId.HasValue, e => e.LoaiHopDongId == model.LoaiHopDongId!.Value)
            .WhereIf(model.TrangThaiId.HasValue, e => e.TrangThaiId == model.TrangThaiId!.Value)
            .WhereIf(model.NguoiPhuTrachId.HasValue, e => e.NguoiPhuTrachChinhId == model.NguoiPhuTrachId!.Value)
            .WhereIf(model.NguoiTheoDoiId.HasValue, e => e.NguoiTheoDoiId == model.NguoiTheoDoiId!.Value)
            .WhereIf(model.GiamDocId.HasValue, e => e.GiamDocId == model.GiamDocId!.Value)
            .WhereIf(model.PhongBanPhuTrachChinhId.HasValue, e => e.PhongBanPhuTrachChinhId == model.PhongBanPhuTrachChinhId!.Value)

            // PhongBanIds: match PhongBanPhuTrachChinhId OR any PhongBanPhoiHops
            .WhereIf(model.PhongBanIds != null && model.PhongBanIds.Count > 0, e => e.PhongBanPhoiHops != null && e.PhongBanPhoiHops.Any(p => model.PhongBanIds!.Contains(p.RightId)))

            // Text search across SoHopDong, Ten, TenKhachHang
            .WhereSearchString(model, e => e.SoHopDong, e => e.Ten, e => e.KhachHang != null ? e.KhachHang.Ten : null)
            .OrderByDescending(e => e.CreatedAt)
            .Select(e => new HopDongDto {
                Id = e.Id,
                SoHopDong = e.SoHopDong,
                Ten = e.Ten,
                DuAnId = e.DuAnId,
                KhachHangId = e.KhachHangId,
                NgayKy = e.NgayKy,
                SoNgay = e.SoNgay,
                NgayNghiemThu = e.NgayNghiemThu,
                LoaiHopDongId = e.LoaiHopDongId,
                TrangThaiHopDongId = e.TrangThaiId,
                NguoiPhuTrachChinhId = e.NguoiPhuTrachChinhId,
                NguoiTheoDoiId = e.NguoiTheoDoiId,
                GiamDocId = e.GiamDocId,
                GiaTri = e.GiaTri,
                TienThue = e.TienThue,
                GiaTriSauThue = e.GiaTriSauThue,
                PhongBanPhuTrachChinhId = e.PhongBanPhuTrachChinhId,
                GiaTriBaoLanh = e.GiaTriBaoLanh,
                NgayBaoLanhTu = e.NgayBaoLanhTu,
                NgayBaoLanhDen = e.NgayBaoLanhDen,
                ThoiHanBaoHanh = e.ThoiHanBaoHanh,
                NgayBaoHanhTu = e.NgayBaoHanhTu,
                NgayBaoHanhDen = e.NgayBaoHanhDen,
                GhiChu = e.GhiChu,
                TienDo = e.TienDo,
                TenKhachHang = e.KhachHang!.Ten,
                PhongBanPhoiHopIds = e.PhongBanPhoiHops != null ? e.PhongBanPhoiHops.Select(p => p.RightId).ToList() : null,
                DanhSachTepDinhKem = _attachmentRepository.GetQueryableSet().Where(f => f.GroupId == e.Id.ToString()).Select(f => f.ToDto()).ToList()
            });

        return await query.PaginatedListAsync(model.Skip(), model.Take(), cancellationToken: cancellationToken);
    }
}