using System.ComponentModel.DataAnnotations;

namespace QLHD.Domain.Entities;

/// <summary>
/// Kế hoạch tháng - Entity quản lý các kỳ kế hoạch theo tháng
/// </summary>
public class KeHoachThang : Entity<int>, IAggregateRoot
{
    /// <summary>
    /// Ngày bắt đầu (ngày đầu tháng, ví dụ: 2027-01-01)
    /// </summary>
    [Required]
    public DateOnly TuNgay { get; set; }

    /// <summary>
    /// Ngày kết thúc (ngày đầu tháng, ví dụ: 2027-12-01)
    /// </summary>
    [Required]
    public DateOnly DenNgay { get; set; }

    /// <summary>
    /// Hiển thị tháng bắt đầu (ví dụ: "Tháng 1 - 2027")
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string TuThangDisplay { get; set; } = string.Empty;

    /// <summary>
    /// Hiển thị tháng kết thúc (ví dụ: "Tháng 12 - 2027")
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string DenThangDisplay { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string? GhiChu { get; set; }
}