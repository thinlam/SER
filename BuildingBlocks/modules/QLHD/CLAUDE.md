# CLAUDE.md - QLHD Module

## Shared Rules

**IMPORTANT:** This module follows the [Rules for Modules](../../CLAUDE.md#rules-for-modules) defined in BuildingBlocks.

Key rules include:
- **Index Configuration:** DanhMuc indexes must allow duplicates with `Used` and `IsDeleted` filtering
- **Naming Conventions:** Use `DanhMuc{Ten}` pattern (not `Dm{Ten}`)
- **Legacy Tables:** No FK navigation to `DmDonVi`/`USER_MASTER` - use `LeftOuterJoin`
- **Migration Column Order:** Standard ordering for DanhMuc tables

See full details: [BuildingBlocks CLAUDE.md - Rules for Modules](../../CLAUDE.md#rules-for-modules)

## Module-Specific Notes

### QLHD Entity Types

| Entity Type | Examples |
|-------------|----------|
| DanhMuc | `DanhMucLoaiHopDong`, `DanhMucTrangThai`, `DanhMucGiamDoc` |
| Business Entities | `HopDong`, `DuAn`, `DuAnPhongBanPhoiHop` |

### Key Business Rules

- Contracts (`HopDong`) belong to Projects (`DuAn`)
- Projects can have multiple participating departments (`DuAnPhongBanPhoiHop`)
- Status transitions follow `DanhMucTrangThai` workflow

### HopDong-DuAn Relationship (Zero-or-One-to-One)

**Constraint:** Each `DuAn` can have at most one `HopDong`. A `HopDong` can optionally belong to a `DuAn` (standalone contracts allowed).

**IMPORTANT:**
- **DuAnId is optional** - Contracts can exist without belonging to a project (standalone contracts)
- **DuAnId is immutable after insert** - Once a HopDong is created, its DuAnId cannot be changed

1. **Database Level:**
   - Nullable foreign key on `HopDong.DuAnId`
   - Unique index on `HopDong.SoHopDong` (contract number must be unique)
   - Foreign key with `SetNull` delete behavior (if DuAn is deleted, DuAnId becomes null)

2. **Application Level (Validators):**
   - `HopDongInsertCommandValidator`: DuAnId is optional, if provided checks DuAn exists and not already assigned
   - `HopDongUpdateCommandValidator`: Checks SoHopDong uniqueness (DuAnId not editable)

3. **HasHopDong Flag Synchronization:**
   - `DuAn.HasHopDong` is set to `true` when a HopDong is created with that DuAnId
   - Handled in `HopDongInsertCommandHandler` (only if DuAnId is provided)

4. **Update Model:**
   - `HopDongUpdateModel` does NOT include `DuAnId` property (immutable)
   - `HopDongMapping.UpdateFrom()` does NOT update `DuAnId`

**Key Files:**
- `QLHD.Domain/Entities/HopDong.cs` - Entity with `DuAnId` (optional, nullable `Guid?`)
- `QLHD.Domain/Entities/DuAn.cs` - Entity with `HasHopDong` flag and `HopDong` nav property
- `QLHD.Persistence/Configurations/HopDongConfiguration.cs` - FK config with SetNull delete
- `QLHD.Application/HopDongs/DTOs/HopDongInsertModel.cs` - `Guid? DuAnId` (optional)
- `QLHD.Application/HopDongs/DTOs/HopDongUpdateModel.cs` - No `DuAnId` property (immutable)
- `QLHD.Application/HopDongs/Validators/HopDongInsertCommandValidator.cs` - DuAnId optional validation
- `QLHD.Application/HopDongs/Commands/HopDongInsertCommandHandler.cs` - HasHopDong sync only if DuAnId provided

### DuAn-HopDong Conceptual Single Entity

**Core Concept:** DuAn (Dự án) và HopDong (Hợp đồng) thực chất là **1 thực thể kinh doanh** với 2 mặt:

| Mặt | Entity | Vai trò | Khi nào |
|-----|--------|---------|---------|
| **Kế hoạch** | `DuAn` | Dữ liệu dự kiến (giá trị dự kiến, thời gian dự kiến) | Có trước |
| **Thực tế** | `HopDong` | Dữ liệu thực tế (giá trị thực, ngày ký, ...) | Có sau |

**Key Rules:**
- **HopDong có thể tạo độc lập** — không cần DuAn (DuAnId = null), tạo trực tiếp hợp đồng không cần kế hoạch
- **Mối quan hệ 0..1 ↔ 0..1** — 1 DuAn có tối đa 1 HopDong
- **DuAnId bất biến** — sau khi tạo không thể thay đổi

**Prefix Routing cho ThuTien/XuatHoaDon:**

Khi tạo ThuTien hoặc XuatHoaDon, dữ liệu được lưu vào bảng khác nhau dựa trên DuAnId:

```
HopDong.DuAnId có giá trị → DuAn_ThuTien / DuAn_XuatHoaDon  (prefix "DuAn_")
HopDong.DuAnId null        → HopDong_ThuTien / HopDong_XuatHoaDon (prefix "HopDong_")
```

**Implementation:** `ThuTienInsertOrUpdateCommandHandler` và `XuatHoaDonInsertOrUpdateCommandHandler` kiểm tra `hopDong.DuAnId` để quyết định routing.

**Key Files:**
- `QLHD.Domain/Constants/LoaiDuAnHopDongConstants.cs` - DU_AN = kế hoạch, HOP_DONG = thực tế
- `QLHD.Application/ThuTiens/Commands/ThuTienInsertOrUpdateCommand.cs` - Routing logic
- `QLHD.Application/XuatHoaDons/Commands/XuatHoaDonInsertOrUpdateCommand.cs` - Routing logic

### LINQ Query Null Checking

**Rule:** When projecting nullable navigation properties in LINQ queries, use explicit nullable casts for non-nullable entity properties.

**Pattern:**
```csharp
// ✅ Correct - Non-nullable entity properties need explicit nullable cast
ThucTeId = k.ThuTienThucTe == null ? (Guid?)null : k.ThuTienThucTe.Id,
ThoiGianThucTe = k.ThuTienThucTe == null ? (DateOnly?)null : k.ThuTienThucTe.ThoiGian,
GiaTriThucTe = k.ThuTienThucTe == null ? (decimal?)null : k.ThuTienThucTe.GiaTri,

// ✅ Correct - Already-nullable entity properties can use ! operator
GhiChuThucTe = k.ThuTienThucTe!.GhiChu,              // string? on entity → safe
SoHoaDon = k.ThuTienThucTe!.SoHoaDon,                // string? on entity → safe
NgayHoaDon = k.ThuTienThucTe!.NgayHoaDon,            // DateOnly? on entity → safe

// ❌ Wrong - Causes "Nullable object must have a value" error
ThucTeId = k.ThuTienThucTe!.Id,                      // Guid (non-nullable) accessed on null navigation
```

**Why:**
- EF Core translates to SQL LEFT JOIN
- When navigation is null, accessing non-nullable properties (Guid, DateOnly, decimal) fails at runtime
- Entity properties like `Id`, `ThoiGian`, `GiaTri` are NOT nullable - they're required fields
- Entity properties like `GhiChu`, `SoHoaDon` are nullable (string?, DateOnly?) - safe to access via `!`
- `!` only suppresses C# compiler warning, but runtime still throws if accessing non-nullable property on null

### Validation Pattern

**Rule:** All validation logic MUST be in FluentValidation validators, NOT in command handlers.

**Pattern:**
```csharp
// ✅ Correct - Validator handles all validation
public class ThuTienInsertCommandValidator : AbstractValidator<ThuTienInsertCommand>
{
    public ThuTienInsertCommandValidator(IServiceProvider serviceProvider)
    {
        RuleFor(x => x.Model.HopDongId)
            .MustAsync(async (id, ct) => await hopDongExists(id))
            .WithMessage("Hợp đồng không tồn tại");
    }
}

// ✅ Handler trusts validator, uses ! operator
public async Task<ThuTienDto> Handle(ThuTienInsertCommand request, ...)
{
    var entity = await _repository.GetQueryableSet()
        .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
    entity!.UpdateFrom(request.Model);  // Validator ensures entity exists
    // ...
}
```

**Why:**
- Single responsibility: Validators own validation logic
- Cleaner handlers focused on business logic
- Consistent error messages and validation behavior
- Easier to test and maintain validation rules

### Upsert Model Pattern (Guid? Id with DefaultValue)

**Rule:** For DTOs that support both insert and update operations (upsert), use `Guid? Id` with `[DefaultValue]` attribute.

**Pattern:**
```csharp
using System.ComponentModel;

public class KeHoachThuTienModel
{
    /// <summary>
    /// If null or empty → Add new. If has value → Update existing.
    /// </summary>
    [DefaultValue("00000000-0000-0000-0000-000000000000")]
    public Guid? Id { get; set; }
    // ... other properties
}
```

**Requirements:**
1. Add `using System.ComponentModel;` for `DefaultValue` attribute
2. Include XML comment explaining upsert behavior
3. Use `Guid.Empty` string representation for default value
4. Handler checks: if `Id.HasValue && Id != Guid.Empty` → update, else → insert

**Examples in codebase:**
- `KeHoachThuTienModel.cs` - DuAn upsert
- `KeHoachXuatHoaDonModel.cs` - DuAn upsert
- `KhoKhanVuongMacInsertModel.cs` - KhoKhanVuongMac upsert

### TienDo-BaoCaoTienDo Parent-Child Pattern

**Relationship:** TienDo (parent) ↔ BaoCaoTienDo (children) with denormalized fields.

**Denormalization Pattern:**
```csharp
// TienDo has denormalized fields updated from BaoCaoTienDo
public class TienDo : Entity<Guid>
{
    public decimal PhanTramThucTe { get; set; }         // Max of BaoCaoTienDo.PhanTramThucTe
    public DateOnly? NgayCapNhatGanNhat { get; set; }   // Max of BaoCaoTienDo.NgayBaoCao
}
```

**Key Files:**
- `QLHD.Domain/Entities/TienDo.cs` - Parent entity with denormalized fields
- `QLHD.Domain/Entities/BaoCaoTienDo.cs` - Child entity with approval workflow
- `QLHD.Domain/Entities/KhoKhanVuongMac.cs` - Optional link to TienDo

**Status Types (LoaiTrangThaiConstants):**
- `TienDo` = `TIENDO` - Status for TienDo entity
- `KhoKhanVuongMac` = `KKHUAN_VUONG_MAC` - Status for KhoKhanVuongMac entity

### Schema-Aware Migration Workflow (dbo/dev)

**Architecture:** One migration set, applied to both schemas at runtime via injection.

```
Scaffold (design-time)          Runtime (dbo)              Runtime (dev)
──────────────────────          ──────────────              ──────────────
Schema = dbo                    Schema = dbo                Schema = dev
No HasDefaultSchema             No HasDefaultSchema         HasDefaultSchema("dev")
Snapshot = schema-neutral       Tables → dbo.*              Tables → dev.*
                                History → dbo.__EF...      History → dev.__EF...
```

**Infrastructure:**

| Component | File | Purpose |
|-----------|------|---------|
| `ISchemaAwareDbContext` | `Schema/ISchemaAwareDbContext.cs` | Marker interface exposing `Schema` property |
| `SchemaConfig` | `DependencyInjection.cs` | DI singleton carrying effective schema name |
| `SchemaAwareModelCacheKeyFactory` | `Schema/SchemaAwareModelCacheKeyFactory.cs` | Separate EF model cache per schema |
| `SchemaAwareModelCacheKey` | `Schema/SchemaAwareModelCacheKey.cs` | Cache key including schema name |
| `SchemaAwareMigrationsSqlGenerator` | `Schema/SchemaAwareMigrationsSqlGenerator.cs` | Injects runtime schema into migration SQL |
| `AppDbContext` | `AppDbContext.cs` | `HasDefaultSchema` only for non-dbo schemas |

**How it works:**
1. **Scaffolding:** Always use `ConnectionStrings__Schema=dbo` → snapshot has no schema references
2. **Runtime (dbo):** No injection needed — SQL defaults to dbo
3. **Runtime (dev):** `SchemaAwareMigrationsSqlGenerator` reads `ConnectionStrings__Schema` env var, injects "dev" into all migration SQL operations (CREATE TABLE, CREATE INDEX, etc.)
4. **Separate history tables:** `dbo.__EFMigrationsHistory` and `dev.__EFMigrationsHistory` track migrations independently

**Migration Commands:**

```bash
# Scaffold migrations (ALWAYS with dbo schema)
cd modules/QLHD/QLHD.Persistence
ConnectionStrings__Schema=dbo dotnet ef migrations add {Name} \
  --startup-project ../QLHD.Migrator \
  --project ../QLHD.Migrator \
  --output-dir Migrations/dbo

# Apply to dbo
ConnectionStrings__Schema=dbo dotnet run --project ../QLHD.Migrator

# Apply to dev
ConnectionStrings__Schema=dev dotnet run --project ../QLHD.Migrator
```

**IMPORTANT:**
- NEVER scaffold migrations with `ConnectionStrings__Schema=dev` — it will contaminate the snapshot with `HasDefaultSchema("dev")`
- ALWAYS use `ConnectionStrings__Schema=dbo` for scaffolding
- The `ReplaceService<IModelCacheKeyFactory, SchemaAwareModelCacheKeyFactory>()` in DI enables different cached models per schema at runtime

### TepDinhKem (Attachment) Pattern

**Rule:** TepDinhKem handling must be separated from entity CRUD operations. Do NOT handle attachments inside Insert/Update command handlers.

**Why:** Separation of concerns - entity operations should not be coupled with file operations. This allows flexible file management (temp files, file reassignment, etc.).

**Required Interfaces:**

| Interface | Property | Usage |
|-----------|----------|-------|
| `IMayHaveTepDinhKemInsertModel` | `List<TepDinhKemInsertModel>? DanhSachTepDinhKem` | Insert models (new files only) |
| `IMayHaveTepDinhKemInsertOrUpdateModel` | `List<TepDinhKemInsertOrUpdateModel>? DanhSachTepDinhKem` | Update models (add/edit/delete) |
| `IMayHaveTepDinhKemDto` | `List<TepDinhKemDto>? DanhSachTepDinhKem` | Response DTOs |

**Correct Pattern (Controller/Caller handles files):**

```csharp
// 1. Insert entity FIRST
var entity = await Mediator.Send(new HopDongInsertCommand(model), cancellationToken);

// 2. Handle attachments SEPARATELY (if provided)
if (model.DanhSachTepDinhKem != null && model.DanhSachTepDinhKem.Count > 0)
{
    var files = model.DanhSachTepDinhKem.ToEntities(entity.Id.ToString());
    await Mediator.Send(new TepDinhKemInsertCommand(files), cancellationToken);
}

// For UPDATE - use bulk insert or update
if (model.DanhSachTepDinhKem != null && model.DanhSachTepDinhKem.Count > 0)
{
    var files = model.DanhSachTepDinhKem.ToEntities(entity.Id.ToString());
    await Mediator.Send(new TepDinhKemBulkInsertOrUpdateCommand
    {
        GroupId = entity.Id.ToString(),
        Entities = files
    }, cancellationToken);
}
```

**File Reassignment Pattern (from temp source):**

```csharp
// Get files from temporary source (e.g., requestId)
var files = await Mediator.Send(new GetDanhSachTepDinhKemQuery
{
    GroupId = [requestId.ToString()],
    EGroupTypes = [EGroupType.YeuCau]
}, cancellationToken);

if (files.Count != 0)
{
    // Reassign to new entity
    files.ForEach(item => {
        item.Id = GuidExtensions.GetSequentialGuidId();
        item.GroupId = entity.Id.ToString();
    });
    await Mediator.Send(new TepDinhKemInsertCommand(files), cancellationToken);
}
```

**Anti-Pattern (DO NOT DO THIS):**

```csharp
// ❌ WRONG - Do NOT handle TepDinhKem inside command handler
public async Task<HopDongDto> Handle(HopDongInsertCommand request, ...)
{
    // ... entity creation ...

    // ❌ This couples entity and file operations
    if (request.Model.TepDinhKems != null && request.Model.TepDinhKems.Count > 0) {
        var tepDinhKems = request.Model.TepDinhKems.ToEntities(entity.Id.ToString());
        await SyncHelper.SyncCollection(_tepDinhKemRepository, null, tepDinhKems, ...);
    }
}
```

**Key Points:**
- Property name MUST be `DanhSachTepDinhKem` (not `TepDinhKems`)
- Models implement appropriate interface (`IMayHaveTepDinhKemInsertModel` or `IMayHaveTepDinhKemInsertOrUpdateModel`)
- DTOs implement `IMayHaveTepDinhKemDto`
- Command handlers do NOT contain TepDinhKem logic
- Controller/Caller is responsible for file operations via MediatR commands