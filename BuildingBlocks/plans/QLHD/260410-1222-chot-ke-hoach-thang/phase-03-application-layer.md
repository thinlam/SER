# Phase 03: Application Layer

**Priority:** High
**Status:** Pending
**Dependencies:** Phase 02

## Overview

Create command, handler, validator, and DTOs for the Chot snapshot operation.

## Requirements

### Functional Requirements

1. Create KeHoachThangChotCommand with KeHoachThangId parameter
2. Handler queries source entities by date range (ThoiGianKeHoach in TuNgay-DenNgay)
3. Bulk insert version records with all fields copied
4. Return summary DTO with counts per table
5. Prevent duplicate snapshots for same KeHoachThang

### Non-Functional Requirements

- Use transaction scope for multi-table operations
- Follow CQRS pattern with MediatR
- Use FluentValidation for validation
- Set CreatedBy, CreatedAt audit fields

## Architecture

### Command Structure

```csharp
public class KeHoachThangChotCommand : IRequest<KeHoachThang_VersionsSummaryDto>
{
    public int KeHoachThangId { get; set; }
}
```

### Handler Logic

```csharp
public async Task<KeHoachThang_VersionsSummaryDto> Handle(
    KeHoachThangChotCommand request, 
    CancellationToken cancellationToken)
{
    // 1. Get KeHoachThang
    var keHoachThang = await _keHoachThangRepository.GetByIdAsync(request.KeHoachThangId, cancellationToken);
    ManagedException.ThrowIfNull(keHoachThang, "Không tìm thấy kế hoạch tháng");
    
    // 2. Check for existing snapshot (prevent duplicates)
    var existingSnapshot = await _duAnThuTienVersionRepo.GetQueryableSet()
        .AnyAsync(v => v.KeHoachThangId == request.KeHoachThangId, cancellationToken);
    if (existingSnapshot)
        throw new ManagedException("Kế hoạch tháng này đã được chốt");
    
    // 3. Query source entities by date range
    var tuNgay = keHoachThang.TuNgay;
    var denNgay = keHoachThang.DenNgay;
    
    // 4. Bulk create version records (in transaction)
    var summary = new KeHoachThang_VersionsSummaryDto();
    
    // Process each entity type...
    
    return summary;
}
```

### Date Range Filter Pattern

```csharp
// Query entities where ThoiGianKeHoach falls within range
var duAnThuTiens = await _duAnThuTienRepo.GetQueryableSet()
    .Where(e => e.ThoiGianKeHoach >= tuNgay && e.ThoiGianKeHoach <= denNgay)
    .ToListAsync(cancellationToken);
```

### Version Record Creation Pattern

```csharp
// Copy all fields from source to version
var versions = duAnThuTiens.Select(source => new DuAn_ThuTien_Version
{
    Id = GuidExtensions.GetSequentialGuidId(),
    KeHoachThangId = keHoachThang.Id,
    SourceEntityId = source.Id,
    DuAnId = source.DuAnId,
    LoaiThanhToanId = source.LoaiThanhToanId,
    ThoiGianKeHoach = source.ThoiGianKeHoach,
    PhanTramKeHoach = source.PhanTramKeHoach,
    GiaTriKeHoach = source.GiaTriKeHoach,
    GhiChuKeHoach = source.GhiChuKeHoach,
    ThoiGianThucTe = source.ThoiGianThucTe,
    GiaTriThucTe = source.GiaTriThucTe,
    GhiChuThucTe = source.GhiChuThucTe,
    HopDongId = source.HopDongId,
    SoHoaDon = source.SoHoaDon,
    KyHieuHoaDon = source.KyHieuHoaDon,
    NgayHoaDon = source.NgayHoaDon,
    CreatedBy = _currentUser.UserId,
    CreatedAt = DateTimeOffset.UtcNow
}).ToList();

await _duAnThuTienVersionRepo.BulkInsertAsync(versions, cancellationToken);
```

## Implementation Steps

1. Create `KeHoachThang_VersionsSummaryDto.cs` - counts per table
2. Create `KeHoachThangChotCommand.cs`
3. Create `KeHoachThangChotCommandValidator.cs` - validate KeHoachThangId exists
4. Create `KeHoachThangChotCommandHandler.cs` - implement snapshot logic
5. Register handler in DI if needed

## Todo List

- [ ] Create VersionsSummaryDto
- [ ] Create KeHoachThangChotCommand
- [ ] Create KeHoachThangChotCommandValidator
- [ ] Create KeHoachThangChotCommandHandler
- [ ] Implement date range filtering for each entity type
- [ ] Implement duplicate check validation
- [ ] Implement bulk insert for each version table

## Success Criteria

- Command handler returns summary with correct counts
- Date range filter works correctly
- Transaction ensures all tables populated or rollback
- Duplicate snapshot prevented
- Audit fields set correctly

## Risk Assessment

| Risk | Mitigation |
|------|------------|
| Large data volume | Use BulkInsertAsync, consider pagination if needed |
| Transaction timeout | Configure appropriate timeout, log progress |
| Partial failure | Use transaction scope, rollback on exception |

## Next Steps

After application layer complete → Phase 04: API Endpoint