using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Persistence.Configurations.SeedData.DanhMuc;

/// <summary>
/// Seed data extension for DanhMucLoaiThanhToan entity.
/// </summary>
public static class DanhMucLoaiThanhToanSeedData {
    private static readonly DateTimeOffset SeedCreatedAt = new(2020, 1, 1, 0, 0, 0, TimeSpan.Zero);

    /// <summary>
    /// Get seed data array for runtime seeding.
    /// </summary>
    public static DanhMucLoaiThanhToan[] GetData() =>
    [
        new() { Id = 1, Ma = "TT01", Ten = "Thanh toán đợt 1", Used = true, IsDefault = true, CreatedAt = SeedCreatedAt },
        new() { Id = 2, Ma = "TT02", Ten = "Thanh toán đợt 2", Used = true, IsDefault = false, CreatedAt = SeedCreatedAt },
        new() { Id = 3, Ma = "TU", Ten = "Tạm ứng", Used = true, IsDefault = false, CreatedAt = SeedCreatedAt },
        new() { Id = 4, Ma = "TT03", Ten = "Thanh toán đợt 3", Used = true, IsDefault = false, CreatedAt = SeedCreatedAt },
        new() { Id = 5, Ma = "DK", Ten = "Thanh toán định kỳ (thuê, bảo trì, HĐĐT)", Used = true, IsDefault = false, CreatedAt = SeedCreatedAt },
        new() { Id = 6, Ma = "TT04", Ten = "Thanh toán đợt n", Used = true, IsDefault = false, CreatedAt = SeedCreatedAt },
        new() { Id = 7, Ma = "TC", Ten = "Thanh toán đợt cuối", Used = true, IsDefault = false, CreatedAt = SeedCreatedAt },
        new() { Id = 8, Ma = "TU", Ten = "Tạm ứng", Used = false, IsDefault = false, CreatedAt = SeedCreatedAt, IsDeleted = true }
    ];

    public static void SeedDanhMucLoaiThanhToan(this EntityTypeBuilder<DanhMucLoaiThanhToan> builder) => builder.HasData(GetData());
}