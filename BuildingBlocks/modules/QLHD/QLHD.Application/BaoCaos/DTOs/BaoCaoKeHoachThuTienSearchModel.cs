namespace QLHD.Application.BaoCaos.DTOs;


public record BaoCaoKeHoachThuTienSearchModel {
    public MonthYear TuThang { get; set; }
    public MonthYear DenThang { get; set; }
    public long? PhongBanPhuTrachChinhId { get; set; }
    public long? NguoiPhuTrachChinhId { get; set; }
}