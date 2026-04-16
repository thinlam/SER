namespace QLDA.Application.DanhMucDuongs.DTOs;

public static class DanhMucDuongMappingConfiguration {
    public static MinimalDanhMucVietInfoDto ToDanhMucDto(this DmDuong entity)
        => new() {
            Id = entity.Id,
            Ten = entity.TenDuong,
        };
}