namespace QLDA.Application.DanhMucQuanHuyens.DTOs;

public static class DanhMucQuanHuyenMappingConfiguration {
   

    public static MinimalDanhMucVietInfoDto ToDanhMucDto(this DmQuanHuyen entity)
        => new() {
            Id = entity.Id,
            ParentId = entity.TinhThanhId,
            Ten = entity.TenQuanHuyen,
        };

}