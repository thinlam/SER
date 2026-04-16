namespace QLDA.WebApi.Models.DmLoaiHopDongs;

public static class DanhMucLoaiHopDongMappingConfigurations {
    public static DanhMucLoaiHopDongModel ToModel(this DanhMucLoaiHopDong entity)
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,Used = entity.Used
        };

    public static DanhMucLoaiHopDong ToEntity(this DanhMucLoaiHopDongModel model)
        => new() {
            Id = model.Id ?? 0,
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,Used = model.Used
        };
}