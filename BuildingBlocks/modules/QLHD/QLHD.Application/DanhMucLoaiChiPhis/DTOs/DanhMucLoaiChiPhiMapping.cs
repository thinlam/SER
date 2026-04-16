namespace QLHD.Application.DanhMucLoaiChiPhis.DTOs;

public static class DanhMucLoaiChiPhiMapping
{
    public static DanhMucLoaiChiPhi ToEntity(this DanhMucLoaiChiPhiInsertModel model) => new()
    {
        Ten = model.Ten,
        MoTa = model.MoTa,
        Used = model.Used,
        IsDefault = model.IsDefault,
        IsMajor = model.IsMajor
    };

    public static void UpdateFrom(this DanhMucLoaiChiPhi entity, DanhMucLoaiChiPhiUpdateModel model)
    {
        entity.Ma = model.Ma;
        entity.Ten = model.Ten;
        entity.MoTa = model.MoTa;
        entity.Used = model.Used;
        entity.IsDefault = model.IsDefault;
        entity.IsMajor = model.IsMajor;
    }
}