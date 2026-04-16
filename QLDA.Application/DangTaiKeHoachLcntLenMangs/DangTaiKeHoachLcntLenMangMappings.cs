using QLDA.Application.DangTaiKeHoachLcntLenMangs.DTOs;

namespace QLDA.Application.DangTaiKeHoachLcntLenMangs;

public static class DangTaiKeHoachLcntLenMangMappings {
    public static DangTaiKeHoachLcntLenMang ToEntity(this DangTaiKeHoachLcntLenMangInsertDto dto) {
        return new DangTaiKeHoachLcntLenMang {
            Id = dto.Id ?? Guid.NewGuid(),
            DuAnId = dto.DuAnId,
            BuocId = dto.BuocId,
            KeHoachLuaChonNhaThauId = dto.KeHoachLuaChonNhaThauId,
            NgayEHSMT = dto.NgayEHSMT,
            TrangThaiId = dto.TrangThaiId
        };
    }

    public static DangTaiKeHoachLcntLenMang ToEntity(this DangTaiKeHoachLcntLenMangUpdateDto dto) {
        return new DangTaiKeHoachLcntLenMang {
            Id = dto.Id,
            KeHoachLuaChonNhaThauId = dto.KeHoachLuaChonNhaThauId,
            NgayEHSMT = dto.NgayEHSMT,
            TrangThaiId = dto.TrangThaiId
        };
    }

    public static DangTaiKeHoachLcntLenMangDto ToDto(this DangTaiKeHoachLcntLenMang entity) {
        return new DangTaiKeHoachLcntLenMangDto {
            Id = entity.Id,
            DuAnId = entity.DuAnId,
            BuocId = entity.BuocId,
            KeHoachLuaChonNhaThauId = entity.KeHoachLuaChonNhaThauId,
            NgayEHSMT = entity.NgayEHSMT,
            TrangThaiId = entity.TrangThaiId
        };
    }
}