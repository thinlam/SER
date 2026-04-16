# Plan: CRUD Danh Mục Tình Trạng Thực Hiện LCNT

**Date:** 2026-03-02
**Use Case:** UC-21 - Quản lý danh mục tình trạng thực hiện LCNT (Lựa chọn nhà thầu)

## Overview

Create CRUD (Create, Read, Update, Delete) functionality for managing LCNT (Lựa chọn nhà thầu - Contractor Selection) implementation status catalog. Statuses include:
- Chưa thực hiện (Not Implemented)
- Đang thực hiện (In Progress)
- Đã thực hiện (Completed)
- And other statuses as defined by business requirements

## Phases

| Phase | Status | Description |
|-------|--------|-------------|
| [Phase 01](./phase-01-domain-entity.md) | **completed** | Create Domain Entity |
| [Phase 02](./phase-02-persistence-configuration.md) | **completed** | Create Persistence Configuration |
| [Phase 03](./phase-03-application-commands-queries.md) | **completed** | Create Application Commands & Queries |
| [Phase 04](./phase-04-api-models-controller.md) | **completed** | Create API Models & Controller |
| [Phase 05](./phase-05-update-common-services.md) | **completed** | Update Common Services & Enums |
| [Phase 06](./phase-06-documentation.md) | **completed** | Update Documentation |

## Key Dependencies

- Existing `DanhMuc<int>` base class
- Common CRUD services infrastructure
- Aggregate root pattern

## Success Criteria

- All CRUD operations working (Create, Read, Update, Delete, List)
- API endpoints accessible via Swagger
- Database migration successful
- Documentation updated with use case UC-21

## API Endpoints

```
/api/danh-muc-tinh-trang-thuc-hien-lcnt/{id}      GET    - Get by ID
/api/danh-muc-tinh-trang-thuc-hien-lcnt/combobox  GET    - Combobox list (no pagination)
/api/danh-muc-tinh-trang-thuc-hien-lcnt/danh-sach GET    - Full list (paginated)
/api/danh-muc-tinh-trang-thuc-hien-lcnt/them-moi  POST   - Create
/api/danh-muc-tinh-trang-thuc-hien-lcnt/cap-nhat   PUT    - Update
/api/danh-muc-tinh-trang-thuc-hien-lcnt/xoa-tam    DELETE - Soft delete
```

## Notes

- Follow existing patterns for `DanhMucGiaiDoan`, `DanhMucTrangThaiDuAn`
- Use `int` as primary key type
- Enable soft delete via `DeletedAt`
- Use kebab-case for API routes: `/api/danh-muc-tinh-trang-thuc-hien-lcnt`
- **Custom endpoints:** `/combobox` for simple list, `/danh-sach` for paginated list

## FluentValidation Implementation

**Validators** (target Commands, not DTOs):
- `DanhMucTinhTrangThucHienLcntInsertCommandValidator` - Validates Create command
- `DanhMucTinhTrangThucHienLcntUpdateCommandValidator` - Validates Update command

**Validation Rules:**
- `Ten`: Required, max 255 characters
- `Ma`: Optional, max 50 characters
- `MoTa`: Optional, max 1000 characters
- `Id` (Update only): Required, must be > 0

**Pattern:** Validators extend `AbstractValidator<TCommand>` and access properties via `x.Dto.PropertyName` to integrate with MediatR pipeline.
