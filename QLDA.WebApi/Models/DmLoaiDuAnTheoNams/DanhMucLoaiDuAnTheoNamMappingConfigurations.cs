namespace QLDA.WebApi.Models.DmLoaiDuAnTheoNams;

public static class DanhMucLoaiDuAnTheoNamMappingConfigurations {
    public static DanhMucLoaiDuAnTheoNamModel ToModel(this DanhMucLoaiDuAnTheoNam entity)
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,Used = entity.Used
        };

    public static DanhMucLoaiDuAnTheoNam ToEntity(this DanhMucLoaiDuAnTheoNamModel model)
        => new() {
            Id = model.Id ?? 0,
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,Used = model.Used
        };
}