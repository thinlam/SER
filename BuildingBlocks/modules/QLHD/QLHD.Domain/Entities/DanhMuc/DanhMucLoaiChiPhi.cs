namespace QLHD.Domain.Entities.DanhMuc;

/// <summary>
/// Loại chi phí
/// </summary>
public class DanhMucLoaiChiPhi : DanhMuc<int>, IAggregateRoot {
    /// <summary>
    /// Loại mặc định
    /// </summary>
    public bool IsDefault { get; set; }
    /// <summary>
    /// Là chi phí chính
    /// </summary>
    public bool IsMajor { get; set; }
}