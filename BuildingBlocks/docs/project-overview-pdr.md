# Project Overview (PDR)

## Project: BuildingBlocks - Shared Infrastructure Library

### Vision
Shared library for modular monolith DNN DesktopModules, providing common infrastructure, domain primitives, and cross-cutting concerns for enterprise digital transformation applications.

### Architecture
**Clean Architecture + DDD + CQRS** with modular monolith design. BuildingBlocks serves as the shared foundation for all business modules.

### Technology Stack

| Category | Package | Version | Purpose |
|----------|---------|---------|---------|
| Runtime | .NET | 8.0 | Target framework |
| ORM | EF Core | 8.0.15 | Primary ORM with SQL Server |
| Micro-ORM | Dapper | 2.1.66 | High-performance queries |
| CQRS | MediatR | 12.5.0 | Command/Query separation |
| Validation | FluentValidation | 12.0.0 | Input validation |
| Logging | Serilog.AspNetCore | 9.0.0 | Structured logging |
| Excel | Aspose.Cells | 20.11.0 | Excel import/export |
| Guids | SequentialGuid | 4.0.6 | Sequential GUID generation |
| Dynamic LINQ | System.Linq.Dynamic.Core | 1.6.3 | Runtime query building |

### External Modules

| Module | Full Name | Vietnamese | Description |
|--------|-----------|------------|-------------|
| DVDC | Dich Vu Dung Chung | Dịch vụ dùng chung | Common services, shared entities |
| QLDA | Quan Ly Du An | Quản lý dự án | Project management |
| QLHD | Quan Ly Hop Dong | Quản lý hợp đồng | Contract management |
| NVTT | Nhiem Vu Trong Tam | Nhiệm vụ trọng tâm | Priority tasks management |

### BuildingBlocks Projects

| Project | Files | Purpose |
|---------|-------|---------|
| BuildingBlocks.Domain | 22 | Entities, interfaces, constants, enums |
| BuildingBlocks.Application | 45+ | CQRS, services, behaviors, DTOs |
| BuildingBlocks.Persistence | 16 | EF Core, Dapper, repositories, interceptors |
| BuildingBlocks.Infrastructure | 6 | DateTime, Office/Excel helpers |
| BuildingBlocks.CrossCutting | 17 | Extensions, exceptions, utilities |
| BuildingBlocks.Tests | - | xUnit test project (no tests yet) |

### Core Entities

| Entity | Purpose |
|--------|---------|
| Entity<TKey> | Base entity with audit fields, soft delete, sequential Guid |
| DanhMuc | Catalog/master data base (Ma, Ten, MoTa, Used) |
| MaterializedPathEntity | Hierarchical entity support (ParentId, Path, Level) |
| UserMaster | User information with DNN integration |
| DmDonVi | Organization unit (đơn vị) |
| TepDinhKem | File attachment (tệp đính kèm) |
| AuditLog | Change tracking log |
| UserSession | User session management |

### QLHD Module Extended Entities

| Entity | Purpose |
|--------|---------|
| DoanhNghiep | Business entity |
| KhachHang | Customer (links to DoanhNghiep) |
| DuAn | Project entity |
| HopDong | Contract entity |
| KeHoachThuTien | Payment plan |
| KeHoachXuatHoaDon | Invoice plan |
| KeHoachChiPhi | Cost plan |
| KeHoachKinhDoanhNam | Annual business plan |
| KeHoachThang | Monthly plan |
| DuAn_ThuTien_Version | Payment plan snapshot (version tracking) |
| DuAn_XuatHoaDon_Version | Invoice plan snapshot (version tracking) |
| HopDong_ThuTien_Version | Payment plan snapshot (version tracking) |
| HopDong_XuatHoaDon_Version | Invoice plan snapshot (version tracking) |
| HopDong_ChiPhi_Version | Cost plan snapshot (version tracking) |
| DanhMucLoaiLai | Interest rate type catalog (with IsDefault) |
| DanhMucLoaiChiPhi | Cost type catalog |
| DanhMucLoaiHopDong | Contract type catalog |
| DanhMucTrangThai | Status catalog |
| DanhMucGiamDoc | Director catalog |
| DanhMucNguoiPhuTrach | Responsible person catalog |
| DanhMucNguoiTheoDoi | Monitoring person catalog |

### Key Services

| Service | Purpose |
|---------|---------|
| CrudService<T, TKey> | Generic CRUD operations |
| UserProvider | JWT parsing, user context extraction |
| HistoryQueryService | Audit log queries |
| DateTimeProvider | Testable datetime abstraction |
| AsposeHelper | Excel operations with Aspose.Cells |
| ExporterHelper | Template-based Excel export |
| ImporterHelper | Excel import with validation |

### Version Tracking Feature

The BuildingBlocks architecture supports a **Version Tracking** pattern for preserving historical states of business plans. This pattern is implemented in QLHD module for KeHoachThang (monthly plan) snapshot functionality:

| Component | Purpose |
|-----------|---------|
| Version Entities | Store snapshots of original plan entities at specific points in time |
| Chot Command | Creates snapshots by copying current plan data to version tables |
| Version Controllers | Manage and access historical data |
| Report Queries | Generate reports from version data (historical view) |

The version tracking system includes:
- **Snapshot Creation**: Monthly plans can be "chốt" (sealed) to preserve their state
- **Historical Preservation**: Original plan data preserved at time of chốt
- **Report Generation**: Reports can be generated from historical version data
- **Transactional Integrity**: Chốt operations maintain data consistency

### Vietnamese Domain Terms

| Term | Meaning |
|------|---------|
| DanhMuc | Danh mục (Catalog/Master Data) |
| TepDinhKem | Tệp đính kèm (File Attachment) |
| DonVi | Đơn vị (Organization Unit) |
| TrangThai | Trạng thái (Status) |
| MoTa | Mô tả (Description) |
| NgayTao | Ngày tạo (Created Date) |
| NguoiTao | Người tạo (Created By) |

### Design Principles

| Principle | Description |
|-----------|-------------|
| **YAGNI** | You Aren't Gonna Need It - avoid over-engineering |
| **KISS** | Keep It Simple, Stupid - prefer simplicity |
| **DRY** | Don't Repeat Yourself - centralize common logic |
| **Clean Architecture** | Clear layer separation, dependency inversion |
| **DDD** | Domain-Driven Design tactical patterns |
| **CQRS** | Command Query Responsibility Segregation |

### References
- Microsoft eShop: https://github.com/dotnet/eShop
- .NET Architecture Guide: https://learn.microsoft.com/dotnet/architecture/
- MediatR Wiki: https://github.com/jbogard/MediatR/wiki

---

**Last Updated:** 2026-03-20
**Version:** 1.0.0