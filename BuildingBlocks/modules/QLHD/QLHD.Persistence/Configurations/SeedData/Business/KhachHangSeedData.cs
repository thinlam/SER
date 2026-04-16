namespace QLHD.Persistence.Configurations.SeedData.Business;

/// <summary>
/// Seed data extension for KhachHang entity.
/// </summary>
public static class KhachHangSeedData
{
    // Static GUIDs for seed data consistency
    private static readonly Guid Seed1 = new("12930000-0000-0000-0000-000000000001");
    private static readonly Guid Seed2 = new("12940000-0000-0000-0000-000000000001");
    private static readonly Guid Seed3 = new("12950000-0000-0000-0000-000000000001");
    private static readonly Guid Seed4 = new("12960000-0000-0000-0000-000000000001");
    private static readonly Guid Seed5 = new("12970000-0000-0000-0000-000000000001");
    private static readonly Guid Seed6 = new("12980000-0000-0000-0000-000000000001");
    private static readonly Guid Seed7 = new("12990000-0000-0000-0000-000000000001");
    private static readonly Guid Seed8 = new("13000000-0000-0000-0000-000000000001");
    private static readonly Guid Seed9 = new("13010000-0000-0000-0000-000000000001");

    // UTC timestamps matching original data
    private static readonly DateTimeOffset Created1 = new(2025, 4, 14, 10, 23, 48, 597, TimeSpan.Zero);
    private static readonly DateTimeOffset Created2 = new(2025, 4, 15, 7, 56, 4, 560, TimeSpan.Zero);
    private static readonly DateTimeOffset Created3 = new(2026, 1, 6, 6, 58, 2, 420, TimeSpan.Zero);
    private static readonly DateTimeOffset Created4 = new(2026, 1, 6, 7, 22, 27, 57, TimeSpan.Zero);
    private static readonly DateTimeOffset Created5 = new(2026, 1, 7, 2, 11, 40, 857, TimeSpan.Zero);
    private static readonly DateTimeOffset Created6 = new(2026, 3, 9, 8, 49, 39, 573, TimeSpan.Zero);
    private static readonly DateTimeOffset Created7 = new(2026, 3, 9, 8, 52, 53, 703, TimeSpan.Zero);
    private static readonly DateTimeOffset Created8 = new(2026, 3, 16, 6, 26, 26, 750, TimeSpan.Zero);
    private static readonly DateTimeOffset Created9 = new(2026, 3, 16, 6, 31, 22, 860, TimeSpan.Zero);

    // Enterprise ID
    private static readonly Guid EnterpriseId = new("36456269-c0af-498c-b640-165f1273649b");

    /// <summary>
    /// Get seed data array for runtime seeding.
    /// </summary>
    public static KhachHang[] GetData() =>
    [
        new KhachHang
        {
            Id = Seed1, Ma = "CUST-14042025052348", Ten = "Ban Quản lý đường sắt đô thị thành phố",
            TaxCode = "0305250928", Address = "29 Lê Quý Đôn, Phường Võ Thị Sáu, Quận 3, Thành phố Hồ Chí Minh, Việt Nam",
            DistrictId = 770, DistrictName = "Quận 3", CityId = 79, CityName = "Thành phố Hồ Chí Minh",
            CountryId = 1311, CountryName = "Việt Nam", IsDefault = false, Used = true,
            DoanhNghiepId = EnterpriseId, CreatedBy = "18b34731-6b0d-46f3-a919-5e4707db4f1b",
            CreatedAt = Created1, UpdatedBy = "18b34731-6b0d-46f3-a919-5e4707db4f1b", UpdatedAt = Created1, Index = 1
        },
        new KhachHang
        {
            Id = Seed2, Ma = "CUST-15042025025604", Ten = "Sở Y tế TP. HCM",
            TaxCode = "0312163017", Address = "59 Đ. Nguyễn Thị Minh Khai, Phường Bến Thành, Quận 1, Hồ Chí Minh",
            DistrictId = 760, DistrictName = "Quận 1", CityId = 79, CityName = "Thành phố Hồ Chí Minh",
            CountryId = 1311, CountryName = "Việt Nam", IsDefault = false, Used = true,
            DoanhNghiepId = EnterpriseId, CreatedBy = "18b34731-6b0d-46f3-a919-5e4707db4f1b",
            CreatedAt = Created2, UpdatedBy = "18b34731-6b0d-46f3-a919-5e4707db4f1b", UpdatedAt = Created2, Index = 2
        },
        new KhachHang
        {
            Id = Seed3, Ma = "CUST-06012026015802", Ten = "cty xyz",
            TaxCode = "07010042", ContactPerson = "nguyễn a", Address = "123 abc phường zy", Phone = "0707926805",
            DistrictId = 493, DistrictName = "Quận Sơn Trà", CityId = 48, CityName = "Thành phố Đà Nẵng",
            CountryId = 1311, CountryName = "Việt Nam", IsDefault = false, Used = true,
            DoanhNghiepId = EnterpriseId, CreatedBy = "cab94c06-8f22-480a-b4b3-4b427acc63f3",
            CreatedAt = Created3, UpdatedBy = "cab94c06-8f22-480a-b4b3-4b427acc63f3", UpdatedAt = Created3, Index = 3
        },
        new KhachHang
        {
            Id = Seed4, Ma = "0123123", Ten = "Cty Test 1",
            TaxCode = "012321321231", Address = "123 Test",
            DistrictId = 760, DistrictName = "Quận 1", CityId = 79, CityName = "Thành phố Hồ Chí Minh",
            CountryId = 1311, CountryName = "Việt Nam", IsDefault = false, Used = true,
            DoanhNghiepId = EnterpriseId, CreatedBy = "cab94c06-8f22-480a-b4b3-4b427acc63f3",
            CreatedAt = Created4, UpdatedBy = "cab94c06-8f22-480a-b4b3-4b427acc63f3", UpdatedAt = Created4, Index = 4
        },
        new KhachHang
        {
            Id = Seed5, Ma = "123", Ten = "Phạm Lê Hoàng",
            TaxCode = "07010042", ContactPerson = "Phạm Lê Hoàng", Address = "123 abc phường zy", Phone = "0707926805",
            DistrictId = 760, DistrictName = "Quận 1", CityId = 79, CityName = "Thành phố Hồ Chí Minh",
            CountryId = 1311, CountryName = "Việt Nam", IsDefault = false, Used = true,
            CreatedBy = "cab94c06-8f22-480a-b4b3-4b427acc63f3",
            CreatedAt = Created5, UpdatedBy = "cab94c06-8f22-480a-b4b3-4b427acc63f3", UpdatedAt = Created5, Index = 5
        },
        new KhachHang
        {
            Id = Seed6, Ma = "CUST-09032026034939", Ten = "Nam",
            TaxCode = "123", Address = "tphcm",
            DistrictId = 760, DistrictName = "Quận 1", CityId = 79, CityName = "Thành phố Hồ Chí Minh",
            CountryId = 1311, CountryName = "Việt Nam", IsDefault = false, Used = true,
            CreatedBy = "cab94c06-8f22-480a-b4b3-4b427acc63f3",
            CreatedAt = Created6, UpdatedBy = "cab94c06-8f22-480a-b4b3-4b427acc63f3", UpdatedAt = Created6, Index = 6
        },
        new KhachHang
        {
            Id = Seed7, Ma = "CUST-09032026035253", Ten = "Nam",
            TaxCode = "123", Address = "tphcm",
            DistrictId = 760, DistrictName = "Quận 1", CityId = 79, CityName = "Thành phố Hồ Chí Minh",
            CountryId = 1311, CountryName = "Việt Nam", IsDefault = false, Used = true,
            DoanhNghiepId = EnterpriseId, CreatedBy = "cab94c06-8f22-480a-b4b3-4b427acc63f3",
            CreatedAt = Created7, UpdatedBy = "cab94c06-8f22-480a-b4b3-4b427acc63f3", UpdatedAt = Created7, Index = 7
        },
        new KhachHang
        {
            Id = Seed8, Ma = "001", Ten = "Khách hàng tiềm năng",
            TaxCode = "0792000123", ContactPerson = "Nguyễn Văn A", Address = "Phường Sài Gòn thành phố Hồ Chí Minh",
            DistrictId = 760, DistrictName = "Quận 1", CityId = 79, CityName = "Thành phố Hồ Chí Minh",
            CountryId = 1311, CountryName = "Việt Nam", IsDefault = false, Used = true,
            CreatedBy = "cab94c06-8f22-480a-b4b3-4b427acc63f3",
            CreatedAt = Created8, UpdatedBy = "cab94c06-8f22-480a-b4b3-4b427acc63f3", UpdatedAt = Created8, Index = 8
        },
        new KhachHang
        {
            Id = Seed9, Ma = "NEW01", Ten = "Khách hàng mới 01",
            TaxCode = "079199912345", ContactPerson = "Nguyễn Văn A", Address = "Phường Sài Gòn",
            DistrictId = 760, DistrictName = "Quận 1", CityId = 79, CityName = "Thành phố Hồ Chí Minh",
            CountryId = 1311, CountryName = "Việt Nam", IsDefault = false, Used = true,
            DoanhNghiepId = EnterpriseId, CreatedBy = "cab94c06-8f22-480a-b4b3-4b427acc63f3",
            CreatedAt = Created9, UpdatedBy = "cab94c06-8f22-480a-b4b3-4b427acc63f3", UpdatedAt = Created9, Index = 9
        }
    ];

    public static void SeedKhachHang(this EntityTypeBuilder<KhachHang> builder) => builder.HasData(GetData());
}