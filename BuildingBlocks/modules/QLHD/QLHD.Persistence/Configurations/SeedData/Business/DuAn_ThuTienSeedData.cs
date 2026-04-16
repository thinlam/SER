namespace QLHD.Persistence.Configurations.SeedData.Business;

using static QLHD.Persistence.Configurations.SeedData.SeedDataGuids;

/// <summary>
/// Seed data extension for DuAn_ThuTien entity.
/// Uses centralized GUIDs from SeedDataGuids.cs to prevent FK mismatches.
/// </summary>
public static class DuAn_ThuTienSeedData {
    // DuAn_ThuTien GUIDs
    private static readonly Guid KHTT1 = new("08DE8BE8-8909-7014-687A-7B18EC052B67");
    private static readonly Guid KHTT2 = new("08DE8AE6-F3FA-88E2-687A-7B1A0405858E");
    private static readonly Guid KHTT3 = new("08DE8AE8-8C4D-CE9B-687A-7B1A04058598");
    private static readonly Guid KHTT4 = new("08DE8E26-3B78-70F4-687A-7B1B8001E387");
    private static readonly Guid KHTT5 = new("08DE8E26-58A9-9714-687A-7B1B8001E394");
    private static readonly Guid KHTT6 = new("08DE8BE0-7700-4105-687A-7B1E74017DD0");
    private static readonly Guid KHTT7 = new("08DE8BE0-D9D5-3A75-687A-7B1E74017DD3");
    private static readonly Guid KHTT8 = new("08DE8BE0-E7E8-2A97-687A-7B1E74017DD6");
    private static readonly Guid KHTT9 = new("08DE8BE0-E897-175D-687A-7B1E74017DD9");
    private static readonly Guid KHTT10 = new("08DE8BE0-E924-2DC8-687A-7B1E74017DDC");
    private static readonly Guid KHTT11 = new("08DE8E0F-254C-7BE3-687A-7B1EC8008BA2");
    private static readonly Guid KHTT12 = new("08DE8E33-4B37-B62E-687A-7B2AD003CB70");
    private static readonly Guid KHTT13 = new("08DE8E33-4B37-D0D5-687A-7B2AD003CB71");
    private static readonly Guid KHTT14 = new("08DE8AEE-3FC7-6F7A-687A-7B2F4800AAE7");
    private static readonly Guid KHTT15 = new("08DE8AEE-575F-044D-687A-7B2F4800AAEC");
    private static readonly Guid KHTT16 = new("08DE8BA8-2569-4FA2-687A-7B311402BFF1");
    private static readonly Guid KHTT17 = new("08DE8BA8-407A-77A7-687A-7B311402BFFE");
    private static readonly Guid KHTT18 = new("08DE8BA8-407A-77EA-687A-7B311402BFFF");
    private static readonly Guid KHTT19 = new("08DE8BA8-ECDB-81AF-687A-7B311402C013");
    private static readonly Guid KHTT20 = new("08DE8BA9-007A-9CCA-687A-7B311402C018");
    private static readonly Guid KHTT21 = new("08DE8BA9-024C-0A15-687A-7B311402C01D");
    private static readonly Guid KHTT22 = new("08DE8E01-5FE5-BAFB-687A-7B31F0054911");
    private static readonly Guid KHTT23 = new("08DE8E02-8153-C181-687A-7B31F0054920");
    private static readonly Guid KHTT24 = new("08DE8E02-B0ED-B722-687A-7B31F005492E");
    private static readonly Guid KHTT25 = new("08DE8E03-F82E-3BD5-687A-7B31F0054949");

    // DuAn IDs (from centralized constants - matches DuAnSeedData exactly)
    private static readonly Guid DuAn1 = DuAn_20260327_03;
    private static readonly Guid DuAn2 = DuAn_20260326_03;
    private static readonly Guid DuAn3 = DuAn_20260326_05;
    private static readonly Guid DuAn4 = DuAn_20260326_02;
    private static readonly Guid DuAn5 = DuAn_20260326_06;
    private static readonly Guid DuAn6 = DuAn_20260327_01;
    private static readonly Guid DuAn7 = DuAn_20260327_02;
    private static readonly Guid DuAn8 = DuAn_20260327_04;
    private static readonly Guid DuAn9 = DuAn_20260327_05;
    private static readonly Guid DuAn10 = DuAn_20260327_06;
    private static readonly Guid DuAn11 = DuAn_20260327_07;
    private static readonly Guid DuAn12 = DuAn_20260327_08;
    private static readonly Guid DuAn13 = DuAn_20260330_01;

    /// <summary>
    /// Get seed data array for runtime seeding.
    /// </summary>
    public static DuAn_ThuTien[] GetData() =>
    [
        new DuAn_ThuTien { Id = KHTT1, DuAnId = DuAn1, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 4, 1), PhanTramKeHoach = 20m, GiaTriKeHoach = 400000000m, GhiChuKeHoach = "200.000.000", CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 27, 10, 6, 38, 223, TimeSpan.Zero), IsDeleted = false, Index = 1774605998 },
        new DuAn_ThuTien { Id = KHTT2, DuAnId = DuAn2, LoaiThanhToanId = 2, ThoiGianKeHoach = new DateOnly(2026, 4, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 20000000m, GhiChuKeHoach = "lần 2", CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 26, 3, 22, 47, 366, TimeSpan.Zero), IsDeleted = false, Index = 1774495367 },
        new DuAn_ThuTien { Id = KHTT3, DuAnId = DuAn3, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 3, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 1000000m, CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 26, 3, 34, 12, 420, TimeSpan.Zero), IsDeleted = false, Index = 1774496052 },
        new DuAn_ThuTien { Id = KHTT4, DuAnId = DuAn11, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 3, 1), PhanTramKeHoach = 10m, GiaTriKeHoach = 2000000000m, GhiChuKeHoach = "2.000.000.000", CreatedBy = "23", CreatedAt = new DateTimeOffset(2026, 3, 30, 6, 33, 19, 161, TimeSpan.Zero), IsDeleted = false, Index = 1774852399 },
        new DuAn_ThuTien { Id = KHTT5, DuAnId = DuAn13, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 3, 1), PhanTramKeHoach = 10m, GiaTriKeHoach = 123450000m, GhiChuKeHoach = "123.450.000", CreatedBy = "23", CreatedAt = new DateTimeOffset(2026, 3, 30, 6, 34, 8, 60, TimeSpan.Zero), IsDeleted = false, Index = 1774852448 },
        new DuAn_ThuTien { Id = KHTT6, DuAnId = DuAn4, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2025, 3, 1), PhanTramKeHoach = 50m, GiaTriKeHoach = 420.36m, GhiChuKeHoach = "string", CreatedBy = "4", CreatedAt = new DateTimeOffset(2026, 3, 27, 9, 8, 51, 987, TimeSpan.Zero), IsDeleted = false, Index = 1774602531 },
        new DuAn_ThuTien { Id = KHTT7, DuAnId = DuAn4, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2025, 3, 1), PhanTramKeHoach = 50m, GiaTriKeHoach = 420.36m, GhiChuKeHoach = "string", CreatedBy = "4", CreatedAt = new DateTimeOffset(2026, 3, 27, 9, 11, 37, 676, TimeSpan.Zero), IsDeleted = false, Index = 1774602697 },
        new DuAn_ThuTien { Id = KHTT8, DuAnId = DuAn4, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2025, 3, 1), PhanTramKeHoach = 50m, GiaTriKeHoach = 420.36m, GhiChuKeHoach = "string", CreatedBy = "4", CreatedAt = new DateTimeOffset(2026, 3, 27, 9, 12, 1, 288, TimeSpan.Zero), IsDeleted = false, Index = 1774602721 },
        new DuAn_ThuTien { Id = KHTT9, DuAnId = DuAn4, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2025, 3, 1), PhanTramKeHoach = 50m, GiaTriKeHoach = 420.36m, GhiChuKeHoach = "string", CreatedBy = "4", CreatedAt = new DateTimeOffset(2026, 3, 27, 9, 12, 2, 434, TimeSpan.Zero), IsDeleted = false, Index = 1774602722 },
        new DuAn_ThuTien { Id = KHTT10, DuAnId = DuAn4, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2025, 3, 1), PhanTramKeHoach = 50m, GiaTriKeHoach = 420.36m, GhiChuKeHoach = "string", CreatedBy = "4", CreatedAt = new DateTimeOffset(2026, 3, 27, 9, 12, 3, 359, TimeSpan.Zero), IsDeleted = false, Index = 1774602723 },
        new DuAn_ThuTien { Id = KHTT11, DuAnId = DuAn1, LoaiThanhToanId = 3, ThoiGianKeHoach = new DateOnly(2026, 6, 1), PhanTramKeHoach = 10m, GiaTriKeHoach = 200000000m, GhiChuKeHoach = "03/2026", CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 30, 3, 48, 3, 510, TimeSpan.Zero), IsDeleted = false, Index = 1774842483 },
        new DuAn_ThuTien { Id = KHTT12, DuAnId = DuAn13, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 4, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 200000000m, CreatedBy = "23", CreatedAt = new DateTimeOffset(2026, 3, 30, 8, 6, 49, 308, TimeSpan.Zero), IsDeleted = false, Index = 1774858009 },
        new DuAn_ThuTien { Id = KHTT13, DuAnId = DuAn13, LoaiThanhToanId = 2, ThoiGianKeHoach = new DateOnly(2026, 6, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 300000000m, CreatedBy = "23", CreatedAt = new DateTimeOffset(2026, 3, 30, 8, 6, 49, 308, TimeSpan.Zero), IsDeleted = false, Index = 1774858009 },
        new DuAn_ThuTien { Id = KHTT14, DuAnId = DuAn6, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 3, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 1000000m, CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 26, 4, 15, 1, 336, TimeSpan.Zero), IsDeleted = false, Index = 1774498501 },
        new DuAn_ThuTien { Id = KHTT15, DuAnId = DuAn7, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 3, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 1000000m, CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 26, 4, 15, 40, 592, TimeSpan.Zero), IsDeleted = false, Index = 1774498540 },
        new DuAn_ThuTien { Id = KHTT16, DuAnId = DuAn8, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 4, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 1000000m, CreatedBy = "23", CreatedAt = new DateTimeOffset(2026, 3, 27, 2, 25, 43, 287, TimeSpan.Zero), IsDeleted = false, Index = 1774578343 },
        new DuAn_ThuTien { Id = KHTT17, DuAnId = DuAn9, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2025, 6, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 1000000000m, CreatedBy = "4", CreatedAt = new DateTimeOffset(2026, 3, 27, 2, 26, 28, 573, TimeSpan.Zero), IsDeleted = false, Index = 1774578388 },
        new DuAn_ThuTien { Id = KHTT18, DuAnId = DuAn9, LoaiThanhToanId = 2, ThoiGianKeHoach = new DateOnly(2025, 8, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 5000000000m, CreatedBy = "4", CreatedAt = new DateTimeOffset(2026, 3, 27, 2, 26, 28, 573, TimeSpan.Zero), IsDeleted = false, Index = 1774578388 },
        new DuAn_ThuTien { Id = KHTT19, DuAnId = DuAn10, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 4, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 20000000m, GhiChuKeHoach = "YC000044", CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 27, 2, 31, 17, 779, TimeSpan.Zero), IsDeleted = false, Index = 1774578677 },
        new DuAn_ThuTien { Id = KHTT20, DuAnId = DuAn11, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 4, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 20000000m, GhiChuKeHoach = "YC000044", CreatedBy = "4", CreatedAt = new DateTimeOffset(2026, 3, 27, 2, 31, 50, 698, TimeSpan.Zero), IsDeleted = false, Index = 1774578710 },
        new DuAn_ThuTien { Id = KHTT21, DuAnId = DuAn12, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 4, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 20000000m, GhiChuKeHoach = "YC000044", CreatedBy = "4", CreatedAt = new DateTimeOffset(2026, 3, 27, 2, 31, 53, 749, TimeSpan.Zero), IsDeleted = false, Index = 1774578713 },
        new DuAn_ThuTien { Id = KHTT22, DuAnId = DuAn1, LoaiThanhToanId = 2, ThoiGianKeHoach = new DateOnly(2026, 5, 1), PhanTramKeHoach = 15m, GiaTriKeHoach = 300000000m, GhiChuKeHoach = "HĐ/02", CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 30, 2, 9, 28, 874, TimeSpan.Zero), IsDeleted = false, Index = 1774836568 },
        new DuAn_ThuTien { Id = KHTT23, DuAnId = DuAn11, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 4, 1), PhanTramKeHoach = 10m, GiaTriKeHoach = 2000000000m, GhiChuKeHoach = "2.000.000.000", CreatedBy = "23", CreatedAt = new DateTimeOffset(2026, 3, 30, 2, 17, 34, 402, TimeSpan.Zero), IsDeleted = false, Index = 1774837054 },
        new DuAn_ThuTien { Id = KHTT24, DuAnId = DuAn11, LoaiThanhToanId = 2, ThoiGianKeHoach = new DateOnly(2026, 4, 1), PhanTramKeHoach = 10m, GiaTriKeHoach = 2000000000m, GhiChuKeHoach = "2.000.000.000", CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 30, 2, 18, 54, 263, TimeSpan.Zero), IsDeleted = false, Index = 1774837134 },
        new DuAn_ThuTien { Id = KHTT25, DuAnId = DuAn13, LoaiThanhToanId = 1, ThoiGianKeHoach = new DateOnly(2026, 3, 1), PhanTramKeHoach = 0m, GiaTriKeHoach = 20000000m, CreatedBy = "23", CreatedAt = new DateTimeOffset(2026, 3, 30, 2, 28, 3, 573, TimeSpan.Zero), IsDeleted = false, Index = 1774837683 }
    ];

    public static void SeedDuAn_ThuTien(this EntityTypeBuilder<DuAn_ThuTien> builder) => builder.HasData(GetData());
}