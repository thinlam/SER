namespace QLHD.Application.DoanhNghieps.DTOs;

public class DoanhNghiepInsertModel
{
    public string? TaxCode { get; set; }
    public string? Ten { get; set; }
    public string? TenTiengAnh { get; set; }
    public int? TaxAuthorityId { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? AddressVN { get; set; }
    public string? AddressEN { get; set; }
    public int? CountryId { get; set; }
    public int? CityId { get; set; }
    public int? DistrictId { get; set; }
    public string? Email { get; set; }
    public string? ContactPerson { get; set; }
    public string? Owner { get; set; }
    public string? BankAccount { get; set; }
    public string? AccountHolder { get; set; }
    public string? BankName { get; set; }
    public bool IsLogo { get; set; }
    public string? LogoFileName { get; set; }
    public string? MoTa { get; set; }
    public bool IsActive { get; set; } = true;
    public string? AuthorizeVolume { get; set; }
    public string? AuthorizeLic { get; set; }
    public DateTime? AuthorizeDate { get; set; }
    public string? Version { get; set; }
}