using QLHD.Application.DuAn_ThuTiens.DTOs;
using QLHD.Application.DuAn_XuatHoaDons.DTOs;

namespace QLHD.Application.DuAns.DTOs;

/// <summary>
/// Display names fetched from navigation entities for DuAnDto.
/// </summary>
public record DuAnDisplayNames(
    string TenKhachHang,
    string? TenTrangThai,
    string? TenPhongBanPhuTrachChinh,
    string TenNguoiPhuTrach,
    string? TenNguoiTheoDoi,
    string? TenGiamDoc);

public static class DuAnMapping {
    /// <summary>
    /// Converts DuAn entity to DuAnDto with child collections.
    /// Navigation display names (TenKhachHang, TenTrangThai, etc.) are not populated.
    /// </summary>
    public static DuAnDto ToDto(this DuAn entity) => new() {
        Id = entity.Id,
        Ten = entity.Ten,
        KhachHangId = entity.KhachHangId,
        NgayLap = entity.NgayLap,
        GiaTriDuKien = entity.GiaTriDuKien,
        ThoiGianDuKien = entity.ThoiGianDuKien,
        PhongBanPhuTrachChinhId = entity.PhongBanPhuTrachChinhId,
        NguoiPhuTrachChinhId = entity.NguoiPhuTrachChinhId,
        NguoiTheoDoiId = entity.NguoiTheoDoiId,
        GiamDocId = entity.GiamDocId,
        GiaVon = entity.GiaVon,
        ThanhTien = entity.ThanhTien,
        TrangThaiId = entity.TrangThaiId,
        HasHopDong = entity.HasHopDong,
        GhiChu = entity.GhiChu,
        // Child collections (merged Plan+Actual)
        PhongBanPhoiHopIds = entity.PhongBanPhoiHops?.Select(p => p.RightId).ToList(),
        PhongBanPhoiHops = entity.PhongBanPhoiHops?.Select(p => p.ToDto()).ToList(),
        KeHoachThuTiens = entity.DuAn_ThuTiens?.Select(t => t.ToDto()).ToList(),
        KeHoachXuatHoaDons = entity.DuAn_XuatHoaDons?.Select(t => t.ToDto()).ToList()
    };

    /// <summary>
    /// Converts DuAn entity to DuAnDto with display names from navigation entities.
    /// Use this method when returning DTO from Insert/Update handlers.
    /// </summary>
    public static DuAnDto ToFullDto(this DuAn entity, DuAnDisplayNames displayNames) {
        var dto = entity.ToDto();
        dto.TenKhachHang = displayNames.TenKhachHang;
        dto.TenTrangThai = displayNames.TenTrangThai;
        dto.TenPhongBanPhuTrachChinh = displayNames.TenPhongBanPhuTrachChinh;
        dto.TenNguoiPhuTrach = displayNames.TenNguoiPhuTrach;
        dto.TenNguoiTheoDoi = displayNames.TenNguoiTheoDoi;
        dto.TenGiamDoc = displayNames.TenGiamDoc;
        return dto;
    }

    public static DuAn ToEntity(this DuAnInsertModel model, int defaultTrangThaiId) => new() {
        Ten = model.Ten,
        KhachHangId = model.KhachHangId,
        NgayLap = model.NgayLap,
        GiaTriDuKien = model.GiaTriDuKien,
        ThoiGianDuKien = model.ThoiGianDuKien,
        PhongBanPhuTrachChinhId = model.PhongBanPhuTrachChinhId,
        NguoiPhuTrachChinhId = model.NguoiPhuTrachChinhId,
        NguoiTheoDoiId = model.NguoiTheoDoiId,
        GiamDocId = model.GiamDocId,
        GiaVon = model.GiaVon,
        ThanhTien = model.ThanhTien,
        TrangThaiId = model.TrangThaiId ?? defaultTrangThaiId,
        GhiChu = model.GhiChu,
        // Child collections will be set by command handler with DuAnId
    };

    public static void UpdateFrom(this DuAn entity, DuAnUpdateModel model) {
        entity.Ten = model.Ten;
        entity.KhachHangId = model.KhachHangId;
        entity.NgayLap = model.NgayLap;
        entity.GiaTriDuKien = model.GiaTriDuKien;
        entity.ThoiGianDuKien = model.ThoiGianDuKien;
        entity.PhongBanPhuTrachChinhId = model.PhongBanPhuTrachChinhId;
        entity.NguoiPhuTrachChinhId = model.NguoiPhuTrachChinhId;
        entity.NguoiTheoDoiId = model.NguoiTheoDoiId;
        entity.GiamDocId = model.GiamDocId;
        entity.GiaVon = model.GiaVon;
        entity.ThanhTien = model.ThanhTien;
        entity.TrangThaiId = model.TrangThaiId;
        entity.GhiChu = model.GhiChu;
    }

    #region PhongBanPhoiHop

    /// <summary>
    /// Creates junction entities with TenPhongBan
    /// </summary>
    public static List<DuAnPhongBanPhoiHop> ToPhongBanPhoiHopEntities(
        this Dictionary<long, string> phongBans,
        Guid duAnId)
        => [.. phongBans.Select(kv => new DuAnPhongBanPhoiHop
        {
            LeftId = duAnId,
            RightId = kv.Key,
            TenPhongBan = kv.Value
        })];
    public static DuAnPhongBanPhoiHopDto ToDto(this DuAnPhongBanPhoiHop entity)
        => new() {
            PhongBanId = entity.RightId,
            TenPhongBan = entity.TenPhongBan
        };
    #endregion

    #region DuAn_ThuTien

    /// <summary>
    /// Converts model to entity. DuAnId is set from parent context.
    /// If Id is null or empty, entity will have auto-generated Id (for Add).
    /// If Id has value, it will be preserved (for Update).
    /// </summary>
    public static DuAn_ThuTien ToEntity(this DuAn_ThuTienInsertModel model, Guid duAnId) {
        var entity = new DuAn_ThuTien {
            DuAnId = duAnId,
            LoaiThanhToanId = model.LoaiThanhToanId,
            ThoiGianKeHoach = model.ThoiGianKeHoach.ToDateOnly(),
            PhanTramKeHoach = model.PhanTramKeHoach,
            GiaTriKeHoach = model.GiaTriKeHoach,
            GhiChuKeHoach = model.GhiChuKeHoach,
            GhiChuThucTe = model.GhiChuThucTe
        };
        // Only set Id if provided (for update scenario)
        if (model.Id.HasValue && model.Id.Value != Guid.Empty) {
            entity.Id = model.Id.Value;
        }
        return entity;
    }

    #endregion

    #region DuAn_XuatHoaDon

    /// <summary>
    /// Converts model to entity. DuAnId is set from parent context.
    /// If Id is null or empty, entity will have auto-generated Id (for Add).
    /// If Id has value, it will be preserved (for Update).
    /// </summary>
    public static DuAn_XuatHoaDon ToEntity(this DuAn_XuatHoaDonInsertModel model, Guid duAnId) {
        var entity = new DuAn_XuatHoaDon {
            DuAnId = duAnId,
            LoaiThanhToanId = model.LoaiThanhToanId,
            ThoiGianKeHoach = model.ThoiGianKeHoach.ToDateOnly(),
            PhanTramKeHoach = model.PhanTramKeHoach,
            GiaTriKeHoach = model.GiaTriKeHoach,
            GhiChuKeHoach = model.GhiChuKeHoach,
            GhiChuThucTe = model.GhiChuThucTe
        };
        // Only set Id if provided (for update scenario)
        if (model.Id.HasValue && model.Id.Value != Guid.Empty) {
            entity.Id = model.Id.Value;
        }
        return entity;
    }

    #endregion
}