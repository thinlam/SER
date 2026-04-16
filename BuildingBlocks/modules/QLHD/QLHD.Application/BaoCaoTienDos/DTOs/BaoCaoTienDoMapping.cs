namespace QLHD.Application.BaoCaoTienDos.DTOs;

public static class BaoCaoTienDoMapping
{
    public static BaoCaoTienDo ToEntity(this BaoCaoTienDoInsertModel model, string tenNguoiBaoCao, string? tenNguoiDuyet = null)
    {
        return new BaoCaoTienDo
        {
            TienDoId = model.TienDoId,
            NgayBaoCao = model.NgayBaoCao,
            NguoiBaoCaoId = model.NguoiBaoCaoId,
            TenNguoiBaoCao = tenNguoiBaoCao,
            PhanTramThucTe = model.PhanTramThucTe,
            NoiDungDaLam = model.NoiDungDaLam,
            KeHoachTiepTheo = model.KeHoachTiepTheo,
            GhiChu = model.GhiChu,
            CanDuyet = model.CanDuyet,
            DaDuyet = !model.CanDuyet, // Auto-approve if no approval required
            NguoiDuyetId = model.CanDuyet ? model.NguoiDuyetId : null,
            TenNguoiDuyet = model.CanDuyet ? tenNguoiDuyet : null
        };
    }

    public static void UpdateFrom(this BaoCaoTienDo entity, BaoCaoTienDoUpdateModel model)
    {
        entity.NgayBaoCao = model.NgayBaoCao;
        entity.PhanTramThucTe = model.PhanTramThucTe;
        entity.NoiDungDaLam = model.NoiDungDaLam;
        entity.KeHoachTiepTheo = model.KeHoachTiepTheo;
        entity.GhiChu = model.GhiChu;
    }

    public static BaoCaoTienDoDto ToDto(this BaoCaoTienDo entity)
    {
        return new BaoCaoTienDoDto
        {
            Id = entity.Id,
            TienDoId = entity.TienDoId,
            TenTienDo = entity.TienDo?.Ten,
            NgayBaoCao = entity.NgayBaoCao,
            NguoiBaoCaoId = entity.NguoiBaoCaoId,
            TenNguoiBaoCao = entity.TenNguoiBaoCao,
            PhanTramThucTe = entity.PhanTramThucTe,
            NoiDungDaLam = entity.NoiDungDaLam,
            KeHoachTiepTheo = entity.KeHoachTiepTheo,
            GhiChu = entity.GhiChu,
            CanDuyet = entity.CanDuyet,
            DaDuyet = entity.DaDuyet,
            NguoiDuyetId = entity.NguoiDuyetId,
            TenNguoiDuyet = entity.TenNguoiDuyet,
            NgayDuyet = entity.NgayDuyet
        };
    }
}