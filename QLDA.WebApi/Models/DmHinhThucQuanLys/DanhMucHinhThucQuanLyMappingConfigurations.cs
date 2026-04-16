namespace QLDA.WebApi.Models.DmHinhThucQuanLys;

public static class DanhMucHinhThucQuanLyMappingConfigurations {
    public static DanhMucHinhThucQuanLyModel ToModel(this DanhMucHinhThucQuanLy entity)
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,Used = entity.Used
        };

    public static DanhMucHinhThucQuanLy ToEntity(this DanhMucHinhThucQuanLyModel model)
        => new() {
            Id = model.Id ?? 0,
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,Used = model.Used
        };
}