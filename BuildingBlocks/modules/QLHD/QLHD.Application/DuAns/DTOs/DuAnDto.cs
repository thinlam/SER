using QLHD.Application.DuAn_ThuTiens.DTOs;
using QLHD.Application.DuAn_XuatHoaDons.DTOs;

namespace QLHD.Application.DuAns.DTOs;

public class DuAnDto : IHasKey<Guid> {
    public Guid Id { get; set; }
    public string? Ten { get; set; }
    public Guid KhachHangId { get; set; }
    public DateOnly NgayLap { get; set; }
    public decimal GiaTriDuKien { get; set; }
    public DateOnly? ThoiGianDuKien { get; set; }
    public long PhongBanPhuTrachChinhId { get; set; }
    public int NguoiPhuTrachChinhId { get; set; }
    public int? NguoiTheoDoiId { get; set; }
    public int? GiamDocId { get; set; }
    public decimal GiaVon { get; set; }
    public decimal ThanhTien { get; set; }
    public int TrangThaiId { get; set; }
    public bool HasHopDong { get; set; }
    public string? GhiChu { get; set; }

    // Navigation names for display
    public string TenKhachHang { get; set; } = string.Empty;
    public string TenNguoiPhuTrach { get; set; } = string.Empty;
    public string? TenNguoiTheoDoi { get; set; }
    public string? TenGiamDoc { get; set; }
    public string? TenTrangThai { get; set; }
    public string? TenPhongBanPhuTrachChinh { get; set; }

    /// <summary>
    /// Danh sách ID phòng ban phối hợp
    /// </summary>
    public List<long>? PhongBanPhoiHopIds { get; set; }

    /// <summary>
    /// Danh sách phòng ban phối hợp với tên
    /// </summary>
    public List<DuAnPhongBanPhoiHopDto>? PhongBanPhoiHops { get; set; }

    /// <summary>
    /// Danh sách kế hoạch thu tiền (gộp kế hoạch + thực tế)
    /// </summary>
    public List<DuAn_ThuTienDto>? KeHoachThuTiens { get; set; }

    /// <summary>
    /// Danh sách kế hoạch xuất hóa đơn (gộp kế hoạch + thực tế)
    /// </summary>
    public List<DuAn_XuatHoaDonDto>? KeHoachXuatHoaDons { get; set; }

}