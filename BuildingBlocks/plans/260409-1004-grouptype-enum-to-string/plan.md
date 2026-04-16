---
name: GroupType Enum to String Conversion
description: Convert TepDinhKem.GroupType from EGroupType enum to string for loose coupling
type: project
---

# Plan: GroupType Enum → String Conversion

## Overview

**Priority:** High
**Status:** Pending
**Branch:** ChuyenDoiSo

Convert `GroupType` property from `EGroupType` enum to `string` for loose coupling between BuildingBlocks and consuming modules.

## Rationale

- Current: Modules must modify BB's `EGroupType` enum to add their table types (tight coupling)
- QLHD workaround: Created separate `EGroupType_QLHD` enum → fragmentation
- Solution: String allows modules to pass table names directly without BB modifications
- Reference: `Attachment.cs` already uses string pattern

## Key Findings

- DB column already `nvarchar(max)` (string) - confirmed via EF Core snapshot
- Table `TepDinhKems` excluded from migrations - no DB changes needed
- 25 files reference `GroupType` - most are auto-updated by changing entity type

---

## Phase 1: Core Entity Change

**Status:** Pending

### Files to Modify

- `BuildingBlocks.Domain/Entities/TepDinhKem.cs`

### Implementation

```csharp
// Before
public EGroupType GroupType { get; set; } = EGroupType.None;

// After
public string GroupType { get; set; } = string.Empty;
```

### Steps

1. [ ] Change property type in `TepDinhKem.cs`
2. [ ] Remove `using BuildingBlocks.Domain.Enums;` if unused elsewhere

---

## Phase 2: DTOs and Models

**Status:** Pending

### Files to Modify

- `BuildingBlocks.Application/TepDinhKems/DTOs/TepDinhKemDto.cs`
- `BuildingBlocks.Application/TepDinhKems/DTOs/TepDinhKemInsertOrUpdateModel.cs`
- `BuildingBlocks.Application/TepDinhKems/DTOs/TepDinhKemMapping.cs`

### Implementation

Change `EGroupType?` → `string?` in DTOs. Remove enum import.

### Steps

1. [ ] Update `TepDinhKemDto.cs` property type
2. [ ] Update `TepDinhKemInsertOrUpdateModel.cs` property type
3. [ ] Update mapping if explicit conversion exists

---

## Phase 3: Queries and Commands

**Status:** Pending

### Files to Check

- `BuildingBlocks.Application/TepDinhKems/Queries/GetDanhSachTepDinhKemQuery.cs`
- `BuildingBlocks.Application/TepDinhKems/Commands/TepDinhKemBulkInsertOrUpdateCommand.cs`
- `BuildingBlocks.Application/Attachments/` (reference only)

### Steps

1. [ ] Review queries for enum comparisons
2. [ ] Update any filter/predicate logic if needed
3. [ ] Verify commands don't use enum-specific logic

---

## Phase 4: Cleanup

**Status:** Pending

### Files

- `BuildingBlocks.Domain/Enums/EGroupType.cs` - Decision: Keep for legacy reference or delete?
- `QLHD.Domain/Enums/EGroupType_QLHD.cs` - May need migration to string usage

### Steps

1. [ ] Decide: Keep or remove `EGroupType.cs`
2. [ ] Update consuming modules if they reference enum
3. [ ] Remove dead imports across affected files

---

## Phase 5: Documentation Update

**Status:** Pending

### Files

- `docs/codebase-summary.md` - Remove "Legacy - uses enum" distinction

### Steps

1. [ ] Update docs to reflect unified string approach
2. [ ] Update `CLAUDE.md` if GroupType patterns documented

---

## Success Criteria

- [ ] `TepDinhKem.cs` uses `string GroupType`
- [ ] All DTOs/models updated
- [ ] No enum imports in TepDinhKem-related files
- [ ] Build succeeds with no errors
- [ ] Existing data in DB compatible (already string)

## Risk Assessment

**Risk:** LOW
- DB already stores string
- No migration needed
- Type change is compile-time only
- Modules already passing string values (via EF conversion)

## Next Steps

After approval:
1. Implement Phase 1-2 (core changes)
2. Run `dotnet build` to verify
3. Review and fix any compile errors
4. Update docs