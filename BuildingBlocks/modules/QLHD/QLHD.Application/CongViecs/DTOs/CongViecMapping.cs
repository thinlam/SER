using BuildingBlocks.Domain.ValueTypes;

namespace QLHD.Application.CongViecs.DTOs;

public static class CongViecMapping
{
    public static CongViecDto ToDto(this CongViec entity) => new()
    {
        Id = entity.Id,
        DuAnId = entity.DuAnId,
        ThoiGian = MonthYear.FromDateOnly(entity.ThoiGian),
        UserPortalId = entity.UserPortalId,
        NguoiThucHien = entity.NguoiThucHien,
        DonViId = entity.DonViId,
        TenDonVi = entity.TenDonVi,
        PhongBanId = entity.PhongBanId,
        TenPhongBan = entity.TenPhongBan ?? string.Empty,
        KeHoachCongViec = entity.KeHoachCongViec,
        NgayHoanThanh = entity.NgayHoanThanh,
        ThucTe = entity.ThucTe,
        TrangThaiId = entity.TrangThaiId,
        TenTrangThai = entity.TenTrangThai,
        TenDuAn = entity.DuAn?.Ten
    };

    public static CongViec ToEntity(this CongViecInsertModel model, string tenTrangThai, string tenDonVi, string? tenPhongBan) => new()
    {
        DuAnId = model.DuAnId,
        ThoiGian = model.ThoiGian.ToDateOnly(),
        UserPortalId = model.UserPortalId,
        DonViId = model.DonViId,
        TenDonVi = tenDonVi,
        PhongBanId = model.PhongBanId,
        TenPhongBan = tenPhongBan,
        KeHoachCongViec = model.KeHoachCongViec,
        NgayHoanThanh = model.NgayHoanThanh,
        ThucTe = model.ThucTe,
        TrangThaiId = model.TrangThaiId,
        TenTrangThai = tenTrangThai
    };

    public static void UpdateFrom(this CongViec entity, CongViecUpdateModel model, string tenTrangThai, string tenDonVi, string? tenPhongBan)
    {
        entity.ThoiGian = model.ThoiGian.ToDateOnly();
        entity.UserPortalId = model.UserPortalId;
        entity.DonViId = model.DonViId;
        entity.TenDonVi = tenDonVi;
        entity.PhongBanId = model.PhongBanId;
        entity.TenPhongBan = tenPhongBan;
        entity.KeHoachCongViec = model.KeHoachCongViec;
        entity.NgayHoanThanh = model.NgayHoanThanh;
        entity.ThucTe = model.ThucTe;
        entity.TrangThaiId = model.TrangThaiId;
        entity.TenTrangThai = tenTrangThai;
    }
}