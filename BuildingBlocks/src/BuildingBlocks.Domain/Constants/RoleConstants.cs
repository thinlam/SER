namespace BuildingBlocks.Domain.Constants;

/// <summary>
/// Base role constants shared across all modules.
/// Each module should define its own RoleConstants in {Module}.Domain project.
/// </summary>
public static class RoleConstants
{
    /// <summary>
    /// Base role for all authenticated users.
    /// All modules inheriting from BuildingBlocks require this role at minimum.
    /// </summary>
    public const string RegisteredUsers = "Registered Users";
}
