using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Persistence.Configurations.SeedData.DanhMuc;

/// <summary>
/// Seed data extension for DanhMucNguoiTheoDoi entity.
/// </summary>
public static class DanhMucNguoiTheoDoiSeedData {
    /// <summary>
    /// Get seed data array for runtime seeding.
    /// </summary>
    public static DanhMucNguoiTheoDoi[] GetData() =>
    [
        new() {
            Id = 1,
            Ma = "NTD001",
            Ten = "Người theo dõi mặc định",
            MoTa = "Bản ghi mặc định để thỏa mãn ràng buộc FK từ DuAn",
            Used = true,
            UserPortalId = 1,
            DonViId = 1,
            PhongBanId = null,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new() {
            Id = 2,
            Ma = "",
            Ten = "Lương Công Phi",
            MoTa = "Bản ghi mặc định để thỏa mãn ràng buộc FK từ DuAn",
            Used = true,
            UserPortalId = 22,
            DonViId = 49,
            PhongBanId = 220,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        }
    ];

    public static void SeedDanhMucNguoiTheoDoi(this EntityTypeBuilder<DanhMucNguoiTheoDoi> builder) => builder.HasData(GetData());
}