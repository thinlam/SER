using System.ComponentModel.DataAnnotations;
using QLHD.Application.DuAn_ThuTiens.DTOs;
using QLHD.Application.DuAn_XuatHoaDons.DTOs;

namespace QLHD.Application.DuAns.DTOs;

public class DuAnUpdateModel {
    public string? Ten { get; set; }

    [Required]
    public Guid KhachHangId { get; set; }

    [Required]
    public DateOnly NgayLap { get; set; }

    [Required]
    public decimal GiaTriDuKien { get; set; }

    public DateOnly? ThoiGianDuKien { get; set; }

    [Required]
    public long PhongBanPhuTrachChinhId { get; set; }

    [Required]
    public int NguoiPhuTrachChinhId { get; set; }

    public int? NguoiTheoDoiId { get; set; }

    public int? GiamDocId { get; set; }

    [Required]
    public decimal GiaVon { get; set; }

    [Required]
    public decimal ThanhTien { get; set; }

    [Required]
    public int TrangThaiId { get; set; }

    /// <summary>
    /// Danh sách thu tiền (gộp kế hoạch + thực tế)
    /// </summary>
    public List<DuAn_ThuTienInsertOrUpdateModel>? KeHoachThuTiens { get; set; }

    /// <summary>
    /// Danh sách xuất hóa đơn (gộp kế hoạch + thực tế)
    /// </summary>
    public List<DuAn_XuatHoaDonInsertOrUpdateModel>? KeHoachXuatHoaDons { get; set; }

    /// <summary>
    /// Danh sách ID phòng ban phối hợp (FK to DM_DONVI)
    /// </summary>
    public List<long>? PhongBanPhoiHopIds { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    public string? GhiChu { get; set; }
}