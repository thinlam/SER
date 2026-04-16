namespace QLHD.Domain.Entities.DanhMuc;

/// <summary>
/// Loại thanh toán
/// </summary>
public class DanhMucLoaiThanhToan : DanhMuc<int>, IAggregateRoot
{
    /// <summary>
    /// Loại mặc định
    /// </summary>
    public bool IsDefault { get; set; }
}