---
title: "Export Quy Trinh Trinh Du An to Excel"
description: "Implement Excel export for Quy Trinh Trinh Du An using Application Layer data fetching"
status: completed
priority: P2
effort: 2h
branch: ChuyenDoiSo
tags: [excel, export, quy-trinh]
created: 2026-02-02
---

## Overview
Implement Excel export functionality for "Quy Trinh Trinh Du An" using the existing `DuAnBuocGetTreeListQuery` to fetch data and `IExcelExporter` to generate the Excel file. This avoids using Stored Procedures as requested.

## Phases

### Phase 1: Setup and Verification
- **Status**: Completed
- **Description**: Verify the Excel template exists and matches the data structure.
- **Tasks**:
  - [x] Check if `PrintTemplates/QuyTrinhTrinhDuAn.xlsx` exists in `QLDA.WebApi`.
  - [x] If not, create a basic template with placeholders matching `DuAnBuocStateDto`.

### Phase 2: Implementation
- **Status**: Completed
- **Description**: Implement the export logic in `PrintController`.
- **Tasks**:
  - [x] Modify `QLDA.WebApi/Controllers/PrintController.cs`:
    - [x] Inject `IExcelExporter`.
    - [x] Add `InQuyTrinhTrinhDuAn` action.
    - [x] Fetch data using `DuAnBuocGetTreeListQuery`.
    - [x] Export using `_excelExporter.Export`.

## Key Considerations
- **Data Source**: Use `DuAnBuocGetTreeListQuery` (Application Layer) instead of Stored Procedure.
- **Template**: Placeholders must match `DuAnBuocStateDto` properties (e.g., `$TenBuoc`, `$TenGiaiDoan`).
- **Dependency Injection**: Ensure `IExcelExporter` is correctly resolved.
