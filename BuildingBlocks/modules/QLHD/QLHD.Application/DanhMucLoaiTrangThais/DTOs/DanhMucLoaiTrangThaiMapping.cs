namespace QLHD.Application.DanhMucLoaiTrangThais.DTOs;

public static class DanhMucLoaiTrangThaiMapping
{
    public static DanhMucLoaiTrangThai ToEntity(this DanhMucLoaiTrangThaiInsertModel model) => new()
    {
        Ma = model.Ma,
        Ten = model.Ten,
        MoTa = model.MoTa,
        Used = model.Used
    };

    public static void UpdateFrom(this DanhMucLoaiTrangThai entity, DanhMucLoaiTrangThaiUpdateModel model)
    {
        entity.Ma = model.Ma;
        entity.Ten = model.Ten;
        entity.MoTa = model.MoTa;
        entity.Used = model.Used;
    }
}