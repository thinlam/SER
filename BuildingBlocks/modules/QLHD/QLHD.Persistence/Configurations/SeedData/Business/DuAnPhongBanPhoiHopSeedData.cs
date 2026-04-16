namespace QLHD.Persistence.Configurations.SeedData.Business;

using static QLHD.Persistence.Configurations.SeedData.SeedDataGuids;

/// <summary>
/// Seed data extension for DuAnPhongBanPhoiHop junction entity.
/// Uses centralized GUIDs from SeedDataGuids.cs to prevent FK mismatches.
/// </summary>
public static class DuAnPhongBanPhoiHopSeedData
{
    // DuAn IDs (from centralized constants - matches DuAnSeedData exactly)
    private static readonly Guid DuAn1 = DuAn_20260326_01;
    private static readonly Guid DuAn2 = DuAn_20260326_02;
    private static readonly Guid DuAn3 = DuAn_20260326_03;
    private static readonly Guid DuAn4 = DuAn_20260326_04;
    private static readonly Guid DuAn5 = DuAn_20260326_05;
    private static readonly Guid DuAn6 = DuAn_20260326_06;
    private static readonly Guid DuAn7 = DuAn_20260330_02; // Was missing, now added to DuAnSeedData
    private static readonly Guid DuAn8 = DuAn_20260327_01;
    private static readonly Guid DuAn9 = DuAn_20260327_02;
    private static readonly Guid DuAn10 = DuAn_20260327_03;
    private static readonly Guid DuAn11 = DuAn_20260327_04;
    private static readonly Guid DuAn12 = DuAn_20260327_06;
    private static readonly Guid DuAn13 = DuAn_20260327_07;
    private static readonly Guid DuAn14 = DuAn_20260327_08;
    private static readonly Guid DuAn15 = DuAn_20260330_01;

    /// <summary>
    /// Get seed data array for runtime seeding.
    /// </summary>
    public static DuAnPhongBanPhoiHop[] GetData() =>
    [
        new DuAnPhongBanPhoiHop { LeftId = DuAn1, RightId = 307L, TenPhongBan = "Đài Tiếng nói Nhân dân Thành phố Hồ Chí Minh" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn2, RightId = 307L, TenPhongBan = "Đài Tiếng nói Nhân dân Thành phố Hồ Chí Minh" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn3, RightId = 261L, TenPhongBan = "Ban Dân tộc" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn3, RightId = 271L, TenPhongBan = "Ban Quản lý dự án đầu tư xây dựng hạ tầng đô thị" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn3, RightId = 288L, TenPhongBan = "Ban An toàn giao thông" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn3, RightId = 304L, TenPhongBan = "Ban Quản lý dự án đầu tư xây dựng các công trình dân dụng" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn4, RightId = 307L, TenPhongBan = "Đài Tiếng nói Nhân dân Thành phố Hồ Chí Minh" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn5, RightId = 261L, TenPhongBan = "Ban Dân tộc" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn6, RightId = 307L, TenPhongBan = "Đài Tiếng nói Nhân dân Thành phố Hồ Chí Minh" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn7, RightId = 217L, TenPhongBan = "Ban Giám đốc" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn7, RightId = 218L, TenPhongBan = "Văn phòng" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn7, RightId = 220L, TenPhongBan = "Phòng Hạ tầng số và An toàn thông tin" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn7, RightId = 358L, TenPhongBan = "Trung Tâm Tư vấn, Đào tạo và Truyền thông số" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn8, RightId = 307L, TenPhongBan = "Đài Tiếng nói Nhân dân Thành phố Hồ Chí Minh" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn9, RightId = 307L, TenPhongBan = "Đài Tiếng nói Nhân dân Thành phố Hồ Chí Minh" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn10, RightId = 307L, TenPhongBan = "Đài Tiếng nói Nhân dân Thành phố Hồ Chí Minh" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn11, RightId = 217L, TenPhongBan = "Ban Giám đốc" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn11, RightId = 219L, TenPhongBan = "Phòng Kế hoạch - Tài chính" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn11, RightId = 360L, TenPhongBan = "Trung Tâm Chuyển Đổi Số Khu Vực 2" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn12, RightId = 272L, TenPhongBan = "Ban Đổi mới quản lý doanh nghiệp" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn13, RightId = 272L, TenPhongBan = "Ban Đổi mới quản lý doanh nghiệp" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn14, RightId = 272L, TenPhongBan = "Ban Đổi mới quản lý doanh nghiệp" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn15, RightId = 217L, TenPhongBan = "Ban Giám đốc" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn15, RightId = 219L, TenPhongBan = "Phòng Kế hoạch - Tài chính" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn15, RightId = 221L, TenPhongBan = "Phòng Nền tảng và Dữ liệu số" },
        new DuAnPhongBanPhoiHop { LeftId = DuAn15, RightId = 359L, TenPhongBan = "Trung Tâm Chuyển Đổi Số Khu Vực 1" }
    ];

    public static void SeedDuAnPhongBanPhoiHop(this EntityTypeBuilder<DuAnPhongBanPhoiHop> builder) => builder.HasData(GetData());
}