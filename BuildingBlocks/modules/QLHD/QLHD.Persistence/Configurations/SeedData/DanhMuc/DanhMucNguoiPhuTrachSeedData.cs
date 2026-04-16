using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Persistence.Configurations.SeedData.DanhMuc;

/// <summary>
/// Seed data extension for DanhMucNguoiPhuTrach entity.
/// </summary>
public static class DanhMucNguoiPhuTrachSeedData {
    /// <summary>
    /// Get seed data array for runtime seeding.
    /// </summary>
    public static DanhMucNguoiPhuTrach[] GetData() =>
    [
        new() {
            Id = 1,
            Ma = "NPT001",
            Ten = "Người phụ trách mặc định",
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
            Ten = "Nguyễn Văn Hậu",
            MoTa = "Bản ghi mặc định để thỏa mãn ràng buộc FK từ DuAn",
            Used = true,
            UserPortalId = 21,
            DonViId = 49,
            PhongBanId = 220,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        }
    ];

    public static void SeedDanhMucNguoiPhuTrach(this EntityTypeBuilder<DanhMucNguoiPhuTrach> builder) => builder.HasData(GetData());
}