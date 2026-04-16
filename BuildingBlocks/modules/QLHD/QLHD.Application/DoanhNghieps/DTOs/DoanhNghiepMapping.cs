namespace QLHD.Application.DoanhNghieps.DTOs;

public static class DoanhNghiepMapping
{
    public static DoanhNghiep ToEntity(this DoanhNghiepInsertModel model) => new()
    {
        TaxCode = model.TaxCode,
        Ten = model.Ten,
        TenTiengAnh = model.TenTiengAnh,
        TaxAuthorityId = model.TaxAuthorityId,
        Phone = model.Phone,
        Fax = model.Fax,
        AddressVN = model.AddressVN,
        AddressEN = model.AddressEN,
        CountryId = model.CountryId,
        CityId = model.CityId,
        DistrictId = model.DistrictId,
        Email = model.Email,
        ContactPerson = model.ContactPerson,
        Owner = model.Owner,
        BankAccount = model.BankAccount,
        AccountHolder = model.AccountHolder,
        BankName = model.BankName,
        IsLogo = model.IsLogo,
        LogoFileName = model.LogoFileName,
        MoTa = model.MoTa,
        IsActive = model.IsActive,
        AuthorizeVolume = model.AuthorizeVolume,
        AuthorizeLic = model.AuthorizeLic,
        AuthorizeDate = model.AuthorizeDate,
        Version = model.Version
    };

    public static void UpdateFrom(this DoanhNghiep entity, DoanhNghiepUpdateModel model)
    {
        entity.TaxCode = model.TaxCode;
        entity.Ten = model.Ten;
        entity.TenTiengAnh = model.TenTiengAnh;
        entity.TaxAuthorityId = model.TaxAuthorityId;
        entity.Phone = model.Phone;
        entity.Fax = model.Fax;
        entity.AddressVN = model.AddressVN;
        entity.AddressEN = model.AddressEN;
        entity.CountryId = model.CountryId;
        entity.CityId = model.CityId;
        entity.DistrictId = model.DistrictId;
        entity.Email = model.Email;
        entity.ContactPerson = model.ContactPerson;
        entity.Owner = model.Owner;
        entity.BankAccount = model.BankAccount;
        entity.AccountHolder = model.AccountHolder;
        entity.BankName = model.BankName;
        entity.IsLogo = model.IsLogo;
        entity.LogoFileName = model.LogoFileName;
        entity.MoTa = model.MoTa;
        entity.IsActive = model.IsActive;
        entity.AuthorizeVolume = model.AuthorizeVolume;
        entity.AuthorizeLic = model.AuthorizeLic;
        entity.AuthorizeDate = model.AuthorizeDate;
        entity.Version = model.Version;
    }
}