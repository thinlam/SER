namespace QLDA.WebApi.Models.DmTrangThaiTienDo;

public static class DanhMucTrangThaiTienDoMappingConfigurations {
    public static DanhMucTrangThaiTienDoModel ToModel(this DanhMucTrangThaiTienDo entity)
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,Used = entity.Used
        };

    public static DanhMucTrangThaiTienDo ToEntity(this DanhMucTrangThaiTienDoModel model)
        => new() {
            Id = model.Id ?? 0,
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,Used = model.Used
        };
}