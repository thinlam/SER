# Phase 05: Migration

**Priority:** High
**Status:** Pending
**Dependencies:** Phase 04

## Overview

Create EF Core migration to add version tables to database.

## Requirements

### Functional Requirements

1. Create migration for all 5 version tables
2. Create FK constraints to KeHoachThang, source entities, owners
3. Create indexes for FK columns
4. Apply migration to dbo and dev schemas

### Non-Functional Requirements

- Use schema-aware migration pattern (ConnectionStrings__Schema=dbo for scaffolding)
- Follow column order standards
- Include proper decimal column types

## Architecture

### Migration Commands

```bash
# Scaffold migration with dbo schema (IMPORTANT: always use dbo for scaffolding)
cd modules/QLHD/QLHD.Persistence
ConnectionStrings__Schema=dbo dotnet ef migrations add AddKeHoachThangVersionTables \
  --startup-project ../QLHD.Migrator \
  --project ../QLHD.Migrator \
  --output-dir Migrations/dbo

# Apply to dbo
ConnectionStrings__Schema=dbo dotnet run --project ../QLHD.Migrator

# Apply to dev
ConnectionStrings__Schema=dev dotnet run --project ../QLHD.Migrator
```

### Tables to Create

| Table | Columns | FKs |
|-------|---------|-----|
| DuAn_ThuTien_Version | Id, KeHoachThangId, SourceEntityId, DuAnId, LoaiThanhToanId, ThoiGianKeHoach, PhanTramKeHoach, GiaTriKeHoach, GhiChuKeHoach, HopDongId, ThoiGianThucTe, GiaTriThucTe, GhiChuThucTe, SoHoaDon, KyHieuHoaDon, NgayHoaDon, CreatedBy, CreatedAt, UpdatedBy, UpdatedAt, IsDeleted, Index | KeHoachThang, DuAn_ThuTien, DuAn, HopDong, DanhMucLoaiThanhToan |
| DuAn_XuatHoaDon_Version | Same structure | KeHoachThang, DuAn_XuatHoaDon, DuAn, HopDong, DanhMucLoaiThanhToan |
| HopDong_ThuTien_Version | Id, KeHoachThangId, SourceEntityId, HopDongId, LoaiThanhToanId, ThoiGianKeHoach, PhanTramKeHoach, GiaTriKeHoach, GhiChuKeHoach, ThoiGianThucTe, GiaTriThucTe, GhiChuThucTe, SoHoaDon, KyHieuHoaDon, NgayHoaDon, CreatedBy, CreatedAt, UpdatedBy, UpdatedAt, IsDeleted, Index | KeHoachThang, HopDong_ThuTien, HopDong, DanhMucLoaiThanhToan |
| HopDong_XuatHoaDon_Version | Same structure | KeHoachThang, HopDong_XuatHoaDon, HopDong, DanhMucLoaiThanhToan |
| HopDong_ChiPhi_Version | Id, KeHoachThangId, SourceEntityId, HopDongId, LoaiChiPhiId, Nam, LanChi, ThoiGianKeHoach, PhanTramKeHoach, GiaTriKeHoach, GhiChuKeHoach, ThoiGianThucTe, GiaTriThucTe, GhiChuThucTe, CreatedBy, CreatedAt, UpdatedBy, UpdatedAt, IsDeleted, Index | KeHoachThang, HopDong_ChiPhi, HopDong, DanhMucLoaiChiPhi |

## Implementation Steps

1. Run `dotnet ef migrations add AddKeHoachThangVersionTables` with dbo schema
2. Review generated migration code
3. Apply to dbo schema
4. Apply to dev schema
5. Verify tables created in database

## Todo List

- [ ] Scaffold migration with dbo schema
- [ ] Review migration code
- [ ] Apply migration to dbo
- [ ] Apply migration to dev
- [ ] Verify tables exist in database

## Success Criteria

- Migration scaffolded without errors
- All 5 version tables created
- FK constraints properly defined
- Indexes created for FK columns
- Decimal columns with correct precision

## Risk Assessment

| Risk | Mitigation |
|------|------------|
| Schema contamination | ALWAYS scaffold with dbo, never with dev |
| FK constraint errors | Use Restrict delete behavior |

## Next Steps

After migration applied → Phase 06: Testing