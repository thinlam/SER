# Phase 03: Application Commands & Queries

## Context

- Uses generic `DanhMucInsertOrUpdateCommand` and `DanhMucGetQuery`
- No custom commands/queries needed for simple CRUD
- Common queries in `QLDA.Application/Common/Queries/`

## Overview

**Priority:** Medium
**Status:** Completed

Since this is a simple catalog entity using the generic infrastructure, no custom commands or queries are needed in the Application layer. The common handlers will support this entity after updating the enum and service registrations.

## Implementation Notes

**No files to create** - Uses existing common infrastructure:
- `DanhMucInsertOrUpdateCommand` - for Create/Update
- `DanhMucGetQuery` - for Get by Id
- `DanhMucGetDanhSachQuery` - for List

## Success Criteria

- Generic queries work via enum switch
- Commands work via enum switch

## Files to Create

- None (uses existing common infrastructure)
