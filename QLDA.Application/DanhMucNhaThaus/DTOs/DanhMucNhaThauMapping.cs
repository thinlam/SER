namespace QLDA.Application.DanhMucNhaThaus.DTOs {
    public static class DanhMucNhaThauMapping {

        public static DanhMucNhaThau ToEntity(this DanhMucNhaThauInsertModel model)
            => new() {
                Id = SequentialGuid.SequentialGuidGenerator.Instance.NewGuid(),
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
}