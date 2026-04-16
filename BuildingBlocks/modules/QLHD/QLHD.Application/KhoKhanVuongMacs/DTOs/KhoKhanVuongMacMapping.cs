namespace QLHD.Application.KhoKhanVuongMacs.DTOs;

public static class KhoKhanVuongMacMapping
{
    public static KhoKhanVuongMac ToEntity(this KhoKhanVuongMacInsertModel model, int defaultTrangThaiId)
    {
        return new KhoKhanVuongMac
        {
            HopDongId = model.HopDongId,
            TienDoId = model.TienDoId,
            NoiDung = model.NoiDung,
            MucDo = model.MucDo,
            NgayPhatHien = model.NgayPhatHien,
            NgayGiaiQuyet = model.NgayGiaiQuyet,
            BienPhapKhacPhuc = model.BienPhapKhacPhuc,
            TrangThaiId = model.TrangThaiId ?? defaultTrangThaiId
        };
    }

    public static void UpdateFrom(this KhoKhanVuongMac entity, KhoKhanVuongMacUpdateModel model)
    {
        entity.NoiDung = model.NoiDung;
        entity.MucDo = model.MucDo;
        entity.NgayPhatHien = model.NgayPhatHien;
        entity.NgayGiaiQuyet = model.NgayGiaiQuyet;
        entity.BienPhapKhacPhuc = model.BienPhapKhacPhuc;
        entity.TienDoId = model.TienDoId;
        if (model.TrangThaiId.HasValue)
        {
            entity.TrangThaiId = model.TrangThaiId.Value;
        }
    }

    public static KhoKhanVuongMacDto ToDto(this KhoKhanVuongMac entity)
    {
        return new KhoKhanVuongMacDto
        {
            Id = entity.Id,
            HopDongId = entity.HopDongId,
            TienDoId = entity.TienDoId,
            TenTienDo = entity.TienDo?.Ten,
            NoiDung = entity.NoiDung,
            MucDo = entity.MucDo,
            NgayPhatHien = entity.NgayPhatHien,
            NgayGiaiQuyet = entity.NgayGiaiQuyet,
            BienPhapKhacPhuc = entity.BienPhapKhacPhuc,
            TrangThaiId = entity.TrangThaiId,
            TenTrangThai = entity.TrangThai?.Ten
        };
    }
}