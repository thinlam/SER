namespace QLDA.WebApi.Models.DanhMucTinhTrangThucHienLcnts;

public static class DanhMucTinhTrangThucHienLcntMappingConfiguration
{
    public static DanhMucTinhTrangThucHienLcntModel ToModel(this DanhMucTinhTrangThucHienLcnt entity)
        => new()
        {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,
            Used = entity.Used
        };

    public static DanhMucTinhTrangThucHienLcnt ToEntity(this DanhMucTinhTrangThucHienLcntModel model)
        => new()
        {
            Id = model.GetId(),
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,
            Used = model.Used
        };
}
