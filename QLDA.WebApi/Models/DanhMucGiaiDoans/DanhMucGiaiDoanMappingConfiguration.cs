namespace QLDA.WebApi.Models.DanhMucGiaiDoans;

public static class DanhMucGiaiDoanMappingConfiguration {
    public static DanhMucGiaiDoanModel ToModel(this DanhMucGiaiDoan entity)
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,Used = entity.Used
        };

    public static DanhMucGiaiDoan ToEntity(this DanhMucGiaiDoanModel model)
        => new() {
            Id = model.GetId(),
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,Used = model.Used
        };
}