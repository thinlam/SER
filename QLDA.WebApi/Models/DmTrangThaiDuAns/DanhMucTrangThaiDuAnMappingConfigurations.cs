namespace QLDA.WebApi.Models.DmTrangThaiDuAns;

public static class DanhMucTrangThaiDuAnMappingConfigurations {
    public static DanhMucTrangThaiDuAnModel ToModel(this DanhMucTrangThaiDuAn entity)
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,Used = entity.Used
        };

    public static DanhMucTrangThaiDuAn ToEntity(this DanhMucTrangThaiDuAnModel model)
        => new() {
            Id = model.Id ?? 0,
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,Used = model.Used
        };
}