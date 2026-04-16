using BuildingBlocks.Domain.ValueTypes;
using QLHD.Domain.Entities;

namespace QLHD.Application.HopDongs.DTOs;

public static class HopDongMapping {
    public static HopDong ToEntity(this HopDongInsertModel model) => new() {
        SoHopDong = model.SoHopDong ?? string.Empty,
        Ten = model.Ten ?? string.Empty,
        DuAnId = model.DuAnId,
        KhachHangId = model.KhachHangId,
        NgayKy = model.NgayKy,
        SoNgay = model.SoNgay,
        NgayNghiemThu = model.NgayNghiemThu,
        LoaiHopDongId = model.LoaiHopDongId,
        TrangThaiId = model.TrangThaiHopDongId,
        NguoiPhuTrachChinhId = model.NguoiPhuTrachChinhId,
        NguoiTheoDoiId = model.NguoiTheoDoiId,
        GiamDocId = model.GiamDocId,
        GiaTri = model.GiaTri,
        TienThue = model.TienThue,
        GiaTriSauThue = model.GiaTriSauThue,
        PhongBanPhuTrachChinhId = model.PhongBanPhuTrachChinhId,
        GiaTriBaoLanh = model.GiaTriBaoLanh,
        NgayBaoLanhTu = model.NgayBaoLanhTu,
        NgayBaoLanhDen = model.NgayBaoLanhDen,
        ThoiHanBaoHanh = model.ThoiHanBaoHanh ?? 0,
        NgayBaoHanhTu = model.NgayBaoHanhTu,
        NgayBaoHanhDen = model.NgayBaoHanhDen,
        GhiChu = model.GhiChu,
        TienDo = model.TienDo
    };

    public static void UpdateFrom(this HopDong entity, HopDongUpdateModel model) {
        entity.SoHopDong = model.SoHopDong ?? string.Empty;
        entity.Ten = model.Ten ?? string.Empty;
        // DuAnId is not editable after insert - immutable
        entity.KhachHangId = model.KhachHangId;
        entity.NgayKy = model.NgayKy;
        entity.SoNgay = model.SoNgay;
        entity.NgayNghiemThu = model.NgayNghiemThu;
        entity.LoaiHopDongId = model.LoaiHopDongId;
        entity.TrangThaiId = model.TrangThaiHopDongId;
        entity.NguoiPhuTrachChinhId = model.NguoiPhuTrachChinhId;
        entity.NguoiTheoDoiId = model.NguoiTheoDoiId;
        entity.GiamDocId = model.GiamDocId;
        entity.GiaTri = model.GiaTri;
        entity.TienThue = model.TienThue;
        entity.GiaTriSauThue = model.GiaTriSauThue;
        entity.PhongBanPhuTrachChinhId = model.PhongBanPhuTrachChinhId;
        entity.GiaTriBaoLanh = model.GiaTriBaoLanh;
        entity.NgayBaoLanhTu = model.NgayBaoLanhTu;
        entity.NgayBaoLanhDen = model.NgayBaoLanhDen;
        entity.ThoiHanBaoHanh = model.ThoiHanBaoHanh ?? 0;
        entity.NgayBaoHanhTu = model.NgayBaoHanhTu;
        entity.NgayBaoHanhDen = model.NgayBaoHanhDen;
        entity.GhiChu = model.GhiChu;
        entity.TienDo = model.TienDo;
    }

    /// <summary>
    /// Creates junction entities for PhongBanPhoiHop
    /// </summary>
    public static List<HopDongPhongBanPhoiHop> ToPhongBanPhoiHopEntities(this List<long> phongBanIds, Guid hopDongId)
        => [.. phongBanIds.Select(phongBanId => new HopDongPhongBanPhoiHop
        {
            LeftId = hopDongId,
            RightId = phongBanId,
        })];

    /// <summary>
    /// Creates junction entities with TenPhongBan
    /// </summary>
    public static List<HopDongPhongBanPhoiHop> ToPhongBanPhoiHopEntities(
        this Dictionary<long, string> phongBans,
        Guid hopDongId)
        => [.. phongBans.Select(kv => new HopDongPhongBanPhoiHop
        {
            LeftId = hopDongId,
            RightId = kv.Key,
            TenPhongBan = kv.Value,
        })];

    public static HopDongPhongBanPhoiHopDto ToDto(this HopDongPhongBanPhoiHop entity)
        => new() {
            PhongBanId = entity.RightId,
            TenPhongBan = entity.TenPhongBan
        };

    #region HopDong_ThuTien (merged Plan+Actual)

    public static HopDong_ThuTienSimpleDto ToDto(this HopDong_ThuTien entity)
        => new() {
            Id = entity.Id,
            LoaiThanhToanId = entity.LoaiThanhToanId,
            TenLoaiThanhToan = entity.LoaiThanhToan?.Ten,
            // Kế hoạch
            ThoiGianKeHoach = MonthYear.FromDateOnly(entity.ThoiGianKeHoach),
            PhanTramKeHoach = entity.PhanTramKeHoach,
            GiaTriKeHoach = entity.GiaTriKeHoach,
            GhiChuKeHoach = entity.GhiChuKeHoach,
            // Thực tế
            ThoiGianThucTe = entity.ThoiGianThucTe,
            GiaTriThucTe = entity.GiaTriThucTe,
            GhiChuThucTe = entity.GhiChuThucTe,
            SoHoaDon = entity.SoHoaDon,
            KyHieuHoaDon = entity.KyHieuHoaDon,
            NgayHoaDon = entity.NgayHoaDon
        };

    #endregion

    #region HopDong_XuatHoaDon (merged Plan+Actual)

    public static HopDong_XuatHoaDonSimpleDto ToDto(this HopDong_XuatHoaDon entity)
        => new() {
            Id = entity.Id,
            LoaiThanhToanId = entity.LoaiThanhToanId,
            TenLoaiThanhToan = entity.LoaiThanhToan?.Ten,
            // Kế hoạch
            ThoiGianKeHoach = MonthYear.FromDateOnly(entity.ThoiGianKeHoach),
            PhanTramKeHoach = entity.PhanTramKeHoach,
            GiaTriKeHoach = entity.GiaTriKeHoach,
            GhiChuKeHoach = entity.GhiChuKeHoach,
            // Thực tế
            ThoiGianThucTe = entity.ThoiGianThucTe,
            GiaTriThucTe = entity.GiaTriThucTe,
            GhiChuThucTe = entity.GhiChuThucTe,
            SoHoaDon = entity.SoHoaDon,
            KyHieuHoaDon = entity.KyHieuHoaDon,
            NgayHoaDon = entity.NgayHoaDon
        };

    #endregion
}