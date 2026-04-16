namespace QLDA.WebApi.Models.DmNhomDuAns;

public static class DanhMucNhomDuAnMappingConfigurations {
    public static DanhMucNhomDuAnModel ToModel(this DanhMucNhomDuAn entity)
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,Used = entity.Used
        };

    public static DanhMucNhomDuAn ToEntity(this DanhMucNhomDuAnModel model)
        => new() {
            Id = model.Id ?? 0,
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,Used = model.Used
        };
}