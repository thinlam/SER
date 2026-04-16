using System.ComponentModel.DataAnnotations;

namespace QLHD.Domain.Entities;

/// <summary>
/// Phụ lục hợp đồng
/// </summary>
public class PhuLucHopDong : Entity<Guid>, IAggregateRoot
{
    /// <summary>
    /// ID hợp đồng (FK to HopDong) - Required
    /// </summary>
    [Required]
    public Guid HopDongId { get; set; }

    /// <summary>
    /// Số phụ lục hợp đồng
    /// </summary>
    [Required]
    public string SoPhuLuc { get; set; } = string.Empty;

    /// <summary>
    /// Ngày ký phụ lục
    /// </summary>
    [Required]
    public DateOnly NgayKy { get; set; }

    /// <summary>
    /// Nội dung phụ lục
    /// </summary>
    public string? NoiDungPhuLuc { get; set; }

    #region Navigation Properties

    public HopDong? HopDong { get; set; }

    #endregion
}