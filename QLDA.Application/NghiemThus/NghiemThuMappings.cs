using QLDA.Application.NghiemThus.DTOs;
using QLDA.Application.TepDinhKems.DTOs;

namespace QLDA.Application.NghiemThus;

public static class NghiemThuMappings {
    public static NghiemThu ToEntity(this NghiemThuInsertDto dto) {
        var id = BuildingBlocks.CrossCutting.ExtensionMethods.GuidExtensions.GetSequentialGuidId();
        return new NghiemThu {
            Id = id,
            DuAnId = dto.DuAnId,
            BuocId = dto.BuocId,
            HopDongId = dto.HopDongId,
            SoBienBan = dto.SoBienBan,
            Dot = dto.Dot,
            Ngay = dto.Ngay,
            NoiDung = dto.NoiDung,
            GiaTri = dto.GiaTri,
            NghiemThuPhuLucHopDongs = [..dto.PhuLucHopDongIds?.Select(phuLucHopDongId => new NghiemThuPhuLucHopDong{
                NghiemThuId = id,
                PhuLucHopDongId = phuLucHopDongId
            })?? []]
        };
    }

    public static NghiemThu ToEntity(this NghiemThuUpdateDto dto) {
        return new NghiemThu {
            Id = dto.Id,
            HopDongId = dto.HopDongId,
            SoBienBan = dto.SoBienBan,
            Dot = dto.Dot,
            Ngay = dto.Ngay,
            NoiDung = dto.NoiDung,
            GiaTri = dto.GiaTri,
            NghiemThuPhuLucHopDongs = [..dto.PhuLucHopDongIds?.Select(phuLucHopDongId => new NghiemThuPhuLucHopDong{
                NghiemThuId = dto.Id,
                PhuLucHopDongId = phuLucHopDongId
            })?? []]
        };
    }

    public static NghiemThuDto ToDto(this NghiemThu entity, IEnumerable<TepDinhKem>? files = null) {
        return new NghiemThuDto {
            Id = entity.Id,
            DuAnId = entity.DuAnId,
            BuocId = entity.BuocId,
            HopDongId = entity.HopDongId,
            ThanhToanId = entity.ThanhToan?.Id,
            SoBienBan = entity.SoBienBan,
            Dot = entity.Dot,
            Ngay = entity.Ngay,
            NoiDung = entity.NoiDung,
            GiaTri = entity.GiaTri,
            PhuLucHopDongIds = entity.NghiemThuPhuLucHopDongs?.Select(x => x.PhuLucHopDongId).ToList(),
            DanhSachTepDinhKem = [.. files?.ToDtos() ?? []]
        };
    }
    public static void Update(this NghiemThu entity, NghiemThuUpdateDto dto) {
        entity.HopDongId = dto.HopDongId;
        entity.SoBienBan = dto.SoBienBan;
        entity.Dot = dto.Dot;
        entity.Ngay = dto.Ngay;
        entity.NoiDung = dto.NoiDung;
        entity.GiaTri = dto.GiaTri;
        entity.NghiemThuPhuLucHopDongs = [..dto.PhuLucHopDongIds?.Select(phuLucHopDongId => new NghiemThuPhuLucHopDong{
            NghiemThuId = dto.Id,
            PhuLucHopDongId = phuLucHopDongId
        })?? []];
    }
}