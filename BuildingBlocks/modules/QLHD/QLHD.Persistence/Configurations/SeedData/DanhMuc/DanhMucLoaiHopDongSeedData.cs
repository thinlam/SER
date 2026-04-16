using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Persistence.Configurations.SeedData.DanhMuc;

/// <summary>
/// Seed data extension for DanhMucLoaiHopDong entity.
/// </summary>
public static class DanhMucLoaiHopDongSeedData
{
    /// <summary>
    /// Get seed data array for runtime seeding.
    /// </summary>
    public static DanhMucLoaiHopDong[] GetData() =>
    [
        new() { Id = 1, Ma = "C0001", Ten = "Hợp đồng Software", Used = true, Symbol = "TTCĐS-", Prefix = 1, IsDefault = false, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 2, Ma = "C0002", Ten = "Hợp đồng Hardware", Used = true, Symbol = "TTCĐS-", Prefix = 1, IsDefault = false, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 3, Ma = "C0003", Ten = "Hợp đồng bảo trì", Used = true, Symbol = "TTCĐS-", Prefix = 1, IsDefault = false, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 4, Ma = "C0004", Ten = "Hợp đồng cho thuê, trả góp", Used = true, Symbol = "TTCĐS-", Prefix = 1, IsDefault = false, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 5, Ma = "C0005", Ten = "Hợp đồng Hóa đơn điện tử (theo số)", Used = false, Symbol = "TTCĐS-", Prefix = 1, IsDefault = false, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 6, Ma = "C0006", Ten = "Hợp đồng dịch vụ khác", Used = true, Symbol = "TTCĐS-", Prefix = 1, IsDefault = false, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 7, Ma = "C0007", Ten = "Hợp đồng tư vấn", Used = true, Symbol = "TTCĐS-", Prefix = 1, IsDefault = true, CreatedAt = SeedDataConstants.SeedCreatedAt }
    ];

    public static void SeedDanhMucLoaiHopDong(this EntityTypeBuilder<DanhMucLoaiHopDong> builder) => builder.HasData(GetData());
}