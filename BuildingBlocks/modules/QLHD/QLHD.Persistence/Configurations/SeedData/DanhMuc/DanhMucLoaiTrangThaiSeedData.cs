using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Persistence.Configurations.SeedData.DanhMuc;

/// <summary>
/// Seed data extension for DanhMucLoaiTrangThai entity.
/// </summary>
public static class DanhMucLoaiTrangThaiSeedData
{
    /// <summary>
    /// Get seed data array for runtime seeding.
    /// </summary>
    public static DanhMucLoaiTrangThai[] GetData() =>
    [
        new() { Id = 1, Ma = "HDONG", Ten = "Hợp đồng", Used = true, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 2, Ma = "KHOACH", Ten = "Kế hoạch", Used = true, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 3, Ma = "CHOP", Ten = "Cuộc họp", Used = true, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 4, Ma = "TIENDO", Ten = "Tiến độ", Used = true, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 5, Ma = "KKHUAN_VUONG_MAC", Ten = "Khó khăn vướng mắc", Used = true, CreatedAt = SeedDataConstants.SeedCreatedAt }
    ];

    public static void SeedDanhMucLoaiTrangThai(this EntityTypeBuilder<DanhMucLoaiTrangThai> builder) => builder.HasData(GetData());
}