using System.ComponentModel.DataAnnotations;
using BuildingBlocks.Domain.ValueTypes;

namespace QLHD.Application.CongViecs.DTOs;

public class CongViecInsertModel
{
    [Required]
    public Guid DuAnId { get; set; }

    /// <summary>
    /// Thời gian thực hiện (MM-yyyy format)
    /// </summary>
    public MonthYear ThoiGian { get; set; }

    /// <summary>
    /// ID người dùng portal (FK to USER_MASTER - legacy table)
    /// </summary>
    [Required]
    public long UserPortalId { get; set; }

    /// <summary>
    /// ID đơn vị (FK to DM_DONVI - legacy table)
    /// </summary>
    [Required]
    public long DonViId { get; set; }

    /// <summary>
    /// ID phòng ban (FK to DM_DONVI - legacy table)
    /// </summary>
    public long? PhongBanId { get; set; }

    [MaxLength(2000)]
    public string KeHoachCongViec { get; set; } = string.Empty;

    public DateOnly? NgayHoanThanh { get; set; }

    [MaxLength(2000)]
    public string? ThucTe { get; set; }

    /// <summary>
    /// Nếu không cung cấp, sẽ lấy giá trị IsDefault của DanhMucTrangThai với MaLoaiTrangThai = KEHOACH
    /// </summary>
    [Required]
    public int TrangThaiId { get; set; }
}