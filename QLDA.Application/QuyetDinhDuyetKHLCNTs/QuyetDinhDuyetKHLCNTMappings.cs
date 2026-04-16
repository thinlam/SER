using QLDA.Application.QuyetDinhDuyetKHLCNTs.DTOs;

namespace QLDA.Application.QuyetDinhDuyetKHLCNTs;

public static class QuyetDinhDuyetKHLCNTMappings {
    public static QuyetDinhDuyetKHLCNT ToEntity(this QuyetDinhDuyetKHLCNTInsertDto dto) {
        return new QuyetDinhDuyetKHLCNT {
            Id = Guid.NewGuid(),
            DuAnId = dto.DuAnId,
            BuocId = dto.BuocId,
            KeHoachLuaChonNhaThauId = dto.KeHoachLuaChonNhaThauId,
            So = dto.SoQuyetDinh,
            Ngay = dto.NgayQuyetDinh,
            CoQuanQuyetDinh = dto.CoQuanQuyetDinh,
            TrichYeu = dto.TrichYeu,
            NgayKy = dto.NgayKy,
            NguoiKy = dto.NguoiKy
        };
    }

    public static QuyetDinhDuyetKHLCNT ToEntity(this QuyetDinhDuyetKHLCNTUpdateDto dto) {
        return new QuyetDinhDuyetKHLCNT {
            Id = dto.Id,
            KeHoachLuaChonNhaThauId = dto.KeHoachLuaChonNhaThauId,
            So = dto.SoQuyetDinh,
            Ngay = dto.NgayQuyetDinh,
            CoQuanQuyetDinh = dto.CoQuanQuyetDinh,
            TrichYeu = dto.TrichYeu,
            NgayKy = dto.NgayKy,
            NguoiKy = dto.NguoiKy
        };
    }

    public static QuyetDinhDuyetKHLCNTDto ToDto(this QuyetDinhDuyetKHLCNT entity) {
        return new QuyetDinhDuyetKHLCNTDto {
            Id = entity.Id,
            DuAnId = entity.DuAnId,
            BuocId = entity.BuocId,
            KeHoachLuaChonNhaThauId = entity.KeHoachLuaChonNhaThauId,
            SoQuyetDinh = entity.So,
            NgayQuyetDinh = entity.Ngay,
            CoQuanQuyetDinh = entity.CoQuanQuyetDinh,
            TrichYeu = entity.TrichYeu,
            NgayKy = entity.NgayKy,
            NguoiKy = entity.NguoiKy
        };
    }
}