namespace QLHD.Persistence.Configurations.SeedData.Business;

using static QLHD.Persistence.Configurations.SeedData.SeedDataGuids;

/// <summary>
/// Seed data extension for CongViec entity.
/// Uses centralized GUIDs from SeedDataGuids.cs to prevent FK mismatches.
/// </summary>
public static class CongViecSeedData
{
    // CongViec GUIDs (from centralized constants)
    private static readonly Guid CV1 = CongViec_01;
    private static readonly Guid CV2 = CongViec_02;
    private static readonly Guid CV3 = CongViec_03;
    private static readonly Guid CV4 = CongViec_04;
    private static readonly Guid CV5 = CongViec_05;
    private static readonly Guid CV6 = CongViec_06;

    // DuAn IDs (from centralized constants - matches DuAnSeedData exactly)
    private static readonly Guid DuAn1 = DuAn_20260326_06; // CV1, CV2, CV3 reference this DuAn (08DE8B11-...)
    private static readonly Guid DuAn2 = DuAn_20260326_03; // CV5 references this DuAn (08DE8AE6-...)
    private static readonly Guid DuAn3 = DuAn_20260330_02; // CV4 references this DuAn (08DE8E33-...) - was missing, now added
    private static readonly Guid DuAn4 = DuAn_20260330_01; // CV6 references this DuAn (08DE8E03-...)

    /// <summary>
    /// Get seed data array for runtime seeding.
    /// </summary>
    public static CongViec[] GetData() =>
    [
        new CongViec { Id = CV1, DuAnId = DuAn1, ThoiGian = new DateOnly(2026, 4, 1), UserPortalId = 22, NguoiThucHien = string.Empty, DonViId = 0, TenDonVi = string.Empty, PhongBanId = 0, TenPhongBan = string.Empty, KeHoachCongViec = "kế hoạch", NgayHoanThanh = new DateOnly(2026, 3, 27), ThucTe = "kế hoạch", TrangThaiId = 5, TenTrangThai = "Chờ xử lý", CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 26, 9, 29, 39, 414, TimeSpan.Zero), IsDeleted = false, Index = 1774517379 },
        new CongViec { Id = CV2, DuAnId = DuAn1, ThoiGian = new DateOnly(2026, 5, 1), UserPortalId = 21, NguoiThucHien = string.Empty, DonViId = 0, TenDonVi = string.Empty, PhongBanId = 0, TenPhongBan = string.Empty, KeHoachCongViec = "keHoachCongViec", NgayHoanThanh = new DateOnly(2026, 3, 28), ThucTe = "thực tế chỉnh sửa", TrangThaiId = 21, TenTrangThai = "Đang thực hiện", CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 26, 9, 35, 52, 765, TimeSpan.Zero), UpdatedBy = "24", UpdatedAt = new DateTimeOffset(2026, 3, 26, 9, 49, 53, 236, TimeSpan.Zero), IsDeleted = false, Index = 1774517752 },
        new CongViec { Id = CV3, DuAnId = DuAn1, ThoiGian = new DateOnly(2027, 6, 1), UserPortalId = 2, NguoiThucHien = string.Empty, DonViId = 0, TenDonVi = string.Empty, PhongBanId = 0, TenPhongBan = string.Empty, KeHoachCongViec = "KH", NgayHoanThanh = new DateOnly(2026, 3, 27), ThucTe = "TT", TrangThaiId = 7, TenTrangThai = "Hoàn thành", CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 26, 9, 53, 26, 880, TimeSpan.Zero), IsDeleted = false, Index = 1774518806 },
        new CongViec { Id = CV4, DuAnId = DuAn3, ThoiGian = new DateOnly(2026, 3, 1), UserPortalId = 22, NguoiThucHien = string.Empty, DonViId = 49, TenDonVi = "Trung tâm Chuyển đổi số - TPHCM", PhongBanId = 220, TenPhongBan = "Phòng Hạ tầng số và An toàn thông tin", KeHoachCongViec = "Triển khai kế hoạch dự án", NgayHoanThanh = new DateOnly(2026, 4, 5), ThucTe = "Triển khai kế hoạch dự án - chỉnh sửa", TrangThaiId = 5, TenTrangThai = "Chờ xử lý", CreatedBy = "23", CreatedAt = new DateTimeOffset(2026, 3, 30, 8, 7, 19, 432, TimeSpan.Zero), UpdatedBy = "23", UpdatedAt = new DateTimeOffset(2026, 3, 30, 8, 11, 22, 265, TimeSpan.Zero), IsDeleted = false, Index = 1774858039 },
        new CongViec { Id = CV5, DuAnId = DuAn2, ThoiGian = new DateOnly(2026, 4, 1), UserPortalId = 22, NguoiThucHien = string.Empty, DonViId = 0, TenDonVi = string.Empty, PhongBanId = 0, TenPhongBan = string.Empty, KeHoachCongViec = "kế hoạch", NgayHoanThanh = new DateOnly(2026, 3, 28), ThucTe = "kế hoạch", TrangThaiId = 5, TenTrangThai = "Chờ xử lý", CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 27, 3, 1, 29, 55, TimeSpan.Zero), IsDeleted = false, Index = 1774580489 },
        new CongViec { Id = CV6, DuAnId = DuAn4, ThoiGian = new DateOnly(2026, 3, 1), UserPortalId = 22, NguoiThucHien = string.Empty, DonViId = 49, TenDonVi = "Trung tâm Chuyển đổi số - TPHCM", PhongBanId = 220, TenPhongBan = "Phòng Hạ tầng số và An toàn thông tin", KeHoachCongViec = "kế hoạch", NgayHoanThanh = new DateOnly(2026, 3, 31), ThucTe = "thực tế", TrangThaiId = 5, TenTrangThai = "Chờ xử lý", CreatedBy = "24", CreatedAt = new DateTimeOffset(2026, 3, 30, 2, 42, 9, 947, TimeSpan.Zero), IsDeleted = false, Index = 1774838529 }
    ];

    public static void SeedCongViec(this EntityTypeBuilder<CongViec> builder) => builder.HasData(GetData());
}