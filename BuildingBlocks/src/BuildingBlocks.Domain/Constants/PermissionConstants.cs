using System.Reflection;

namespace BuildingBlocks.Domain.Constants;

public static class PermissionConstants
{
    // public static class DemoCategory
    // {
    //     public const string Create = "DemoCategory.Create";
    //     public const string Read = "DemoCategory.Read";
    //     public const string Update = "DemoCategory.Update";
    //     public const string Delete = "DemoCategory.Delete";
    // }
}
public static class PermissionHelper
{
    public static List<string> GetAllPermissions()
    {
        var allPermissions = new List<string>();

        // Lấy type của class chứa các hằng số quyền
        var permissionType = typeof(PermissionConstants);

        // Lấy tất cả các nested class public bên trong nó
        var nestedTypes = permissionType.GetNestedTypes(BindingFlags.Public);

        foreach (var type in nestedTypes)
        {
            // Lấy tất cả các trường public, static (const là static)
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

            foreach (var field in fields)
            {
                // Lấy giá trị của trường đó và thêm vào danh sách
                var propertyValue = field.GetValue(null);
                if (propertyValue is not null)
                {
                    allPermissions.Add(propertyValue.ToString()!);
                }
            }
        }

        return allPermissions;
    }
}
