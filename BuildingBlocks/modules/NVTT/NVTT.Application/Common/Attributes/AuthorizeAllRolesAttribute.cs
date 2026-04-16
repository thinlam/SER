using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using NVTT.Domain.Constants;
using BuildingBlocksConstants = BuildingBlocks.Domain.Constants;

namespace NVTT.Application.Common.Attributes;

/// <summary>
/// Authorization attribute that requires user to have both base registered user role and at least one NVTT role.
/// Combines base BuildingBlocks authorization with NVTT-specific roles from NVTT.Domain.Constants.RoleConstants.
/// </summary>
public class AuthorizeAllRolesAttribute : AuthorizeAttribute
{
    public AuthorizeAllRolesAttribute()
    {
        // Get all public constant strings from NVTT.RoleConstants class
        var nvttRoles = typeof(NVTT.Domain.Constants.RoleConstants)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(f => f.IsLiteral && !f.IsInitOnly && f.FieldType == typeof(string))
            .Select(f => (string)f.GetValue(null)!)
            .Where(role => !string.IsNullOrEmpty(role))
            .Distinct()
            .ToList();

        // Include the base BuildingBlocks registered users role to ensure proper authentication
        var allRoles = nvttRoles.Concat(new[] { BuildingBlocksConstants.RoleConstants.RegisteredUsers }).Distinct();

        // Join roles with comma for authorization - this requires user to have at least one of the specified roles
        Roles = string.Join(",", allRoles);
    }
}