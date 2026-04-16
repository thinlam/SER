namespace QLDA.WebApi.Models.DanhMucHinhThucLuaChonNhaThaus;

public static class DanhMucHinhThucLuaChonNhaThauMappingConfigurations {
    public static DanhMucHinhThucLuaChonNhaThauModel ToModel(this DanhMucHinhThucLuaChonNhaThau entity)
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,Used = entity.Used
        };

    public static DanhMucHinhThucLuaChonNhaThau ToEntity(this DanhMucHinhThucLuaChonNhaThauModel model)
        => new() {
            Id = model.Id ?? 0,
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,Used = model.Used
        };
}