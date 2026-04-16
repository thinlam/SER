using QLDA.Application.VanBanChuTruongs.DTOs;

namespace QLDA.Application.VanBanChuTruongs;

public static class VanBanChuTruongMappings {
    public static VanBanChuTruong ToEntity(this VanBanChuTruongInsertDto dto) {
        return new VanBanChuTruong {
            Id = Guid.NewGuid(),
            DuAnId = dto.DuAnId,
            BuocId = dto.BuocId,
            So = dto.SoVanBan,
            Ngay = dto.NgayVanBan,
            TrichYeu = dto.TrichYeu,
            NgayKy = dto.NgayKy,
            NguoiKy = dto.NguoiKy,
            LoaiVanBanId = dto.LoaiVanBanId,
            ChucVuId = dto.ChucVuId
        };
    }

    public static VanBanChuTruong ToEntity(this VanBanChuTruongUpdateDto dto) {
        return new VanBanChuTruong {
            Id = dto.Id,
            So = dto.SoVanBan,
            Ngay = dto.NgayVanBan,
            TrichYeu = dto.TrichYeu,
            NgayKy = dto.NgayKy,
            NguoiKy = dto.NguoiKy,
            LoaiVanBanId = dto.LoaiVanBanId,
            ChucVuId = dto.ChucVuId
        };
    }

    public static VanBanChuTruongDto ToDto(this VanBanChuTruong entity) {
        return new VanBanChuTruongDto {
            Id = entity.Id,
            DuAnId = entity.DuAnId,
            BuocId = entity.BuocId,
            SoVanBan = entity.So,
            NgayVanBan = entity.Ngay,
            TrichYeu = entity.TrichYeu,
            NgayKy = entity.NgayKy,
            NguoiKy = entity.NguoiKy,
            LoaiVanBanId = entity.LoaiVanBanId,
            ChucVuId = entity.ChucVuId
        };
    }
}