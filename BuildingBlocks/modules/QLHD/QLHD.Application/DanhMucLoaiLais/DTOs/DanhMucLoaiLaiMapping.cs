using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Application.DanhMucLoaiLais.DTOs;

public static class DanhMucLoaiLaiMapping
{
    public static DanhMucLoaiLai ToEntity(this DanhMucLoaiLaiInsertModel model) => new()
    {
        Ten = model.Ten,
        MoTa = model.MoTa,
        Used = model.Used,
        IsDefault = model.IsDefault
    };

    public static void UpdateFrom(this DanhMucLoaiLai entity, DanhMucLoaiLaiUpdateModel model)
    {
        entity.Ma = model.Ma;
        entity.Ten = model.Ten;
        entity.MoTa = model.MoTa;
        entity.Used = model.Used;
        entity.IsDefault = model.IsDefault;
    }

    public static DanhMucLoaiLaiDto ToDto(this DanhMucLoaiLai entity) => new()
    {
        Id = entity.Id,
        Ma = entity.Ma,
        Ten = entity.Ten,
        MoTa = entity.MoTa,
        Used = entity.Used,
        IsDefault = entity.IsDefault
    };
}