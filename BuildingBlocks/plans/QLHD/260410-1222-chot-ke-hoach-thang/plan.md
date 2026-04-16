---
name: 260410-1222-chot-ke-hoach-thang
description: Feature to snapshot DuAn/HopDong ThuTien, XuatHoaDon, ChiPhi data into versioned tables linked to KeHoachThang
type: project
blockedBy: []
blocks: []
---

# Plan: Chốt Kế Hoạch Tháng Feature

## Overview

**Priority:** High
**Status:** Completed
**Module:** QLHD

Create "Chốt kế hoạch tháng" feature that snapshots plan and actual data from DuAn/HopDong entities into versioned tables linked to a KeHoachThang period.

**Source Entities:**
- DuAn_ThuTien, DuAn_XuatHoaDon (Project-based)
- HopDong_ThuTien, HopDong_XuatHoaDon, HopDong_ChiPhi (Contract-based)

**Versioned Entities (new):**
- DuAn_ThuTien_Version, DuAn_XuatHoaDon_Version
- HopDong_ThuTien_Version, HopDong_XuatHoaDon_Version, HopDong_ChiPhi_Version

**Trigger:** Manual API call with KeHoachThangId
**Filter:** ThoiGianKeHoach within KeHoachThang.TuNgay-DenNgay range
**Data Scope:** All plan + actual fields + SourceEntityId reference

## Key Insights

1. Source entities implement IKeHoach, IThucTe, IHoaDon interfaces - versioned entities should mirror these
2. Existing entities have no FK to KeHoachThang - versioned tables will add KeHoachThangId FK
3. Pattern: `{Owner}_{Purpose}_Version` naming convention
4. Bulk insert via repository pattern - use transaction for multi-table operations

## Architecture

### Entity Structure

```
KeHoachThang (int key, existing)
    ↓
Versioned Entities (Guid key, new)
├── DuAn_ThuTien_Version
│   ├── KeHoachThangId (FK, required)
│   ├── DuAnId (FK to DuAn, required)
│   ├── SourceEntityId (FK to DuAn_ThuTien, required)
│   ├── IKeHoach fields (copy from source)
│   ├── IThucTe fields (copy from source)
│   └── IHoaDon fields (copy from source)
├── DuAn_XuatHoaDon_Version (same structure)
├── HopDong_ThuTien_Version
│   ├── KeHoachThangId (FK, required)
│   ├── HopDongId (FK to HopDong, required)
│   ├── SourceEntityId (FK to HopDong_ThuTien, required)
│   └── IKeHoach + IThucTe + IHoaDon fields
├── HopDong_XuatHoaDon_Version (same structure)
└── HopDong_ChiPhi_Version
    ├── KeHoachThangId (FK, required)
    ├── HopDongId (FK to HopDong, required)
    ├── SourceEntityId (FK to HopDong_ChiPhi, required)
    ├── IKeHoach + IThucTe fields (NO IHoaDon)
```

### Data Flow

```mermaid
flowchart TD
    A[API: POST /ke-hoach-thang/chot/{id}] --> B[KeHoachThangChotCommand]
    B --> C[Query KeHoachThang by Id]
    C --> D[Validate TuNgay <= DenNgay]
    D --> E[Query Source Entities by Date Range]
    E --> F1[DuAn_ThuTien where ThoiGianKeHoach in range]
    E --> F2[DuAn_XuatHoaDon where ThoiGianKeHoach in range]
    E --> F3[HopDong_ThuTien where ThoiGianKeHoach in range]
    E --> F4[HopDong_XuatHoaDon where ThoiGianKeHoach in range]
    E --> F5[HopDong_ChiPhi where ThoiGianKeHoach in range]
    F1 --> G[Bulk Create Version Records]
    F2 --> G
    F3 --> G
    F4 --> G
    F5 --> G
    G --> H[Save to Version Tables]
    H --> I[Return Snapshot Summary]
```

## Related Code Files

### New Files to Create

**Domain Layer:**
- `QLHD.Domain/Entities/DuAn_ThuTien_Version.cs`
- `QLHD.Domain/Entities/DuAn_XuatHoaDon_Version.cs`
- `QLHD.Domain/Entities/HopDong_ThuTien_Version.cs`
- `QLHD.Domain/Entities/HopDong_XuatHoaDon_Version.cs`
- `QLHD.Domain/Entities/HopDong_ChiPhi_Version.cs`

**Persistence Layer:**
- `QLHD.Persistence/Configurations/DuAn_ThuTien_VersionConfiguration.cs`
- `QLHD.Persistence/Configurations/DuAn_XuatHoaDon_VersionConfiguration.cs`
- `QLHD.Persistence/Configurations/HopDong_ThuTien_VersionConfiguration.cs`
- `QLHD.Persistence/Configurations/HopDong_XuatHoaDon_VersionConfiguration.cs`
- `QLHD.Persistence/Configurations/HopDong_ChiPhi_VersionConfiguration.cs`

**Application Layer:**
- `QLHD.Application/KeHoachThangs/Commands/KeHoachThangChotCommand.cs`
- `QLHD.Application/KeHoachThangs/Commands/KeHoachThangChotCommandHandler.cs`
- `QLHD.Application/KeHoachThangs/Validators/KeHoachThangChotCommandValidator.cs`
- `QLHD.Application/KeHoachThang_Versions/DTOs/KeHoachThang_VersionsSummaryDto.cs`

**WebApi Layer:**
- Update `QLHD.WebApi/Controllers/KeHoachThangController.cs` - add Chot endpoint

### Existing Files to Update

- `QLHD.Persistence/AppDbContext.cs` - Add DbSet for version entities
- `QLHD.Persistence/DependencyInjection.cs` - Register version repositories
- `QLHD.Persistence/Migrations/` - Add migration for version tables

## Success Criteria

1. Version tables created with proper FKs (KeHoachThangId, SourceEntityId)
2. API endpoint returns snapshot summary with record counts per table
3. Date range filter correctly selects records by ThoiGianKeHoach
4. Transaction ensures all tables populated or rollback on error
5. Cannot chot same KeHoachThang twice (validation prevents duplicates)

## Risk Assessment

| Risk | Severity | Mitigation |
|------|----------|------------|
| Large data volumes | Medium | Paginated processing, timeout config |
| Duplicate snapshots | High | Validation: check existing version records |
| Data integrity | High | Transaction scope, FK constraints |
| Performance | Medium | Bulk insert, async operations |

## Security Considerations

- API endpoint requires authentication
- User must have appropriate permissions
- Audit fields (CreatedBy, CreatedAt) set on version records

---

## Phase Files

- [Phase 01: Domain Entities](phase-01-domain-entities.md)
- [Phase 02: Persistence Configuration](phase-02-persistence-configuration.md)
- [Phase 03: Application Layer](phase-03-application-layer.md)
- [Phase 04: API Endpoint](phase-04-api-endpoint.md)
- [Phase 05: Migration](phase-05-migration.md)
- [Phase 06: Testing](phase-06-testing.md)