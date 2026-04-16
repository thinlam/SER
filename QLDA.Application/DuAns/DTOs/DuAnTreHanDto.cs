namespace QLDA.Application.DuAns.DTOs;

public class DuAnTreHanDto
{
    /// <summary>
    /// Dự án - Khoá 
    /// </summary>
    /// <example>955bda57-e635-4233-a333-3a333b24bf8d</example>
    public Guid DuAnId { get; set; }
    /// <summary>
    /// Tên dự án
    /// </summary>
    /// <example>Dự án công nghệ thông tin</example>
    public string? TenDuAn { get; set; }
    /// <summary>
    /// Đơn vị/ phòng ban phụ trách chính - Khoá 
    /// </summary>
    /// <example>1</example>
    public long? DonViPhuTrachChinhId { get; set; }
    /// <summary>
    /// Tên đơn vị phụ trách chính
    /// </summary>
    /// <example>Phòng công nghệ</example>
    public string? TenDonViPhuTrachChinh { get; set; }

    // /// <summary>
    // /// Bước của dự án bước - Khoá 
    // /// </summary>
    // /// <example>1</example>
    // public int? DuAnBuocId { get; set; }
    /// <summary>
    /// Bước của danh mục bước - Khoá 
    /// </summary>
    /// <example>1</example>
    public int? BuocId { get; set; }
    /// <summary>
    /// Tên bước - danh mục bước
    /// </summary>
    /// <example>Kế hoạch gói thâu</example>
    public string? TenBuoc { get; set; }
    /// <summary>
    /// Thời gian dự kiến - bắt đầu 
    /// </summary>
    /// <example>2025-08-31T17:00:00+00:00</example>
    public DateOnly? NgayDuKienBatDau { get; set; }

    /// <summary>
    /// Thời gian dự kiến - kết thúc
    /// </summary>
    /// <example>2025-12-12T17:00:00+00:00</example>
    public DateOnly? NgayDuKienKetThuc { get; set; }

    /// <summary>
    /// Thời gian thực tế - kết thúc
    /// </summary>
    /// <example>2025-08-31T17:00:00+00:00</example>
    public DateOnly? NgayThucTeBatDau { get; set; }

    /// <summary>
    /// Thời gian thực tế - kết thúc
    /// </summary>
    /// <example>2025-08-31T17:00:00+00:00</example>
    public DateOnly? NgayThucTeKetThuc { get; set; }
}