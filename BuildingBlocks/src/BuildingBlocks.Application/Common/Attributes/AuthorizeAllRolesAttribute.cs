using BuildingBlocks.Domain.Constants;
using Microsoft.AspNetCore.Authorization;

namespace BuildingBlocks.Application.Common.Attributes;

/// <summary>
/// Base authorization attribute that requires "Registered Users" role.
/// For module-specific authorization, use the AuthorizeAllRolesAttribute from each module's Application layer.
/// </summary>
public class AuthorizeAllRolesAttribute : AuthorizeAttribute
{
    public AuthorizeAllRolesAttribute()
    {
        // Default authorization - requires Registered Users role
        Roles = RoleConstants.RegisteredUsers;
    }
}
