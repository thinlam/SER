using BuildingBlocks.Domain.ValueTypes;
using QLHD.Application.XuatHoaDons.DTOs;

namespace QLHD.Application.XuatHoaDons.Queries;

/// <summary>
/// Query lấy chi tiết xuất hóa đơn theo Id (unified routing)
/// - Nếu entity có DuAnId → DuAn_XuatHoaDon
/// - Nếu entity có HopDongId (no DuAnId) → HopDong_XuatHoaDon
/// </summary>
public record XuatHoaDonGetDetailQuery(Guid Id) : IRequest<XuatHoaDonDto>;

internal class XuatHoaDonGetDetailQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<XuatHoaDonGetDetailQuery, XuatHoaDonDto> {
    private readonly IRepository<HopDong, Guid> _hopDongRepository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
    private readonly IRepository<DuAn_XuatHoaDon, Guid> _duAnXuatHoaDonRepository = serviceProvider.GetRequiredService<IRepository<DuAn_XuatHoaDon, Guid>>();
    private readonly IRepository<HopDong_XuatHoaDon, Guid> _hopDongXuatHoaDonRepository = serviceProvider.GetRequiredService<IRepository<HopDong_XuatHoaDon, Guid>>();

    public async Task<XuatHoaDonDto> Handle(XuatHoaDonGetDetailQuery request, CancellationToken cancellationToken = default) {
        XuatHoaDonDto? dto;
        var duAnXuatHoaDon = await _duAnXuatHoaDonRepository.GetQueryableSet()
            .Where(e => e.Id == request.Id)
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
            .FirstOrDefaultAsync(cancellationToken);

        dto = duAnXuatHoaDon ?? await _hopDongXuatHoaDonRepository.GetQueryableSet()
            .Where(e => e.Id == request.Id)
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
            .FirstOrDefaultAsync(cancellationToken);
        ManagedException.ThrowIfNull(dto, "Không tìm thấy thông tin thu tiền với ID đã cho");
        return dto;
    }
}