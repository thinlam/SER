using System.ComponentModel.DataAnnotations;

namespace QLHD.Application.KhachHangs.DTOs;

public class KhachHangUpdateModel
{
    public string? Ma { get; set; }

    [Required]
    public string Ten { get; set; } = string.Empty;
    public bool IsPersonal { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public string? TaxCode { get; set; }
    public string? ContactPerson { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public int? DistrictId { get; set; }
    public string? DistrictName { get; set; }
    public int? CityId { get; set; }
    public string? CityName { get; set; }
    public int? CountryId { get; set; }
    public string? CountryName { get; set; }
    public bool IsDefault { get; set; }
    public bool Used { get; set; }
    public long? DonViId { get; set; }
    public Guid? DoanhNghiepId { get; set; }
}