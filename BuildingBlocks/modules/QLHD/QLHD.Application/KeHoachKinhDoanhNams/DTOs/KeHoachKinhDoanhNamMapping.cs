namespace QLHD.Application.KeHoachKinhDoanhNams.DTOs;

public static class KeHoachKinhDoanhNamMapping {
    public static KeHoachKinhDoanhNamDto ToDto(this KeHoachKinhDoanhNam entity) => new() {
        Id = entity.Id,
        BatDau = entity.BatDau,
        KetThuc = entity.KetThuc,
        GhiChu = entity.GhiChu,
        BoPhans = entity.KeHoachKinhDoanhNam_BoPhans?.Select(b => b.ToDto()).ToList(),
        CaNhans = entity.KeHoachKinhDoanhNam_CaNhans?.Select(c => c.ToDto()).ToList()
    };

    public static KeHoachKinhDoanhNam ToEntity(this KeHoachKinhDoanhNamInsertModel model) => new() {
        BatDau = model.BatDau,
        KetThuc = model.KetThuc,
        GhiChu = model.GhiChu
    };

    public static void UpdateFrom(this KeHoachKinhDoanhNam entity, KeHoachKinhDoanhNamUpdateModel model) {
        entity.BatDau = model.BatDau;
        entity.KetThuc = model.KetThuc;
        entity.GhiChu = model.GhiChu;
    }

    #region BoPhan

    public static KeHoachKinhDoanhNam_BoPhanDto ToDto(this KeHoachKinhDoanhNam_BoPhan entity) => new()
    {
        Id = entity.Id,
        KeHoachKinhDoanhNamId = entity.KeHoachKinhDoanhNamId,
        DonViId = entity.DonViId,
        Ten = entity.Ten,
        DoanhKySo = entity.DoanhKySo,
        LaiGopKy = entity.LaiGopKy,
        DoanhSoXuatHoaDon = entity.DoanhSoXuatHoaDon,
        LaiGopXuatHoaDon = entity.LaiGopXuatHoaDon,
        ThuTien = entity.ThuTien,
        LaiGopThuTien = entity.LaiGopThuTien,
        ChiPhiTrucTiep = entity.ChiPhiTrucTiep,
        ChiPhiPhanBo = entity.ChiPhiPhanBo,
        LoiNhuan = entity.LoiNhuan
    };

    /// <summary>
    /// Converts model to entity. KeHoachKinhDoanhNamId is set from parent context.
    /// If Id is null or empty, entity will have auto-generated Id (for Add).
    /// If Id has value, it will be preserved (for Update).
    /// </summary>
    public static KeHoachKinhDoanhNam_BoPhan ToEntity(
        this KeHoachKinhDoanhNam_BoPhanInsertOrUpdateModel model,
        Guid keHoachKinhDoanhNamId,
        string ten) {
        var entity = new KeHoachKinhDoanhNam_BoPhan {
            KeHoachKinhDoanhNamId = keHoachKinhDoanhNamId,
            DonViId = model.DonViId,
            Ten = ten,
            DoanhKySo = model.DoanhKySo,
            LaiGopKy = model.LaiGopKy,
            DoanhSoXuatHoaDon = model.DoanhSoXuatHoaDon,
            LaiGopXuatHoaDon = model.LaiGopXuatHoaDon,
            ThuTien = model.ThuTien,
            LaiGopThuTien = model.LaiGopThuTien,
            ChiPhiTrucTiep = model.ChiPhiTrucTiep,
            ChiPhiPhanBo = model.ChiPhiPhanBo,
            LoiNhuan = model.LoiNhuan
        };

        if (model.Id.HasValue && model.Id.Value != Guid.Empty) {
            entity.Id = model.Id.Value;
        }

        return entity;
    }

    #endregion

    #region CaNhan

    public static KeHoachKinhDoanhNam_CaNhanDto ToDto(this KeHoachKinhDoanhNam_CaNhan entity) => new()
    {
        Id = entity.Id,
        KeHoachKinhDoanhNamId = entity.KeHoachKinhDoanhNamId,
        UserPortalId = entity.UserPortalId,
        Ten = entity.Ten,
        DoanhKySo = entity.DoanhKySo,
        LaiGopKy = entity.LaiGopKy,
        DoanhSoXuatHoaDon = entity.DoanhSoXuatHoaDon,
        LaiGopXuatHoaDon = entity.LaiGopXuatHoaDon,
        ThuTien = entity.ThuTien,
        LaiGopThuTien = entity.LaiGopThuTien,
        ChiPhiTrucTiep = entity.ChiPhiTrucTiep,
        ChiPhiPhanBo = entity.ChiPhiPhanBo,
        LoiNhuan = entity.LoiNhuan
    };

    /// <summary>
    /// Converts model to entity. KeHoachKinhDoanhNamId is set from parent context.
    /// If Id is null or empty, entity will have auto-generated Id (for Add).
    /// If Id has value, it will be preserved (for Update).
    /// </summary>
    public static KeHoachKinhDoanhNam_CaNhan ToEntity(
        this KeHoachKinhDoanhNam_CaNhanInsertOrUpdateModel model,
        Guid keHoachKinhDoanhNamId,
        string ten) {
        var entity = new KeHoachKinhDoanhNam_CaNhan {
            KeHoachKinhDoanhNamId = keHoachKinhDoanhNamId,
            UserPortalId = model.UserPortalId,
            Ten = ten,
            DoanhKySo = model.DoanhKySo,
            LaiGopKy = model.LaiGopKy,
            DoanhSoXuatHoaDon = model.DoanhSoXuatHoaDon,
            LaiGopXuatHoaDon = model.LaiGopXuatHoaDon,
            ThuTien = model.ThuTien,
            LaiGopThuTien = model.LaiGopThuTien,
            ChiPhiTrucTiep = model.ChiPhiTrucTiep,
            ChiPhiPhanBo = model.ChiPhiPhanBo,
            LoiNhuan = model.LoiNhuan
        };

        if (model.Id.HasValue && model.Id.Value != Guid.Empty) {
            entity.Id = model.Id.Value;
        }

        return entity;
    }

    #endregion
}