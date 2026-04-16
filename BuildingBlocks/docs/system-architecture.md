# System Architecture

## Overview

Modular Monolith architecture with Clean Architecture principles. BuildingBlocks provides shared infrastructure for all business modules (DVDC, QLDA, QLHD, NVTT).

```
┌─────────────────────────────────────────────────────────────────────────┐
│                           WebApi Layer                                   │
│    (DVDC.WebApi, QLDA.WebApi, QLHD.WebApi, NVTT.WebApi)                │
│    └─ Controllers, Middleware, Program.cs                               │
└─────────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────────┐
│                        Application Layer                                 │
│    ┌─────────────────────────────────────────────────────────────┐      │
│    │ BuildingBlocks.Application                                  │      │
│    │  └─ Commands, Queries, Handlers, DTOs, Services             │      │
│    │  └─ Pipeline Behaviors: Validation, Logging, Performance   │      │
│    └─────────────────────────────────────────────────────────────┘      │
└─────────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────────┐
│                          Domain Layer                                    │
│    ┌─────────────────────────────────────────────────────────────┐      │
│    │ BuildingBlocks.Domain                                       │      │
│    │  └─ Entities, Value Objects, Interfaces, Enums             │      │
│    │  └─ Constants, Domain Events, Exceptions                    │      │
│    └─────────────────────────────────────────────────────────────┘      │
└─────────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────────┐
│                       Persistence Layer                                   │
│    ┌─────────────────────────────────────────────────────────────┐      │
│    │ BuildingBlocks.Persistence                                  │      │
│    │  └─ Repositories, EF Configurations, Interceptors           │      │
│    │  └─ Dapper Queries, Unit of Work, DbContext                 │      │
│    └─────────────────────────────────────────────────────────────┘      │
└─────────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────────┐
│                       Infrastructure Layer                                │
│    ┌──────────────────────┐    ┌───────────────────────────────┐        │
│    │ BuildingBlocks.      │    │ BuildingBlocks.               │        │
│    │ Infrastructure       │    │ CrossCutting                   │        │
│    │  └─ DateTime, Excel  │    │  └─ Extensions, Exceptions     │        │
│    └──────────────────────┘    └───────────────────────────────┘        │
└─────────────────────────────────────────────────────────────────────────┘
```

## Layer Dependencies

```
CrossCutting (base - no dependencies)
        │
        ▼
Domain → CrossCutting, SequentialGuid
        │
        ▼
Persistence → Domain, CrossCutting, EF Core, Dapper
        │
        ▼
Application → Domain, Persistence, CrossCutting, MediatR, FluentValidation
        │
        ▼
Infrastructure → CrossCutting, Aspose.Cells
```

## BuildingBlocks Project Details

### BuildingBlocks.CrossCutting
- **Purpose:** Cross-cutting concerns, utilities, extensions
- **Dependencies:** None (base layer)
- **Contents:**
  - Exceptions: `ManagedException`, `NotFoundException`, `ValidationException`
  - Extensions: String, DateTime, Collection, LINQ extensions
  - Utilities: Common utilities used across all layers

### BuildingBlocks.Domain
- **Purpose:** Domain entities, interfaces, constants
- **Dependencies:** CrossCutting, SequentialGuid
- **Contents:**
  - Entities: `Entity<TKey>`, `DanhMuc`, `MaterializedPathEntity`, `TepDinhKem`, `Attachment`
  - Interfaces: `IRepository<TEntity, TKey>`, `IUnitOfWork`
  - Constants: Role, Permission, Error messages, Table names
  - Enums: Domain enumerations

### BuildingBlocks.Persistence
- **Purpose:** Data access, EF Core configurations
- **Dependencies:** Domain, CrossCutting, EF Core, Dapper
- **Contents:**
  - Repositories: Generic `Repository<TEntity, TKey>`, `DapperRepository`, `JunctionRepository<TJunction>`
  - Configurations: EF Core entity configurations
  - Interceptors: `AuditInterceptor`, `AuditableEntityInterceptor`
  - DbContext: Base `ApplicationDbContext`

### BuildingBlocks.Application
- **Purpose:** CQRS handlers, services, DTOs
- **Dependencies:** Domain, Persistence, CrossCutting, MediatR
- **Contents:**
  - Commands/Queries: MediatR request types
  - Handlers: Request handlers with business logic
  - DTOs: Data Transfer Objects
  - Services: `CrudService<T>`, `UserProvider`, `HistoryQueryService`
  - Behaviors: Pipeline behaviors for cross-cutting concerns

### BuildingBlocks.Infrastructure
- **Purpose:** External service integrations, helpers
- **Dependencies:** CrossCutting, Aspose.Cells
- **Contents:**
  - DateTime: `DateTimeProvider` for testable datetime
  - Office: Excel helpers with Aspose.Cells
  - External integrations: Third-party service wrappers

## Key Patterns

| Pattern | Implementation | Location |
|---------|---------------|----------|
| **CQRS** | MediatR Commands/Queries/Handlers | Application |
| **Repository** | `IRepository<TEntity, TKey>` with bulk ops | Domain/Persistence |
| **Junction Repository** | `IJunctionRepository<TJunction>` for soft-delete | Domain/Persistence |
| **Unit of Work** | `IUnitOfWork` with transaction management | Persistence |
| **Pipeline Behaviors** | Validation, Logging, Performance, Exception | Application |
| **Audit Trail** | `AuditInterceptor` with `IAuditable` | Persistence |
| **Materialized Path** | Hierarchical entities (ParentId, Path, Level) | Domain |
| **Template Export** | Excel with `$FieldName` placeholders | Infrastructure |
| **File Attachments** | `TepDinhKem` (legacy) and `Attachment` (new flexible) | Domain/Application |
| **Role Interfaces** | `IKeHoach`, `IThucTe`, `IHoaDon`, `IHopDongBase` for consistent property contracts | Domain |
| **Version Tracking** | Snapshot entities for preserving plan states (Monthly plans → Version tables) | Domain/Persistence/Application |

## File Attachment Patterns

### Legacy TepDinhKem Entity
- **GroupType:** Uses `string` for flexible types (CapPhat, YeuCau, BaoCaoTienDo, etc.) with constants in `GroupTypeConstants`
- **Advantage:** Supports any group type without enum updates, though maintains legacy structure
- **Usage:** Still supported for existing functionality
- **Note:** `EGroupType` enum marked as [Obsolete], replaced by string constants

### New Attachment Entity  
- **GroupType:** Uses `string?` for dynamic, flexible group types
- **Advantage:** Supports any group type without code changes
- **Usage:** Recommended for new development
- **Backwards Compatible:** Both entities can coexist

### Attachment Entity Structure
```csharp
public class Attachment : Entity<Guid>, IAggregateRoot {
    public Guid? ParentId { get; set; }
    public string GroupId { get; set; } = SequentialGuidGenerator.Instance.NewGuid().ToString();
    public string? GroupType { get; set; }  // Flexible string instead of enum
    public string? Type { get; set; }
    public string? FileName { get; set; }
    public string? OriginalName { get; set; }
    public string? Path { get; set; }
    public long Size { get; set; }
}
```

### TepDinhKem Entity Structure
```csharp
public class TepDinhKem : Entity<Guid>, IAggregateRoot {
    public Guid? ParentId { get; set; }
    public string GroupId { get; set; } = SequentialGuidGenerator.Instance.NewGuid().ToString();
    public string GroupType { get; set; } = string.Empty;  // String constant from GroupTypeConstants
    public string? Type { get; set; }
    public string? FileName { get; set; }
    public string? OriginalName { get; set; }
    public string? Path { get; set; }
    public long Size { get; set; }
}
```

### Export Methods (IExporterHelper)

| Method | Purpose | Data Type |
|--------|---------|-----------|
| `Export<T>` | Generic export with property reflection | `List<T>` (DTO/Entity) |
| `ExportDynamic` | Dictionary-based export, no reflection | `List<Dictionary<string, object?>>` |
| `ExportHierarchical` | Two-level grouped export (LinhVuc → PhongBan → Items) | Generic with group formatters |
| `ExportWithOutline` | Tree outline with Excel expand/collapse | `List<T>` with `Level` property |

**ExportDynamic Usage:**
```csharp
var instruction = new DynamicExportInstruction
{
    TemplatePath = "template.xlsx",
    Items = new List<Dictionary<string, object?>>
    {
        new() { ["Ten"] = "Item 1", ["SoTien"] = 100000 }
    }
};
var result = exporterHelper.ExportDynamic(instruction);
```

## Pipeline Behaviors

### ValidationBehaviour
- Validates MediatR requests using FluentValidation
- Throws `ValidationException` on validation failures
- Registered automatically for all requests

### LoggingBehavior
- Logs request start/end with Serilog
- Includes request details in JSON format
- Configurable log levels

### PerformanceBehaviour
- Warns when requests exceed 500ms
- Helps identify performance bottlenecks
- Logs slow requests with context

### UnhandledExceptionBehaviour
- Catches and logs unhandled exceptions
- Provides consistent error logging
- Preserves exception context

## Data Flow

```
HTTP Request
    │
    ▼
Controller (WebApi)
    │
    ▼
MediatR Command/Query
    │
    ├──► ValidationBehavior ──► FluentValidation
    │
    ├──► LoggingBehavior ──► Serilog
    │
    ├──► PerformanceBehavior ──► Timer
    │
    ▼
Handler (Application)
    │
    ├──► Repository (Persistence)
    │         │
    │         ▼
    │    DbContext / Dapper
    │         │
    │         ▼
    │    Database (SQL Server)
    │
    └──► Domain Entity (Domain)
```

## Module Structure

Each business module follows Clean Architecture:

```
{Module}/
├── {Module}.Domain/           # Entities, Enums, Interfaces
│   ├── Constants/
│   ├── DTOs/
│   ├── Entities/
│   ├── Enums/
│   ├── Interfaces/
│   └── GlobalUsing.cs
├── {Module}.Application/      # Commands, Queries, Services
│   ├── Commands/
│   ├── Queries/
│   ├── DTOs/
│   ├── Mappings/
│   └── GlobalUsing.cs
├── {Module}.Infrastructure/   # External integrations
├── {Module}.Persistence/      # EF Configs, Repositories
│   ├── Configurations/
│   ├── Repositories/
│   └── Migrations/
├── {Module}.Migrator/         # DB Migrations
└── {Module}.WebApi/           # Controllers, Program.cs
    ├── Controllers/
    ├── Middleware/
    ├── Program.cs
    └── appsettings.json
```

## Audit System

### Entity Audit Interface
```csharp
public interface IAuditable
{
    Guid Id { get; }
    DateTime CreatedAt { get; set; }
    Guid CreatedBy { get; set; }
    DateTime? UpdatedAt { get; set; }
    Guid? UpdatedBy { get; set; }
}
```

### Audit Interceptors
- **AuditInterceptor:** Intercepts SaveChanges, sets audit fields
- **AuditableEntityInterceptor:** Alternative implementation
- **AuditLog:** Stores change history for query

### Audit Log Queries
- `HistoryQueryService` provides audit history
- Query changes by entity type, ID, user, date range

## GitNexus Execution Flows

> Indexed by GitNexus: 1085 symbols, 2579 relationships, 27 execution flows

### Functional Areas (Clusters)

| Area | Symbols | Cohesion | Description |
|------|---------|----------|-------------|
| Interfaces | 39 | 79% | Repository, UnitOfWork, Services |
| Offices | 24 | 92% | Excel/Aspose helpers |
| Interceptors | 15 | 86% | Audit, Entity interceptors |
| ExtensionMethods | 14 | 100% | LINQ, String, DateTime extensions |
| DTOs | 11 | 90% | Data Transfer Objects |
| Entities | 9 | 87% | Domain entities |
| Configurations | 6 | 100% | EF Core configs |
| Commands | 6 | 73% | MediatR commands |
| History | 6 | 100% | Audit log queries |

### Key Execution Processes

#### Audit Flow (SavingChanges)
```
SavingChanges → ShouldAudit → GetEntityId → AuditLog
              → GetSequentialGuidId → SerializeEntity
```
- **Type:** Cross-community (Interceptors → Domain → Application)
- **Steps:** 4
- **Files:** `AuditInterceptor.cs`, `IAuditable.cs`, `AuditLogExtensions.cs`

#### Repository Operations
```
Handle → AddRangeAsync → BeginTransactionAsync → SaveChangesAsync
Handle → Delete → DisableAudit
```
- **Type:** Cross-community
- **Steps:** 4-5
- **Pattern:** Unit of Work with transaction management

#### Entity Operations
```
AddOrUpdateAsync → UpdateAsync | AddAsync → SaveChangesAsync
```
- **Type:** Intra-community (within Persistence)
- **Steps:** 3
- **Pattern:** Upsert with auto-detection

#### Export Operations
```
ExportHierarchical → ThrowIf → HierarchicalTemplateConfig
```
- **Type:** Cross-community
- **Steps:** 3
- **Pattern:** Template-based Excel export

### Process Types

| Type | Count | Description |
|------|-------|-------------|
| Cross-community | 18 | Spans multiple functional areas |
| Intra-community | 9 | Within single functional area |

### Using GitNexus Tools

| Task | Tool | Example |
|------|------|---------|
| Find execution flows | `gitnexus_query` | `query({query: "audit save changes"})` |
| Symbol context | `gitnexus_context` | `context({name: "SavingChanges"})` |
| Blast radius | `gitnexus_impact` | `impact({target: "IRepository", direction: "upstream"})` |

> See CLAUDE.md for full GitNexus tool reference and usage guidelines.

## Architecture References

### Clean Architecture Principles

This project follows **Clean Architecture** (also known as Onion Architecture or Hexagonal Architecture), which:

- Places business logic and application model at the center
- Inverts dependencies: infrastructure depends on Application Core, not vice versa
- Defines abstractions in Application Core, implemented by Infrastructure layer
- Enables easy unit testing and implementation swapping

**Key Benefits:**
- Business logic independent of infrastructure
- Easy to write automated unit tests
- Swap implementations without affecting core
- Enforce separation of concerns through dependency rules

### Modular Monolith Approach

A **Modular Monolith** combines simplicity of monolithic deployment with modular internal structure:

- **Single deployment unit** - simpler operations, easier debugging
- **Logical separation** - code organized into modules by business capability
- **Clear boundaries** - each module has well-defined interfaces
- **Future-ready** - modules can be extracted to microservices if needed

**When Modular Monolith is appropriate:**
- Early stage development, natural boundaries unclear
- Team size is small to medium
- Independent scaling not yet required
- Complexity of microservices outweighs benefits

### Layer Organization

Based on Microsoft's Clean Architecture guidance:

| Layer | Contents | Dependencies |
|-------|----------|--------------|
| **Application Core** | Entities, Interfaces, Domain Services, Specifications | None |
| **Infrastructure** | EF Core, Repositories, External Services | Application Core |
| **UI/WebApi** | Controllers, Views, ViewModels, Startup | Application Core, Infrastructure (DI only) |

**Dependency Rules:**
- Dependencies flow inward toward Application Core
- UI layer references Infrastructure only for DI composition root
- Infrastructure implements interfaces defined in Application Core

### Sources

- **Microsoft .NET Architecture Guide**
  - [Common Web Application Architectures](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures)
  - eBook: "Architect Modern Web Applications with ASP.NET Core and Azure"

- **Clean Architecture**
  - Robert C. Martin: [The Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
  - Jeffrey Palermo: [Onion Architecture](https://jeffreypalermo.com/blog/the-onion-architecture-part-1/)

- **Reference Implementations**
  - [dotnet/eShop](https://github.com/dotnet/eShop) - Microsoft's reference application
  - [ardalis/cleanarchitecture](https://github.com/ardalis/cleanarchitecture) - Clean Architecture solution template

---

**Last Updated:** 2026-04-06
**GitNexus Index:** 162 files, 1085 symbols, 2579 relationships