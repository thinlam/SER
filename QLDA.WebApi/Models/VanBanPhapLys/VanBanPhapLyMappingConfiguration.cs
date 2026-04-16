using QLDA.WebApi.Models.TepDinhKems;

namespace QLDA.WebApi.Models.VanBanPhapLys;

public static class VanBanPhapLyMappingConfiguration {
    public static VanBanPhapLyModel ToModel(this VanBanPhapLy entity,
        List<TepDinhKem>? danhSachTepDinhKem = null) =>
        new() {
            Id = entity.Id,
            BuocId = entity.BuocId,
            DuAnId = entity.DuAnId,
            ChucVuId = entity.ChucVuId,
            LoaiVanBanId = entity.LoaiVanBanId,
            NgayKy = entity.NgayKy,
            NguoiKy = entity.NguoiKy,
            TrichYeu = entity.TrichYeu,
            SoVanBan = entity.So,
            NgayVanBan = entity.Ngay,
            DanhSachTepDinhKem = danhSachTepDinhKem?
                // .Where(o => o.GroupType == nameof(EGroupType.VanBanPhapLy))
                .Select(o => o.ToModel()).ToList()
        };


    public static VanBanPhapLy ToEntity(this VanBanPhapLyModel model)
        => new() {
            Id = model.GetId(),
            BuocId = model.BuocId,
            DuAnId = model.DuAnId,
            ChucVuId = model.ChucVuId,
            LoaiVanBanId = model.LoaiVanBanId,
            NgayKy = model.NgayKy,
            NguoiKy = model.NguoiKy,
            So = model.SoVanBan,
            TrichYeu = model.TrichYeu,
            Ngay = model.NgayVanBan,
        };

    public static void Update(this VanBanPhapLy entity, VanBanPhapLyModel model) {
        entity.BuocId = model.BuocId;
        entity.DuAnId = model.DuAnId;
        entity.ChucVuId = model.ChucVuId;
        entity.LoaiVanBanId = model.LoaiVanBanId;
        entity.NgayKy = model.NgayKy;
        entity.NguoiKy = model.NguoiKy;
        entity.So = model.SoVanBan;
        entity.Ngay = model.NgayVanBan;
        entity.TrichYeu = model.TrichYeu;
    }
}