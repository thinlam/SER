namespace QLHD.Persistence.Configurations.SeedData.Business;

/// <summary>
/// Seed data extension for BaoCaoTienDo entity.
/// Note: No seed data currently defined.
/// </summary>
public static class BaoCaoTienDoSeedData
{
    /// <summary>
    /// Get seed data array for runtime seeding.
    /// </summary>
    public static BaoCaoTienDo[] GetData() => [];

    public static void SeedBaoCaoTienDo(this EntityTypeBuilder<BaoCaoTienDo> builder) => builder.HasData(GetData());
}