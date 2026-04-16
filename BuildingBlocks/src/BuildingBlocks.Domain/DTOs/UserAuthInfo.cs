namespace BuildingBlocks.Domain.DTOs;

/// <summary>
/// Base user authentication info shared across all modules.
/// For module-specific role checking, extend this class in each module.
/// </summary>
public class UserAuthInfo
{
    public List<string> Roles { get; set; } = [];
    public List<string> Permissions { get; set; } = [];

    /// <summary>
    /// Checks if user has any role (authenticated with valid roles)
    /// </summary>
    public bool HasRoles => Roles.Count > 0;

    /// <summary>
    /// Checks if user is denied access (no roles assigned)
    /// </summary>
    public bool AccessDenied => Roles.Count == 0;

    /// <summary>
    /// Checks if user has a specific role
    /// </summary>
    public bool HasRole(string role) => Roles.Contains(role);
}
