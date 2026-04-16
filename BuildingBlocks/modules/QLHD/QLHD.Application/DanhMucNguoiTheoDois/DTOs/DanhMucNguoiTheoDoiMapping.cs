namespace QLHD.Application.DanhMucNguoiTheoDois.DTOs;

public static class DanhMucNguoiTheoDoiMapping {
    public static DanhMucNguoiTheoDoi ToEntity(this DanhMucNguoiTheoDoiInsertModel model) => new() {
        Used = true,
        UserPortalId = model.UserPortalId,
        DonViId = model.DonViId,
        PhongBanId = model.PhongBanId
    };

    public static void UpdateFrom(this DanhMucNguoiTheoDoi entity, DanhMucNguoiTheoDoiUpdateModel model) {
        entity.Used = model.Used;
        entity.UserPortalId = model.UserPortalId;
        entity.DonViId = model.DonViId;
        entity.PhongBanId = model.PhongBanId;
    }
}