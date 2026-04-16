using System.ComponentModel.DataAnnotations;

namespace QLHD.Domain.Entities;

/// <summary>
/// Khách hàng
/// </summary>
public class KhachHang : Entity<Guid>, IAggregateRoot
{
    /// <summary>
    /// Mã khách hàng (CustomerCode)
    /// </summary>
    public string? Ma { get; set; }

    /// <summary>
    /// Tên khách hàng (CustomerName)
    /// </summary>
    [Required]
    public string Ten { get; set; } = string.Empty;

    /// <summary>
    /// Là cá nhân hay tổ chức
    /// </summary>
    public bool IsPersonal { get; set; }

    /// <summary>
    /// Ngày sinh (đối với cá nhân)
    /// </summary>
    public DateOnly? DateOfBirth { get; set; }

    /// <summary>
    /// Mã số thuế
    /// </summary>
    public string? TaxCode { get; set; }

    /// <summary>
    /// Người liên hệ
    /// </summary>
    public string? ContactPerson { get; set; }

    /// <summary>
    /// Địa chỉ
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Số điện thoại
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// ID quận/huyện
    /// </summary>
    public int? DistrictId { get; set; }

    /// <summary>
    /// Tên quận/huyện
    /// </summary>
    public string? DistrictName { get; set; }

    /// <summary>
    /// ID tỉnh/thành phố
    /// </summary>
    public int? CityId { get; set; }

    /// <summary>
    /// Tên tỉnh/thành phố
    /// </summary>
    public string? CityName { get; set; }

    /// <summary>
    /// ID quốc gia
    /// </summary>
    public int? CountryId { get; set; }

    /// <summary>
    /// Tên quốc gia
    /// </summary>
    public string? CountryName { get; set; }

    /// <summary>
    /// Là khách hàng mặc định
    /// </summary>
    public bool IsDefault { get; set; }

    /// <summary>
    /// Trạng thái sử dụng
    /// </summary>
    public bool Used { get; set; } = true;

    /// <summary>
    /// ID đơn vị (FK to DM_DONVI - legacy table, no navigation)
    /// </summary>
    public long? DonViId { get; set; }

    /// <summary>
    /// ID doanh nghiệp
    /// </summary>
    public Guid? DoanhNghiepId { get; set; }

    /// <summary>
    /// Doanh nghiệp
    /// </summary>
    public DoanhNghiep? DoanhNghiep { get; set; }
}