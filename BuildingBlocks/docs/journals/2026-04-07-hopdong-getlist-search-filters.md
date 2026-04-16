# HopDong GetList Query - Search Filters Implementation

**Date**: 2026-04-07 11:53
**Severity**: Medium  
**Component**: QLHD.Application.HopDongs
**Status**: Resolved

## What Happened

Implemented comprehensive search filters for the HopDong GetList query using the SearchModel pattern from DuAnGetListQuery. Added 12 filter properties including date ranges, foreign key filters, department ID filtering, and enhanced text search capabilities.

## The Brutal Truth

The most frustrating part was dealing with the nullable PhongBanPhuTrachChinhId property on HopDong entity. Unlike DuAn which had a non-nullable foreign key, HopDong has a nullable long? for the main responsible department ID. This tripped me up when copying the pattern, leading to a potential runtime crash that could've made it to production. The realization that I needed to add .HasValue checks hit me after initially assuming the pattern was identical.

## Technical Details

Modified: `modules/QLHD/QLHD.Application/HopDongs/Queries/HopDongGetListQuery.cs`

Added HopDongSearchModel with these properties:
- Date ranges: TuNgayKy/DenNgayKy, TuNgayNghiemThu/DenNgayNghiemThu  
- FK filters: KhachHangId, LoaiHopDongId, TrangThaiId, NguoiPhuTrachId, NguoiTheoDoiId, GiamDocId
- Department filter: PhongBanIds (matches PhongBanPhuTrachChinhId OR any PhongBanPhoiHops)
- Text search: TenHopDong, PhongBanPhuTrachChinhId

Critical bug fix: Changed `p.PhongBanPhuTrachChinhId == searchModel.PhongBanPhuTrachChinhId` to `p.PhongBanPhuTrachChinhId.HasValue && p.PhongBanPhuTrachChinhId.Value == searchModel.PhongBanPhuTrachChinhId` to handle nullable type.

Enhanced WhereSearchString to include TenKhachHang in addition to TenHopDong for broader text matching.

## What We Tried

Initially tried to directly copy the DuAnGetListQuery pattern without considering the nullable nature of HopDong.PhongBanPhuTrachChinhId. This would have caused a NullReferenceException when comparing null values.

## Root Cause Analysis

We assumed all entities follow the same pattern for foreign key relationships, but HopDong has a nullable department relationship while DuAn has a required one. This difference wasn't immediately obvious when copying the search pattern, showing how dangerous assumptions can be when refactoring code.

## Lessons Learned

Always verify nullable vs non-nullable types when copying patterns between entities. The null-safety check `HasValue && Value` pattern needs to be instinctive when working with nullable database fields. Assumptions about entity similarities can lead to runtime crashes.

## Next Steps

The changes build successfully (0 errors, 4 warnings). Waiting for manual commit by the user to include in the broader feature branch. The search functionality is now feature-complete and ready for testing.