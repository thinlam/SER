namespace QLHD.Persistence.Configurations.SeedData.Business;

/// <summary>
/// Seed data extension for KhoKhanVuongMac entity.
/// Note: No seed data currently defined.
/// </summary>
public static class KhoKhanVuongMacSeedData
{
    /// <summary>
    /// Get seed data array for runtime seeding.
    /// </summary>
    public static KhoKhanVuongMac[] GetData() => [];

    public static void SeedKhoKhanVuongMac(this EntityTypeBuilder<KhoKhanVuongMac> builder) => builder.HasData(GetData());
}