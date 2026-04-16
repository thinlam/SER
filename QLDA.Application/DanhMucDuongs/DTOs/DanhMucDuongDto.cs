namespace QLDA.Application.DanhMucDuongs.DTOs;

public class DanhMucDuongDto {
    public long Id { get; set; }
    public long PhuongXaId { get; set; }
    public long QuanHuyenId { get; set; }
    /// <summary>
    /// Tên
    /// </summary>
    public string? Ten { get; set; }
}