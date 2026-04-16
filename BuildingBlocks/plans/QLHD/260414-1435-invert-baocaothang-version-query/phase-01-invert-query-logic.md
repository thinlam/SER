---
name: phase-01-invert-query-logic
description: Implement the inverted query logic in KeHoachThangReportQuery.cs
type: implementation
blockedBy: []
blocks: []
---

# Phase 01: Invert Query Logic

## Overview

**Priority:** High
**Status:** Completed

Modify `KeHoachThangReportQuery.cs` to invert ThuTien/XuatHoaDon/ChiPhi queries: start from source entities with LEFT JOIN to version tables.

## Implementation Steps

### Step 1: Add Source Entity Repository Injection

Add repositories for source entities in constructor:

```csharp
private readonly IRepository<DuAn_ThuTien, Guid> _duAnThuTienRepo;
private readonly IRepository<DuAn_XuatHoaDon, Guid> _duAnXuatHoaDonRepo;
private readonly IRepository<HopDong_ThuTien, Guid> _hopDongThuTienRepo;
private readonly IRepository<HopDong_XuatHoaDon, Guid> _hopDongXuatHoaDonRepo;
private readonly IRepository<HopDong_ChiPhi, Guid> _hopDongChiPhiRepo;
```

Initialize in constructor:
```csharp
_duAnThuTienRepo = serviceProvider.GetRequiredService<IRepository<DuAn_ThuTien, Guid>>();
_duAnXuatHoaDonRepo = serviceProvider.GetRequiredService<IRepository<DuAn_XuatHoaDon, Guid>>();
_hopDongThuTienRepo = serviceProvider.GetRequiredService<IRepository<HopDong_ThuTien, Guid>>();
_hopDongXuatHoaDonRepo = serviceProvider.GetRequiredService<IRepository<HopDong_XuatHoaDon, Guid>>();
_hopDongChiPhiRepo = serviceProvider.GetRequiredService<IRepository<HopDong_ChiPhi, Guid>>();
```

### Step 2: Define Source Entity Queries with Date Filters

Create base queries for source entities (filtered by ThoiGianKeHoach date range):

```csharp
// ThuTien source queries
var duAnThuTienSource = _duAnThuTienRepo.GetQueryableSet()
    .Where(e => e.ThoiGianKeHoach >= filterTuThang)
    .Where(e => e.ThoiGianKeHoach <= filterDenThang)
    .WhereIf(isBoPhanFilter, e => e.DuAn!.PhongBanPhuTrachChinhId == filterBoPhan);

var hopDongThuTienSource = _hopDongThuTienRepo.GetQueryableSet()
    .Where(e => e.ThoiGianKeHoach >= filterTuThang)
    .Where(e => e.ThoiGianKeHoach <= filterDenThang)
    .WhereIf(isBoPhanFilter, e => e.HopDong!.PhongBanPhuTrachChinhId == filterBoPhan);

// XuatHoaDon source queries
var duAnXuatHoaDonSource = _duAnXuatHoaDonRepo.GetQueryableSet()
    .Where(e => e.ThoiGianKeHoach >= filterTuThang)
    .Where(e => e.ThoiGianKeHoach <= filterDenThang)
    .WhereIf(isBoPhanFilter, e => e.DuAn!.PhongBanPhuTrachChinhId == filterBoPhan);

var hopDongXuatHoaDonSource = _hopDongXuatHoaDonRepo.GetQueryableSet()
    .Where(e => e.ThoiGianKeHoach >= filterTuThang)
    .Where(e => e.ThoiGianKeHoach <= filterDenThang)
    .WhereIf(isBoPhanFilter, e => e.HopDong!.PhongBanPhuTrachChinhId == filterBoPhan);

// ChiPhi source query (only HopDong)
var hopDongChiPhiSource = _hopDongChiPhiRepo.GetQueryableSet()
    .Where(e => e.ThoiGianKeHoach >= filterTuThang)
    .Where(e => e.ThoiGianKeHoach <= filterDenThang)
    .WhereIf(isBoPhanFilter, e => e.HopDong!.PhongBanPhuTrachChinhId == filterBoPhan);
```

### Step 3: Apply LEFT JOIN Pattern with KeHoachThangId Filter

Pattern for LEFT JOIN source→version with conditional KeHoachThangId filter:

```csharp
// ThuTien DuAn: Source LEFT JOIN Version
var thuTienDuAn = duAnThuTienSource
    .LeftOuterJoin(duAnThuTienVersions, s => s.Id, v => v.SourceEntityId, (s, v) => new { Source = s, Version = v })
    .WhereIf(isKeHoachFilter, x => x.Version!.KeHoachThangId == filterKeHoach)
    .Join(dmDonViQuery, x => x.Source.DuAn!.PhongBanPhuTrachChinhId, pb => pb.Id, (x, pb) => new PhongBanReportDto {
        PhongBanId = pb.Id,
        TenPhongBan = pb.TenDonVi ?? DefaultConstants.UNKNOWN,
        Id = x.Source.DuAnId,
        KeHoach = x.Version != null ? x.Version.GiaTriKeHoach : 0m, // NO fallback to source
        ThucTe = x.Source.GiaTriThucTe ?? 0m
    });

// ThuTien HopDong: Source LEFT JOIN Version
var thuTienHopDong = hopDongThuTienSource
    .LeftOuterJoin(hopDongThuTienVersions, s => s.Id, v => v.SourceEntityId, (s, v) => new { Source = s, Version = v })
    .WhereIf(isKeHoachFilter, x => x.Version!.KeHoachThangId == filterKeHoach)
    .Join(dmDonViQuery, x => x.Source.HopDong!.PhongBanPhuTrachChinhId, pb => pb.Id, (x, pb) => new PhongBanReportDto {
        PhongBanId = pb.Id,
        TenPhongBan = pb.TenDonVi ?? DefaultConstants.UNKNOWN,
        Id = x.Source.HopDongId,
        KeHoach = x.Version != null ? x.Version.GiaTriKeHoach : 0m, // NO fallback to source
        ThucTe = x.Source.GiaTriThucTe ?? 0m
    });
```

### Step 4: Apply Same Pattern to XuatHoaDon and ChiPhi

```csharp
// XuatHoaDon DuAn
var xuatHoaDonDuAn = duAnXuatHoaDonSource
    .LeftOuterJoin(duAnXuatHoaDonVersions, s => s.Id, v => v.SourceEntityId, (s, v) => new { Source = s, Version = v })
    .WhereIf(isKeHoachFilter, x => x.Version!.KeHoachThangId == filterKeHoach)
    .Join(dmDonViQuery, x => x.Source.DuAn!.PhongBanPhuTrachChinhId, pb => pb.Id, (x, pb) => new PhongBanReportDto {
        PhongBanId = pb.Id,
        TenPhongBan = pb.TenDonVi ?? DefaultConstants.UNKNOWN,
        Id = x.Source.DuAnId,
        KeHoach = x.Version != null ? x.Version.GiaTriKeHoach : 0m, // NO fallback to source
        ThucTe = x.Source.GiaTriThucTe ?? 0m
    });

// XuatHoaDon HopDong
var xuatHoaDonHopDong = hopDongXuatHoaDonSource
    .LeftOuterJoin(hopDongXuatHoaDonVersions, s => s.Id, v => v.SourceEntityId, (s, v) => new { Source = s, Version = v })
    .WhereIf(isKeHoachFilter, x => x.Version!.KeHoachThangId == filterKeHoach)
    .Join(dmDonViQuery, x => x.Source.HopDong!.PhongBanPhuTrachChinhId, pb => pb.Id, (x, pb) => new PhongBanReportDto {
        PhongBanId = pb.Id,
        TenPhongBan = pb.TenDonVi ?? DefaultConstants.UNKNOWN,
        Id = x.Source.HopDongId,
        KeHoach = x.Version != null ? x.Version.GiaTriKeHoach : 0m, // NO fallback to source
        ThucTe = x.Source.GiaTriThucTe ?? 0m
    });

// ChiPhi HopDong (no IHoaDon interface - different structure)
var chiPhiHopDong = hopDongChiPhiSource
    .LeftOuterJoin(hopDongChiPhiVersions, s => s.Id, v => v.SourceEntityId, (s, v) => new { Source = s, Version = v })
    .WhereIf(isKeHoachFilter, x => x.Version!.KeHoachThangId == filterKeHoach)
    .Join(dmDonViQuery, x => x.Source.HopDong!.PhongBanPhuTrachChinhId, pb => pb.Id, (x, pb) => new PhongBanReportDto {
        PhongBanId = pb.Id,
        TenPhongBan = pb.TenDonVi ?? DefaultConstants.UNKNOWN,
        Id = x.Source.HopDongId,
        KeHoach = x.Version != null ? x.Version.GiaTriKeHoach : 0m, // NO fallback to source
        ThucTe = x.Source.GiaTriThucTe ?? 0m
    });
```

### Step 5: Remove Version-Only Repository Fields (Optional)

After refactoring, version repositories are still needed for LEFT JOIN but can be renamed or kept. Keep them for clarity.

### Step 6: Update Version Query Definitions

The version queries (`duAnThuTienVersions`, etc.) still need date filters for the LEFT JOIN:

```csharp
// Version queries - keep date filters for LEFT JOIN matching
var duAnThuTienVersions = _duAnThuTienVersionRepo.GetQueryableSet()
    .Where(e => e.ThoiGianKeHoach >= filterTuThang)
    .Where(e => e.ThoiGianKeHoach <= filterDenThang);
// NOTE: Remove PhongBan and KeHoachThangId filters from version queries
// These will be applied AFTER the LEFT JOIN via WhereIf
```

## Key Changes Summary

| Element | Current | After |
|---------|---------|-------|
| Query start | `_VersionRepo.GetQueryableSet()` | `_SourceRepo.GetQueryableSet()` |
| Join type | JOIN (inner) | LeftOuterJoin |
| Version access | `v.SourceEntity!.Property` | `x.Version?.Property ?? x.Source.Property` |
| KeHoachThangId filter | On version query | On LEFT JOIN result via WhereIf |
| ThucTe source | `v.SourceEntity.GiaTriThucTe` | `x.Source.GiaTriThucTe` (direct) |
| KeHoach source | `v.GiaTriKeHoach` | `x.Version?.GiaTriKeHoach ?? 0m` (NO fallback to source) |

## Success Criteria

- [ ] All 5 aggregations (ThuTien DuAn/HopDong, XuatHoaDon DuAn/HopDong, ChiPhi) use LEFT JOIN pattern
- [ ] KeHoachThangId filter applied via WhereIf on LEFT JOIN result
- [ ] Date range filters on source entities
- [ ] PhongBan filter on source entities via WhereIf
- [ ] ThucTe comes directly from source entity
- [ ] KeHoach comes from version when available, falls back to source
- [ ] Query compiles without errors

## Additional Requirement

**Filter out records with all zero values:**
When all of these fields are 0 → exclude the record from results:
- `doanhSoKyKeHoach`, `doanhSoKyThucTe`, `phanTramKy`
- `thuTienKeHoach`, `thuTienThucTe`, `phanTramThuTien`
- `xuatHoaDonKeHoach`, `xuatHoaDonThucTe`, `phanTramXuatHoaDon`
- `chiPhiKeHoach`, `chiPhiThucTe`, `phanTramChiPhi`

**Implementation:** Add filter after merging aggregations, before returning:

```csharp
// Filter out records with all zero values
merged = merged.Where(x =>
    x.DoanhSoKyKeHoach != 0 || x.DoanhSoKyThucTe != 0 ||
    x.ThuTienKeHoach != 0 || x.ThuTienThucTe != 0 ||
    x.XuatHoaDonKeHoach != 0 || x.XuatHoaDonThucTe != 0 ||
    x.ChiPhiKeHoach != 0 || x.ChiPhiThucTe != 0
).ToList();
```

**Note:** `phanTram` fields are computed from KeHoach/ThucTe ratios, so checking KeHoach/ThucTe covers them.

## Files to Modify

- `modules/QLHD/QLHD.Application/BaoCaos/Queries/KeHoachThangReportQuery.cs`