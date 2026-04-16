namespace QLDA.WebApi.Models.DanhMucNhaThaus;

public static class DanhMucNhaThauMappingConfigurations {
    public static DanhMucNhaThauModel ToModel(this DanhMucNhaThau entity)
        => new() {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,
            Used = entity.Used,
            DiaChi = entity.DiaChi,
            MaSoThue = entity.MaSoThue,
            Email = entity.Email,
            SoDienThoai = entity.SoDienThoai,
            NguoiDaiDien = entity.NguoiDaiDien,
        };

    public static DanhMucNhaThau ToEntity(this DanhMucNhaThauModel model)
        => new() {
            Id = model.GetId(),
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,
            Used = model.Used,
            DiaChi = model.DiaChi,
            MaSoThue = model.MaSoThue,
            Email = model.Email,
            SoDienThoai = model.SoDienThoai,
            NguoiDaiDien = model.NguoiDaiDien,
        };
}