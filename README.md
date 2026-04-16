# QLDA - Quản Lý Dự Án (Project Management System)

A .NET 8.0 Clean Architecture Web API for managing government IT projects in Ho Chi Minh City, Vietnam.

## Overview

QLDA streamlines the full lifecycle of government IT projects—from planning and bidding through execution, financial management, and reporting—ensuring transparency and compliance.

## Technology Stack

| Layer | Technology |
|-------|------------|
| Runtime | .NET 8.0 |
| API | ASP.NET Core Web API |
| Database | SQL Server + EF Core + Dapper |
| CQRS | MediatR |
| Validation | FluentValidation |
| Authentication | JWT Bearer |
| Documents | Aspose (Office processing) |

## Solution Structure

```
QLDA.sln
├── QLDA.Domain/           # Core entities, interfaces, business rules
├── QLDA.Application/      # CQRS handlers, DTOs, validators
├── QLDA.Infrastructure/   # External services (Aspose, email)
├── QLDA.Persistence/      # EF Core DbContext, repositories
├── QLDA.WebApi/           # Controllers, middleware, JWT auth
└── QLDA.Migrator/         # Database migration tool
```

## Core Modules

| Module | Description |
|--------|-------------|
| **DuAn** | Project management with hierarchical structure |
| **GoiThau** | Bid package and tender management |
| **HopDong** | Contract lifecycle management |
| **ThanhToan/TamUng** | Payment and advance processing |
| **BaoCao** | Progress reporting |
| **VanBanQuyetDinh** | Legal decision documents |
| **DanhMuc*** | Master data (categories, statuses) |

## API Endpoints

Routes follow kebab-case convention:

```
/api/{resource}/danh-sach     # List (paginated)
/api/{resource}/{id}/chi-tiet # Detail
/api/{resource}/them-moi      # Create
/api/{resource}/cap-nhat      # Update
/api/{resource}/xoa-tam       # Soft delete
```

**Authentication:**
```
POST /api/auth/login    # Get JWT token
POST /api/auth/refresh  # Refresh token
POST /api/auth/logout   # Revoke session
```

## Quick Start

### Prerequisites
- .NET 8.0 SDK
- SQL Server 2019+
- Visual Studio 2022 / VS Code

### Setup

1. **Clone and configure:**
   ```bash
   git clone <repository-url>
   cd SER
   ```

2. **Update connection string** in `QLDA.WebApi/appsettings.json`

3. **Run migrations:**
   ```bash
   dotnet run --project QLDA.Migrator
   ```

4. **Start the API:**
   ```bash
   dotnet run --project QLDA.WebApi
   ```

5. **Access Swagger:** `http://localhost:{port}/swagger`

## Architecture

The system follows Clean Architecture with strict dependency rules:

```
WebApi → Application → Domain ← Infrastructure/Persistence
```

**Key Patterns:**
- CQRS with MediatR (Commands/Queries separation)
- Repository + Unit of Work
- MediatR Pipeline Behaviors (logging, validation, exceptions)
- Soft Delete with `DeletedAt`
- Materialized Path for hierarchical data

## Documentation

| Document | Description |
|----------|-------------|
| [Project Overview & PDR](docs/project-overview-pdr.md) | Requirements, scope, NFRs |
| [Codebase Summary](docs/codebase-summary.md) | Solution structure, entry points |
| [Code Standards](docs/code-standards.md) | Naming, patterns, best practices |
| [System Architecture](docs/system-architecture.md) | Layers, flows, deployment |
| [Architecture (Vietnamese)](docs/architecture.md) | Detailed architecture diagrams |
| [Data Model](docs/data-model.md) | Database schema and ERD |
| [Features](docs/features.md) | Use cases and modules |
| [API Documentation](docs/api.md) | Endpoint reference |

## Development Guidelines

- Use Vietnamese for entity property names matching business terms
- Use kebab-case for API routes
- Follow CQRS: Commands modify state, Queries read data
- Validate with FluentValidation in Application layer
- Use Dapper for complex read queries, EF Core for writes
- Soft delete via `DeletedAt` field

## Project Structure

```
QLDA.Application/
├── Auth/                 # Login, logout, refresh commands
├── Common/
│   ├── Behaviors/        # MediatR pipeline (logging, validation)
│   ├── DTOs/             # ResultApi, PaginatedList, UserInfo
│   └── Interfaces/       # IUserProvider, ICrudService
├── {Feature}/
│   ├── Commands/         # Create, Update, Delete operations
│   ├── Queries/          # List, GetById operations
│   ├── DTOs/             # Feature-specific DTOs
│   └── Validators/       # FluentValidation rules
└── DependencyInjection.cs

QLDA.WebApi/
├── Controllers/          # API endpoints
├── Middleware/           # Error handling, auth
├── ConfigurationOptions/ # AppSettings
└── Program.cs            # Entry point
```

## Contributing

1. Follow Clean Architecture principles
2. Write validators for all commands
3. Add DTOs for API boundaries (never expose entities)
4. Use async/await throughout
5. Update documentation for significant changes

## Contact

**Phòng CNTT - UBND Thành phố Hồ Chí Minh**
(IT Department - Ho Chi Minh City People's Committee)

---
*Last updated: 2025-12-09*
