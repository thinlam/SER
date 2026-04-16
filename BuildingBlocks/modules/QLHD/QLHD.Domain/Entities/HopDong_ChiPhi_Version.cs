using QLHD.Domain.Entities.DanhMuc;
using QLHD.Domain.Interfaces;

namespace QLHD.Domain.Entities;

/// <summary>
/// Version snapshot of HopDong_ChiPhi for KeHoachThang period (Plan data only)
/// </summary>
public class HopDong_ChiPhi_Version : Entity<Guid>, IAggregateRoot, IKeHoach
{
    // === VERSION FIELDS (required) ===
    /// <summary>
    /// ID kế hoạch tháng (FK to KeHoachThang)
    /// </summary>
    public int KeHoachThangId { get; set; }

    /// <summary>
    /// ID bản ghi nguồn (FK to HopDong_ChiPhi)
    /// </summary>
    public Guid SourceEntityId { get; set; }

    // === OWNER (required) ===
    /// <summary>
    /// ID hợp đồng (FK to HopDong)
    /// </summary>
    public Guid HopDongId { get; set; }

    // === COMMON FIELDS ===
    /// <summary>
    /// ID loại chi phí (FK to DanhMucLoaiChiPhi)
    /// </summary>
    public int LoaiChiPhiId { get; set; }

    /// <summary>
    /// Năm chi phí
    /// </summary>
    public short Nam { get; set; }

    /// <summary>
    /// Lần chi phí
    /// </summary>
    public byte LanChi { get; set; }

    /// <summary>
    /// Ghi chú kế hoạch
    /// </summary>
    public string? GhiChuKeHoach { get; set; }

    // === PLAN FIELDS ===
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

    #region Navigation Properties

    public KeHoachThang? KeHoachThang { get; set; }
    public HopDong_ChiPhi? SourceEntity { get; set; }
    public HopDong? HopDong { get; set; }
    public DanhMucLoaiChiPhi? LoaiChiPhi { get; set; }

    #endregion
}