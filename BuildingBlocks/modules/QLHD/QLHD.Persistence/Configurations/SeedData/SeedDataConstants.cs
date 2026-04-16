namespace QLHD.Persistence.Configurations.SeedData;

/// <summary>
/// Common constants for seed data across all entities.
/// </summary>
public static class SeedDataConstants
{
    /// <summary>
    /// Default UTC timestamp for all seed data (2025-01-01 00:00:00 UTC).
    /// Per seed data rules, all CreatedAt must use UTC timezone.
    /// </summary>
    public static readonly DateTimeOffset SeedCreatedAt = new(2025, 1, 1, 0, 0, 0, TimeSpan.Zero);
}