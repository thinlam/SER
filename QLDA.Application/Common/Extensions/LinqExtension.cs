using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace QLDA.Application.Common.Extensions;

public static class LinqExtension {
    public static IQueryable<T> IncludeNotDeleted<T, TProperty>(this IQueryable<T> query, Expression<Func<T, TProperty>> navigationProperty)
        where T : class where TProperty : class {
        if (navigationProperty.Body is not MemberExpression memberExpression) throw new ArgumentException("Expression must be a member access");
        var property = memberExpression.Member as System.Reflection.PropertyInfo ?? throw new ArgumentException("Expression must be a property access");
        var propertyType = property.PropertyType;
        if (typeof(System.Collections.IEnumerable).IsAssignableFrom(propertyType) && propertyType.IsGenericType) {
            var elementType = propertyType.GetGenericArguments()[0];
            if (typeof(IMayHaveDelete).IsAssignableFrom(elementType)) {
                // Build e => e.property.Where(p => !p.IsDeleted)
                var parameter = Expression.Parameter(typeof(T), "e");
                var propertyAccess = Expression.Property(parameter, property);
                var pParameter = Expression.Parameter(elementType, "p");
                var isDeletedProperty = Expression.Property(pParameter, "IsDeleted");
                var notIsDeleted = Expression.Not(isDeletedProperty);
                var whereLambda = Expression.Lambda(notIsDeleted, pParameter);
                var whereMethod = typeof(System.Linq.Enumerable).GetMethods().First(m => m.Name == "Where" && m.GetParameters().Length == 2).MakeGenericMethod(elementType);
                var whereCall = Expression.Call(whereMethod, propertyAccess, whereLambda);
                var includeLambda = Expression.Lambda(whereCall, parameter);
                return query.Include((Expression<Func<T, object>>)includeLambda);
            }
        }
        // For non-collections or collections not implementing IMayHaveDelete, just Include
        return query.Include(navigationProperty);
    }
}