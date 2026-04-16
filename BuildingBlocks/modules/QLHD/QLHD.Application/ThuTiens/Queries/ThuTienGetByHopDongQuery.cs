using BuildingBlocks.Domain.ValueTypes;
using QLHD.Application.ThuTiens.DTOs;

namespace QLHD.Application.ThuTiens.Queries;

/// <summary>
/// Query lấy danh sách thu tiền (plan + actual) theo HopDongId
/// Routing: Nếu HopDong có DuAnId → dùng DuAn_ThuTien, ngược lại dùng HopDong_ThuTien
/// </summary>
public record ThuTienGetByHopDongQuery(Guid HopDongId) : IRequest<List<ThuTienDto>>;

internal class ThuTienGetByHopDongQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<ThuTienGetByHopDongQuery, List<ThuTienDto>> {
    private readonly IRepository<HopDong, Guid> _hopDongRepository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
    private readonly IRepository<DuAn_ThuTien, Guid> _duAnThuTienRepository = serviceProvider.GetRequiredService<IRepository<DuAn_ThuTien, Guid>>();
    private readonly IRepository<HopDong_ThuTien, Guid> _hopDongThuTienRepository = serviceProvider.GetRequiredService<IRepository<HopDong_ThuTien, Guid>>();

    public async Task<List<ThuTienDto>> Handle(ThuTienGetByHopDongQuery request, CancellationToken cancellationToken = default) {
        // Get HopDong to determine routing
        var hopDong = await _hopDongRepository.GetQueryableSet()
            .FirstOrDefaultAsync(h => h.Id == request.HopDongId, cancellationToken);
        ManagedException.ThrowIfNull(hopDong, "Không tìm thấy hợp đồng");

        // Routing: DuAnId.HasValue → DuAn_ThuTien, else → HopDong_ThuTien
        if (hopDong.DuAnId.HasValue) {
            // Query from DuAn_ThuTien (merged entity with plan + actual)
            return await _duAnThuTienRepository.GetQueryableSet()
                .Where(k => k.DuAnId == hopDong.DuAnId.Value)
                .OrderBy(k => k.ThoiGianKeHoach)
                .Select(e => new ThuTienDto {
                    Id = e.Id,
                    DuAnId = e.DuAnId,
                    HopDongId = e.HopDongId,
                    LoaiThanhToanId = e.LoaiThanhToanId,
                    TenLoaiThanhToan = e.LoaiThanhToan!.Ten,
                    // Plan fields
                    ThoiGianKeHoach = MonthYear.FromDateOnly(e.ThoiGianKeHoach),
                    PhanTramKeHoach = e.PhanTramKeHoach,
                    GiaTriKeHoach = e.GiaTriKeHoach,
                    GhiChuKeHoach = e.GhiChuKeHoach,
                    GhiChuThucTe = e.GhiChuThucTe,
                    // Actual fields (nullable)
                    ThoiGianThucTe = e.ThoiGianThucTe,
                    GiaTriThucTe = e.GiaTriThucTe,
                    SoHoaDon = e.SoHoaDon,
                    KyHieuHoaDon = e.KyHieuHoaDon,
                    NgayHoaDon = e.NgayHoaDon,
                    // Thong tin chung
                    TenDuAn = e.DuAn!.Ten,
                    TenHopDong = e.HopDong!.Ten,
                    SoHopDong = e.HopDong!.SoHopDong,
                    TenKhachHang = e.HopDong!.KhachHang!.Ten,
                    IsDuAnOwned = true
                })
                .ToListAsync(cancellationToken);
        } else {
            // Query from HopDong_ThuTien (merged entity with plan + actual)
            return await _hopDongThuTienRepository.GetQueryableSet()
                .Where(k => k.HopDongId == hopDong.Id)
                .OrderBy(k => k.ThoiGianKeHoach)
                .Select(e => new ThuTienDto {

                    Id = e.Id,
                    HopDongId = e.HopDongId,
                    LoaiThanhToanId = e.LoaiThanhToanId,
                    TenLoaiThanhToan = e.LoaiThanhToan!.Ten,
                    // Plan fields
                    ThoiGianKeHoach = MonthYear.FromDateOnly(e.ThoiGianKeHoach),
                    PhanTramKeHoach = e.PhanTramKeHoach,
                    GiaTriKeHoach = e.GiaTriKeHoach,
                    GhiChuKeHoach = e.GhiChuKeHoach,
                    GhiChuThucTe = e.GhiChuThucTe,
                    // Actual fields (nullable)
                    ThoiGianThucTe = e.ThoiGianThucTe,
                    GiaTriThucTe = e.GiaTriThucTe,
                    SoHoaDon = e.SoHoaDon,
                    KyHieuHoaDon = e.KyHieuHoaDon,
                    NgayHoaDon = e.NgayHoaDon,
                    // Thong tin chung
                    TenHopDong = e.HopDong!.Ten,
                    SoHopDong = e.HopDong!.SoHopDong,
                    TenKhachHang = e.HopDong!.KhachHang!.Ten,
                    IsDuAnOwned = false
                })
                .ToListAsync(cancellationToken);
        }
    }
}