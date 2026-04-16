# Plan: Add API "them-moi" for DuAnBuoc

## Objective
Add a new API endpoint to create a new `DuAnBuoc` with validation ensuring the `BuocId` belongs to the same `QuyTrinhId` as the `DuAn`.

## Architecture
- **Controller**: `DuAnBuocController` (WebApi)
- **Command**: `DuAnBuocCreateCommand` (Application)
- **DTO**: `DuAnBuocCreateDto` (Application)
- **Entity**: `DuAnBuoc` (Domain)
- **Validation**:
    1. `DuAn.QuyTrinhId == DanhMucBuoc.QuyTrinhId`.
    2. Date validation: `NgayDuKienKetThuc >= NgayDuKienBatDau` (if provided).

## Steps

1.  **Create DTO**: `QLDA.Application/DuAnBuocs/DTOs/DuAnBuocCreateDto.cs`
    *   Fields: `DuAnId`, `BuocId`, `TenBuoc` (optional), `NgayDuKienBatDau`, `NgayDuKienKetThuc`, `GhiChu`, `TrachNhiemThucHien`.
2.  **Create Command**: `QLDA.Application/DuAnBuocs/Commands/DuAnBuocCreateCommand.cs`
    *   Properties: `DuAnBuocCreateDto Dto`.
    *   Return: `DuAnBuoc`.
3.  **Implement Handler**: `QLDA.Application/DuAnBuocs/Commands/DuAnBuocCreateCommandHandler.cs`
    *   Inject `IApplicationDbContext`.
    *   Fetch `DuAn` (throw if null).
    *   Fetch `DanhMucBuoc` (throw if null).
    *   **Validation 1**: `if (duAn.QuyTrinhId != danhMucBuoc.QuyTrinhId) throw Exception`.
    *   **Validation 2**: `if (Dto.NgayDuKienBatDau.HasValue && Dto.NgayDuKienKetThuc.HasValue && Dto.NgayDuKienKetThuc < Dto.NgayDuKienBatDau) throw Exception`.
    *   Map DTO to `DuAnBuoc` entity.
    *   `_context.DuAnBuocs.Add(entity)`.
    *   `await _context.SaveChangesAsync`.
4.  **Update Controller**: `QLDA.WebApi/Controllers/DuAnBuocController.cs`
    *   Add `[HttpPost("api/du-an-buoc/them-moi")]`.
    *   Method `Create([FromBody] DuAnBuocCreateDto dto)`.
    *   Call Mediator.
