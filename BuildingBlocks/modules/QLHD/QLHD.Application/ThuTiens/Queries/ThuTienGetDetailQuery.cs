using BuildingBlocks.Domain.ValueTypes;
using QLHD.Application.ThuTiens.DTOs;

namespace QLHD.Application.ThuTiens.Queries;

/// <summary>
/// Query lấy chi tiết thu tiền theo ID (từ DuAn_ThuTien hoặc HopDong_ThuTien)
/// Routing: Nếu HopDong có DuAnId → dùng DuAn_ThuTien, ngược lại dùng HopDong_ThuTien
/// </summary>
public record ThuTienGetDetailQuery(Guid Id) : IRequest<ThuTienDto>;

internal class ThuTienGetDetailQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<ThuTienGetDetailQuery, ThuTienDto> {
    private readonly IRepository<DuAn_ThuTien, Guid> _duAnThuTienRepository = serviceProvider.GetRequiredService<IRepository<DuAn_ThuTien, Guid>>();
    private readonly IRepository<HopDong_ThuTien, Guid> _hopDongThuTienRepository = serviceProvider.GetRequiredService<IRepository<HopDong_ThuTien, Guid>>();
    private readonly IRepository<HopDong, Guid> _hopDongRepository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();

    public async Task<ThuTienDto> Handle(ThuTienGetDetailQuery request, CancellationToken cancellationToken = default) {
        ThuTienDto? dto;
        var duAnThuTien = await _duAnThuTienRepository.GetQueryableSet()
            .Where(e => e.Id == request.Id)
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
            .FirstOrDefaultAsync(cancellationToken);

        dto = duAnThuTien ?? await _hopDongThuTienRepository.GetQueryableSet()
            .Where(e => e.Id == request.Id)
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
            .FirstOrDefaultAsync(cancellationToken);
        ManagedException.ThrowIfNull(dto, "Không tìm thấy thông tin thu tiền với ID đã cho");
        return dto;
    }
}