namespace QLDA.Application.DanhMucPhuongXas.DTOs;

public static class DanhMucPhuongXaMappingConfiguration {
    public static MinimalDanhMucVietInfoDto ToDanhMucDto(this DmPhuongXa entity)
        => new() {
            Id = entity.Id,
            ParentId = entity.QuanHuyenId,
            Ten = entity.TenPhuongXa,
        };
}