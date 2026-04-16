namespace BuildingBlocks.Application.Common.DTOs;

public static class DanhMucMappingConfiguration {
    public static TEntity ToEntity<TEntity, TKey>(this DanhMucInsertModel model)
    where TEntity : DanhMuc<TKey>, new()
    => new() {
        Ma = model.Ma,
        Ten = model.Ten,
        MoTa = model.MoTa,
        Used = true,
    };
    public static void Update<TEntity>(this TEntity entity, DanhMucUpdateModel<int> model)
    where TEntity : DanhMuc<int> {

        entity.Ma = model.Ma;
        entity.Ten = model.Ten;
        entity.MoTa = model.MoTa;
        entity.Used = model.Used;
    }
}
