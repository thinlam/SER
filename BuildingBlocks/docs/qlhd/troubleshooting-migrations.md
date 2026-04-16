# QLHD Migration Troubleshooting

## Schema-Aware Migrations

### Error: "ALTER TABLE DROP COLUMN failed because column does not exist"

**Symptom:**
```
ALTER TABLE DROP COLUMN failed because column 'GhiChu' does not exist in table 'HopDong_XuatHoaDon'
```

**Root Cause:**
The `SchemaAwareMigrationsSqlGenerator` is missing override for column operations. SQL is generated without schema prefix:

```sql
-- Wrong (defaults to dbo)
ALTER TABLE [HopDong_XuatHoaDon] DROP COLUMN [GhiChu];

-- Correct (with schema prefix)
ALTER TABLE [dev].[HopDong_XuatHoaDon] DROP COLUMN [GhiChu];
```

**Fix:**
Add missing overrides in `SchemaAwareMigrationsSqlGenerator.cs`:

```csharp
protected override void Generate(DropColumnOperation operation, IModel? model, MigrationCommandListBuilder builder, bool terminate = true) {
    InjectSchema(operation);
    base.Generate(operation, model, builder, terminate);
}

protected override void Generate(AddColumnOperation operation, IModel? model, MigrationCommandListBuilder builder, bool terminate = true) {
    InjectSchema(operation);
    base.Generate(operation, model, builder, terminate);
}

protected override void Generate(AlterColumnOperation operation, IModel? model, MigrationCommandListBuilder builder) {
    InjectSchema(operation);
    base.Generate(operation, model, builder);
}
```

**Location:** `modules/QLHD/QLHD.Persistence/Schema/SchemaAwareMigrationsSqlGenerator.cs`

---

### Error: "Cannot insert duplicate key row" in FakeDataTool

**Symptom:**
```
Cannot insert duplicate key row in object 'dev.KhachHang' with unique index 'IX_KhachHang_Ma'
```

**Root Cause:**
Faker generates deterministic data using seed. Re-running with same seed produces duplicate unique values.

**Fix:**
Use Guid-based unique values for code fields:

```csharp
// Before (deterministic but duplicates)
.RuleFor(e => e.Ma, f => $"KH{f.UniqueIndex + 100}")

// After (unique per generation)
.RuleFor(e => e.Ma, f => $"KH{Guid.NewGuid().ToString("N")[..8].ToUpper()}")
```

---

### Error: FK constraint violation when inserting child entities

**Symptom:**
```
The INSERT statement conflicted with the FOREIGN KEY constraint "FK_HopDong_KhachHang_KhachHangId"
```

**Root Cause:**
Child entity requires parent entity to exist.

**Fix:**
FakeDataTool now auto-seeds FK dependencies:

| Entity | Auto-seeds |
|--------|-----------|
| `HopDong` | `KhachHang` |
| `CongViec` | `DuAn` → `KhachHang` |
| `HopDong_ThuTien` | `HopDong` → `KhachHang` |

---

### Error: Migration already applied but not in history

**Symptom:**
Migration tries to run but columns already exist in database.

**Root Cause:**
Migration was applied manually or partially, but not recorded in `__EFMigrationsHistory`.

**Fix:**
Manually record the migration:

```sql
INSERT INTO dev.__EFMigrationsHistory (MigrationId, ProductVersion)
VALUES ('20260407021321_UpdateTabls_KeHoachKinhDoanh_Attachment', '8.0.0');
```

---

## Best Practices

1. **Always scaffold migrations with `dbo` schema:**
   ```bash
   ./ef.bat QLHD add MigrationName
   ```

2. **Apply to specific schema:**
   ```bash
   ./ef.bat QLHD update --dev
   ```

3. **Check migration history before troubleshooting:**
   ```sql
   SELECT * FROM dev.__EFMigrationsHistory ORDER BY MigrationId;
   SELECT * FROM dbo.__EFMigrationsHistory ORDER BY MigrationId;
   ```

4. **Never modify database directly** - use migrations only.