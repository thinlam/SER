# Phase 01: Domain Entities

**Priority:** High
**Status:** Pending
**Dependencies:** None

## Overview

Create 5 versioned entity classes that mirror the source entities with added KeHoachThangId and SourceEntityId FKs.

## Requirements

### Functional Requirements

1. Create versioned entities for each source entity type
2. Implement appropriate interfaces (IKeHoach, IThucTe, IHoaDon)
3. Add FK fields: KeHoachThangId (int), SourceEntityId (Guid), OwnerId (Guid)
4. Copy all fields from source entities (both plan and actual)

### Non-Functional Requirements

- Follow Entity<Guid> base class pattern
- Implement IAggregateRoot marker
- Use proper data types (decimal with precision, DateOnly)
- Include navigation properties for FK relationships

## Architecture

### Entity Template

```csharp
// Template for DuAn_ThuTien_Version
public class DuAn_ThuTien_Version : Entity<Guid>, IAggregateRoot,
    IKeHoach, IThucTe, IHoaDon
{
    // === VERSION FIELDS (required) ===
    public int KeHoachThangId { get; set; }
    public Guid SourceEntityId { get; set; }  // FK to DuAn_ThuTien
    
    // === OWNER (required) ===
    public Guid DuAnId { get; set; }
    
    // === COMMON FIELDS ===
    public int LoaiThanhToanId { get; set; }
    public string? GhiChuKeHoach { get; set; }
    public string? GhiChuThucTe { get; set; }
    
    // === PLAN FIELDS (copied from source) ===
    public DateOnly ThoiGianKeHoach { get; set; }
    public decimal PhanTramKeHoach { get; set; }
    public decimal GiaTriKeHoach { get; set; }
    
    // === ACTUAL FIELDS (copied from source) ===
    public Guid? HopDongId { get; set; }
    public DateOnly? ThoiGianThucTe { get; set; }
    public decimal? GiaTriThucTe { get; set; }
    
    // === INVOICE FIELDS (copied from source) ===
    public string? SoHoaDon { get; set; }
    public string? KyHieuHoaDon { get; set; }
    public DateOnly? NgayHoaDon { get; set; }
    
    #region Navigation Properties
    public KeHoachThang? KeHoachThang { get; set; }
    public DuAn_ThuTien? SourceEntity { get; set; }
    public DuAn? DuAn { get; set; }
    public HopDong? HopDong { get; set; }
    public DanhMucLoaiThanhToan? LoaiThanhToan { get; set; }
    #endregion
}
```

## Implementation Steps

1. Create `DuAn_ThuTien_Version.cs` - copy DuAn_ThuTien fields + version FKs
2. Create `DuAn_XuatHoaDon_Version.cs` - copy DuAn_XuatHoaDon fields + version FKs
3. Create `HopDong_ThuTien_Version.cs` - copy HopDong_ThuTien fields + version FKs
4. Create `HopDong_XuatHoaDon_Version.cs` - copy HopDong_XuatHoaDon fields + version FKs
5. Create `HopDong_ChiPhi_Version.cs` - copy HopDong_ChiPhi fields + version FKs (NO IHoaDon)

## Todo List

- [ ] Create DuAn_ThuTien_Version entity
- [ ] Create DuAn_XuatHoaDon_Version entity
- [ ] Create HopDong_ThuTien_Version entity
- [ ] Create HopDong_XuatHoaDon_Version entity
- [ ] Create HopDong_ChiPhi_Version entity

## Success Criteria

- All 5 entities created with proper interfaces
- FK fields present: KeHoachThangId, SourceEntityId, OwnerId
- Navigation properties defined
- No compile errors

## Risk Assessment

| Risk | Mitigation |
|------|------------|
| Missing fields | Compare with source entity files line by line |
| Interface mismatch | Verify IKeHoach, IThucTe, IHoaDon implementation |

## Next Steps

After entities created → Phase 02: Persistence Configuration