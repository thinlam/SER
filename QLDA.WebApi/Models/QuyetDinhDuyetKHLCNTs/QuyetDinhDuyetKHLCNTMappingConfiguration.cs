using QLDA.WebApi.Models.TepDinhKems;

namespace QLDA.WebApi.Models.QuyetDinhDuyetKHLCNTs;

public static class QuyetDinhDuyetKHLCNTMappingConfiguration {
    public static QuyetDinhDuyetKHLCNTModel ToModel(this QuyetDinhDuyetKHLCNT entity,
        List<TepDinhKem>? danhSachTepDinhKem = null) =>
        new() {
            Id = entity.Id,
            DuAnId = entity.DuAnId,
            BuocId = entity.BuocId,
            KeHoachLuaChonNhaThauId = entity.KeHoachLuaChonNhaThauId,
            SoQuyetDinh = entity.So,
            NgayQuyetDinh = entity.Ngay,
            CoQuanQuyetDinh = entity.CoQuanQuyetDinh,
            TrichYeu = entity.TrichYeu,
            NgayKy = entity.NgayKy,
            NguoiKy = entity.NguoiKy,
            DanhSachTepDinhKem = danhSachTepDinhKem?
                // .Where(o => o.GroupType == nameof(EGroupType.QuyetDinhDuyetKHLCNT))
                .Select(o => o.ToModel()).ToList()
        };


    public static QuyetDinhDuyetKHLCNT ToEntity(this QuyetDinhDuyetKHLCNTModel model)
        => new() {
            Id = model.GetId(),
            DuAnId = model.DuAnId,
            BuocId = model.BuocId,
            KeHoachLuaChonNhaThauId = model.KeHoachLuaChonNhaThauId,
            So = model.SoQuyetDinh,
            Ngay = model.NgayQuyetDinh,
            CoQuanQuyetDinh = model.CoQuanQuyetDinh,
            TrichYeu = model.TrichYeu,
            NgayKy = model.NgayKy,
            NguoiKy = model.NguoiKy,
        };

    public static void Update(this QuyetDinhDuyetKHLCNT entity, QuyetDinhDuyetKHLCNTModel model) {
        entity.DuAnId = model.DuAnId;
        entity.BuocId = model.BuocId;
        entity.KeHoachLuaChonNhaThauId = model.KeHoachLuaChonNhaThauId;
        entity.So = model.SoQuyetDinh;
        entity.Ngay = model.NgayQuyetDinh;
        entity.CoQuanQuyetDinh = model.CoQuanQuyetDinh;
        entity.TrichYeu = model.TrichYeu;
        entity.NgayKy = model.NgayKy;
        entity.NguoiKy = model.NguoiKy;
    }
}