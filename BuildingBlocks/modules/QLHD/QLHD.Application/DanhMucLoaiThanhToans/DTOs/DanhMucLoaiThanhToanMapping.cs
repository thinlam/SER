namespace QLHD.Application.DanhMucLoaiThanhToans.DTOs;

public static class DanhMucLoaiThanhToanMapping
{
    public static DanhMucLoaiThanhToan ToEntity(this DanhMucLoaiThanhToanInsertModel model) => new()
    {
        Ten = model.Ten,
        MoTa = model.MoTa,
        Used = model.Used,
        IsDefault = model.IsDefault
    };

    public static void UpdateFrom(this DanhMucLoaiThanhToan entity, DanhMucLoaiThanhToanUpdateModel model)
    {
        entity.Ten = model.Ten;
        entity.MoTa = model.MoTa;
        entity.Used = model.Used;
        entity.IsDefault = model.IsDefault;
    }
}