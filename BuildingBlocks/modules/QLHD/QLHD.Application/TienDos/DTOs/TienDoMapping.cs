namespace QLHD.Application.TienDos.DTOs;

public static class TienDoMapping
{
    public static TienDo ToEntity(this TienDoInsertModel model, int defaultTrangThaiId)
    {
        return new TienDo
        {
            HopDongId = model.HopDongId,
            Ten = model.Ten,
            PhanTramKeHoach = model.PhanTramKeHoach,
            NgayBatDauKeHoach = model.NgayBatDauKeHoach,
            NgayKetThucKeHoach = model.NgayKetThucKeHoach,
            MoTa = model.MoTa,
            TrangThaiId = model.TrangThaiId ?? defaultTrangThaiId,
            PhanTramThucTe = 0
        };
    }

    public static void UpdateFrom(this TienDo entity, TienDoUpdateModel model)
    {
        entity.Ten = model.Ten;
        entity.PhanTramKeHoach = model.PhanTramKeHoach;
        entity.NgayBatDauKeHoach = model.NgayBatDauKeHoach;
        entity.NgayKetThucKeHoach = model.NgayKetThucKeHoach;
        entity.MoTa = model.MoTa;
        if (model.TrangThaiId.HasValue)
        {
            entity.TrangThaiId = model.TrangThaiId.Value;
        }
    }

    public static TienDoDto ToDto(this TienDo entity)
    {
        return new TienDoDto
        {
            Id = entity.Id,
            HopDongId = entity.HopDongId,
            Ten = entity.Ten,
            PhanTramKeHoach = entity.PhanTramKeHoach,
            NgayBatDauKeHoach = entity.NgayBatDauKeHoach,
            NgayKetThucKeHoach = entity.NgayKetThucKeHoach,
            MoTa = entity.MoTa,
            TrangThaiId = entity.TrangThaiId,
            TenTrangThai = entity.TrangThai?.Ten,
            PhanTramThucTe = entity.PhanTramThucTe,
            NgayCapNhatGanNhat = entity.NgayCapNhatGanNhat
        };
    }
}