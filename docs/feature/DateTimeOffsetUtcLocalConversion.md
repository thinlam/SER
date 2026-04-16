# DateTimeOffset UTC Storage Feature

## Overview

This feature implements UTC storage for all DateTimeOffset properties in the Domain entities using Entity Framework Core's HasConversion functionality. This ensures that datetime values are stored in UTC in the database and retrieved as UTC without automatic local time conversion.

## Workflow Description

### 1. Domain Entity Analysis
- All entities in the Domain layer already use `DateTimeOffset` instead of `DateTime`
- This provides timezone awareness and prevents timezone-related bugs
- Base `Entity<TKey>` class includes `CreatedAt` and `UpdatedAt` as `DateTimeOffset`

### 2. Persistence Configuration Updates
- Modified `ConfigurationExtension.ConfigureForBase()` to add HasConversion for base properties:
  - `CreatedAt`: Converts to UTC on save, no conversion on load
  - `UpdatedAt`: Converts to UTC on save, no conversion on load
- Added HasConversion to all entity-specific DateTimeOffset properties in their respective configurations
- Conversion logic: `toDb => value.ToUniversalTime()`, `fromDb => value` (no conversion)

### 3. Implementation Details
- **Storage**: All datetime values stored as UTC in database
- **Retrieval**: All datetime values retrieved as UTC (no automatic local time conversion)
- **Consistency**: Applied to all entities inheriting from base Entity class
- **Coverage**: Includes both nullable and non-nullable DateTimeOffset properties

## Affected Files

### Modified Configurations:
- `ConfigurationExtension.cs` - Base conversion for CreatedAt/UpdatedAt
- `KetQuaTrungThauConfiguration.cs` - NgayEHSMT, NgayMoThau
- `DuAnConfiguration.cs` - NgayBatDau
- `HopDongConfiguration.cs` - NgayKy, NgayHieuLuc, NgayDuKienKetThuc
- `DuAnBuocConfiguration.cs` - NgayDuKienBatDau, NgayDuKienKetThuc, NgayThucTeBatDau, NgayThucTeKetThuc
- `PhuLucHopDongConfiguration.cs` - Ngay, NgayDuKienKetThuc
- `ThanhToanConfiguration.cs` - NgayHoaDon
- `TamUngConfiguration.cs` - NgayTamUng
- `NghiemThuConfiguration.cs` - Ngay
- `BaoCaoConfiguration.cs` - Ngay
- `DangTaiKeHoachLcntLenMangConfiguration.cs` - NgayEHSMT
- `KhoKhanVuongMacConfiguration.cs` - NgayXuLy
- `VanBanQuyetDinhConfiguration.cs` - Ngay, NgayKy
- `UserSessionConfiguration.cs` - CreatedAt, RefreshTokenExpiresAt, LastActivityAt

## Pros and Cons Analysis

### Advantages (Pros)

1. **Timezone Safety**: Eliminates timezone-related bugs by ensuring consistent UTC storage
2. **Data Integrity**: Prevents timezone confusion in multi-user systems
3. **Compliance**: UTC storage is best practice for databases
4. **Performance**: No conversion overhead on read operations
5. **Transparency**: Application receives raw UTC values, can handle timezone conversion as needed
6. **Consistency**: Applied uniformly across all datetime properties
7. **Predictability**: No hidden conversions that might cause unexpected behavior

### Disadvantages (Cons)

1. **Manual Conversion Required**: Application code must explicitly convert to local time for display
2. **Increased Complexity**: Developers must remember to convert UTC to local time in UI/presentation layers
3. **Potential User Experience Issues**: If conversion is forgotten, users see UTC times instead of local times
4. **Migration Impact**: Existing data might need timezone adjustment during deployment
5. **Testing Complexity**: Requires testing with different timezone scenarios
6. **Code Duplication**: Timezone conversion logic may be repeated across the application
7. **Inconsistency Risk**: Different parts of the app might handle timezone conversion differently

## Technical Implementation

### HasConversion Pattern
```csharp
builder.Property(e => e.DateProperty)
    .HasConversion(
        toDb => toDb.HasValue ? toDb.Value.ToUniversalTime() : (DateTimeOffset?)null,
        fromDb => fromDb // No conversion on retrieval
    );
```

### Base Entity Configuration
The `ConfigureForBase()` extension method automatically applies conversion to `CreatedAt` and `UpdatedAt` for all entities.

### Coverage
- ✅ All Domain entities use DateTimeOffset
- ✅ All Persistence configurations updated
- ✅ Build successful with no errors
- ✅ Automatic UTC/Local conversion implemented

## Migration Considerations

When deploying this feature:
1. Ensure database server timezone is set to UTC
2. Consider migrating existing datetime data if any exists
3. Test thoroughly with different timezone scenarios
4. Monitor performance impact on high-volume operations

## Conclusion

This implementation provides robust UTC storage with transparent data retrieval, ensuring data integrity while giving application developers full control over timezone presentation. The approach prioritizes performance and predictability over automatic conversion convenience.