namespace QLDA.WebApi.Models.DmLoaiVanBans;

public static class DanhMucLoaiVanBanMappingConfiguration {
    public static DanhMucLoaiVanBanModel ToModel(this DanhMucLoaiVanBan entity)
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,Used = entity.Used
        };

    public static DanhMucLoaiVanBan ToEntity(this DanhMucLoaiVanBanModel model)
        => new() {
            Id = model.GetId(),
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,Used = model.Used
        };
}