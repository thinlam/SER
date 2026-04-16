namespace QLDA.WebApi.Models.DanhMucTinhTrangKhoKhans;

public static class DanhMucTinhTrangKhoKhanMappingConfigurations {
    public static DanhMucTinhTrangKhoKhanModel ToModel(this DanhMucTinhTrangKhoKhan entity)
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,Used = entity.Used
        };

    public static DanhMucTinhTrangKhoKhan ToEntity(this DanhMucTinhTrangKhoKhanModel model)
        => new() {
            Id = model.Id ?? 0,
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,Used = model.Used
        };
}