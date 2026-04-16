# KeHoachThangReportQuery Logic Inversion

**Date**: 2026-04-14 15:30
**Severity**: Medium
**Component**: QLHD.Application/BaoCaos
**Status**: Resolved

## What Happened

Successfully inverted the KeHoachThangReportQuery logic to fix reporting gaps. Previously, the query started from version entities and navigated to source entities, which missed records that hadn't been "chốt kế hoạch tháng" (locked for the month). The new approach starts from source entities and LEFT JOINs to version tables, ensuring all records appear regardless of lock status.

## The Brutal Truth

This change felt like we should have designed it this way from the beginning. The original approach was fundamentally flawed because version tables only exist after monthly locking occurs. The frustrating part was that we spent time debugging why some records weren't showing up in reports until we realized the architectural mismatch between business logic (versioning only after locking) and query design (assuming versions always exist).

## Technical Details

Modified `modules/QLHD/QLHD.Application/BaoCaos/Queries/KeHoachThangReportQuery.cs`:
- Changed query structure from Version→Source to Source→Version LEFT JOIN
- Added repositories for source entities: DuAn_ThuTien, DuAn_XuatHoaDon, HopDong_ThuTien, HopDong_XuatHoaDon, HopDong_ChiPhi
- ThucTe values pulled directly from source entities
- KeHoach values taken from version tables (0 when null, no fallback to source)
- Applied KeHoachThangId filter with null-safe check: `x.Version != null && x.Version.KeHoachThangId == filterKeHoach`
- Zero-value filtering applied to final results

## What We Tried

Initially tried fixing with navigation properties and includes, but the fundamental issue was the query direction. Attempted various Include/ThenInclude combinations which led to incorrect results and null reference exceptions.

## Root Cause Analysis

The original design assumed version entities always existed for every source record, but business logic only creates versions after "chốt kế hoạch tháng". Records that hadn't been locked for the month were completely missing from reports because the query started from version tables that didn't exist yet.

## Lessons Learned

1. Always consider the existence lifecycle of related entities in queries
2. Versioned data patterns require LEFT JOIN from base entity to version entity, not the reverse
3. When versions are optional (created conditionally), the base query must start from the always-existing entity
4. KeHoach = 0 when version is null is correct business logic - no fallback to source values

## Next Steps

Monitor report accuracy in upcoming months to ensure the inverted logic handles all edge cases correctly. No additional work needed - build and tests passed successfully.