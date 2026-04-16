namespace QLHD.Persistence.Configurations.SeedData.Business;

/// <summary>
/// Seed data extension for HopDongPhongBanPhoiHop junction entity.
/// Note: Uses actual entity type for composite key.
/// </summary>
public static class HopDongPhongBanPhoiHopSeedData
{
    // HopDong IDs
    private static readonly Guid HopDong1 = new("08DE8E34-0E94-CBE5-687A-7B2AD003CB9E");
    private static readonly Guid HopDong2 = new("08DE8E34-4CC7-D0C2-687A-7B2AD003CBA3");
    private static readonly Guid HopDong3 = new("08DE8BA9-EC59-9CB7-687A-7B311402C046");
    private static readonly Guid HopDong4 = new("08DE8BAA-2AFF-9D92-687A-7B311402C04C");
    private static readonly Guid HopDong5 = new("08DE8E04-EA40-BC98-687A-7B31F0054957");
    private static readonly Guid HopDong6 = new("08DE8AE2-8EB5-87C9-4BAF-8361500292E3");

    /// <summary>
    /// Get seed data array for runtime seeding.
    /// </summary>
    public static HopDongPhongBanPhoiHop[] GetData() =>
    [
        new HopDongPhongBanPhoiHop { LeftId = HopDong1, RightId = 217L, TenPhongBan = "Ban Giám đốc" },
        new HopDongPhongBanPhoiHop { LeftId = HopDong1, RightId = 218L, TenPhongBan = "Văn phòng" },
        new HopDongPhongBanPhoiHop { LeftId = HopDong1, RightId = 220L, TenPhongBan = "Phòng Hạ tầng số và An toàn thông tin" },
        new HopDongPhongBanPhoiHop { LeftId = HopDong1, RightId = 358L, TenPhongBan = "Trung Tâm Tư vấn, Đào tạo và Truyền thông số" },
        new HopDongPhongBanPhoiHop { LeftId = HopDong2, RightId = 360L, TenPhongBan = "Trung Tâm Chuyển Đổi Số Khu Vực 2" },
        new HopDongPhongBanPhoiHop { LeftId = HopDong3, RightId = 272L, TenPhongBan = "Ban Đổi mới quản lý doanh nghiệp" },
        new HopDongPhongBanPhoiHop { LeftId = HopDong4, RightId = 307L, TenPhongBan = "Đài Tiếng nói Nhân dân Thành phố Hồ Chí Minh" },
        new HopDongPhongBanPhoiHop { LeftId = HopDong5, RightId = 217L, TenPhongBan = "Ban Giám đốc" },
        new HopDongPhongBanPhoiHop { LeftId = HopDong5, RightId = 219L, TenPhongBan = "Phòng Kế hoạch - Tài chính" },
        new HopDongPhongBanPhoiHop { LeftId = HopDong5, RightId = 221L, TenPhongBan = "Phòng Nền tảng và Dữ liệu số" },
        new HopDongPhongBanPhoiHop { LeftId = HopDong5, RightId = 359L, TenPhongBan = "Trung Tâm Chuyển Đổi Số Khu Vực 1" },
        new HopDongPhongBanPhoiHop { LeftId = HopDong6, RightId = 288L, TenPhongBan = "Ban An toàn giao thông" }
    ];

    public static void SeedHopDongPhongBanPhoiHop(this EntityTypeBuilder<HopDongPhongBanPhoiHop> builder) => builder.HasData(GetData());
}