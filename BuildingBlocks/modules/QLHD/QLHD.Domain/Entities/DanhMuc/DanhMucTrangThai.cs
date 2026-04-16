namespace QLHD.Domain.Entities.DanhMuc;

/// <summary>
/// Trạng thái - các trạng thái chi tiết thuộc từng loại
/// </summary>
public class DanhMucTrangThai : DanhMuc<int>, IAggregateRoot {
    /// <summary>
    /// Loại trạng thái ID
    /// </summary>
    public int? LoaiTrangThaiId { get; set; }

    /// <summary>
    /// Mã loại trạng thái (read-optimized)
    /// </summary>
    public string? MaLoaiTrangThai { get; set; }

    /// <summary>
    /// Tên loại trạng thái (read-optimized)
    /// </summary>
    public string? TenLoaiTrangThai { get; set; }
    /// <summary>
    /// Thứ tự hiển thị trong cùng loại trạng thái
    /// </summary>
    public int ThuTu { get; set; }
    public bool IsDefault { get; set; } = false;

    /// <summary>
    /// Navigation to LoaiTrangThai
    /// </summary>
    public virtual DanhMucLoaiTrangThai? LoaiTrangThai { get; set; }
}