using System.ComponentModel.DataAnnotations;
using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Domain.Entities;

/// <summary>
/// Tiến độ / Giai đoạn - Thuộc về Hợp đồng
/// </summary>
public class TienDo : Entity<Guid>, IAggregateRoot
{
    /// <summary>
    /// ID hợp đồng (FK to HopDong) - Required
    /// </summary>
    [Required]
    public Guid HopDongId { get; set; }

    /// <summary>
    /// Tên giai đoạn/tiến độ
    /// </summary>
    [Required]
    [MaxLength(500)]
    public string Ten { get; set; } = string.Empty;

    /// <summary>
    /// Phần trăm kế hoạch (0-100)
    /// </summary>
    public decimal PhanTramKeHoach { get; set; }

    /// <summary>
    /// Ngày bắt đầu kế hoạch
    /// </summary>
    public DateOnly? NgayBatDauKeHoach { get; set; }

    /// <summary>
    /// Ngày kết thúc kế hoạch
    /// </summary>
    public DateOnly? NgayKetThucKeHoach { get; set; }

    /// <summary>
    /// Mô tả giai đoạn
    /// </summary>
    [MaxLength(2000)]
    public string? MoTa { get; set; }

    /// <summary>
    /// ID trạng thái (FK to DanhMucTrangThai - TIENDO type)
    /// </summary>
    public int TrangThaiId { get; set; }

    #region Denormalized fields (updated on BaoCaoTienDo insert)

    /// <summary>
    /// Phần trăm thực tế (denormalized - max of BaoCaoTienDo.PhanTramThucTe)
    /// </summary>
    public decimal PhanTramThucTe { get; set; }

    /// <summary>
    /// Ngày cập nhật gần nhất (denormalized - max of BaoCaoTienDo.NgayBaoCao)
    /// </summary>
    public DateOnly? NgayCapNhatGanNhat { get; set; }

    #endregion

    #region Navigation Properties

    public HopDong? HopDong { get; set; }
    public DanhMucTrangThai? TrangThai { get; set; }
    public ICollection<BaoCaoTienDo>? BaoCaoTienDos { get; set; }

    #endregion
}