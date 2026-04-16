using System.Reflection;
using BuildingBlocksConstants = BuildingBlocks.Domain.Constants;

namespace QLHD.Application.Common.Attributes;

/// <summary>
/// Authorization attribute that requires user to have both base registered user role and at least one QLHD role.
/// Combines base BuildingBlocks authorization with QLHD-specific roles from QLHD.Domain.Constants.RoleConstants.
/// </summary>
public class AuthorizeAllRolesAttribute : AuthorizeAttribute
{
    public AuthorizeAllRolesAttribute()
    {
        // Get all public constant strings from QLHD.RoleConstants class
        var qlhdRoles = typeof(QLHD.Domain.Constants.RoleConstants)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(f => f.IsLiteral && !f.IsInitOnly && f.FieldType == typeof(string))
            .Select(f => (string)f.GetValue(null)!)
            .Where(role => !string.IsNullOrEmpty(role))
            .Distinct()
            .ToList();

        // Include the base BuildingBlocks registered users role to ensure proper authentication
        var allRoles = qlhdRoles.Concat(new[] { BuildingBlocksConstants.RoleConstants.RegisteredUsers }).Distinct();

        // Join roles with comma for authorization - this requires user to have at least one of the specified roles
        Roles = string.Join(",", allRoles);
    }
}