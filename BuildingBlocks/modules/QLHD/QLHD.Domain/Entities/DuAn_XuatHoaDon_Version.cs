using QLHD.Domain.Entities.DanhMuc;
using QLHD.Domain.Interfaces;

namespace QLHD.Domain.Entities;

/// <summary>
/// Version snapshot of DuAn_XuatHoaDon for KeHoachThang period (Plan data only)
/// </summary>
public class DuAn_XuatHoaDon_Version : Entity<Guid>, IAggregateRoot, IKeHoach
{
    // === VERSION FIELDS (required) ===
    /// <summary>
    /// ID kế hoạch tháng (FK to KeHoachThang)
    /// </summary>
    public int KeHoachThangId { get; set; }

    /// <summary>
    /// ID bản ghi nguồn (FK to DuAn_XuatHoaDon)
    /// </summary>
    public Guid SourceEntityId { get; set; }

    // === OWNER (required) ===
    /// <summary>
    /// ID dự án (FK to DuAn)
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

    // === PLAN FIELDS ===
    /// <summary>
    /// Thời gian kế hoạch xuất hóa đơn
    /// </summary>
    public DateOnly ThoiGianKeHoach { get; set; }

    /// <summary>
    /// Phần trăm kế hoạch (từ 0-100)
    /// </summary>
    public decimal PhanTramKeHoach { get; set; }

    /// <summary>
    /// Giá trị kế hoạch xuất hóa đơn
    /// </summary>
    public decimal GiaTriKeHoach { get; set; }

    #region Navigation Properties

    public KeHoachThang? KeHoachThang { get; set; }
    public DuAn_XuatHoaDon? SourceEntity { get; set; }
    public DuAn? DuAn { get; set; }
    public DanhMucLoaiThanhToan? LoaiThanhToan { get; set; }

    #endregion
}