# Phase 02: Persistence Configuration

**Priority:** High
**Status:** Pending
**Dependencies:** Phase 01

## Overview

Create EF Core configurations for versioned entities with proper FK relationships, decimal precision, and indexes.

## Requirements

### Functional Requirements

1. Configure FK relationships with cascade behaviors
2. Set decimal precision for monetary fields (18, 2)
3. Set decimal precision for percentage fields (5, 2)
4. Create indexes for KeHoachThangId, SourceEntityId, OwnerId
5. Configure string lengths for notes and invoice fields

### Non-Functional Requirements

- Use AggregateRootConfiguration base class pattern
- Apply ConfigureForBase() for audit fields
- Follow existing configuration patterns in QLHD.Persistence

## Architecture

### Configuration Template

```csharp
public class DuAn_ThuTien_VersionConfiguration : AggregateRootConfiguration<DuAn_ThuTien_Version>
{
    public override void Configure(EntityTypeBuilder<DuAn_ThuTien_Version> builder)
    {
        builder.ToTable("DuAn_ThuTien_Version");
        builder.ConfigureForBase();

        // FK to KeHoachThang (required)
        builder.Property(e => e.KeHoachThangId).IsRequired();
        builder.HasOne(e => e.KeHoachThang)
            .WithMany()
            .HasForeignKey(e => e.KeHoachThangId)
            .OnDelete(DeleteBehavior.Restrict);

        // FK to Source Entity (required)
        builder.Property(e => e.SourceEntityId).IsRequired();
        builder.HasOne(e => e.SourceEntity)
            .WithMany()
            .HasForeignKey(e => e.SourceEntityId)
            .OnDelete(DeleteBehavior.Restrict);

        // FK to Owner (DuAn)
        builder.Property(e => e.DuAnId).IsRequired();
        builder.HasOne(e => e.DuAn)
            .WithMany()
            .HasForeignKey(e => e.DuAnId)
            .OnDelete(DeleteBehavior.Restrict);

        // FK to executing HopDong (nullable)
        builder.Property(e => e.HopDongId);
        builder.HasOne(e => e.HopDong)
            .WithMany()
            .HasForeignKey(e => e.HopDongId)
            .OnDelete(DeleteBehavior.SetNull);

        // FK to LoaiThanhToan
        builder.Property(e => e.LoaiThanhToanId).IsRequired();
        builder.HasOne(e => e.LoaiThanhToan)
            .WithMany()
            .HasForeignKey(e => e.LoaiThanhToanId)
            .OnDelete(DeleteBehavior.Restrict);

        // Decimal precision
        builder.Property(e => e.GiaTriKeHoach).HasPrecision(18, 2);
        builder.Property(e => e.GiaTriThucTe).HasPrecision(18, 2);
        builder.Property(e => e.PhanTramKeHoach).HasPrecision(5, 2);

        // Plan fields (required)
        builder.Property(e => e.ThoiGianKeHoach).IsRequired();
        builder.Property(e => e.PhanTramKeHoach).IsRequired();
        builder.Property(e => e.GiaTriKeHoach).IsRequired();

        // String lengths
        builder.Property(e => e.GhiChuKeHoach).HasMaxLength(1000);
        builder.Property(e => e.GhiChuThucTe).HasMaxLength(1000);
        builder.Property(e => e.SoHoaDon).HasMaxLength(50);
        builder.Property(e => e.KyHieuHoaDon).HasMaxLength(50);

        // Indexes
        builder.HasIndex(e => e.KeHoachThangId);
        builder.HasIndex(e => e.SourceEntityId);
        builder.HasIndex(e => e.DuAnId);
    }
}
```

## Implementation Steps

1. Create `DuAn_ThuTien_VersionConfiguration.cs`
2. Create `DuAn_XuatHoaDon_VersionConfiguration.cs`
3. Create `HopDong_ThuTien_VersionConfiguration.cs`
4. Create `HopDong_XuatHoaDon_VersionConfiguration.cs`
5. Create `HopDong_ChiPhi_VersionConfiguration.cs`
6. Update `AppDbContext.cs` - add DbSet for each version entity
7. Update `DependencyInjection.cs` - register version repositories

## Todo List

- [ ] Create DuAn_ThuTien_Version configuration
- [ ] Create DuAn_XuatHoaDon_Version configuration
- [ ] Create HopDong_ThuTien_Version configuration
- [ ] Create HopDong_XuatHoaDon_Version configuration
- [ ] Create HopDong_ChiPhi_Version configuration
- [ ] Update AppDbContext with DbSet entries
- [ ] Update DependencyInjection with repository registrations

## Success Criteria

- All 5 configurations created
- FK relationships properly configured
- Decimal precision applied to monetary fields
- Indexes created for FK fields
- DbSets added to AppDbContext
- Repositories registered in DI

## Risk Assessment

| Risk | Mitigation |
|------|------------|
| FK cascade issues | Use Restrict for all FKs except nullable ones |
| Decimal overflow | Use precision (18, 2) for all monetary values |

## Next Steps

After configurations created → Phase 03: Application Layer