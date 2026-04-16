namespace QLHD.Domain.Entities.DanhMuc;

/// <summary>
/// Danh mục người theo dõi
/// </summary>
public class DanhMucNguoiTheoDoi : DanhMuc<int>, IAggregateRoot {
    /// <summary>
    /// ID người dùng portal (FK to USER_MASTER table)
    /// </summary>
    public long UserPortalId { get; set; }
    public long DonViId { get; set; }
    public long? PhongBanId { get; set; }
}