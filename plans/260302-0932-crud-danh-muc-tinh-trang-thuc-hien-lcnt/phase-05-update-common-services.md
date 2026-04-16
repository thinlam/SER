# Phase 05: Update Common Services & Enums

## Context

- Common command: `QLDA.Application/Common/Commands/DanhMucInsertOrUpdateCommand.cs`
- Common query: `QLDA.Application/Common/Queries/DanhMucGetQuery.cs`
- Enum: `QLDA.Application/Common/Enums/EDanhMuc.cs`
- List query: `QLDA.Application/Common/Queries/DanhMucGetDanhSachQuery.cs`

## Overview

**Priority:** High
**Status:** Completed

Update common handlers to support the new entity via enum switch statements.

## Implementation Steps

### 1. Update EDanhMuc Enum

**File:** `QLDA.Application/Common/Enums/EDanhMuc.cs`

Add new enum value:
```csharp
[Description("Danh mục tình trạng thực hiện LCNT")] DanhMucTinhTrangThucHienLcnt,
```

### 2. Update DanhMucInsertOrUpdateCommand Handler

**File:** `QLDA.Application/Common/Commands/DanhMucInsertOrUpdateCommand.cs`

**Add field:**
```csharp
private readonly ICrudService<DanhMucTinhTrangThucHienLcnt, int> DanhMucTinhTrangThucHienLcnt;
```

**In constructor:**
```csharp
DanhMucTinhTrangThucHienLcnt = serviceProvider.GetRequiredService<ICrudService<DanhMucTinhTrangThucHienLcnt, int>>();
```

**In switch statement (Handle method):**
```csharp
case EDanhMuc.DanhMucTinhTrangThucHienLcnt: {
    await DanhMucTinhTrangThucHienLcnt.AddOrUpdateAsync((DanhMucTinhTrangThucHienLcnt)request.Entity,
        cancellationToken: cancellationToken);
    break;
}
```

### 3. Update DanhMucGetQuery Handler

**File:** `QLDA.Application/Common/Queries/DanhMucGetQuery.cs`

**Add field:**
```csharp
private readonly IRepository<DanhMucTinhTrangThucHienLcnt, int> DanhMucTinhTrangThucHienLcnt = serviceProvider.GetRequiredService<IRepository<DanhMucTinhTrangThucHienLcnt, int>>();
```

**In switch statement (Handle method):**
```csharp
EDanhMuc.DanhMucTinhTrangThucHienLcnt => await Get(request, DanhMucTinhTrangThucHienLcnt, cancellationToken),
```

### 4. Update DanhMucGetDanhSachQuery Handler

**File:** `QLDA.Application/Common/Queries/DanhMucGetDanhSachQuery.cs`

Add similar pattern in the switch statement (if it follows the same pattern as DanhMucGetQuery).

## Success Criteria

- All handlers compile
- Switch statements include new enum case
- Service registered via DI

## Files to Modify

- `QLDA.Application/Common/Enums/EDanhMuc.cs`
- `QLDA.Application/Common/Commands/DanhMucInsertOrUpdateCommand.cs`
- `QLDA.Application/Common/Queries/DanhMucGetQuery.cs`
- `QLDA.Application/Common/Queries/DanhMucGetDanhSachQuery.cs` (verify pattern)
