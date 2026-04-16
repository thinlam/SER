using System.ComponentModel;
using System.Reflection;

namespace SharedKernel.CrossCuttingConcerns.ExtensionMethods
{
    public static class PropertyInfoExtensions
    {
        /// <summary>
        /// Lấy giá trị Description từ attribute [Description] của property.
        /// Nếu không có attribute, trả về tên property.
        /// </summary>
        public static string GetDescription(this PropertyInfo property)
        {
            return property.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() is DescriptionAttribute attr ? attr.Description : property.Name;
        }
    }
}