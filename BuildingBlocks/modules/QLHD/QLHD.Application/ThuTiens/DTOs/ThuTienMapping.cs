using BuildingBlocks.Domain.ValueTypes;

namespace QLHD.Application.ThuTiens.DTOs;

public static class ThuTienMapping {
    public static ThuTienDto ToDto(this DuAn_ThuTien e)
        => new() {
            Id = e.Id,
            DuAnId = e.DuAnId,
            HopDongId = e.HopDongId,
            LoaiThanhToanId = e.LoaiThanhToanId,
            TenLoaiThanhToan = e.LoaiThanhToan?.Ten,
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
            TenDuAn = e.DuAn?.Ten,
            TenHopDong = e.HopDong?.Ten,
            SoHopDong = e.HopDong?.SoHopDong,
            TenKhachHang = e.HopDong?.KhachHang?.Ten,
            IsDuAnOwned = true
        };
    public static ThuTienDto ToDto(this HopDong_ThuTien e)
        => new() {
            Id = e.Id,
            HopDongId = e.HopDongId,
            LoaiThanhToanId = e.LoaiThanhToanId,
            TenLoaiThanhToan = e.LoaiThanhToan?.Ten,
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
            TenHopDong = e.HopDong?.Ten,
            SoHopDong = e.HopDong?.SoHopDong,
            TenKhachHang = e.HopDong?.KhachHang?.Ten,
            IsDuAnOwned = false
        };
}