namespace QLHD.Domain.Entities;

/// <summary>
/// Doanh nghiệp
/// </summary>
public class DoanhNghiep : Entity<Guid>, IAggregateRoot
{
    /// <summary>
    /// Mã số thuế
    /// </summary>
    public string? TaxCode { get; set; }

    /// <summary>
    /// Tên doanh nghiệp tiếng Việt
    /// </summary>
    public string? Ten { get; set; }

    /// <summary>
    /// Tên doanh nghiệp tiếng Anh
    /// </summary>
    public string? TenTiengAnh { get; set; }

    /// <summary>
    /// Mã cơ quan thuế
    /// </summary>
    public int? TaxAuthorityId { get; set; }

    /// <summary>
    /// Số điện thoại
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Số fax
    /// </summary>
    public string? Fax { get; set; }

    /// <summary>
    /// Địa chỉ tiếng Việt
    /// </summary>
    public string? AddressVN { get; set; }

    /// <summary>
    /// Địa chỉ tiếng Anh
    /// </summary>
    public string? AddressEN { get; set; }

    /// <summary>
    /// ID quốc gia
    /// </summary>
    public int? CountryId { get; set; }

    /// <summary>
    /// ID tỉnh/thành phố
    /// </summary>
    public int? CityId { get; set; }

    /// <summary>
    /// ID quận/huyện
    /// </summary>
    public int? DistrictId { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Người liên hệ
    /// </summary>
    public string? ContactPerson { get; set; }

    /// <summary>
    /// Chủ doanh nghiệp
    /// </summary>
    public string? Owner { get; set; }

    /// <summary>
    /// Số tài khoản ngân hàng
    /// </summary>
    public string? BankAccount { get; set; }

    /// <summary>
    /// Chủ tài khoản
    /// </summary>
    public string? AccountHolder { get; set; }

    /// <summary>
    /// Tên ngân hàng
    /// </summary>
    public string? BankName { get; set; }

    /// <summary>
    /// Có logo không
    /// </summary>
    public bool IsLogo { get; set; }

    /// <summary>
    /// Tên file logo
    /// </summary>
    public string? LogoFileName { get; set; }

    /// <summary>
    /// Mô tả
    /// </summary>
    public string? MoTa { get; set; }

    /// <summary>
    /// Trạng thái hoạt động
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Quy mô cấp phép
    /// </summary>
    public string? AuthorizeVolume { get; set; }

    /// <summary>
    /// Giấy phép
    /// </summary>
    public string? AuthorizeLic { get; set; }

    /// <summary>
    /// Ngày cấp phép
    /// </summary>
    public DateTime? AuthorizeDate { get; set; }

    /// <summary>
    /// Phiên bản
    /// </summary>
    public string? Version { get; set; }
}