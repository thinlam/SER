namespace QLDA.WebApi.Models.DmChucVus;

public static class DanhMucChucVuMappingConfiguration {
    public static DanhMucChucVuModel ToModel(this DanhMucChucVu entity)
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,Used = entity.Used
        };

    public static DanhMucChucVu ToEntity(this DanhMucChucVuModel model)
        => new() {
            Id = model.GetId(),
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,Used = model.Used
        };
}