# DateTimeOffset to DateOnly Conversion for Date Range Queries

## Workflow Description

This workflow involves modifying models and query handlers to use `DateOnly` instead of `DateTimeOffset` for date range filtering properties (`TuNgay` and `DenNgay`). The changes ensure consistent date-only filtering across the application, improving precision and avoiding time-related issues in date comparisons.

### Steps Performed

1. **Identify Affected Models**: Found all models (both WebApi SearchModels and Application Queries) that have `DateTimeOffset? TuNgay` and `DateTimeOffset? DenNgay` properties.

2. **Update Models to Inherit IFromDateToDate**:
   - Changed models to inherit from `IFromDateToDate` interface, which defines `DateOnly? TuNgay` and `DateOnly? DenNgay`.
   - Removed explicit `DateTimeOffset` properties where applicable.

3. **Update Query Handlers**:
   - Modified `WhereIf` conditions to use `ToStartOfDayUtc()` and `ToEndOfDayUtc()` extensions for precise date range filtering.
   - Changed comparisons from `e.Ngay.Value >= request.TuNgay!.Value` to `e.Ngay.Value >= request.TuNgay!.Value.ToStartOfDayUtc()`.

4. **Build and Fix Errors**:
   - Compiled the WebApi project.
   - Fixed any compilation errors related to type mismatches.

## Technical Details

### Interface Used
```csharp
public interface IFromDateToDate {
    public DateOnly? TuNgay { get; set; }
    public DateOnly? DenNgay { get; set; }
}
```

### Extension Methods
```csharp
public static DateTimeOffset ToStartOfDayUtc(this DateOnly date) {
    return new DateTimeOffset(
        new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, DateTimeKind.Utc));
}

public static DateTimeOffset ToEndOfDayUtc(this DateOnly date) {
    return new DateTimeOffset(
        new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, DateTimeKind.Utc));
}
```

### Before and After Comparison

**Before:**
```csharp
public record SomeQuery : PaginationRecord, IRequest<PaginatedList<SomeDto>> {
    public DateTimeOffset? TuNgay { get; set; }
    public DateTimeOffset? DenNgay { get; set; }
}

// In handler:
.WhereIf(request.TuNgay.HasValue, e => e.Ngay.HasValue && e.Ngay.Value >= request.TuNgay!.Value)
.WhereIf(request.DenNgay.HasValue, e => e.Ngay.HasValue && e.Ngay.Value <= request.DenNgay!.Value)
```

**After:**
```csharp
public record SomeQuery : PaginationRecord, IRequest<PaginatedList<SomeDto>>, IFromDateToDate {
    // TuNgay and DenNgay inherited from IFromDateToDate
}

// In handler:
.WhereIf(request.TuNgay.HasValue,
    e => e.Ngay.HasValue && e.Ngay.Value >= request.TuNgay!.Value.ToStartOfDayUtc())
.WhereIf(request.DenNgay.HasValue,
    e => e.Ngay.HasValue && e.Ngay.Value <= request.DenNgay!.Value.ToEndOfDayUtc())
```

## Pros and Cons

### Advantages
- **Improved Precision**: Using `DateOnly` eliminates time-of-day concerns in date filtering, ensuring consistent results regardless of time components.
- **Better Performance**: Date-only comparisons are more efficient and avoid unnecessary time parsing.
- **Consistency**: Standardized interface (`IFromDateToDate`) ensures uniform handling of date ranges across the application.
- **Maintainability**: Centralized date conversion logic through extension methods.
- **Type Safety**: `DateOnly` prevents accidental time manipulations that could occur with `DateTimeOffset`.

### Disadvantages
- **Breaking Changes**: Existing API consumers may need to update their date format expectations.
- **Migration Effort**: Requires updating all related models, queries, and potentially client-side code.
- **Potential Data Loss**: If time components were previously significant, they are now ignored.
- **Increased Complexity**: Need for extension methods and interface inheritance adds some architectural complexity.
- **Testing Overhead**: Requires thorough testing to ensure date filtering works correctly across all scenarios.

## Files Modified

### WebApi Models
- `QLDA.WebApi/Models/KhoKhanVuongMacs/KhoKhanVuongMacSearchModel.cs`
- `QLDA.WebApi/Models/TongHopVanBanQuyetDinhs/TongHopVanBanQuyetDinhSearchModel.cs`
- `QLDA.WebApi/Models/QuyetDinhLapHoiDongThamDinhs/QuyetDinhLapHoiDongThamDinhSearchModel.cs`
- `QLDA.WebApi/Models/QuyetDinhLapBenMoiThaus/QuyetDinhLapBenMoiThauSearchModel.cs`
- `QLDA.WebApi/Models/QuyetDinhLapBanQLDAs/QuyetDinhLapBanQldaSearchModel.cs`
- `QLDA.WebApi/Models/DuAns/DuAnSearchModel.cs`
- `QLDA.WebApi/Models/DangTaiKeHoachLcntLenMangs/DangTaiKeHoachLcntLenMangSearchModel.cs`
- `QLDA.WebApi/Models/BaoCaoTienDos/BaoCaoTienDoSearchModel.cs`
- `QLDA.WebApi/Models/BaoCaoBaoHanhSanPhams/BaoCaoBaoHanhSanPhamSearchModel.cs`
- `QLDA.WebApi/Models/BaoCaoBanGiaoSanPhams/BaoCaoBanGiaoSanPhamSearchModel.cs`

### Application Queries
- `QLDA.Application/KhoKhanVuongMacs/Queries/KhoKhanVuongMacGetDanhSachQuery.cs`
- `QLDA.Application/TongHopVanBanQuyetDinhs/Queries/TongHopVanBanQuyetDinhGetListQuery.cs`
- `QLDA.Application/QuyetDinhLapHoiDongThamDinhs/Queries/QuyetDinhLapHoiDongThamDinhGetDanhSachQuery.cs`
- `QLDA.Application/QuyetDinhLapBenMoiThaus/Queries/QuyetDinhLapBenMoiThauGetDanhSachQuery.cs`
- And others following the same pattern.

## Conclusion

This refactoring improves the robustness and consistency of date range filtering throughout the application. While it requires careful implementation and testing, the benefits of type safety and precision outweigh the migration costs in the long term.