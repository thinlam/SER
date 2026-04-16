namespace QLDA.Application.Common.DTOs;

public static class DanhMucMappingConfiguration {
    public static TDto ToDanhMucDto<TEntity, TKey, TDto>(this TEntity entity)
        where TEntity : DanhMuc<TKey>, IMayHaveStt
        where TDto : DanhMucDto<TKey>, new()
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,
            Used = entity.Used,
        };
}