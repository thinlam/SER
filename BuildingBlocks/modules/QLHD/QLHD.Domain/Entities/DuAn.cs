using System.ComponentModel.DataAnnotations;
using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Domain.Entities;

/// <summary>
/// Dự án — đại diện cho mặt "Kế hoạch" (Plan) của thực thể DuAn-HopDong.
/// <para>
/// DuAn và HopDong thực chất là 1 thực thể kinh doanh:
///   - DuAn (Dự án) có trước → đại diện cho kế hoạch (giá trị dự kiến, thời gian dự kiến)
///   - HopDong (Hợp đồng) có sau → đại diện cho thực tế (giá trị thực tế, ngày ký, ...).
/// Mối quan hệ: 1 DuAn có tối đa 1 HopDong (0..1 → 0..1).
/// HopDong có thể tạo độc lập không cần DuAn.
/// </para>
/// <para>
/// Prefix routing: Nếu HopDong có DuAnId → ThuTien/XuatHoaDon lưu vào DuAn_ThuTien/DuAn_XuatHoaDon.
/// Ngược lại → lưu vào HopDong_ThuTien/HopDong_XuatHoaDon.
/// </para>
/// </summary>
public class DuAn : Entity<Guid>, IAggregateRoot, IAuditable {

    /// <summary>
    /// Tên dự án/ thầu/ hm(hạng mục)
    /// </summary>
    public string? Ten { get; set; }

    /// <summary>
    /// ID khách hàng (FK to KhachHang)
    /// </summary>
    [Required] public Guid KhachHangId { get; set; }

    /// <summary>
    /// Ngày lập dự án <br/>
    /// best practice: dùng DateOnly để chỉ lưu ngày, không lưu thời gian, tránh lỗi khi so sánh ngày tháng với thời gian khác nhau
    /// </summary>
    public DateOnly NgayLap { get; set; }

    /// <summary>
    /// Giá trị dự kiến <br/>
    /// best practice: kiểu decimal để tránh lỗi làm tròn khi tính toán với số tiền lớn
    /// </summary>
    public decimal GiaTriDuKien { get; set; }

    /// <summary>
    /// Thời gian dự kiến hoàn thành <br/>
    /// best practice: dùng DateOnly để chỉ lưu ngày, không lưu thời gian, tránh lỗi khi so sánh ngày tháng với thời gian khác nhau
    /// </summary>
    public DateOnly? ThoiGianDuKien { get; set; }

    /// <summary>
    /// ID phòng ban phụ trách chính (FK to DM_DONVI) <br/>
    /// </summary>
    public long PhongBanPhuTrachChinhId { get; set; }
    /// <summary>
    /// ID người phụ trách chính/ người thực hiện (FK to DanhMucNguoiPhuTrach) <br/>
    /// </summary>
    [Required] public int NguoiPhuTrachChinhId { get; set; }

    /// <summary>
    /// ID người theo dõi/ giám sát (FK to DanhMucNguoiTheoDoi)
    /// </summary>
    public int? NguoiTheoDoiId { get; set; }

    /// <summary>
    /// ID người quản lý/ giám đốc (FK to DanhMucGiamDoc)
    /// </summary>
    public int? GiamDocId { get; set; }
    /// <summary>
    /// Giá vốn %<br/>
    /// best practice: kiểu decimal để tránh lỗi làm tròn khi tính toán với số tiền lớn, nếu muốn lưu phần trăm vốn thì có thể lưu giá trị từ 0-100, khi hiển thị thì chia cho 100 để ra phần trăm thực tế
    /// </summary>
    public decimal GiaVon { get; set; }
    /// <summary>
    /// Thành tiền dự kiến = Giá trị dự kiến * Giá vốn % <br/>
    /// best practice: kiểu decimal để tránh lỗi làm tròn khi tính toán với số tiền
    /// </summary>
    public decimal ThanhTien { get; set; }
    /// <summary>
    /// ID trạng thái  (FK to DanhMucTrangThai) - Loại trang thái = LoaiTrangThaiConstants.KeHoach
    /// </summary>
    [Required] public int TrangThaiId { get; set; }

    /// <summary>
    /// Đã có hợp đồng - true khi HopDong được tạo với DuAnId này, false khi HopDong bị xóa
    /// </summary>
    public bool HasHopDong { get; set; } = false;

    /// <summary>
    /// Ghi chú
    /// </summary>
    public string? GhiChu { get; set; }

    #region Navigation Properties
    public HopDong? HopDong { get; set; }
    public KhachHang? KhachHang { get; set; }
    public DanhMucNguoiPhuTrach? NguoiPhuTrach { get; set; }
    public DanhMucNguoiTheoDoi? NguoiTheoDoi { get; set; }
    public DanhMucGiamDoc? GiamDoc { get; set; }
    public DanhMucTrangThai? TrangThai { get; set; }
    public ICollection<DuAnPhongBanPhoiHop>? PhongBanPhoiHops { get; set; }
    // === Merged Plan+Actual collections ===
    public ICollection<DuAn_ThuTien>? DuAn_ThuTiens { get; set; }
    public ICollection<DuAn_XuatHoaDon>? DuAn_XuatHoaDons { get; set; }
    public ICollection<CongViec>? CongViecs { get; set; }

    #endregion
}