namespace QLHD.Domain.Entities.DanhMuc;

/// <summary>
/// Danh mục loại lãi
/// </summary>
public class DanhMucLoaiLai : DanhMuc<int>, IAggregateRoot
{
    /// <summary>
    /// Loại mặc định
    /// </summary>
    public bool IsDefault { get; set; }
}