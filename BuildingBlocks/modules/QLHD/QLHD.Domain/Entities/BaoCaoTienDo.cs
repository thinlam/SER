using System.ComponentModel.DataAnnotations;

namespace QLHD.Domain.Entities;

/// <summary>
/// Báo cáo tiến độ - Thuộc về Tiến độ
/// </summary>
public class BaoCaoTienDo : Entity<Guid>, IAggregateRoot
{
    /// <summary>
    /// ID tiến độ (FK to TienDo) - Required
    /// </summary>
    [Required]
    public Guid TienDoId { get; set; }

    /// <summary>
    /// Ngày báo cáo
    /// </summary>
    [Required]
    public DateOnly NgayBaoCao { get; set; }

    /// <summary>
    /// ID người báo cáo (FK to USER_MASTER)
    /// </summary>
    public long NguoiBaoCaoId { get; set; }

    /// <summary>
    /// Tên người báo cáo (denormalized)
    /// </summary>
    [MaxLength(200)]
    public string TenNguoiBaoCao { get; set; } = string.Empty;

    /// <summary>
    /// Phần trăm thực tế (0-100)
    /// </summary>
    public decimal PhanTramThucTe { get; set; }

    /// <summary>
    /// Nội dung đã làm
    /// </summary>
    [MaxLength(4000)]
    public string? NoiDungDaLam { get; set; }

    /// <summary>
    /// Kế hoạch tiếp theo
    /// </summary>
    [MaxLength(4000)]
    public string? KeHoachTiepTheo { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    [MaxLength(2000)]
    public string? GhiChu { get; set; }

    #region Optional Approval

    /// <summary>
    /// Có thể duyệt (flag để bật/tắt luồng duyệt)
    /// If true, report requires approval before being effective
    /// </summary>
    public bool CanDuyet { get; set; }

    /// <summary>
    /// Đã duyệt
    /// </summary>
    public bool DaDuyet { get; set; }

    /// <summary>
    /// ID người duyệt (FK to USER_MASTER)
    /// Required if CanDuyet = true
    /// </summary>
    public long? NguoiDuyetId { get; set; }

    /// <summary>
    /// Tên người duyệt (denormalized)
    /// </summary>
    [MaxLength(200)]
    public string? TenNguoiDuyet { get; set; }

    /// <summary>
    /// Ngày duyệt
    /// </summary>
    public DateOnly? NgayDuyet { get; set; }

    #endregion

    #region Navigation Properties

    public TienDo? TienDo { get; set; }

    #endregion
}