namespace QLHD.Persistence.Configurations.SeedData.Business;

/// <summary>
/// Seed data extension for TienDo entity.
/// Note: No seed data currently defined.
/// </summary>
public static class TienDoSeedData
{
    /// <summary>
    /// Get seed data array for runtime seeding.
    /// </summary>
    public static TienDo[] GetData() => [];

    public static void SeedTienDo(this EntityTypeBuilder<TienDo> builder) => builder.HasData(GetData());
}