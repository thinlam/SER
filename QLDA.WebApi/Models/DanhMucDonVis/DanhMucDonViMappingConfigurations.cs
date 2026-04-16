using QLDA.Domain.Entities.ViMaster;

namespace QLDA.WebApi.Models.DanhMucDonVis;

public static class DanhMucDonViMappingConfigurations {
    public static DanhMucDonViModel ToModel(this DanhMucDonVi entity)
        => new() {
            Id = entity.Id,
            Ma = entity.MaDonVi,
            Ten = entity.TenDonVi,
            MoTa = entity.MoTa,
            Used = entity.Used ?? false,
        };
}