namespace QLDA.WebApi.Models.DmHinhThucDauTus;

public static class DanhMucHinhThucDauTuMappingConfigurations {
    public static DanhMucHinhThucDauTuModel ToModel(this DanhMucHinhThucDauTu entity)
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,Used = entity.Used
        };

    public static DanhMucHinhThucDauTu ToEntity(this DanhMucHinhThucDauTuModel model)
        => new() {
            Id = model.Id ?? 0,
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,Used = model.Used
        };
}