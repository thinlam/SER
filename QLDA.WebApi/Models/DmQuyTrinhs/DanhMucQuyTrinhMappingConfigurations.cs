namespace QLDA.WebApi.Models.DmQuyTrinhs;

public static class DanhMucQuyTrinhMappingConfigurations {
    public static DanhMucQuyTrinhModel ToModel(this DanhMucQuyTrinh entity)
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,Used = entity.Used,
            MacDinh = entity.MacDinh,
        };

    public static DanhMucQuyTrinh ToEntity(this DanhMucQuyTrinhModel model)
        => new() {
            Id = model.Id ?? 0,
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,Used = model.Used,
            MacDinh = model.MacDinh,
        };
}