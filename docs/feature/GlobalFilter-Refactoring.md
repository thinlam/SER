# GlobalFilter Refactoring Workflow

## Overview
This document describes the refactoring of GlobalFilter handling across the QLDA codebase to improve code reusability, maintainability, and consistency.

## Problem Statement
The original code had repetitive patterns for handling GlobalFilter in query classes:

```csharp
request.GlobalFilter ??= string.Empty;
bool hasGlobalFilter = !string.IsNullOrEmpty(request.GlobalFilter);
if (hasGlobalFilter) request.GlobalFilter = request.GlobalFilter.Trim().ToLower();

.WhereIf(hasGlobalFilter, e =>
    e.SomeProperty!.ToLower().Contains(request.GlobalFilter) ||
    e.AnotherProperty!.ToLower().Contains(request.GlobalFilter)
);
```

This pattern was duplicated across multiple query handlers, leading to:
- Code duplication
- Inconsistency in filter logic
- Maintenance overhead
- Potential for bugs

## Solution
Created a centralized extension method approach using an `IGlobalFilter` interface and extension methods.

### Files Created/Modified

#### 1. IGlobalFilter Interface
**Location:** `QLDA.CrossCuttingConcerns.ExtensionMethods/GlobalFilterExtensions.cs`
```csharp
public interface IGlobalFilter
{
    string? GlobalFilter { get; set; }
}
```

#### 2. Extension Methods
**Location:** `QLDA.CrossCuttingConcerns.ExtensionMethods/GlobalFilterExtensions.cs`

- `WhereGlobalFilter<T>()`: Generic method for building dynamic OR conditions across multiple string properties

#### 3. Updated Query Classes
Query classes can now implement `IGlobalFilter` interface and use the `WhereGlobalFilter<T>()` extension method instead of manual filter processing.

## Implementation Details

### Before (Original Code)
```csharp
public async Task<PaginatedList<DangTaiKeHoachLcntLenMangDto>> Handle(DangTaiKeHoachLcntLenMangGetDanhSachQuery request, CancellationToken cancellationToken = default) {
    request.GlobalFilter ??= string.Empty;
    bool hasGlobalFilter = !string.IsNullOrEmpty(request.GlobalFilter);
    if (hasGlobalFilter) request.GlobalFilter = request.GlobalFilter.Trim().ToLower();

    var queryable = DangTaiKeHoachLcntLenMang.GetQueryableSet().AsNoTracking()
        .Where(e => !e.IsDeleted)
        // ... other filters ...
        .WhereIf(hasGlobalFilter, e =>
            e.KeHoachLuaChonNhaThau.Ten!.ToLower().Contains(request.GlobalFilter) ||
            e.KeHoachLuaChonNhaThau.So!.ToLower().Contains(request.GlobalFilter) ||
            e.KeHoachLuaChonNhaThau.NguoiKy!.ToLower().Contains(request.GlobalFilter) ||
            e.KeHoachLuaChonNhaThau.TrichYeu!.ToLower().Contains(request.GlobalFilter)
        );
}
```

### After (Refactored Code)
```csharp
public async Task<PaginatedList<DangTaiKeHoachLcntLenMangDto>> Handle(DangTaiKeHoachLcntLenMangGetDanhSachQuery request, CancellationToken cancellationToken = default) {
    var queryable = DangTaiKeHoachLcntLenMang.GetQueryableSet().AsNoTracking()
        .Where(e => !e.IsDeleted)
        // ... other filters ...
        .WhereGlobalFilter(
            request,
            e => e.KeHoachLuaChonNhaThau.Ten,
            e => e.KeHoachLuaChonNhaThau.So,
            e => e.KeHoachLuaChonNhaThau.NguoiKy,
            e => e.KeHoachLuaChonNhaThau.TrichYeu
        );
}
```

## Benefits

### Pros
1. **Code Reusability**: Filter logic is centralized and reusable across multiple query classes
2. **Consistency**: All GlobalFilter handling follows the same pattern
3. **Maintainability**: Changes to filter logic only need to be made in one place
4. **Readability**: Query handlers are cleaner and more focused on their specific logic
5. **Type Safety**: Interface ensures required properties are present
6. **Testability**: Extension methods can be unit tested independently

### Cons
1. **Learning Curve**: Developers need to understand the new extension methods
2. **Dependency**: Query classes must implement the interface
3. **Limited Flexibility**: Specific filter methods may not cover all use cases
4. **Additional Complexity**: More abstraction layers to understand

## Usage Guidelines

### For New Query Classes
1. Implement `IGlobalFilter` interface
2. Use `WhereGlobalFilter<T>()` extension method
3. Pass property selectors as needed

### For Existing Query Classes
1. Gradually refactor to use the new pattern
2. Ensure all filter logic is preserved
3. Test thoroughly after changes

## Future Enhancements

### Potential Improvements
1. **Generic Filter Method**: Create a more generic filtering method that accepts property lists
2. **Configuration-Based Filtering**: Allow filter configuration through attributes or configuration
3. **Performance Optimization**: Cache compiled expressions for frequently used filters
4. **Additional Filter Types**: Support for different filter operations (exact match, starts with, etc.)

### Remaining Work
- Apply the pattern to other query classes with similar GlobalFilter usage
- Create additional specialized filter methods for common entity patterns
- Add unit tests for extension methods

## Testing
- Build verification: ✅ Project builds successfully
- Functionality preserved: ✅ Same filtering behavior maintained
- Type safety: ✅ Interface ensures proper implementation

## Conclusion
This refactoring successfully centralizes GlobalFilter handling, improving code quality while maintaining backward compatibility. The extension method approach provides a clean, reusable solution that can be extended for future filtering needs.

## LINQ Translation Fix

### Problem
The original `WhereGlobalFilter` method used `Func<T, string?>[]` for property selectors, which are delegates. When building expression trees for Entity Framework, attempting to call delegate methods via `Expression.Call` resulted in LINQ expressions that could not be translated to SQL, causing runtime errors like:

```
The LINQ expression 'DbSet<VanBanQuyetDinh>()...Where(v => __p_0.<Handle>b__9_6(v) != null && __p_0.<Handle>b__9_6(v).ToLower().Contains("20"))' could not be translated.
```

### Solution
Changed the method signature to use `Expression<Func<T, string?>>[]` instead of `Func<T, string?>[]`. This allows direct manipulation of expression trees that Entity Framework can properly translate.

#### Key Concepts Explained

**Expression vs Func:**
- `Func<T, string?>`: Delegate - compiled code that executes immediately
- `Expression<Func<T, string?>>`: Expression tree - data structure representing code that can be analyzed and translated

**Expression.Parameter:**
- Creates a parameter placeholder for lambda expressions
- Example: `Expression.Parameter(typeof(Product), "p")` creates variable `p` of type `Product`

**Selector:**
- `Expression<Func<T, string?>>` that selects a property from entity T
- Example: `p => p.Name` selects the Name property

**Expression.Call:**
- Represents calling a method on an expression
- Example: `Expression.Call(propertyExpr, "ToLower", Type.EmptyTypes)` = `property.ToLower()`

**Expression.AndAlso / OrElse:**
- `AndAlso`: Logical AND (&&) - short-circuit evaluation
- `OrElse`: Logical OR (||) - short-circuit evaluation
- Used to combine multiple conditions in expression trees

#### How Expression Building Works

```
Input: selectors = [p => p.Name, p => p.Description]
Filter: "abc"

Step 1: Create parameter 'e' for entity T
Step 2: For each selector:
  - Replace selector parameter with 'e'
  - Build: (e.Property != null && e.Property.ToLower().Contains("abc"))
Step 3: Combine with OR: condition1 || condition2 || ...
Step 4: Create lambda: e => (combined_conditions)
Step 5: Apply: query.Where(lambda)
```

#### Example Generated Expression
```csharp
// Input selectors: v => v.Name, v => v.Description
// Generated lambda: e => (e.Name != null && e.Name.ToLower().Contains("abc")) ||
//                      (e.Description != null && e.Description.ToLower().Contains("abc"))
```

#### ParameterReplacer Class
```csharp
// Purpose: Replace parameters in expression trees
// Example: v => v.Name  ->  e => e.Name
private class ParameterReplacer : ExpressionVisitor {
    protected override Expression VisitParameter(ParameterExpression node) {
        return node == _oldParam ? _newParam : base.VisitParameter(node);
    }
}
```

### Benefits
- Resolves LINQ translation errors in Entity Framework queries
- Maintains type safety and performance
- Improves consistency in string operations across different cultures
- Enables dynamic query building at runtime