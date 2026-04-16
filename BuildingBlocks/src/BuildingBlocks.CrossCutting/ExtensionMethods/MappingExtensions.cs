namespace BuildingBlocks.CrossCutting.ExtensionMethods;

using System;
using System.Linq;
using System.Reflection;

public static class MappingExtensions
{
    /// <summary>
    /// Maps all publicly readable properties from <typeparamref name="TSource"/>
    /// onto publicly writable properties of <typeparamref name="TTarget"/> with the same name.
    /// </summary>
    public static TTarget MapTo<TSource, TTarget>(this TSource source)
        where TTarget : new()
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        var target = new TTarget();
        // get all readable properties on source
        var sourceProps = typeof(TSource)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanRead);

        // get all writable properties on target, keyed by name
        var targetProps = typeof(TTarget)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanWrite)
            .ToDictionary(p => p.Name);

        foreach (var sp in sourceProps)
        {
            if (targetProps.TryGetValue(sp.Name, out var tp))
            {
                var value = sp.GetValue(source);
                if (value == null) continue;

                var targetType = Nullable.GetUnderlyingType(tp.PropertyType)
                                 ?? tp.PropertyType;

                if (targetType.IsEnum)
                {
                    // xử lý enum
                    var enumValue = Enum.Parse(targetType, value.ToString()!);
                    tp.SetValue(target, enumValue);
                }
                else if (targetType.IsAssignableFrom(value.GetType()))
                {
                    tp.SetValue(target, value);
                }
                else
                {
                    // thử convert ChangeType
                    var converted = Convert.ChangeType(value, targetType);
                    tp.SetValue(target, converted);
                }
            }

        }


        return target;
    }
}