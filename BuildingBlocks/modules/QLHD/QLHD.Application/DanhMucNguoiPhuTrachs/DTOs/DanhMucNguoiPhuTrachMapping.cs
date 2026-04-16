namespace QLHD.Application.DanhMucNguoiPhuTrachs.DTOs;

public static class DanhMucNguoiPhuTrachMapping
{
    public static DanhMucNguoiPhuTrach ToEntity(this DanhMucNguoiPhuTrachInsertModel model) => new()
    {
        Used = true,
        UserPortalId = model.UserPortalId,
        DonViId = model.DonViId,
        PhongBanId = model.PhongBanId
    };

    public static void UpdateFrom(this DanhMucNguoiPhuTrach entity, DanhMucNguoiPhuTrachUpdateModel model)
    {
        entity.Used = model.Used;
        entity.UserPortalId = model.UserPortalId;
        entity.DonViId = model.DonViId;
        entity.PhongBanId = model.PhongBanId;
    }
}