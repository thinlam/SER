using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Persistence.Configurations.SeedData.DanhMuc;

/// <summary>
/// Seed data extension for DanhMucLoaiChiPhi entity.
/// </summary>
public static class DanhMucLoaiChiPhiSeedData
{
    /// <summary>
    /// Get seed data array for runtime seeding.
    /// </summary>
    public static DanhMucLoaiChiPhi[] GetData() =>
    [
        new() { Id = 1, Ma = "CP001", Ten = "Chi phí nhân công xây dựng, hiệu chỉnh", MoTa = "Chi phí nhân công xây dựng, hiệu chỉnh (MM)_30M/MM", Used = true, IsDefault = false, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 2, Ma = "CP002", Ten = "Chi phí nhân công triển khai", MoTa = "Nhân công MM triển khai", Used = true, IsDefault = false, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 3, Ma = "CP003", Ten = "Chi phí bảo hành sản phẩm", Used = true, IsDefault = false, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 4, Ma = "CP004", Ten = "Chi phí tiếp khách: Kickoff, tiếp khách, nghiệm thu", Used = true, IsDefault = false, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 5, Ma = "CP005", Ten = "Chi phí đi lại, tàu xe, máy bay", Used = true, IsDefault = false, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 6, Ma = "CP006", Ten = "Công tác phí, in ấn tài liệu", Used = true, IsDefault = false, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 7, Ma = "CP007", Ten = "Chi phí khách sạn", Used = true, IsDefault = false, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 8, Ma = "CP008", Ten = "Thưởng dự án đúng hạn", Used = true, IsDefault = false, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 9, Ma = "CP009", Ten = "Khoán chi phí dự án", Used = true, IsDefault = false, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 10, Ma = "CP010", Ten = "Outsource, mua hàng hóa, dịch vụ bên ngoài", Used = true, IsDefault = false, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 11, Ma = "CP011", Ten = "Chi phí kinh doanh, quản lý", Used = true, IsDefault = false, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 12, Ma = "CP012", Ten = "Chi phí vốn vay/trả chậm", Used = true, IsDefault = false, CreatedAt = SeedDataConstants.SeedCreatedAt },
        new() { Id = 13, Ma = "CP015", Ten = "Chi phí TK khác", Used = true, IsDefault = true, CreatedAt = SeedDataConstants.SeedCreatedAt }
    ];

    public static void SeedDanhMucLoaiChiPhi(this EntityTypeBuilder<DanhMucLoaiChiPhi> builder) => builder.HasData(GetData());
}