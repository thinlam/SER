using QLDA.Application.BaoCaoBaoHanhSanPhams.DTOs;

namespace QLDA.Application.BaoCaoBaoHanhSanPhams;

public static class BaoCaoBaoHanhSanPhamMappings {
    public static BaoCaoBaoHanhSanPham ToEntity(this BaoCaoBaoHanhSanPhamInsertDto dto) {
        return new BaoCaoBaoHanhSanPham {
            Id = dto.Id ?? Guid.NewGuid(),
            DuAnId = dto.DuAnId,
            BuocId = dto.BuocId,
            Ngay = dto.Ngay,
            NoiDung = dto.NoiDung,
            Loai = "BaoCaoBaoHanhSanPham", // Set the discriminator value
            LanhDaoPhuTrachId = dto.LanhDaoPhuTrachId
        };
    }

    public static BaoCaoBaoHanhSanPham ToEntity(this BaoCaoBaoHanhSanPhamUpdateDto dto) {
     
        return new BaoCaoBaoHanhSanPham {
            Id = dto.Id,
            Ngay = dto.Ngay,
            NoiDung = dto.NoiDung,
            Loai = "BaoCaoBaoHanhSanPham", // Set the discriminator value
            LanhDaoPhuTrachId = dto.LanhDaoPhuTrachId
        };
    }

    public static BaoCaoBaoHanhSanPhamDto ToDto(this BaoCaoBaoHanhSanPham entity) {
        return new BaoCaoBaoHanhSanPhamDto {
            Id = entity.Id,
            DuAnId = entity.DuAnId,
            BuocId = entity.BuocId,
            Ngay = entity.Ngay,
            NoiDung = entity.NoiDung,
            LanhDaoPhuTrachId = entity.LanhDaoPhuTrachId
        };
    }
}