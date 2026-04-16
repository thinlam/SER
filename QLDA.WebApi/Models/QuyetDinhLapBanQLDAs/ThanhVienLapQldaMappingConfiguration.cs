namespace QLDA.WebApi.Models.QuyetDinhLapBanQLDAs;

public static class ThanhVienBanQldaMappingConfiguration {
    public static ThanhVienBanQldaModel ToModel(this ThanhVienBanQLDA entity) =>
        new() {
            Id = entity.Id,
            Ten = entity.Ten,
            ChucVu = entity.ChucVu,
            VaiTro = entity.VaiTro,
        };


    public static ThanhVienBanQLDA ToEntity(this ThanhVienBanQldaModel model)
        => new() {
            Id = model.Id ?? 0,
            Ten = model.Ten,
            ChucVu = model.ChucVu,
            VaiTro = model.VaiTro,
        };

    public static void Update(this ThanhVienBanQLDA entity, ThanhVienBanQldaModel model) {
        entity.Ten = model.Ten;
        entity.ChucVu = model.ChucVu;
        entity.VaiTro = model.VaiTro;
    }
}