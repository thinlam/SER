namespace QLHD.Persistence.Configurations.SeedData.Business;

/// <summary>
/// Seed data extension for DoanhNghiep entity.
/// </summary>
public static class DoanhNghiepSeedData
{
    // UTC timestamps for seed data
    private static readonly DateTimeOffset SeedCreatedAt = new(2018, 10, 11, 0, 0, 0, TimeSpan.Zero);
    private static readonly DateTimeOffset SeedUpdatedAt = new(2020, 10, 30, 16, 8, 22, TimeSpan.Zero);

    /// <summary>
    /// Get seed data array for runtime seeding.
    /// </summary>
    public static DoanhNghiep[] GetData() =>
    [
        new DoanhNghiep
        {
            Id = Guid.Parse("36456269-c0af-498c-b640-165f1273649b"),
            TaxCode = "0318546665",
            Ten = "TRUNG TÂM CHUYỂN ĐỔI SỐ THÀNH PHỐ HỒ CHÍ MINH",
            TenTiengAnh = "TRUNG TÂM CHUYỂN ĐỔI SỐ THÀNH PHỐ HỒ CHÍ MINH",
            TaxAuthorityId = 79,
            Phone = "(028) 3822 3989",
            AddressVN = "Lầu 4, Số 26 Lý Tự Trọng, Phường Bến Nghé, Quận 1, TP.HCM",
            AddressEN = "Lầu 4, Số 26 Lý Tự Trọng, Phường Bến Nghé, Quận 1, TP.HCM",
            Email = "vothitrungtrinh@tphcm.gov.vn",
            ContactPerson = "Võ Thị Trung Trinh",
            Owner = "Võ Thị Trung Trinh",
            IsLogo = true,
            LogoFileName = "logo.png",
            IsActive = true,
            AuthorizeVolume = "6D4FEBF488C433AFBFF",
            AuthorizeLic = "zZIuWonO/S8gpAmtkDwSGDbJnx3zNYMCemlRfy/+l6g=",
            AuthorizeDate = new DateTime(2020, 8, 19),
            Version = "0.1",
            CreatedBy = "b56b81a2-dc45-4c93-8a52-858a8d973e5b",
            CreatedAt = SeedCreatedAt,
            UpdatedBy = "0f9e650a-68be-45d3-a996-3f98370e1ca3",
            UpdatedAt = SeedUpdatedAt,
            IsDeleted = false,
            Index = 1
        }
    ];

    public static void SeedDoanhNghiep(this EntityTypeBuilder<DoanhNghiep> builder) => builder.HasData(GetData());
}