namespace QLDA.WebApi.Models.DmLinhVucs;

public static class DanhMucLinhVucMappingConfigurations {
    public static DanhMucLinhVucModel ToModel(this DanhMucLinhVuc entity)
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,Used = entity.Used
        };

    public static DanhMucLinhVuc ToEntity(this DanhMucLinhVucModel model)
        => new() {
            Id = model.Id ?? 0,
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,Used = model.Used
        };
}