namespace QLDA.WebApi.Models.DanhMucLoaiGoiThaus;

public static class DanhMucLoaiGoiThauMappingConfiguration {
    public static DanhMucLoaiGoiThauModel ToModel(this DanhMucLoaiGoiThau entity)
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,Used = entity.Used
        };

    public static DanhMucLoaiGoiThau ToEntity(this DanhMucLoaiGoiThauModel model)
        => new() {
            Id = model.GetId(),
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,Used = model.Used
        };
}