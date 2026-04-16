# Phase 02: Create Persistence Configuration

## Context

- Base configuration: `QLDA.Persistence.Configurations.AggregateRootConfiguration<TEntity>`
- Reference: `QLDA.Persistence.Configurations.DanhMuc.DanhMucGiaiDoanConfiguration.cs`
- Location: `QLDA.Persistence/Configurations/DanhMuc/`

## Overview

**Priority:** High
**Status:** Completed

Create EF Core configuration for database mapping.

## Implementation Steps

1. **Create configuration file:** `QLDA.Persistence/Configurations/DanhMuc/DanhMucTinhTrangThucHienLcntConfiguration.cs`

```csharp
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucTinhTrangThucHienLcntConfiguration : AggregateRootConfiguration<DanhMucTinhTrangThucHienLcnt>
{
    public override void Configure(EntityTypeBuilder<DanhMucTinhTrangThucHienLcnt> builder)
    {
        builder.ToTable("DmTinhTrangThucHienLcnt");
        builder.ConfigureForDanhMuc();

        // Add navigation properties configuration here if needed
    }
}
```

## Success Criteria

- Configuration compiles without errors
- Table name set correctly: `DmTinhTrangThucHienLcnt`
- Inherits `ConfigureForDanhMuc()` method for common fields

## Files to Create

- `QLDA.Persistence/Configurations/DanhMuc/DanhMucTinhTrangThucHienLcntConfiguration.cs`
