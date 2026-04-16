namespace QLHD.Application.DanhMucTrangThais.DTOs;

public static class DanhMucTrangThaiMapping
{
    public static DanhMucTrangThai ToEntity(this DanhMucTrangThaiInsertModel model) => new()
    {
        Ma = model.Ma,
        Ten = model.Ten,
        MoTa = model.MoTa,
        Used = model.Used,
        LoaiTrangThaiId = model.LoaiTrangThaiId,
        ThuTu = model.ThuTu,
        IsDefault = model.IsDefault
    };

    public static void UpdateFrom(this DanhMucTrangThai entity, DanhMucTrangThaiUpdateModel model)
    {
        entity.Ma = model.Ma;
        entity.Ten = model.Ten;
        entity.MoTa = model.MoTa;
        entity.Used = model.Used;
        entity.LoaiTrangThaiId = model.LoaiTrangThaiId;
        entity.ThuTu = model.ThuTu;
        entity.IsDefault = model.IsDefault;
    }
}