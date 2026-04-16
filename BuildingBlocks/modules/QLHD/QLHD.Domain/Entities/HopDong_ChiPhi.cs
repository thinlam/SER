using QLHD.Domain.Entities.DanhMuc;
using QLHD.Domain.Interfaces;

namespace QLHD.Domain.Entities;

/// <summary>
/// Chi phí theo hợp đồng (độc lập) - Gộp kế hoạch và thực tế trong một bản ghi <br/>
/// Lãi gộp = Thu tiền - Chi phí chính <br/>
/// Chi phí chính = LoaiChiPhi.IsMajor
/// </summary>
public class HopDong_ChiPhi : Entity<Guid>, IAggregateRoot,
    IKeHoach, IThucTe {
    // === OWNER (required) ===
    /// <summary>
    /// ID hợp đồng (FK to HopDong) - Required
    /// </summary>
    public Guid HopDongId { get; set; }

    // === COMMON FIELDS ===
    /// <summary>
    /// ID loại chi phí (FK to DanhMucLoaiChiPhi)
    /// </summary>
    public int LoaiChiPhiId { get; set; }

    /// <summary>
    /// Năm chi phí (ví dụ: 2024) - Dùng để phân loại chi phí theo năm, phục vụ báo cáo và thống kê
    /// </summary>
    public short Nam { get; set; }

    /// <summary>
    /// Lần chi phí (ví dụ: 1, 2, 3...) - Dùng để phân biệt các lần chi phí trong cùng một năm của một hợp đồng, phục vụ theo dõi và quản lý chi phí theo từng đợt hoặc giai đoạn thực hiện hợp đồng
    /// </summary>
    public byte LanChi { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    public string? GhiChuKeHoach { get; set; }

    // === PLAN FIELDS (required at creation) ===
    /// <summary>
    /// Thời gian kế hoạch chi phí
    /// </summary>
    public DateOnly ThoiGianKeHoach { get; set; }

    /// <summary>
    /// Phần trăm kế hoạch (từ 0-100)
    /// </summary>
    public decimal PhanTramKeHoach { get; set; }

    /// <summary>
    /// Giá trị kế hoạch chi phí
    /// </summary>
    public decimal GiaTriKeHoach { get; set; }

    // === ACTUAL FIELDS (nullable - filled when executed) ===
    /// <summary>
    /// Thời gian thực tế chi phí
    /// </summary>
    public DateOnly? ThoiGianThucTe { get; set; }

    /// <summary>
    /// Giá trị thực tế chi phí
    /// </summary>
    public decimal? GiaTriThucTe { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    public string? GhiChuThucTe { get; set; }

    #region Navigation Properties

    public HopDong? HopDong { get; set; }
    public DanhMucLoaiChiPhi? LoaiChiPhi { get; set; }

    #endregion
}