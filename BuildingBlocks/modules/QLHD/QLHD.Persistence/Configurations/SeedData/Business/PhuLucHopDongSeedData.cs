namespace QLHD.Persistence.Configurations.SeedData.Business;

/// <summary>
/// Seed data extension for PhuLucHopDong entity.
/// </summary>
public static class PhuLucHopDongSeedData
{
    // Static GUIDs from SQL seed data
    private static readonly Guid PLHD1 = new("08DE8E34-65F2-3572-687A-7B2AD003CBA4");
    private static readonly Guid PLHD2 = new("08DE8E2C-E7D1-16E8-687A-7B351006E476");
    private static readonly Guid PLHD3 = new("08DE8E2D-6722-CC2E-687A-7B351006E48D");

    // HopDong IDs
    private static readonly Guid HopDong1 = new("08DE8E34-0E94-CBE5-687A-7B2AD003CB9E");
    private static readonly Guid HopDong2 = new("08DE8BAA-2AFF-9D92-687A-7B311402C04C");
    private static readonly Guid HopDong3 = new("08DE8E04-EA40-BC98-687A-7B31F0054957");

    /// <summary>
    /// Get seed data array for runtime seeding.
    /// </summary>
    public static PhuLucHopDong[] GetData() =>
    [
        new PhuLucHopDong { Id = PLHD1, HopDongId = HopDong1, SoPhuLuc = "PL/03-2026", NgayKy = new DateOnly(2026, 3, 31), NoiDungPhuLuc = "thông tin phụ lục hợp đồng - chỉnh sửa", CreatedBy = "23", CreatedAt = new DateTimeOffset(2026, 3, 30, 8, 14, 43, 305, TimeSpan.Zero), UpdatedBy = "23", UpdatedAt = new DateTimeOffset(2026, 3, 30, 8, 15, 38, 777, TimeSpan.Zero), IsDeleted = false, Index = 1774858483 },
        new PhuLucHopDong { Id = PLHD2, HopDongId = HopDong2, SoPhuLuc = "PL-01", NgayKy = new DateOnly(2026, 3, 31), NoiDungPhuLuc = "phụ lục hợp đồng 01", CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 30, 7, 21, 5, 308, TimeSpan.Zero), IsDeleted = false, Index = 1774855265 },
        new PhuLucHopDong { Id = PLHD3, HopDongId = HopDong3, SoPhuLuc = "PL-01", NgayKy = new DateOnly(2026, 3, 31), NoiDungPhuLuc = "PHỤ LỤC HỢP ĐỒNG", CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 30, 7, 24, 38, 820, TimeSpan.Zero), IsDeleted = false, Index = 1774855478 }
    ];

    public static void SeedPhuLucHopDong(this EntityTypeBuilder<PhuLucHopDong> builder) => builder.HasData(GetData());
}