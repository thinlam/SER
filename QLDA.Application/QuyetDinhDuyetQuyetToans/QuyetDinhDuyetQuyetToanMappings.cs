using QLDA.Application.QuyetDinhDuyetQuyetToans.DTOs;

namespace QLDA.Application.QuyetDinhDuyetQuyetToans;

public static class QuyetDinhDuyetQuyetToanMappings {
    public static QuyetDinhDuyetQuyetToan ToEntity(this QuyetDinhDuyetQuyetToanInsertDto dto) {
        return new QuyetDinhDuyetQuyetToan {
            Id = Guid.NewGuid(),
            DuAnId = dto.DuAnId,
            BuocId = dto.BuocId,
            So = dto.SoQuyetDinh,
            Ngay = dto.NgayQuyetDinh,
            CoQuanQuyetDinh = dto.CoQuanQuyetDinh,
            TrichYeu = dto.TrichYeu,
            NgayKy = dto.NgayKy,
            NguoiKy = dto.NguoiKy,
            GiaTri = dto.GiaTri
        };
    }

    public static QuyetDinhDuyetQuyetToan ToEntity(this QuyetDinhDuyetQuyetToanUpdateDto dto) {
        return new QuyetDinhDuyetQuyetToan {
            Id = dto.Id,
            So = dto.SoQuyetDinh,
            Ngay = dto.NgayQuyetDinh,
            CoQuanQuyetDinh = dto.CoQuanQuyetDinh,
            TrichYeu = dto.TrichYeu,
            NgayKy = dto.NgayKy,
            NguoiKy = dto.NguoiKy,
            GiaTri = dto.GiaTri
        };
    }

    public static QuyetDinhDuyetQuyetToanDto ToDto(this QuyetDinhDuyetQuyetToan entity) {
        return new QuyetDinhDuyetQuyetToanDto {
            Id = entity.Id,
            DuAnId = entity.DuAnId,
            BuocId = entity.BuocId,
            SoQuyetDinh = entity.So,
            NgayQuyetDinh = entity.Ngay,
            CoQuanQuyetDinh = entity.CoQuanQuyetDinh,
            TrichYeu = entity.TrichYeu,
            NgayKy = entity.NgayKy,
            NguoiKy = entity.NguoiKy,
            GiaTri = entity.GiaTri
        };
    }
}