# Plan: Add API "them-moi" for DuAnBuoc

## Objective
Add a new API endpoint to create a new `DuAnBuoc` with validation ensuring the `BuocId` belongs to the same `QuyTrinhId` as the `DuAn`.

## Architecture
- **Controller**: `DuAnBuocController` (WebApi)
- **Command**: `DuAnBuocCreateCommand` (Application)
- **DTO**: `DuAnBuocCreateDto` (Application)
- **Entity**: `DuAnBuoc` (Domain)
- **Validation**: Ensure `DuAn.QuyTrinhId == DanhMucBuoc.QuyTrinhId`.

## Steps

1.  **Create DTO**: `QLDA.Application/DuAnBuocs/DTOs/DuAnBuocCreateDto.cs`
    *   Fields: `DuAnId`, `BuocId`, `TenBuoc` (optional), `NgayDuKienBatDau`, `NgayDuKienKetThuc`, `GhiChu`, `TrachNhiemThucHien`.
2.  **Create Command**: `QLDA.Application/DuAnBuocs/Commands/DuAnBuocCreateCommand.cs`
    *   Properties: `DuAnBuocCreateDto Dto`.
    *   Return: `DuAnBuoc`.
3.  **Implement Handler**: `QLDA.Application/DuAnBuocs/Commands/DuAnBuocCreateCommandHandler.cs`
    *   Fetch `DuAn` by `Dto.DuAnId`. Throw if not found.
    *   Fetch `DanhMucBuoc` by `Dto.BuocId`. Throw if not found.
    *   **Validation**: Check `if (duAn.QuyTrinhId != danhMucBuoc.QuyTrinhId) throw new ValidationException(...)`.
    *   Map DTO to Entity.
    *   Save changes.
4.  **Update Controller**: `QLDA.WebApi/Controllers/DuAnBuocController.cs`
    *   Add `[HttpPost("api/du-an-buoc/them-moi")]`.
    *   Method `Create([FromBody] DuAnBuocCreateDto dto)`.
    *   Call Mediator.
