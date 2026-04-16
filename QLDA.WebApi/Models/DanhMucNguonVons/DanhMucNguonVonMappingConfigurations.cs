namespace QLDA.WebApi.Models.DanhMucNguonVons;

public static class DanhMucNguonVonMappingConfigurations {
    public static DanhMucNguonVonModel ToModel(this DanhMucNguonVon entity)
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,Used = entity.Used
        };

    public static DanhMucNguonVon ToEntity(this DanhMucNguonVonModel model)
        => new() {
            Id = model.Id ?? 0,
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,Used = model.Used
        };
}