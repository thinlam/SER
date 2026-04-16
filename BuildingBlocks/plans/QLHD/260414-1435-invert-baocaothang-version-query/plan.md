---
name: 260414-1435-invert-baocaothang-version-query
description: Invert BaoCaoThang query - start from source entity with left join to version instead of version→source navigation
type: project
blockedBy: []
blocks: []
---

# Plan: Invert BaoCaoThang thuTienDuAn Query Logic

## Overview

**Priority:** Medium
**Status:** Completed
**Module:** QLHD

Invert the query logic in `KeHoachThangReportQuery.cs` for `thuTienDuAn` and related aggregations:
- **Current:** Start from `_Version` table → access `SourceEntity` for ThucTe
- **Desired:** Start from **SourceEntity** → LEFT JOIN to `_Version` table for KeHoach

## Key Insight

Version tables only exist after "Chốt kế hoạch tháng" (locking period). Starting from version misses records not yet locked.

**Why invert:**
1. Source entity (`DuAn_ThuTien`) always has complete data (KeHoach + ThucTe)
2. Version table (`DuAn_ThuTien_Version`) may not exist for unlocked periods
3. LEFT JOIN from source→version ensures all ThuTien records appear
4. ThucTe comes directly from source, KeHoach from version (if locked)

## Architecture

### Current Query Flow (Version → Source)

```
DuAn_ThuTien_Version (filtered by ThoiGianKeHoach range)
    ↓ Navigation property
DuAn_ThuTien (SourceEntity) → gets GiaTriThucTe
    ↓ Join
DmDonVi → gets PhongBan info
```

### Desired Query Flow (Source → Version)

```
DuAn_ThuTien (filtered by ThoiGianKeHoach range)
    ↓ LEFT JOIN
DuAn_ThuTien_Version (if KeHoachThang locked)
    ↓ Join
DmDonVi → gets PhongBan info

Result:
- KeHoach = version.GiaTriKeHoach (if locked) OR 0 (if not locked - NO fallback to source)
- ThucTe = source.GiaTriThucTe (always from source)
```

## Related Code Files

### Files to Modify

| File | Change |
|------|--------|
| `modules/QLHD/QLHD.Application/BaoCaos/Queries/KeHoachThangReportQuery.cs` | Invert query logic for ThuTien, XuatHoaDon, ChiPhi aggregations |

### Entities Involved

| Source Entity | Version Entity | Navigation |
|---------------|----------------|------------|
| `DuAn_ThuTien` | `DuAn_ThuTien_Version` | `SourceEntity` |
| `DuAn_XuatHoaDon` | `DuAn_XuatHoaDon_Version` | `SourceEntity` |
| `HopDong_ThuTien` | `HopDong_ThuTien_Version` | `SourceEntity` |
| `HopDong_XuatHoaDon` | `HopDong_XuatHoaDon_Version` | `SourceEntity` |
| `HopDong_ChiPhi` | `HopDong_ChiPhi_Version` | `SourceEntity` |

## Implementation Steps

### Phase 01: Add Source Entity Repositories

1. Inject source entity repositories:
   - `IRepository<DuAn_ThuTien, Guid>`
   - `IRepository<DuAn_XuatHoaDon, Guid>`
   - `IRepository<HopDong_ThuTien, Guid>`
   - `IRepository<HopDong_XuatHoaDon, Guid>`
   - `IRepository<HopDong_ChiPhi, Guid>`

### Phase 02: Rewrite thuTienDuAn Query

Current (lines 93-100):
```csharp
var thuTienDuAn = duAnThuTienVersions
    .Join(dmDonViQuery, v => v.DuAn!.PhongBanPhuTrachChinhId, pb => pb.Id, (v, pb) => new PhongBanReportDto {
        PhongBanId = pb.Id,
        TenPhongBan = pb.TenDonVi ?? DefaultConstants.UNKNOWN,
        Id = v.DuAnId,
        KeHoach = v.GiaTriKeHoach,
        ThucTe = v.SourceEntity!.GiaTriThucTe ?? 0m
    });
```

Desired:
```csharp
var thuTienDuAnSource = _duAnThuTienRepo.GetQueryableSet()
    .Where(e => e.ThoiGianKeHoach >= filterTuThang)
    .Where(e => e.ThoiGianKeHoach <= filterDenThang)
    .WhereIf(isBoPhanFilter, e => e.DuAn!.PhongBanPhuTrachChinhId == filterBoPhan)
    .WhereIf(isKeHoachFilter, e => e.KeHoachThangId == filterKeHoach); // Note: SourceEntity doesn't have KeHoachThangId

var thuTienDuAn = thuTienDuAnSource
    .LeftOuterJoin(duAnThuTienVersions, s => s.Id, v => v.SourceEntityId, (s, v) => new PhongBanReportDto {
        PhongBanId = s.DuAn!.PhongBanPhuTrachChinhId,
        TenPhongBan = s.DuAn!.DuAn_PhongBanPhuTrachChinh!.TenDonVi ?? DefaultConstants.UNKNOWN, // Need join to DmDonVi
        Id = s.DuAnId,
        KeHoach = v != null ? v.GiaTriKeHoach : 0m, // NO fallback to source
        ThucTe = s.GiaTriThucTe ?? 0m
    });
```

### Phase 03: Apply Same Pattern to Other Aggregations

Apply same inversion pattern to:
- `thuTienHopDong` (HopDong_ThuTien → HopDong_ThuTien_Version)
- `xuatHoaDonDuAn` (DuAn_XuatHoaDon → DuAn_XuatHoaDon_Version)
- `xuatHoaDonHopDong` (HopDong_XuatHoaDon → HopDong_XuatHoaDon_Version)
- `chiPhiHopDong` (HopDong_ChiPhi → HopDong_ChiPhi_Version)

### Phase 04: Handle DmDonVi Join Pattern

Source entities don't have direct PhongBan navigation like version entities.

Two options:
1. **Join DmDonVi separately** - Join source query to DmDonVi, then LEFT JOIN to version
2. **Use subquery** - Get TenPhongBan from DmDonVi via Join after the LEFT JOIN

Recommended: Join to DmDonVi after LEFT JOIN to version (single join chain).

```csharp
var thuTienDuAn = thuTienDuAnSource
    .LeftOuterJoin(duAnThuTienVersions, s => s.Id, v => v.SourceEntityId, (s, v) => new { Source = s, Version = v })
    .Join(dmDonViQuery, x => x.Source.DuAn!.PhongBanPhuTrachChinhId, pb => pb.Id, (x, pb) => new PhongBanReportDto {
        PhongBanId = pb.Id,
        TenPhongBan = pb.TenDonVi ?? DefaultConstants.UNKNOWN,
        Id = x.Source.DuAnId,
        KeHoach = x.Version != null ? x.Version.GiaTriKeHoach : 0m, // NO fallback to source
        ThucTe = x.Source.GiaTriThucTe ?? 0m
    });
```

## Risk Assessment

| Risk | Severity | Mitigation |
|------|----------|------------|
| Missing KeHoachThangId on source | Medium | Source entities don't have KeHoachThangId FK - filter by ThoiGianKeHoach only |
| Performance | Low | LEFT JOIN is efficient, same filter conditions |
| Null handling | Low | Use null-coalescing for version fields |

## Questions (Resolved)

1. Source entities (`DuAn_ThuTien`, etc.) don't have `KeHoachThangId`. How to filter by `isKeHoachFilter`?
   - **Answer:** When `KeHoachThangId` is null → filter by date range only. When `KeHoachThangId` has value → add filter `Version.KeHoachThangId == KeHoachThangId` on the LEFT JOIN result.

2. Should `KeHoach` fallback to source value when version missing?
   - **Answer:** NO - When version is null, `KeHoach` = 0 (not `source.GiaTriKeHoach`). Only use version data when locked.

## Phase Files

- [Phase 01: Invert Query Logic](phase-01-invert-query-logic.md)

---

## Additional Requirement

**Filter out records with all zero values:**
When all metric fields are 0 → exclude the record from results:
- `DoanhSoKyKeHoach`, `DoanhSoKyThucTe`
- `ThuTienKeHoach`, `ThuTienThucTe`
- `XuatHoaDonKeHoach`, `XuatHoaDonThucTe`
- `ChiPhiKeHoach`, `ChiPhiThucTe`

**Implementation:** Add filter after merging, before returning.

## Success Criteria

1. All ThuTien/XuatHoaDon/ChiPhi records appear regardless of version table status
2. KeHoach comes from version when locked, 0 when unlocked (NO fallback)
3. ThucTe always comes from source entity
4. Existing filter logic (date range, PhongBan) preserved
5. Query compiles and returns same aggregated results for locked periods
6. Records with all zero values filtered out

## Next Steps

1. Implement Phase 01 using `/ck:cook`