# EF Core Decimal Precision Configuration for QLHD Entities

**Date**: 2026-03-24 16:32
**Severity**: Low
**Component**: QLHD.Persistence - Entity Configurations
**Status**: Resolved

## What Happened

EF Core was generating truncation warnings for decimal properties in QLHD entities. The database would have stored values with default precision, potentially causing data loss for currency and percentage calculations. Configuration files needed to be created and updated to specify explicit decimal precision.

## The Brutal Truth

This was a straightforward configuration task. The warning had been there for a while but was ignored until it became a blocking issue. The solution was simple - add `HasPrecision()` calls to entity configurations. No major drama, just technical debt cleanup that should have been done earlier.

## Technical Details

**EF Core Warning:**
```
The decimal column 'TienThue' was created with default precision. Consider using HasPrecision() to specify the precision explicitly.
```

**Affected Properties:**
- `HopDong.TienThue`, `GiaTriSauThue`, `GiaTriBaoLanh` - Currency values
- `KeHoachThuTien.GiaTri`, `PhanTram` - Currency and percentage
- `KeHoachXuatHoaDon.GiaTri`, `PhanTram` - Currency and percentage

**Precision Standards Applied:**
- Currency values: `HasPrecision(18, 2)` - 18 total digits, 2 decimal places
- Percentages: `HasPrecision(5, 2)` - 5 total digits, 2 decimal places (supports 0.00% to 999.99%)

## What We Tried

1. Initially considered converting decimals to integers (cents) in DTOs - rejected by user
2. Added `HasPrecision(18, 2)` to existing `HopDongConfiguration.cs`
3. Created new configuration files for `KeHoachThuTien` and `KeHoachXuatHoaDon`
4. Applied consistent precision rules across all monetary and percentage fields

## Root Cause Analysis

The root cause was missing EF Core configuration. When entities with decimal properties are not explicitly configured, EF Core creates columns with default precision which:
- Generates compiler warnings
- Risks data truncation
- Creates ambiguity about intended precision

This happens because EF Core cannot infer the intended precision from the C# `decimal` type alone.

## Lessons Learned

1. **Always configure decimal properties explicitly** - Never rely on EF Core defaults for financial data
2. **Establish precision standards early** - Currency (18,2), Percentage (5,2) should be documented and reused
3. **Document the pattern** - Added new rule section to CLAUDE.md for future reference
4. **Keep DTOs consistent with entities** - User decision to keep decimal type in DTOs maintains type safety

## Next Steps

- Apply same precision pattern to other QLHD entities if they have decimal properties
- Consider creating a shared extension method for consistent precision configuration
- Review other modules (DVDC, QLDA, NVTT) for similar warnings