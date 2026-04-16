using BuildingBlocks.Domain.ValueTypes;

namespace QLHD.Application.XuatHoaDons.DTOs;

public static class XuatHoaDonMapping {

    public static XuatHoaDonDto ToDto(this DuAn_XuatHoaDon entity)
        => new() {
            Id = entity.Id,
            DuAnId = entity.DuAnId,
            HopDongId = entity.HopDongId,
            LoaiThanhToanId = entity.LoaiThanhToanId,
            TenLoaiThanhToan = entity.LoaiThanhToan?.Ten,
            // Plan fields
            ThoiGianKeHoach = MonthYear.FromDateOnly(entity.ThoiGianKeHoach),
            PhanTramKeHoach = entity.PhanTramKeHoach,
            GiaTriKeHoach = entity.GiaTriKeHoach,
            GhiChuKeHoach = entity.GhiChuKeHoach,
            GhiChuThucTe = entity.GhiChuThucTe,
            // Actual fields (nullable)
            ThoiGianThucTe = entity.ThoiGianThucTe,
            GiaTriThucTe = entity.GiaTriThucTe,
            SoHoaDon = entity.SoHoaDon,
            KyHieuHoaDon = entity.KyHieuHoaDon,
            NgayHoaDon = entity.NgayHoaDon,
            // Thong tin chung
            TenDuAn = entity.DuAn?.Ten,
            TenHopDong = entity.HopDong?.Ten,
            SoHopDong = entity.HopDong?.SoHopDong,
            TenKhachHang = entity.HopDong?.KhachHang?.Ten,
            IsDuAnOwned = true
        };

    public static XuatHoaDonDto ToDto(this HopDong_XuatHoaDon entity)
        => new() {
            Id = entity.Id,
            HopDongId = entity.HopDongId,
            LoaiThanhToanId = entity.LoaiThanhToanId,
            TenLoaiThanhToan = entity.LoaiThanhToan?.Ten,
            // Plan fields
            ThoiGianKeHoach = MonthYear.FromDateOnly(entity.ThoiGianKeHoach),
            PhanTramKeHoach = entity.PhanTramKeHoach,
            GiaTriKeHoach = entity.GiaTriKeHoach,
            GhiChuKeHoach = entity.GhiChuKeHoach,
            GhiChuThucTe = entity.GhiChuThucTe,
            // Actual fields (nullable)
            ThoiGianThucTe = entity.ThoiGianThucTe,
            GiaTriThucTe = entity.GiaTriThucTe,
            SoHoaDon = entity.SoHoaDon,
            KyHieuHoaDon = entity.KyHieuHoaDon,
            NgayHoaDon = entity.NgayHoaDon,
            // Thong tin chung
            TenHopDong = entity.HopDong?.Ten,
            SoHopDong = entity.HopDong?.SoHopDong,
            TenKhachHang = entity.HopDong?.KhachHang?.Ten,
            IsDuAnOwned = false
        };
}