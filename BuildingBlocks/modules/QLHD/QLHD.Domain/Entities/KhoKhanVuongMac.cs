using System.ComponentModel.DataAnnotations;
using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Domain.Entities;

/// <summary>
/// Khó khăn vướng mắc - Thuộc về Hợp đồng, có thể liên kết với Tiến độ
/// </summary>
public class KhoKhanVuongMac : Entity<Guid>, IAggregateRoot
{
    /// <summary>
    /// ID hợp đồng (FK to HopDong) - Required
    /// </summary>
    [Required]
    public Guid HopDongId { get; set; }

    /// <summary>
    /// ID tiến độ (FK to TienDo) - Optional
    /// </summary>
    public Guid? TienDoId { get; set; }

    /// <summary>
    /// Nội dung khó khăn/vướng mắc
    /// </summary>
    [Required]
    [MaxLength(2000)]
    public string NoiDung { get; set; } = string.Empty;

    /// <summary>
    /// Mức độ: "Nhẹ", "Trung bình", "Nặng"
    /// </summary>
    [MaxLength(50)]
    public string? MucDo { get; set; }

    /// <summary>
    /// Ngày phát hiện
    /// </summary>
    [Required]
    public DateOnly NgayPhatHien { get; set; }

    /// <summary>
    /// Ngày giải quyết
    /// </summary>
    public DateOnly? NgayGiaiQuyet { get; set; }

    /// <summary>
    /// Biện pháp khắc phục
    /// </summary>
    [MaxLength(2000)]
    public string? BienPhapKhacPhuc { get; set; }

    /// <summary>
    /// ID trạng thái (FK to DanhMucTrangThai - KHO_KHAN type)
    /// </summary>
    public int TrangThaiId { get; set; }

    #region Navigation Properties

    public HopDong? HopDong { get; set; }
    public TienDo? TienDo { get; set; }
    public DanhMucTrangThai? TrangThai { get; set; }

    #endregion
}