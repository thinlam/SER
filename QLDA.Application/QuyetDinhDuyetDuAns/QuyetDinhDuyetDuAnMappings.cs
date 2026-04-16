using QLDA.Application.QuyetDinhDuyetDuAns.DTOs;

namespace QLDA.Application.QuyetDinhDuyetDuAns;

public static class QuyetDinhDuyetDuAnMappings {
    public static QuyetDinhDuyetDuAn ToEntity(this QuyetDinhDuyetDuAnInsertDto dto) {
        return new QuyetDinhDuyetDuAn {
            Id = Guid.NewGuid(),
            DuAnId = dto.DuAnId,
            BuocId = dto.BuocId,
            So = dto.SoQuyetDinh,
            Ngay = dto.NgayQuyetDinh,
            TrichYeu = dto.TrichYeu,
            CoQuanQuyetDinhDauTu = dto.CoQuanQuyetDinhDauTu
        };
    }

    public static QuyetDinhDuyetDuAn ToEntity(this QuyetDinhDuyetDuAnUpdateDto dto) {
        return new QuyetDinhDuyetDuAn {
            Id = dto.Id,
            So = dto.SoQuyetDinh,
            Ngay = dto.NgayQuyetDinh,
            TrichYeu = dto.TrichYeu,
            CoQuanQuyetDinhDauTu = dto.CoQuanQuyetDinhDauTu
        };
    }

    public static QuyetDinhDuyetDuAnDto ToDto(this QuyetDinhDuyetDuAn entity) {
        return new QuyetDinhDuyetDuAnDto {
            Id = entity.Id,
            DuAnId = entity.DuAnId,
            BuocId = entity.BuocId,
            SoQuyetDinh = entity.So,
            NgayQuyetDinh = entity.Ngay,
            TrichYeu = entity.TrichYeu,
            CoQuanQuyetDinhDauTu = entity.CoQuanQuyetDinhDauTu
        };
    }
}