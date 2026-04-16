# Phase 1: Implement Export Functionality

## Context
Implement the export API for `QuyTrinhTrinhDuAn` which lists the steps/stages of a project process.

## Requirements
- Create Excel template `QuyTrinhTrinhDuAn.xlsx`
- Create Stored Procedure `usp_In_QuyTrinhTrinhDuAn`
- Implement API method in `PrintController`

## File Ownership
- `QLDA.WebApi/PrintTemplates/QuyTrinhTrinhDuAn.xlsx`
- `../../DichVuDungChung/SER/DVDC.Migrator/Migrations/20260202050000_Add_usp_In_QuyTrinhTrinhDuAn.cs` (or similar migration file)
- `QLDA.WebApi/Controllers/PrintController.cs`

## Implementation Steps
1. [ ] Check `DuAnBuocController` for search parameters.
2. [ ] Create Excel Template `QuyTrinhTrinhDuAn.xlsx` (copy from `DanhSachDuAn.xlsx` or similar as base).
3. [ ] Create Migration for `usp_In_QuyTrinhTrinhDuAn`.
4. [x] Implement `InQuyTrinhTrinhDuAn` in `PrintController`.
5. [ ] Verify implementation.

## Success Criteria
- API returns 200 OK with Excel file.
- Excel file contains correct data from `DuAnBuoc`.
