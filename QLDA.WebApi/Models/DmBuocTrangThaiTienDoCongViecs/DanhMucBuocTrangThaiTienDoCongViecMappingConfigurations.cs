namespace QLDA.WebApi.Models.DmBuocTrangThaiTienDoCongViecs;

public static class DanhMucDanhMucTrangThaiTienDoMappingConfigurations {
    public static DanhMucDanhMucTrangThaiTienDoModel ToModel(this DanhMucBuocTrangThaiTienDo entity)
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,Used = entity.Used
        };

    public static DanhMucBuocTrangThaiTienDo ToEntity(this DanhMucDanhMucTrangThaiTienDoModel model)
        => new() {
            Id = model.Id ?? 0,
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,Used = model.Used
        };
}