# Role Interfaces Pattern for QLHD

## Context

Create role interfaces in Domain layer (similar to `INgayHopDong`) to ensure consistent property contracts across entities and DTOs.

**Problem:** Multiple entities/DTOs share property groups (KeHoach, ThucTe, HoaDon) but no type contract exists.

**Solution:** Create role interfaces in Domain layer, apply to entities and DTOs.

## Existing Pattern

```csharp
// modules/QLHD/QLHD.Domain/Interfaces/INgayHopDong.cs
public interface INgayHopDong {
    public DateOnly NgayKy { get; set; }
}
```

Used by: `HopDong` entity, `HopDongThuTienDto`, `HopDongXuatHoaDonDto`, `HopDongCoChiPhiDto`

## Property Groups

| Interface | Properties | Applies To |
|-----------|------------|------------|
| `IKeHoach` | `ThoiGianKeHoach`, `PhanTramKeHoach`, `GiaTriKeHoach`, `GhiChuKeHoach` | ThuTien, XuatHoaDon, ChiPhi entities/DTOs |
| `IThucTe` | `ThoiGianThucTe`, `GiaTriThucTe`, `GhiChuThucTe` | ThuTien, XuatHoaDon, ChiPhi entities/DTOs |
| `IHoaDon` | `SoHoaDon`, `KyHieuHoaDon`, `NgayHoaDon` | ThuTien, XuatHoaDon only |
| `IHopDongBase` | `Id`, `SoHopDong`, `Ten`, `DuAnId`, `KhachHangId`, `GiaTri`, `TrangThaiId` | HopDong*Dto list DTOs |

## Implementation

### Phase 1: Create Interfaces (Domain) - COMPLETE

**Status:** Complete
**Files:**
```
modules/QLHD/QLHD.Domain/Interfaces/
├── IKeHoach.cs
├── IThucTe.cs
├── IHoaDon.cs
└── IHopDongBase.cs
```

```csharp
// IKeHoach.cs
namespace QLHD.Domain.Interfaces;

public interface IKeHoach {
    DateOnly ThoiGianKeHoach { get; set; }
    decimal PhanTramKeHoach { get; set; }
    decimal GiaTriKeHoach { get; set; }
    string? GhiChuKeHoach { get; set; }
}

// IThucTe.cs
namespace QLHD.Domain.Interfaces;

public interface IThucTe {
    DateOnly? ThoiGianThucTe { get; set; }
    decimal? GiaTriThucTe { get; set; }
    string? GhiChuThucTe { get; set; }
}

// IHoaDon.cs
namespace QLHD.Domain.Interfaces;

public interface IHoaDon {
    string? SoHoaDon { get; set; }
    string? KyHieuHoaDon { get; set; }
    DateOnly? NgayHoaDon { get; set; }
}

// IHopDongBase.cs
namespace QLHD.Domain.Interfaces;

public interface IHopDongBase : IHasKey<Guid> {
    string? SoHopDong { get; set; }
    string? Ten { get; set; }
    Guid? DuAnId { get; set; }
    Guid KhachHangId { get; set; }
    decimal GiaTri { get; set; }
    int? TrangThaiId { get; set; }
}
```

### Phase 2: Apply to Entities - COMPLETE

**Status:** Complete
| Entity | Interfaces |
|--------|------------|
| `HopDong_ThuTien` | `IKeHoach`, `IThucTe`, `IHoaDon` |
| `DuAn_ThuTien` | `IKeHoach`, `IThucTe`, `IHoaDon` |
| `HopDong_XuatHoaDon` | `IKeHoach`, `IThucTe`, `IHoaDon` |
| `DuAn_XuatHoaDon` | `IKeHoach`, `IThucTe`, `IHoaDon` |
| `HopDong_ChiPhi` | `IKeHoach`, `IThucTe` |

### Phase 3: Apply to DTOs - COMPLETE

**Status:** Complete
| DTO | Interfaces |
|-----|------------|
| `ThuTienDto` | `IKeHoach`, `IThucTe`, `IHoaDon` |
| `XuatHoaDonDto` | `IKeHoach`, `IThucTe`, `IHoaDon` |
| `ChiPhiDto` | `IKeHoach`, `IThucTe` |
| `HopDongThuTienDto` | `IHopDongBase`, `INgayHopDong` |
| `HopDongXuatHoaDonDto` | `IHopDongBase`, `INgayHopDong` |
| `HopDongCoChiPhiDto` | `IHopDongBase`, `INgayHopDong` |

## Completion Status

**Overall Status:** COMPLETE
**Completion Date:** 2026-04-07
**Build Verification:** PASSED

## Files

| Action | Path |
|--------|------|
| CREATE | `modules/QLHD/QLHD.Domain/Interfaces/IKeHoach.cs` |
| CREATE | `modules/QLHD/QLHD.Domain/Interfaces/IThucTe.cs` |
| CREATE | `modules/QLHD/QLHD.Domain/Interfaces/IHoaDon.cs` |
| CREATE | `modules/QLHD/QLHD.Domain/Interfaces/IHopDongBase.cs` |
| MODIFY | `modules/QLHD/QLHD.Domain/Entities/HopDong_ThuTien.cs` |
| MODIFY | `modules/QLHD/QLHD.Domain/Entities/DuAn_ThuTien.cs` |
| MODIFY | `modules/QLHD/QLHD.Domain/Entities/HopDong_XuatHoaDon.cs` |
| MODIFY | `modules/QLHD/QLHD.Domain/Entities/DuAn_XuatHoaDon.cs` |
| MODIFY | `modules/QLHD/QLHD.Domain/Entities/HopDong_ChiPhi.cs` |
| MODIFY | `modules/QLHD/QLHD.Application/ThuTiens/DTOs/ThuTienDto.cs` |
| MODIFY | `modules/QLHD/QLHD.Application/XuatHoaDons/DTOs/XuatHoaDonDto.cs` |
| MODIFY | `modules/QLHD/QLHD.Application/ChiPhis/DTOs/ChiPhiDto.cs` |
| MODIFY | `modules/QLHD/QLHD.Application/ThuTiens/DTOs/HopDongThuTienDto.cs` |
| MODIFY | `modules/QLHD/QLHD.Application/XuatHoaDons/DTOs/HopDongXuatHoaDonDto.cs` |
| MODIFY | `modules/QLHD/QLHD.Application/ChiPhis/DTOs/HopDongChiPhiDto.cs` |

## Design Decisions

1. **IHopDongBase:** Core identifiers only (no display fields)
2. **Simple DTOs:** No interfaces - subcomponents
3. **Search models:** No interfaces - Domain only
4. **Extension methods:** Skip (YAGNI - add later if needed)

## Verification

```bash
dotnet build modules/QLHD/QLHD.sln
```