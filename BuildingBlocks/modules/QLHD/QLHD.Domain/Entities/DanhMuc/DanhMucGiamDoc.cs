namespace QLHD.Domain.Entities.DanhMuc;

/// <summary>
/// Danh mục giám đốc
/// </summary>
public class DanhMucGiamDoc : DanhMuc<int>, IAggregateRoot {
    /// <summary>
    /// ID người dùng portal (FK to USER_MASTER table)
    /// </summary>
    public long UserPortalId { get; set; }
    public long DonViId { get; set; }
    public long? PhongBanId { get; set; }
}