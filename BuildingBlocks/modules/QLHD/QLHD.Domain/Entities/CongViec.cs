using System.ComponentModel.DataAnnotations;

namespace QLHD.Domain.Entities;

/// <summary>
/// Quản lý công việc / Công việc
/// </summary>
public class CongViec : Entity<Guid>, IAggregateRoot, IAuditable {
    /// <summary>
    /// ID dự án (FK to DuAn)
    /// </summary>
    [Required]
    public Guid DuAnId { get; set; }

    /// <summary>
    /// Thời gian thực hiện (tháng/năm)
    /// </summary>
    public DateOnly ThoiGian { get; set; }

    /// <summary>
    /// ID người dùng portal (FK to USER_MASTER - legacy table)
    /// </summary>
    public long UserPortalId { get; set; }

    /// <summary>
    /// Người thực hiện
    /// </summary>
    [Required]
    public string NguoiThucHien { get; set; } = string.Empty;

    /// <summary>
    /// ID đơn vị (FK to DM_DONVI - legacy table)
    /// </summary>

    [Required] public long DonViId { get; set; }

    /// <summary>
    /// Tên đơn vị (denormalized for read optimization)
    /// </summary>
    [Required]
    public string TenDonVi { get; set; } = string.Empty;

    /// <summary>
    /// ID phòng ban (FK to DM_DONVI - legacy table)
    /// </summary>
    public long? PhongBanId { get; set; }

    /// <summary>
    /// Tên phòng ban (denormalized for read optimization)
    /// </summary>
    public string? TenPhongBan { get; set; }

    /// <summary>
    /// Kế hoạch thực hiện công việc
    /// </summary>
    public string KeHoachCongViec { get; set; } = string.Empty;

    /// <summary>
    /// Ngày hoàn thành
    /// </summary>
    public DateOnly? NgayHoanThanh { get; set; }

    /// <summary>
    /// Thực tế thực hiện
    /// </summary>
    public string? ThucTe { get; set; }

    /// <summary>
    /// ID trạng thái (FK to DanhMucTrangThai) - Loại trang thái = LoaiTrangThaiConstants.KeHoach
    /// </summary>
    [Required]
    public int TrangThaiId { get; set; }

    /// <summary>
    /// Tên trạng thái
    /// </summary>
    [Required]
    public string TenTrangThai { get; set; } = string.Empty;

    #region Navigation properties
    public DuAn? DuAn { get; set; }
    #endregion
}