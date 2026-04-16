namespace QLHD.Domain.Entities.DanhMuc;

/// <summary>
/// Danh mục người phụ trách
/// </summary>
public class DanhMucNguoiPhuTrach : DanhMuc<int>, IAggregateRoot {
    public new string Ten { get; set; } = string.Empty;
    /// <summary>
    /// ID người dùng portal (FK to USER_MASTER table)
    /// </summary>
    public long UserPortalId { get; set; }
    public long DonViId { get; set; }
    public long? PhongBanId { get; set; }
}