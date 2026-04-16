# Codebase Summary

## Project Information

| Attribute | Value |
|-----------|-------|
| **Name** | BuildingBlocks |
| **Former Name** | SharedKernel |
| **Purpose** | Shared library for modular monolith DNN DesktopModules |
| **Target Framework** | .NET 8.0 |
| **Architecture** | Clean Architecture + DDD + CQRS |
| **CQRS Framework** | MediatR 12.5.0 |
| **Primary ORM** | Entity Framework Core 8.0.15 |
| **Secondary ORM** | Dapper 2.1.66 |
| **Platform** | DNN (DotNetNuke) DesktopModules |

## Project Statistics

| Metric | Value |
|--------|-------|
| **Total Files** | 738 |
| **Symbols** | 2894 |
| **Relationships** | 8499 |
| **Execution Flows** | 97 |
| **Functional Areas** | 117 |

| Project | Files | Purpose |
|---------|-------|---------|
| BuildingBlocks.Domain | 54 | Entities, interfaces, constants |
| BuildingBlocks.Application | 49 | CQRS, services, behaviors |
| BuildingBlocks.Persistence | 12 | EF Core, Dapper, repositories |
| BuildingBlocks.Infrastructure | 6 | DateTime, Office/Excel helpers |
| BuildingBlocks.CrossCutting | 22 | Extensions, exceptions, utilities |
| BuildingBlocks.Tests | 0 | xUnit project (no tests) |
| **Modules (QLHD only)** | 649 | Contract management module |

## NuGet Dependencies

| Package | Version | Purpose |
|---------|---------|---------|
| MediatR | 12.5.0 | CQRS pattern implementation |
| FluentValidation | 12.0.0 | Input validation |
| EF Core | 8.0.15 | ORM with SQL Server |
| Dapper | 2.1.66 | High-performance queries |
| Serilog.AspNetCore | 9.0.0 | Structured logging |
| Aspose.Cells | 20.11.0 | Excel import/export |
| SequentialGuid | 4.0.6 | Sequential GUID generation |
| System.Linq.Dynamic.Core | 1.6.3 | Runtime query building |

## Layer Architecture

```
CrossCutting (base)
       |
       v
Domain --> CrossCutting, SequentialGuid
       |
       v
Persistence --> Domain, CrossCutting, EF Core, Dapper
       |
       v
Application --> Domain, Persistence, CrossCutting, MediatR
       |
       v
Infrastructure --> CrossCutting, Aspose.Cells
```

## Key Entities

### Base Entities

| Entity | Key Type | Features |
|--------|----------|----------|
| Entity<TKey> | Generic | Audit fields, soft delete, sequential GUID |
| DanhMuc | Guid | Catalog base (Ma, Ten, MoTa, Used) |
| MaterializedPathEntity | Guid | Hierarchical (ParentId, Path, Level) |

### Domain Entities

| Entity | Vietnamese | Purpose |
|--------|------------|---------|
| UserMaster | - | User information with DNN integration |
| DmDonVi | Đơn vị | Organization unit catalog |
| TepDinhKem | Tệp đính kèm | File attachment (Legacy - uses EGroupType enum) |
| Attachment | Tệp đính kèm | File attachment (New - uses string? GroupType for flexibility) |
| AuditLog | - | Change tracking log |
| UserSession | - | User session management |

### QLHD Module Entities

| Entity | Vietnamese | Purpose |
|--------|------------|---------|
| DoanhNghiep | Doanh nghiệp | Enterprise/business entity |
| KhachHang | Khách hàng | Customer (links to DoanhNghiep) |
| DuAn | Dự án | Project entity |
| HopDong | Hợp đồng | Contract entity |
| DuAnPhongBanPhoiHop | - | Junction: DuAn ↔ PhongBan |
| HopDongPhongBanPhoiHop | - | Junction: HopDong ↔ PhongBan |
| KeHoachThuTien | Kế hoạch thu tiền | Payment plan (polymorphic: DuAn/HopDong) |
| KeHoachXuatHoaDon | Kế hoạch xuất hóa đơn | Invoice plan (polymorphic: DuAn/HopDong) |
| KeHoachChiPhi | Kế hoạch chi phí | Cost plan (polymorphic: DuAn/HopDong) |
| KeHoachKinhDoanhNam | Kế hoạch kinh doanh năm | Annual business plan entity |
| KeHoachThang | Kế hoạch tháng | Monthly plan entity |
| ThuTienThucTe | Thu tiền thực tế | Actual payment received |
| XuatHoaDonThucTe | Xuất hóa đơn thực tế | Actual invoice issued |
| ThucTeChiPhi | Thực tế chi phí | Actual cost record |
| PhuLucHopDong | Phụ luc hợp đồng | Contract appendix |
| TienDo | Tiến độ | Progress/Phase for HopDong |
| BaoCaoTienDo | Báo cáo tiến độ | Progress report (child of TienDo) |
| KhoKhanVuongMac | Khó khăn vướng mắc | Issues/Obstacles for HopDong/TienDo |
| CongViec | Công việc | Work item for DuAn |

### QLHD DanhMuc Entities

| Entity | Vietnamese | Purpose |
|--------|------------|---------|
| DanhMucHinhThucThanhToan | Hình thức thanh toán | Payment method catalog |
| DanhMucLoaiThanhToan | Loại thanh toán | Payment type catalog |
| DanhMucLoaiTien | Loại tiền | Currency type catalog |
| DanhMucNguonVon | Nguồn vốn | Funding source catalog |
| DanhMucLoaiChiPhi | Loại chi phí | Cost type catalog (with IsDefault) |
| DanhMucGiamDoc | Giám đốc | Director catalog |
| DanhMucNguoiPhuTrach | Người phụ trách | Person responsible catalog |
| DanhMucNguoiTheoDoi | Người theo dõi | Person monitoring catalog |
| DanhMucLoaiHopDong | Loại hợp đồng | Contract type catalog |
| DanhMucLoaiTrangThai | Loại trạng thái | Status type catalog |
| DanhMucTrangThai | Trạng thái | Status catalog (linked to LoaiTrangThai) |
| DanhMucLoaiLai | Loại lãi | Interest rate type catalog (NEW - with IsDefault) |

### QLHD Version Entities (Snapshot Tables)

| Entity | Purpose |
|--------|---------|
| DuAn_ThuTien_Version | Snapshot of DuAn payment plans for KeHoachThang |
| DuAn_XuatHoaDon_Version | Snapshot of DuAn invoice plans for KeHoachThang |
| HopDong_ThuTien_Version | Snapshot of HopDong payment plans for KeHoachThang |
| HopDong_XuatHoaDon_Version | Snapshot of HopDong invoice plans for KeHoachThang |
| HopDong_ChiPhi_Version | Snapshot of HopDong cost plans for KeHoachThang |

### New Domain Interfaces

| Interface | Purpose |
|-----------|---------|
| IEntityType | Base interface with `Loai` property for entity type discrimination |
| IInheritanceEntity | Marker interface for TPH inheritance |
| IJunctionEntity<LeftId, RightId> | Generic interface for many-to-many junction tables |
| IKeHoach | Contract for planned values (ThoiGianKeHoach, PhanTramKeHoach, GiaTriKeHoach, GhiChuKeHoach) |
| IThucTe | Contract for actual values (ThoiGianThucTe, GiaTriThucTe, GhiChuThucTe) |
| IHoaDon | Contract for invoice data (SoHoaDon, KyHieuHoaDon, NgayHoaDon) |
| IHopDongBase | Contract for core contract identifiers (SoHopDong, Ten, DuAnId, KhachHangId, etc.) |

### File Attachment Components (New)

| Component | Purpose |
|-----------|---------|
| TepDinhKem | Legacy file attachment (uses EGroupType enum) |
| Attachment | New flexible file attachment (uses string? GroupType) |
| AttachmentDto | Data Transfer Object for file attachments |
| AttachmentInsertOrUpdateModel | Model for creating/updating attachments |
| AttachmentInsertCommand | Command to insert attachments |
| AttachmentBulkInsertOrUpdateCommand | Command to bulk insert/update attachments |
| GetAttachmentListQuery | Query to retrieve attachment lists by GroupId |

### Authorization Attributes

| Attribute | Purpose |
|-----------|---------|
| AuthorizeAllRoles | Requires ALL specified roles (AND logic) vs default ANY role (OR logic) |

## Key Services

### CrudService<TEntity, TKey>
Generic CRUD service with:
- Create, Read, Update, Delete operations
- Bulk operations support
- Pagination support
- Filtering and sorting

### UserProvider
User context extraction from:
- JWT token parsing
- User ID and role extraction
- Organization unit mapping

### HistoryQueryService
Audit log queries:
- Entity change history
- User action tracking
- Date range filtering

### DateTimeProvider
Testable datetime abstraction:
- Now, UtcNow abstraction
- Unit test mocking support

### Excel Helpers
- **AsposeHelper**: Aspose.Cells operations
- **ExporterHelper**: Template-based export with `$FieldName` placeholders
  - `Export<T>`: Generic export with property reflection
  - `ExportDynamic`: Dictionary-based export (no reflection needed)
  - `ExportHierarchical`: Two-level grouped export
  - `ExportWithOutline`: Tree outline with expand/collapse
  - `ExportMultiLevelHierarchical`: Multi-level nested grouping with configurable instructions
- **ImporterHelper**: Excel import with validation

## Pipeline Behaviors

| Behavior | Purpose |
|---------|---------|
| ValidationBehaviour | FluentValidation integration |
| LoggingBehavior | Serilog structured logging |
| PerformanceBehaviour | Warns >500ms requests |
| UnhandledExceptionBehaviour | Exception logging |

## Repository Pattern

### IRepository<TEntity, TKey>
- `GetByIdAsync` - Single entity by ID
- `GetAllAsync` - All entities
- `AddAsync` - Add single entity
- `UpdateAsync` - Update single entity
- `DeleteAsync` - Delete by ID
- `AddRangeAsync` - Bulk add
- `UpdateRangeAsync` - Bulk update
- `DeleteRangeAsync` - Bulk delete

### IDapperRepository<TEntity, TKey>
- High-performance read queries
- Raw SQL support
- Stored procedure support

## Unit of Work

### IUnitOfWork
- `SaveChangesAsync` - Commit transaction
- Transaction management
- Change tracking

## Domain Constants

### RoleConstants
- `DVDC_TiepNhan` - Tiếp nhận
- `DVDC_XuLy` - Xử lý
- `QLDA_Admin` - Quản lý dự án admin
- `QLHD_Manager` - Quản lý hợp đồng manager

### PermissionConstants
- Module-specific permissions
- CRUD permissions
- Special action permissions

### ErrorMessageConstants (Vietnamese)
- `NotFound` - "Không tìm thấy dữ liệu"
- `DuplicateCode` - "Mã đã tồn tại trong hệ thống"
- `InvalidInput` - "Dữ liệu đầu vào không hợp lệ"

### PaginationConstants
- `MAX_PAGE_SIZE` = 100

## External Modules

| Module | Name | Description |
|--------|------|-------------|
| DVDC | Dịch vụ dùng chung | Common services, shared entities |
| QLDA | Quản lý dự án | Project management |
| QLHD | Quản lý hợp đồng | Contract management |
| NVTT | Nhiệm vụ trọng tâm | Priority tasks |

## Known Issues

| Issue | Severity | Location |
|-------|----------|----------|
| ExcelHelper.cs exceeds 200 lines | Medium | Infrastructure |
| No tests implemented | High | Tests project |
| CryptographyHelper uses deprecated TripleDES ECB | Medium | CrossCutting |
| Duplicate logic in interceptors | Low | Persistence |
| GitNexus index may be stale | Low | Run `npx gitnexus analyze` |

## Technical Patterns

| Pattern | Implementation |
|---------|---------------|
| Clean Architecture | Layer separation, dependency inversion |
| Domain-Driven Design | Aggregate Root, Repository, UoW |
| CQRS | MediatR commands/queries |
| Materialized Path | Hierarchical entity support |
| Audit Trail | IAuditable + Interceptors |
| Soft Delete | ISoftDeletable interface |
| Template Export | Excel with placeholder substitution |
| Polymorphic FK | XOR constraint: DuAnId OR HopDongId (KeHoach entities) |
| Zero-or-One-to-One | HopDong.DuAnId nullable with SetNull delete |
| Upsert Pattern | Single endpoint for insert/update (ChiPhi feature) |
| Version Tracking | Snapshot entities for preserving plan states (KeHoachThang → Version tables) |

## Vietnamese Terminology Reference

| Vietnamese | English | Context |
|------------|---------|---------|
| Danh mục | Catalog/Master Data | Base class for catalogs |
| Tệp đính kèm | File Attachment | Upload entities |
| Đơn vị | Organization Unit | Org hierarchy |
| Trạng thái | Status | Status fields |
| Mô tả | Description | Description fields |
| Ngày tạo | Created Date | Audit field |
| Người tạo | Created By | Audit field |
| DNN | DotNetNuke | Platform |

## GitNexus Code Intelligence

This codebase is indexed by GitNexus for code navigation and impact analysis.

### Quick Reference

| Tool | Purpose | Command |
|------|---------|---------|
| `query` | Find execution flows | `gitnexus_query({query: "concept"})` |
| `context` | Symbol details | `gitnexus_context({name: "symbol"})` |
| `impact` | Blast radius | `gitnexus_impact({target: "X", direction: "upstream"})` |
| `detect_changes` | Pre-commit check | `gitnexus_detect_changes({scope: "staged"})` |

### Key Processes

| Process | Steps | Type |
|---------|-------|------|
| SavingChanges → AuditLog | 4 | Cross-community |
| Handle → SaveChangesAsync | 5 | Cross-community |
| AddOrUpdateAsync → AddAsync | 3 | Intra-community |
| ExportHierarchical → TemplateConfig | 3 | Cross-community |

> See `CLAUDE.md` for complete GitNexus usage guidelines.

## Entity Relationship Summary (QLHD)

```
DuAn (Project)
  ├── ICollection<KeHoachThuTien>      [Polymorphic: XOR with HopDong]
  ├── ICollection<KeHoachXuatHoaDon>   [Polymorphic: XOR with HopDong]
  ├── ICollection<KeHoachChiPhi>       [Polymorphic: XOR with HopDong]
  └── HopDong?                         [0-1 relationship, SetNull delete]

HopDong (Contract)
  ├── ICollection<PhuLucHopDong>       [Cascade delete]
  ├── ICollection<KeHoachThuTien>      [Polymorphic, Cascade]
  ├── ICollection<KeHoachXuatHoaDon>   [Polymorphic, Cascade]
  ├── ICollection<KeHoachChiPhi>       [Polymorphic, Cascade]
  ├── ICollection<ThucTeChiPhi>        [Restrict delete]
  ├── ICollection<ThuTienThucTe>       [Restrict delete]
  └── ICollection<XuatHoaDonThucTe>    [Restrict delete]

KeHoachChiPhi (Cost Plan)
  └── ThucTeChiPhi?                    [0-1, SetNull delete]

ThucTeChiPhi (Actual Cost)
  ├── KeHoachChiPhi?                   [Optional link to plan]
  └── HopDong                          [Required owner]
```

---
**Generated:** 2026-04-10
**Analysis Method:** Scout agent analysis + GitNexus context
**GitNexus Index:** 2894 symbols, 8499 relationships, 97 processes
**Last Updated:** 2026-04-10 (KeHoachThang snapshot feature, Version entities, BaoCao reports)