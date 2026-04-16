namespace QLDA.WebApi.Models.DanhMucMucDoKhoKhans;

public static class DanhMucMucDoKhoKhanMappingConfigurations {
    public static DanhMucMucDoKhoKhanModel ToModel(this DanhMucMucDoKhoKhan entity)
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,Used = entity.Used
        };

    public static DanhMucMucDoKhoKhan ToEntity(this DanhMucMucDoKhoKhanModel model)
        => new() {
            Id = model.Id ?? 0,
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,Used = model.Used
        };
}