namespace QLDA.Domain.Interfaces;

public interface INguoiKy {
    /// <summary>
    /// Người ký
    /// </summary>
    public string? NguoiKy { get; set; }
    /// <summary>
    /// Ngày ký
    /// </summary>
    public DateTimeOffset? NgayKy { get; set; }
}