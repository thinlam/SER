namespace QLDA.WebApi.Models.DmLoaiDuAns;

public static class DanhMucLoaiDuAnMappingConfigurations {
    public static DanhMucLoaiDuAnModel ToModel(this DanhMucLoaiDuAn entity)
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,Used = entity.Used
        };

    public static DanhMucLoaiDuAn ToEntity(this DanhMucLoaiDuAnModel model)
        => new() {
            Id = model.Id ?? 0,
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,Used = model.Used
        };
}