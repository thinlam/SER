# Phase 06: Update Documentation

## Context

- Features documentation: `docs/features.md`
- API documentation: `docs/api.md`
- Use case: UC-21

## Overview

**Priority:** Medium
**Status:** Completed

Update project documentation to reflect the new CRUD functionality.

## Implementation Steps

### 1. Update Features Documentation

**File:** `docs/features.md`

Add under "## 7. Quản lý Danh mục" section:

```markdown
### Use Cases chính:
- **Danh mục tình trạng thực hiện LCNT**: Quản lý trạng thái thực hiện LCNT (chưa thực hiện, đang thực hiện, đã thực hiện, ...) [UC-21]
```

### 2. Update API Documentation

**File:** `docs/api.md`

Add new endpoint documentation:

```markdown
### Danh mục tình trạng thực hiện LCNT

| Endpoint | Method | Description |
|----------|--------|-------------|
| `/api/danh-muc-tinh-trang-thuc-hien-lcnt/{id}` | GET | Lấy chi tiết theo ID |
| `/api/danh-muc-tinh-trang-thuc-hien-lcnt/combobox` | GET | Danh sách cho combobox (không phân trang) |
| `/api/danh-muc-tinh-trang-thuc-hien-lcnt/danh-sach` | GET | Danh sách đầy đủ (có phân trang) |
| `/api/danh-muc-tinh-trang-thuc-hien-lcnt/them-moi` | POST | Tạo mới |
| `/api/danh-muc-tinh-trang-thuc-hien-lcnt/cap-nhat` | PUT | Cập nhật |
| `/api/danh-muc-tinh-trang-thuc-hien-lcnt/xoa-tam` | DELETE | Xóa tạm |
```

### 3. Update Data Model Documentation

**File:** `docs/data-model.md`

Add new table definition:

```sql
CREATE TABLE DmTinhTrangThucHienLcnt (
    Id int PRIMARY KEY,
    Ma nvarchar(50) NULL,
    Ten nvarchar(255) NULL,
    MoTa nvarchar(1000) NULL,
    Stt int NULL,
    Used bit NOT NULL DEFAULT 1,
    CreatedAt datetimeoffset NULL,
    CreatedBy nvarchar(450) NULL,
    LastModifiedAt datetimeoffset NULL,
    LastModifiedBy nvarchar(450) NULL,
    DeletedAt datetimeoffset NULL,
    IsDeleted bit NOT NULL DEFAULT 0
);
```

## Success Criteria

- All documentation files updated
- UC-21 referenced correctly
- API endpoints documented

## Files to Modify

- `docs/features.md`
- `docs/api.md`
- `docs/data-model.md`
