using QLDA.Application.DanhMucBuocs.DTOs;
using QLDA.Application.DuAnBuocs.DTOs;

namespace QLDA.Application.DuAnBuocs;

public static class DuAnBuocMapping {
    public static DuAnBuocDto ToDto(this DuAnBuoc entity)
            => new() {
                Id = entity.Id,
                TenBuoc = entity.TenBuoc ?? entity.Buoc?.Ten,
                GiaiDoanId = entity.Buoc?.GiaiDoanId,
                BuocId = entity.BuocId,
                DuAnId = entity.DuAnId,
                ParentId = entity.Buoc?.ParentId,
                Stt = entity.Buoc?.Stt ?? 0,
                Used = entity.Used,
                Path = entity.Buoc?.Path ?? $"/{entity.BuocId}/",
                NgayDuKienBatDau = entity.NgayDuKienBatDau,
                NgayDuKienKetThuc = entity.NgayDuKienKetThuc,
                GiaiDoan = entity.Buoc?.GiaiDoan?.ToPhaseDto(),
                DanhSachManHinh = [.. new List<int>()
                    .Union(entity.DuAnBuocManHinhs?.Select(e => e.ManHinhId).ToList() ??
                           entity.Buoc?.BuocManHinhs?.Select(e => e.ManHinhId).ToList() ?? [])]
            };

    public static DuAnBuocDuAnUpdateStateDto ToUpdateStateDto(this DuAnBuoc entity)
        => new() {
            Id = entity.Id,
            TrangThaiId = entity.TrangThaiId,
            NgayDuKienBatDau = entity.NgayDuKienBatDau,
            NgayDuKienKetThuc = entity.NgayDuKienKetThuc,
            NgayThucTeBatDau = entity.NgayThucTeBatDau,
            NgayThucTeKetThuc = entity.NgayThucTeKetThuc,
            GhiChu = entity.GhiChu,
            TrachNhiemThucHien = entity.TrachNhiemThucHien,
            IsKetThuc = entity.IsKetThuc,
        };

    public static void UpdateState(this DuAnBuoc entity, DuAnBuocDuAnUpdateStateDto dto) {
        entity.TrangThaiId = dto.TrangThaiId;
        entity.NgayDuKienBatDau = dto.NgayDuKienBatDau;
        entity.NgayDuKienKetThuc = dto.NgayDuKienKetThuc;
        entity.NgayThucTeBatDau = dto.NgayThucTeBatDau;
        entity.NgayThucTeKetThuc = dto.NgayThucTeKetThuc;
        entity.GhiChu = dto.GhiChu;
        entity.TrachNhiemThucHien = dto.TrachNhiemThucHien;
        entity.IsKetThuc = dto.IsKetThuc;
    }

    public static void Update(this DuAnBuoc entity, DuAnBuocUpdateDto dto) {
        entity.TenBuoc = dto.TenBuoc;
        entity.Used = dto.Used;
        entity.NgayDuKienBatDau = dto.NgayDuKienBatDau;
        entity.NgayDuKienKetThuc = dto.NgayDuKienKetThuc;
        entity.DuAnBuocManHinhs = [.. dto.DanhSachManHinh?.Select((manHinhId, index) => new DuAnBuocManHinh() {
            BuocId = entity.Id,
            ManHinhId = manHinhId,
            Stt = index
        }) ?? []];
    }
}