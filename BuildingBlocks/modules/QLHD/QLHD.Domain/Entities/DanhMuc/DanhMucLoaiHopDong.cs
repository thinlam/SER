namespace QLHD.Domain.Entities.DanhMuc;

/// <summary>
/// Loại hợp đồng
/// </summary>
public class DanhMucLoaiHopDong : DanhMuc<int>, IAggregateRoot
{
    /// <summary>
    /// Ký hiệu (ví dụ: TTCĐS-)
    /// </summary>
    public string? Symbol { get; set; }

    /// <summary>
    /// Tiền tố số hợp đồng
    /// </summary>
    public int Prefix { get; set; }

    /// <summary>
    /// Loại mặc định
    /// </summary>
    public bool IsDefault { get; set; }
}