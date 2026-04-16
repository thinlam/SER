using QLDA.Application.BaoCaoBanGiaoSanPhams.DTOs;

namespace QLDA.Application.BaoCaoBanGiaoSanPhams;

public static class BaoCaoBanGiaoSanPhamMappings {
    public static BaoCaoBanGiaoSanPham ToEntity(this BaoCaoBanGiaoSanPhamInsertDto dto) {
        return new BaoCaoBanGiaoSanPham {
            Id = dto.Id ?? Guid.NewGuid(),
            DuAnId = dto.DuAnId,
            BuocId = dto.BuocId,
            Ngay = dto.Ngay,
            NoiDung = dto.NoiDung,
            Loai = "BaoCaoBanGiaoSanPham", // Set the discriminator value
            DonViBanGiaoId = dto.DonViBanGiaoId,
            DonViNhanBanGiaoId = dto.DonViNhanBanGiaoId
        };
    }

    public static BaoCaoBanGiaoSanPham ToEntity(this BaoCaoBanGiaoSanPhamUpdateDto dto) {
       
        return new BaoCaoBanGiaoSanPham {
            Id = dto.Id,
            Ngay = dto.Ngay,
            NoiDung = dto.NoiDung,
            Loai = "BaoCaoBanGiaoSanPham", // Set the discriminator value
            DonViBanGiaoId = dto.DonViBanGiaoId,
            DonViNhanBanGiaoId = dto.DonViNhanBanGiaoId
        };
    }

    public static BaoCaoBanGiaoSanPhamDto ToDto(this BaoCaoBanGiaoSanPham entity) {
        return new BaoCaoBanGiaoSanPhamDto {
            Id = entity.Id,
            DuAnId = entity.DuAnId,
            BuocId = entity.BuocId,
            Ngay = entity.Ngay,
            NoiDung = entity.NoiDung,
            DonViBanGiaoId = entity.DonViBanGiaoId,
            DonViNhanBanGiaoId = entity.DonViNhanBanGiaoId
        };
    }
}