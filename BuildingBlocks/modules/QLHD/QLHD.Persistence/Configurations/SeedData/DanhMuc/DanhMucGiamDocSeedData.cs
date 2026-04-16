using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Persistence.Configurations.SeedData.DanhMuc;

/// <summary>
/// Seed data extension for DanhMucGiamDoc entity.
/// </summary>
public static class DanhMucGiamDocSeedData {
    /// <summary>
    /// Get seed data array for runtime seeding.
    /// </summary>
    public static DanhMucGiamDoc[] GetData() =>
    [
        new() {
            Id = 1,
            Ma = "GD001",
            Ten = "Giám đốc mặc định",
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
            Ten = "Võ Thị Trung Trinh",
            MoTa = "Bản ghi mặc định để thỏa mãn ràng buộc FK từ DuAn",
            Used = true,
            UserPortalId = 2,
            DonViId = 49,
            PhongBanId = 217,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        }
    ];

    public static void SeedDanhMucGiamDoc(this EntityTypeBuilder<DanhMucGiamDoc> builder) => builder.HasData(GetData());
}