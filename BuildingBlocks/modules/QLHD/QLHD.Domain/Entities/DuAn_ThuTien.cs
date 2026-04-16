using QLHD.Domain.Entities.DanhMuc;
using QLHD.Domain.Interfaces;

namespace QLHD.Domain.Entities;

/// <summary>
/// Thu tiền theo dự án - Gộp kế hoạch và thực tế trong một bản ghi
/// </summary>
public class DuAn_ThuTien : Entity<Guid>, IAggregateRoot,
    IKeHoach, IThucTe, IHoaDon
{
    // === OWNER (required) ===
    /// <summary>
    /// ID dự án (FK to DuAn) - Required
    /// </summary>
    public Guid DuAnId { get; set; }

    // === COMMON FIELDS ===
    /// <summary>
    /// ID loại thanh toán (FK to DanhMucLoaiThanhToan)
    /// </summary>
    public int LoaiThanhToanId { get; set; }

    /// <summary>
    /// Ghi chú kế hoạch
    /// </summary>
    public string? GhiChuKeHoach { get; set; }

    /// <summary>
    /// Ghi chú thực tế
    /// </summary>
    public string? GhiChuThucTe { get; set; }

    // === PLAN FIELDS (required at creation) ===
    /// <summary>
    /// Thời gian kế hoạch thu tiền
    /// </summary>
    public DateOnly ThoiGianKeHoach { get; set; }

    /// <summary>
    /// Phần trăm kế hoạch (từ 0-100)
    /// </summary>
    public decimal PhanTramKeHoach { get; set; }

    /// <summary>
    /// Giá trị kế hoạch thu tiền
    /// </summary>
    public decimal GiaTriKeHoach { get; set; }

    // === ACTUAL FIELDS (nullable - filled when executed) ===
    /// <summary>
    /// ID hợp đồng thực hiện thu (FK to HopDong) - Set when actual payment recorded
    /// </summary>
    public Guid? HopDongId { get; set; }

    /// <summary>
    /// Thời gian thực tế thu tiền
    /// </summary>
    public DateOnly? ThoiGianThucTe { get; set; }

    /// <summary>
    /// Giá trị thực tế thu được
    /// </summary>
    public decimal? GiaTriThucTe { get; set; }

    /// <summary>
    /// Số hóa đơn
    /// </summary>
    public string? SoHoaDon { get; set; }

    /// <summary>
    /// Ký hiệu hóa đơn
    /// </summary>
    public string? KyHieuHoaDon { get; set; }

    /// <summary>
    /// Ngày hóa đơn
    /// </summary>
    public DateOnly? NgayHoaDon { get; set; }

    #region Navigation Properties

    public DuAn? DuAn { get; set; }
    public HopDong? HopDong { get; set; }
    public DanhMucLoaiThanhToan? LoaiThanhToan { get; set; }

    #endregion
}