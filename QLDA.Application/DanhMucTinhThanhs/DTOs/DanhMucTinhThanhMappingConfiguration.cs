namespace QLDA.Application.DanhMucTinhThanhs.DTOs;

public static class DanhMucTinhThanhMappingConfiguration {
    public static MinimalDanhMucVietInfoDto ToDanhMucDto(this DmTinhThanh entity)
        => new() {
            Id = entity.Id,
            ParentId = entity.QuocGiaId,
            Ten = entity.TenTinhThanh,
        };
}