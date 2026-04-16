namespace QLDA.WebApi.Models.DmChuDauTus;

public static class DanhMucChuDauTuMappingConfigurations {
    public static DanhMucChuDauTuModel ToModel(this DanhMucChuDauTu entity)
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,Used = entity.Used
        };

    public static DanhMucChuDauTu ToEntity(this DanhMucChuDauTuModel model)
        => new() {
            Id = model.Id ?? 0,
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,Used = model.Used
        };
}