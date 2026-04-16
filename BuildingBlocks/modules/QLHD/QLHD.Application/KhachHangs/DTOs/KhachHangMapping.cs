namespace QLHD.Application.KhachHangs.DTOs;

public static class KhachHangMapping
{
    public static KhachHang ToEntity(this KhachHangInsertModel model) => new()
    {
        Ten = model.Ten,
        IsPersonal = model.IsPersonal,
        DateOfBirth = model.DateOfBirth,
        TaxCode = model.TaxCode,
        ContactPerson = model.ContactPerson,
        Address = model.Address,
        Phone = model.Phone,
        Email = model.Email,
        DistrictId = model.DistrictId,
        DistrictName = model.DistrictName,
        CityId = model.CityId,
        CityName = model.CityName,
        CountryId = model.CountryId,
        CountryName = model.CountryName,
        IsDefault = model.IsDefault,
        Used = model.Used,
        DonViId = model.DonViId,
        DoanhNghiepId = model.DoanhNghiepId
    };

    public static void UpdateFrom(this KhachHang entity, KhachHangUpdateModel model)
    {
        entity.Ma = model.Ma;
        entity.Ten = model.Ten;
        entity.IsPersonal = model.IsPersonal;
        entity.DateOfBirth = model.DateOfBirth;
        entity.TaxCode = model.TaxCode;
        entity.ContactPerson = model.ContactPerson;
        entity.Address = model.Address;
        entity.Phone = model.Phone;
        entity.Email = model.Email;
        entity.DistrictId = model.DistrictId;
        entity.DistrictName = model.DistrictName;
        entity.CityId = model.CityId;
        entity.CityName = model.CityName;
        entity.CountryId = model.CountryId;
        entity.CountryName = model.CountryName;
        entity.IsDefault = model.IsDefault;
        entity.Used = model.Used;
        entity.DonViId = model.DonViId;
        entity.DoanhNghiepId = model.DoanhNghiepId;
    }
}