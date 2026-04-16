using System.Reflection;
using BuildingBlocksConstants = BuildingBlocks.Domain.Constants;

namespace QLDA.Application.Common.Attributes;

/// <summary>
/// Authorization attribute that requires user to have both base registered user role and at least one QLDA role.
/// Combines base BuildingBlocks authorization with QLDA-specific roles from QLDA.Domain.Constants.RoleConstants.
/// </summary>
public class AuthorizeAllRolesAttribute : AuthorizeAttribute
{
    public AuthorizeAllRolesAttribute()
    {
        // Get all public constant strings from QLDA.RoleConstants class
        var qldaRoles = typeof(QLDA.Domain.Constants.RoleConstants)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(f => f.IsLiteral && !f.IsInitOnly && f.FieldType == typeof(string))
            .Select(f => (string)f.GetValue(null)!)
            .Where(role => !string.IsNullOrEmpty(role))
            .Distinct()
            .ToList();

        // Include the base BuildingBlocks registered users role to ensure proper authentication
        var allRoles = qldaRoles.Concat(new[] { BuildingBlocksConstants.RoleConstants.RegisteredUsers }).Distinct();

        // Join roles with comma for authorization - this requires user to have at least one of the specified roles
        Roles = string.Join(",", allRoles);
    }
}