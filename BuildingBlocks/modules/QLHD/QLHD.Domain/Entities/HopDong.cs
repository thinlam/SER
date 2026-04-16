using System.ComponentModel.DataAnnotations;
using QLHD.Domain.Entities.DanhMuc;
using QLHD.Domain.Interfaces;

namespace QLHD.Domain.Entities;

/// <summary>
/// Hợp đồng — đại diện cho mặt "Thực tế" (Actual) của thực thể DuAn-HopDong.
/// <para>
/// DuAn và HopDong thực chất là 1 thực thể kinh doanh:
///   - DuAn (Dự án) có trước → đại diện cho kế hoạch
///   - HopDong (Hợp đồng) có sau → đại diện cho thực tế (giá trị thực tế, ngày ký, ...).
/// Mối quan hệ: 1 DuAn có tối đa 1 HopDong (0..1 → 0..1).
/// HopDong có thể tạo độc lập không cần DuAn (DuAnId = null).
/// </para>
/// <para>
/// Prefix routing cho ThuTien/XuatHoaDon:
///   - Nếu DuAnId có giá trị → dữ liệu lưu vào DuAn_ThuTien/DuAn_XuatHoaDon (theo DuAn)
///   - Nếu DuAnId null → dữ liệu lưu vào HopDong_ThuTien/HopDong_XuatHoaDon (độc lập)
/// </para>
/// </summary>
public class HopDong : Entity<Guid>, IAggregateRoot,
    INgayHopDong {

    /// <summary>
    /// ID dự án (FK to DuAn) - Optional, nullable for standalone contracts
    /// </summary>
    public Guid? DuAnId { get; set; }
    /// <summary>
    /// Tên hợp đồng
    /// </summary>
    [Required] public string Ten { get; set; } = string.Empty;
    /// <summary>
    /// Số hợp đồng
    /// </summary>
    [Required] public string SoHopDong { get; set; } = string.Empty;

    [Required] public DateOnly NgayKy { get; set; }
    [Required] public int SoNgay { get; set; }
    /// <summary>
    /// Ngày nghiệm thu <br/>
    /// NgayNghiemThu có thể khác NgayKy + SoNgay <br/>
    /// vì có thể có thời gian gia hạn, hoặc nghiệm thu sớm hơn dự kiến nên NgayKy và SoNgay không hoàn toàn quyết định ngày nghiệm thu <br/>
    /// best practice: dùng DateOnly để chỉ lưu ngày, không lưu thời gian, tránh lỗi khi so sánh ngày tháng với thời gian khác nhau
    /// </summary>
    [Required] public DateOnly NgayNghiemThu { get; set; }
    [Required] public Guid KhachHangId { get; set; }
    /// <summary>
    /// ID người phụ trách chính (FK to DanhMucNguoiPhuTrach) <br/>
    /// </summary>
    public int NguoiPhuTrachChinhId { get; set; }
    /// <summary>
    /// ID người theo dõi/ giám sát (FK to DanhMucNguoiTheoDoi)
    /// </summary>
    public int? NguoiTheoDoiId { get; set; }
    /// <summary>
    /// ID giám đốc (FK to DanhMucGiamDoc)
    /// </summary>
    public int? GiamDocId { get; set; }
    /// <summary>
    /// ID loại hợp đồng (FK to DanhMucLoaiHopDong)
    /// </summary>
    [Required] public int LoaiHopDongId { get; set; }
    /// <summary>
    /// Giá trị hợp đồng <br/>
    /// </summary>
    public decimal GiaTri { get; set; }
    /// <summary>
    /// Tiền thuế <br/>
    /// </summary>
    public decimal? TienThue { get; set; }
    /// <summary>
    /// Giá trị sau thuế <br/>
    /// </summary>
    public decimal? GiaTriSauThue { get; set; }

    /// <summary>
    /// ID phòng ban phụ trách chính (FK to DM_DONVI) <br/>
    /// </summary>
    public long PhongBanPhuTrachChinhId { get; set; }
    /// <summary>
    /// Bảo lãnh THHĐ
    /// </summary>
    public decimal GiaTriBaoLanh { get; set; }
    /// <summary>
    /// Ngày bảo lãnh từ (cả 2 phải cùng được thêm nếu 1 trong 2 được thêm)
    /// </summary>
    public DateOnly? NgayBaoLanhTu { get; set; }
    /// <summary>
    /// Ngày bảo lãnh đến (cả 2 phải cùng được thêm nếu 1 trong 2 được thêm)
    /// </summary>
    public DateOnly? NgayBaoLanhDen { get; set; }
    /// <summary>
    /// Thời hạn bảo hành (tháng)
    /// </summary>
    [Required] public byte ThoiHanBaoHanh { get; set; }
    /// <summary>
    /// Ngày bảo hành từ (cả 2 phải cùng được thêm nếu 1 trong 2 được thêm)
    /// </summary>
    public DateOnly? NgayBaoHanhTu { get; set; }
    /// <summary>
    /// Ngày bảo hành đến (cả 2 phải cùng được thêm nếu 1 trong 2 được thêm)
    /// </summary>
    public DateOnly? NgayBaoHanhDen { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    public string? GhiChu { get; set; }

    /// <summary>
    /// Tiến độ
    /// </summary>
    public string? TienDo { get; set; }

    /// <summary>
    /// ID trạng thái hợp đồng (FK to DanhMucTrangThaiHopDong)
    /// </summary>
    [Required] public int TrangThaiId { get; set; }

    #region Navigation Properties

    public DuAn? DuAn { get; set; }
    public KhachHang? KhachHang { get; set; }
    public DanhMucLoaiHopDong? LoaiHopDong { get; set; }
    public DanhMucTrangThai? TrangThai { get; set; }
    public DanhMucNguoiPhuTrach? NguoiPhuTrach { get; set; }
    public DanhMucNguoiTheoDoi? NguoiTheoDoi { get; set; }
    public DanhMucGiamDoc? GiamDoc { get; set; }
    public ICollection<HopDongPhongBanPhoiHop>? PhongBanPhoiHops { get; set; }
    // === Merged Plan+Actual collections (standalone contracts) ===
    public ICollection<HopDong_ThuTien>? HopDong_ThuTiens { get; set; }
    public ICollection<HopDong_XuatHoaDon>? HopDong_XuatHoaDons { get; set; }
    public ICollection<HopDong_ChiPhi>? HopDong_ChiPhis { get; set; }

    // === Legacy collections (to be removed after migration) ===
    public ICollection<TienDo>? TienDos { get; set; }
    public ICollection<KhoKhanVuongMac>? KhoKhanVuongMacs { get; set; }
    public ICollection<PhuLucHopDong>? PhuLucHopDongs { get; set; }

    #endregion
}