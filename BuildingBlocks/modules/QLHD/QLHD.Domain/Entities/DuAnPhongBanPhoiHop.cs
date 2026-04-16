namespace QLHD.Domain.Entities;

/// <summary>
/// Junction table: DuAn ↔ PhongBan (DmDonVi)
/// Database columns: DuAnId, PhongBanId
/// Note: No navigation to DmDonVi (legacy table) - use LeftOuterJoin in queries
/// </summary>
public class DuAnPhongBanPhoiHop : IJunctionEntity<Guid, long>
{
    /// <summary>
    /// FK to DuAn (mapped to DuAnId column in database)
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

    public DuAn? DuAn { get; set; }

    #endregion
}
