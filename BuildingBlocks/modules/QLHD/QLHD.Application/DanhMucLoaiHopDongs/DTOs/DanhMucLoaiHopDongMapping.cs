namespace QLHD.Application.DanhMucLoaiHopDongs.DTOs;

public static class DanhMucLoaiHopDongMapping
{
    public static DanhMucLoaiHopDong ToEntity(this DanhMucLoaiHopDongInsertModel model) => new()
    {
        Ten = model.Ten,
        MoTa = model.MoTa,
        Used = model.Used,
        Symbol = model.Symbol,
        Prefix = model.Prefix,
        IsDefault = model.IsDefault
    };

    public static void UpdateFrom(this DanhMucLoaiHopDong entity, DanhMucLoaiHopDongUpdateModel model)
    {
        entity.Ten = model.Ten;
        entity.MoTa = model.MoTa;
        entity.Used = model.Used;
        entity.Symbol = model.Symbol;
        entity.Prefix = model.Prefix;
        entity.IsDefault = model.IsDefault;
    }
}