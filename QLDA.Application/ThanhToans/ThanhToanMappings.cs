using QLDA.Application.ThanhToans.DTOs;
using QLDA.Application.TepDinhKems.DTOs;

namespace QLDA.Application.ThanhToans;

public static class ThanhToanMappings {
    public static ThanhToan ToEntity(this ThanhToanInsertDto dto) {
        return new ThanhToan {
            DuAnId = dto.DuAnId,
            BuocId = dto.BuocId,
            NghiemThuId = dto.NghiemThuId,
            SoHoaDon = dto.SoHoaDon,
            NgayHoaDon = dto.NgayHoaDon,
            GiaTri = dto.GiaTri,
            NoiDung = dto.NoiDung
        };
    }

    public static ThanhToan ToEntity(this ThanhToanUpdateDto dto) {
        return new ThanhToan {
            Id = dto.Id,
            NghiemThuId = dto.NghiemThuId,
            SoHoaDon = dto.SoHoaDon,
            NgayHoaDon = dto.NgayHoaDon,
            GiaTri = dto.GiaTri,
            NoiDung = dto.NoiDung
        };
    }

    public static ThanhToanDto ToDto(this ThanhToan entity, IEnumerable<TepDinhKem>? files = null) {
        return new ThanhToanDto {
            Id = entity.Id,
            DuAnId = entity.DuAnId,
            BuocId = entity.BuocId,
            NghiemThuId = entity.NghiemThuId,
            SoHoaDon = entity.SoHoaDon,
            NgayHoaDon = entity.NgayHoaDon,
            GiaTri = entity.GiaTri,
            NoiDung = entity.NoiDung,
            DanhSachTepDinhKem = [.. files?.ToDtos() ?? []]
        };
    }
    public static void Update(this ThanhToan entity, ThanhToanUpdateDto dto) {
        entity.NghiemThuId = dto.NghiemThuId;
        entity.SoHoaDon = dto.SoHoaDon;
        entity.NgayHoaDon = dto.NgayHoaDon;
        entity.GiaTri = dto.GiaTri;
        entity.NoiDung = dto.NoiDung;
    }
}