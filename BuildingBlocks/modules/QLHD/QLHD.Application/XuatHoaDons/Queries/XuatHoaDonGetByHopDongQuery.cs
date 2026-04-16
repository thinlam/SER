using BuildingBlocks.Domain.ValueTypes;
using QLHD.Application.XuatHoaDons.DTOs;

namespace QLHD.Application.XuatHoaDons.Queries;

/// <summary>
/// Query lấy danh sách xuất hóa đơn theo HopDongId (merged entity structure)
/// </summary>
public record XuatHoaDonGetByHopDongQuery(Guid HopDongId) : IRequest<List<XuatHoaDonDto>>;

internal class XuatHoaDonGetByHopDongQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<XuatHoaDonGetByHopDongQuery, List<XuatHoaDonDto>> {
    private readonly IRepository<HopDong, Guid> _hopDongRepository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
    private readonly IRepository<DuAn_XuatHoaDon, Guid> _duAnXuatHoaDonRepository = serviceProvider.GetRequiredService<IRepository<DuAn_XuatHoaDon, Guid>>();
    private readonly IRepository<HopDong_XuatHoaDon, Guid> _hopDongXuatHoaDonRepository = serviceProvider.GetRequiredService<IRepository<HopDong_XuatHoaDon, Guid>>();

    public async Task<List<XuatHoaDonDto>> Handle(XuatHoaDonGetByHopDongQuery request, CancellationToken cancellationToken = default) {
        // Get HopDong to determine routing
        var hopDong = await _hopDongRepository.GetQueryableSet()
            .FirstOrDefaultAsync(h => h.Id == request.HopDongId, cancellationToken);
        ManagedException.ThrowIfNull(hopDong, "Không tìm thấy hợp đồng");

        // Routing: DuAnId.HasValue → DuAn_XuatHoaDon, else → HopDong_XuatHoaDon
        if (hopDong.DuAnId.HasValue) {
            // Query from DuAn_XuatHoaDon (merged entity with plan + actual)
            return await _duAnXuatHoaDonRepository.GetQueryableSet()
                .Where(k => k.DuAnId == hopDong.DuAnId)
                .OrderBy(k => k.ThoiGianKeHoach)
                .Select(e => new XuatHoaDonDto {
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
            // Query from HopDong_XuatHoaDon (merged entity with plan + actual)
            return await _hopDongXuatHoaDonRepository.GetQueryableSet()
                .Where(k => k.HopDongId == hopDong.Id)
                .OrderBy(k => k.ThoiGianKeHoach)
                .Select(e => new XuatHoaDonDto {
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