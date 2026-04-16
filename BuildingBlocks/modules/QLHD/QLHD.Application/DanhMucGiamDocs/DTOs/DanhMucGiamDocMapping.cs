namespace QLHD.Application.DanhMucGiamDocs.DTOs;

public static class DanhMucGiamDocMapping
{
    public static DanhMucGiamDoc ToEntity(this DanhMucGiamDocInsertModel model) => new()
    {
        Used = true,
        UserPortalId = model.UserPortalId,
        DonViId = model.DonViId,
        PhongBanId = model.PhongBanId
    };

    public static void UpdateFrom(this DanhMucGiamDoc entity, DanhMucGiamDocUpdateModel model)
    {
        entity.Used = model.Used;
        entity.UserPortalId = model.UserPortalId;
        entity.DonViId = model.DonViId;
        entity.PhongBanId = model.PhongBanId;
    }
}