using QLHD.Domain.Entities.DanhMuc;
using QLHD.Domain.Interfaces;

namespace QLHD.Domain.Entities;

/// <summary>
/// Version snapshot of HopDong_ThuTien for KeHoachThang period (Plan data only)
/// </summary>
public class HopDong_ThuTien_Version : Entity<Guid>, IAggregateRoot, IKeHoach
{
    // === VERSION FIELDS (required) ===
    /// <summary>
    /// ID kế hoạch tháng (FK to KeHoachThang)
    /// </summary>
    public int KeHoachThangId { get; set; }

    /// <summary>
    /// ID bản ghi nguồn (FK to HopDong_ThuTien)
    /// </summary>
    public Guid SourceEntityId { get; set; }

    // === OWNER (required) ===
    /// <summary>
    /// ID hợp đồng (FK to HopDong)
    /// </summary>
    public Guid HopDongId { get; set; }

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

    #region Navigation Properties

    public KeHoachThang? KeHoachThang { get; set; }
    public HopDong_ThuTien? SourceEntity { get; set; }
    public HopDong? HopDong { get; set; }
    public DanhMucLoaiThanhToan? LoaiThanhToan { get; set; }

    #endregion
}