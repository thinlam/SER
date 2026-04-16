using QLDA.Application.BaoCaoTienDos.DTOs;

namespace QLDA.Application.BaoCaoTienDos;

public static class BaoCaoTienDoMappings {
    public static BaoCaoTienDo ToEntity(this BaoCaoTienDoInsertDto dto) {
        return new BaoCaoTienDo {
            Id = dto.Id ?? Guid.NewGuid(),
            DuAnId = dto.DuAnId,
            BuocId = dto.BuocId,
            Ngay = dto.Ngay,
            NoiDung = dto.NoiDung,
            Loai = "BaoCaoTienDo" // Set the discriminator value
        };
    }

    public static BaoCaoTienDo ToEntity(this BaoCaoTienDoUpdateDto dto) {
        
        return new BaoCaoTienDo {
            Id = dto.Id,
            Ngay = dto.Ngay,
            NoiDung = dto.NoiDung,
            Loai = "BaoCaoTienDo" // Set the discriminator value
        };
    }

    public static BaoCaoTienDoDto ToDto(this BaoCaoTienDo entity) {
        return new BaoCaoTienDoDto {
            Id = entity.Id,
            DuAnId = entity.DuAnId,
            BuocId = entity.BuocId,
            Ngay = entity.Ngay,
            NoiDung = entity.NoiDung
        };
    }
}