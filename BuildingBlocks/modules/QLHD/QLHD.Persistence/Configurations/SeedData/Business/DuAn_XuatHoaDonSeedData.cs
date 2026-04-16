namespace QLHD.Persistence.Configurations.SeedData.Business;

using static QLHD.Persistence.Configurations.SeedData.SeedDataGuids;

/// <summary>
/// Seed data extension for DuAn_XuatHoaDon entity.
/// Uses centralized GUIDs from SeedDataGuids.cs to prevent FK mismatches.
/// </summary>
public static class DuAn_XuatHoaDonSeedData {
    // DuAn_XuatHoaDon GUIDs
    private static readonly Guid KHXHD1 = new("08DE8E15-BBA3-975B-687A-7B17FC0696F6");
    private static readonly Guid KHXHD2 = new("08DE8AE6-F3FA-8985-687A-7B1A0405858F");
    private static readonly Guid KHXHD3 = new("08DE8AE8-8C4D-CF0A-687A-7B1A04058599");
    private static readonly Guid KHXHD4 = new("08DE8E26-83F5-298D-687A-7B1B8001E3A0");
    private static readonly Guid KHXHD5 = new("08DE8E33-4B37-EE56-687A-7B2AD003CB72");
    private static readonly Guid KHXHD6 = new("08DE8E33-4B38-06A5-687A-7B2AD003CB73");
    private static readonly Guid KHXHD7 = new("08DE8AEE-3FC7-C32A-687A-7B2F4800AAE8");
    private static readonly Guid KHXHD8 = new("08DE8AEE-575F-04BC-687A-7B2F4800AAED");
    private static readonly Guid KHXHD9 = new("08DE8BA8-2569-936F-687A-7B311402BFF2");
    private static readonly Guid KHXHD10 = new("08DE8BA8-407A-7841-687A-7B311402C000");
    private static readonly Guid KHXHD11 = new("08DE8BA8-407A-7854-687A-7B311402C001");
    private static readonly Guid KHXHD12 = new("08DE8BA8-ECDB-820A-687A-7B311402C014");
    private static readonly Guid KHXHD13 = new("08DE8BA9-007A-9D8F-687A-7B311402C019");
    private static readonly Guid KHXHD14 = new("08DE8BA9-024C-0A97-687A-7B311402C01E");
    private static readonly Guid KHXHD15 = new("08DE8E03-F82E-74D9-687A-7B31F005494A");

    // DuAn IDs (from centralized constants - matches DuAnSeedData exactly)
    private static readonly Guid DuAn1 = DuAn_20260327_03;
    private static readonly Guid DuAn2 = DuAn_20260326_03;
    private static readonly Guid DuAn3 = DuAn_20260326_05;
    private static readonly Guid DuAn4 = DuAn_20260330_01;
    private static readonly Guid DuAn5 = DuAn_20260330_02; // Was missing, now added to DuAnSeedData
    private static readonly Guid DuAn6 = DuAn_20260327_01;
    private static readonly Guid DuAn7 = DuAn_20260327_02;
    private static readonly Guid DuAn8 = DuAn_20260327_04;
    private static readonly Guid DuAn9 = DuAn_20260327_05;
    private static readonly Guid DuAn10 = DuAn_20260327_06;
    private static readonly Guid DuAn11 = DuAn_20260327_07;
    private static readonly Guid DuAn12 = DuAn_20260327_08;

    /// <summary>
    /// Get seed data array for runtime seeding.
    /// </summary>
    public static DuAn_XuatHoaDon[] GetData() =>
    [
        new DuAn_XuatHoaDon { Id = KHXHD1, DuAnId = DuAn1, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 3, 1), PhanTramKeHoach = 10m, GiaTriKeHoach = 200000000m, GhiChuKeHoach = "200.000.000", CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 30, 4, 35, 12, 773, TimeSpan.Zero), IsDeleted = false, Index = 1774845312 },
        new DuAn_XuatHoaDon { Id = KHXHD2, DuAnId = DuAn2, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 4, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 20000000m, GhiChuKeHoach = "lần 1", CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 26, 3, 22, 47, 366, TimeSpan.Zero), IsDeleted = false, Index = 1774495367 },
        new DuAn_XuatHoaDon { Id = KHXHD3, DuAnId = DuAn3, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 3, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 1000000m, CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 26, 3, 34, 12, 420, TimeSpan.Zero), IsDeleted = false, Index = 1774496052 },
        new DuAn_XuatHoaDon { Id = KHXHD4, DuAnId = DuAn4, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 3, 1), PhanTramKeHoach = 10m, GiaTriKeHoach = 123450000m, GhiChuKeHoach = "123.450.000", CreatedBy = "23", CreatedAt = new DateTimeOffset(2026, 3, 30, 6, 35, 20, 741, TimeSpan.Zero), IsDeleted = false, Index = 1774852520 },
        new DuAn_XuatHoaDon { Id = KHXHD5, DuAnId = DuAn5, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 4, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 200000000m, CreatedBy = "23", CreatedAt = new DateTimeOffset(2026, 3, 30, 8, 6, 49, 308, TimeSpan.Zero), IsDeleted = false, Index = 1774858009 },
        new DuAn_XuatHoaDon { Id = KHXHD6, DuAnId = DuAn5, LoaiThanhToanId = 2, ThoiGianKeHoach = new DateOnly(2026, 6, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 300000000m, CreatedBy = "23", CreatedAt = new DateTimeOffset(2026, 3, 30, 8, 6, 49, 308, TimeSpan.Zero), IsDeleted = false, Index = 1774858009 },
        new DuAn_XuatHoaDon { Id = KHXHD7, DuAnId = DuAn6, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 3, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 1000000m, CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 26, 4, 15, 1, 336, TimeSpan.Zero), IsDeleted = false, Index = 1774498501 },
        new DuAn_XuatHoaDon { Id = KHXHD8, DuAnId = DuAn7, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 3, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 1000000m, CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 26, 4, 15, 40, 592, TimeSpan.Zero), IsDeleted = false, Index = 1774498540 },
        new DuAn_XuatHoaDon { Id = KHXHD9, DuAnId = DuAn8, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 4, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 1000000m, CreatedBy = "23", CreatedAt = new DateTimeOffset(2026, 3, 27, 2, 25, 43, 287, TimeSpan.Zero), IsDeleted = false, Index = 1774578343 },
        new DuAn_XuatHoaDon { Id = KHXHD10, DuAnId = DuAn9, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2025, 6, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 1000000000m, GhiChuKeHoach = "hgc1", CreatedBy = "4", CreatedAt = new DateTimeOffset(2026, 3, 27, 2, 26, 28, 573, TimeSpan.Zero), IsDeleted = false, Index = 1774578388 },
        new DuAn_XuatHoaDon { Id = KHXHD11, DuAnId = DuAn9, LoaiThanhToanId = 2, ThoiGianKeHoach = new DateOnly(2025, 8, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 5000000000m, GhiChuKeHoach = "ghc2", CreatedBy = "4", CreatedAt = new DateTimeOffset(2026, 3, 27, 2, 26, 28, 573, TimeSpan.Zero), IsDeleted = false, Index = 1774578388 },
        new DuAn_XuatHoaDon { Id = KHXHD12, DuAnId = DuAn10, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 4, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 20000000m, GhiChuKeHoach = "YC000044", CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 27, 2, 31, 17, 779, TimeSpan.Zero), IsDeleted = false, Index = 1774578677 },
        new DuAn_XuatHoaDon { Id = KHXHD13, DuAnId = DuAn11, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 4, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 20000000m, GhiChuKeHoach = "YC000044", CreatedBy = "4", CreatedAt = new DateTimeOffset(2026, 3, 27, 2, 31, 50, 698, TimeSpan.Zero), IsDeleted = false, Index = 1774578710 },
        new DuAn_XuatHoaDon { Id = KHXHD14, DuAnId = DuAn12, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 4, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 20000000m, GhiChuKeHoach = "YC000044", CreatedBy = "4", CreatedAt = new DateTimeOffset(2026, 3, 27, 2, 31, 53, 749, TimeSpan.Zero), IsDeleted = false, Index = 1774578713 },
        new DuAn_XuatHoaDon { Id = KHXHD15, DuAnId = DuAn4, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 3, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 200000000m, CreatedBy = "23", CreatedAt = new DateTimeOffset(2026, 3, 30, 2, 28, 3, 573, TimeSpan.Zero), IsDeleted = false, Index = 1774837683 }
    ];

    public static void SeedDuAn_XuatHoaDon(this EntityTypeBuilder<DuAn_XuatHoaDon> builder) => builder.HasData(GetData());
}