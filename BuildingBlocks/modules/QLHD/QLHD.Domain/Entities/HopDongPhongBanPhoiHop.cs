namespace QLHD.Domain.Entities;

/// <summary>
/// Junction table: HopDong ↔ PhongBan (DmDonVi)
/// Database columns: HopDongId, PhongBanId
/// Note: No navigation to DmDonVi (legacy table) - use LeftOuterJoin in queries
/// </summary>
public class HopDongPhongBanPhoiHop : IJunctionEntity<Guid, long> {
    /// <summary>
    /// FK to HopDong (mapped to HopDongId column in database)
    /// </summary>
    public Guid LeftId { get; set; }

    /// <summary>
    /// FK to DmDonVi/PhongBan (mapped to PhongBanId column in database)
    /// </summary>
    public long RightId { get; set; }

    /// <summary>
    /// Denormalized department name (from DmDonVi.TenDonVi)
    /// </summary>
    public string? TenPhongBan { get; set; }

    #region Navigation Properties

    public HopDong? HopDong { get; set; }

    #endregion
}