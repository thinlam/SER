using System.Linq.Expressions;

namespace SharedKernel.CrossCuttingConcerns.ExtensionMethods;

public interface IMayHaveGlobalFilter {
    string? GlobalFilter { get; set; }
}

public static class GlobalFilterExtensions {
    // ParameterReplacer: Class giúp thay thế parameter trong expression tree
    // Ví dụ: từ v => v.Name thành e => e.Name (thay v bằng e)
    private class ParameterReplacer(ParameterExpression oldParam, ParameterExpression newParam) : ExpressionVisitor {
        private readonly ParameterExpression _oldParam = oldParam;
        private readonly ParameterExpression _newParam = newParam;

        // VisitParameter: Phương thức override để thay thế parameter cũ bằng parameter mới
        protected override Expression VisitParameter(ParameterExpression node) {
            return node == _oldParam ? _newParam : base.VisitParameter(node);
        }
    }

    /// <summary>
    /// Áp dụng điều kiện WhereIf cho GlobalFilter search trên nhiều thuộc tính string.
    /// Xây dựng điều kiện OR động cho tất cả property selectors được cung cấp.
    /// </summary>
    /// <typeparam name="T">Kiểu entity</typeparam>
    /// <param name="query">Queryable để filter</param>
    /// <param name="request">Request implement IGlobalFilter</param>
    /// <param name="propertySelectors">Expressions để select các thuộc tính string để search</param>
    /// <returns>Queryable đã được filter</returns>
    public static IQueryable<T> WhereGlobalFilter<T>(
        this IQueryable<T> query,
        IMayHaveGlobalFilter request,
        params Expression<Func<T, string?>>[] propertySelectors) {
        // Kiểm tra nếu không có filter hoặc không có property nào để search thì trả về query gốc
        if (string.IsNullOrWhiteSpace(request.GlobalFilter) || propertySelectors.Length == 0)
            return query;

        // Chuẩn bị giá trị filter: trim và chuyển về lowercase theo culture hiện tại
        // CultureInfo.CurrentCulture đảm bảo lowercase đúng theo ngôn ngữ hiện tại
        var filterValue = request.GlobalFilter?.Trim().ToLower(System.Globalization.CultureInfo.CurrentCulture) ?? string.Empty;

        // Expression.Parameter: Tạo một parameter đại diện cho entity T trong lambda expression
        // Ví dụ: tạo biến 'e' kiểu T để dùng trong e => e.Name
        var parameter = Expression.Parameter(typeof(T), "e");
        Expression? body = null;

        // Duyệt qua từng property selector để build điều kiện OR
        foreach (var selector in propertySelectors) {
            // selector: Là Expression<Func<T, string?>>, ví dụ: v => v.Name
            // selector.Parameters[0]: Parameter của lambda (v)
            // selector.Body: Phần thân của lambda (v.Name)

            // Thay thế parameter trong selector.Body từ parameter cũ sang parameter mới
            // Ví dụ: từ v.Name thành e.Name
            var propertyCall = new ParameterReplacer(selector.Parameters[0], parameter).Visit(selector.Body);

            // Tạo điều kiện kiểm tra null: property != null
            var nullCheck = Expression.NotEqual(propertyCall, Expression.Constant(null, typeof(string)));

            // Tạo gọi phương thức ToLower(): property.ToLower()
            var toLowerCall = Expression.Call(propertyCall, "ToLower", Type.EmptyTypes);

            // Tạo gọi phương thức Contains(): property.ToLower().Contains(filterValue)
            var containsCall = Expression.Call(toLowerCall, "Contains", Type.EmptyTypes, Expression.Constant(filterValue));

            // Kết hợp null check và contains bằng AND: (property != null && property.ToLower().Contains(filterValue))
            var condition = Expression.AndAlso(nullCheck, containsCall);

            // Kết hợp các điều kiện từ nhiều properties bằng OR
            // Ví dụ: (Name.Contains("abc") || Description.Contains("abc"))
            body = body == null ? condition : Expression.OrElse(body, condition);
        }

        if (body == null) return query;

        // Tạo lambda expression hoàn chỉnh: e => body
        // Ví dụ: e => (e.Name != null && e.Name.ToLower().Contains("abc")) || (e.Description != null && e.Description.ToLower().Contains("abc"))
        var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);

        // Áp dụng Where với lambda expression đã build
        return query.Where(lambda);
    }
}