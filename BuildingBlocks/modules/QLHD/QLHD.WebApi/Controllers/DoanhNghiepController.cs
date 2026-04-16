using QLHD.Application.DoanhNghieps.Commands;
using QLHD.Application.DoanhNghieps.DTOs;
using QLHD.Application.DoanhNghieps.Queries;

namespace QLHD.WebApi.Controllers;

[Tags("Doanh nghiệp (doanh-nghiep)")]
public class DoanhNghiepController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    [HttpPost("doanh-nghiep/them-moi")]
    [ProducesResponseType<ResultApi<DoanhNghiepDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Create(
        [FromBody] DoanhNghiepInsertModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new DoanhNghiepInsertCommand(model), cancellationToken);
        return ResultApi.Ok(new DoanhNghiepDto
        {
            Id = entity.Id,
            TaxCode = entity.TaxCode,
            Ten = entity.Ten,
            TenTiengAnh = entity.TenTiengAnh,
            TaxAuthorityId = entity.TaxAuthorityId,
            Phone = entity.Phone,
            Fax = entity.Fax,
            AddressVN = entity.AddressVN,
            AddressEN = entity.AddressEN,
            CountryId = entity.CountryId,
            CityId = entity.CityId,
            DistrictId = entity.DistrictId,
            Email = entity.Email,
            ContactPerson = entity.ContactPerson,
            Owner = entity.Owner,
            BankAccount = entity.BankAccount,
            AccountHolder = entity.AccountHolder,
            BankName = entity.BankName,
            IsLogo = entity.IsLogo,
            LogoFileName = entity.LogoFileName,
            MoTa = entity.MoTa,
            IsActive = entity.IsActive,
            AuthorizeVolume = entity.AuthorizeVolume,
            AuthorizeLic = entity.AuthorizeLic,
            AuthorizeDate = entity.AuthorizeDate,
            Version = entity.Version
        });
    }

    [HttpPut("doanh-nghiep/cap-nhat/{id}")]
    [ProducesResponseType<ResultApi<DoanhNghiepDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Update(
        Guid id,
        [FromBody] DoanhNghiepUpdateModel model,
        CancellationToken cancellationToken = default)
    {
        model.Id = id;
        var entity = await Mediator.Send(new DoanhNghiepUpdateCommand(model), cancellationToken);
        return ResultApi.Ok(new DoanhNghiepDto
        {
            Id = entity.Id,
            TaxCode = entity.TaxCode,
            Ten = entity.Ten,
            TenTiengAnh = entity.TenTiengAnh,
            TaxAuthorityId = entity.TaxAuthorityId,
            Phone = entity.Phone,
            Fax = entity.Fax,
            AddressVN = entity.AddressVN,
            AddressEN = entity.AddressEN,
            CountryId = entity.CountryId,
            CityId = entity.CityId,
            DistrictId = entity.DistrictId,
            Email = entity.Email,
            ContactPerson = entity.ContactPerson,
            Owner = entity.Owner,
            BankAccount = entity.BankAccount,
            AccountHolder = entity.AccountHolder,
            BankName = entity.BankName,
            IsLogo = entity.IsLogo,
            LogoFileName = entity.LogoFileName,
            MoTa = entity.MoTa,
            IsActive = entity.IsActive,
            AuthorizeVolume = entity.AuthorizeVolume,
            AuthorizeLic = entity.AuthorizeLic,
            AuthorizeDate = entity.AuthorizeDate,
            Version = entity.Version
        });
    }

    [HttpGet("doanh-nghiep/danh-sach")]
    [ProducesResponseType<ResultApi<PaginatedList<DoanhNghiepDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] DoanhNghiepSearchModel searchModel)
    {
        var result = await Mediator.Send(new DoanhNghiepGetListQuery(searchModel));
        return ResultApi.Ok(result);
    }

    [HttpGet("doanh-nghiep/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<DoanhNghiepDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetById(Guid id)
    {
        var result = await Mediator.Send(new DoanhNghiepGetByIdQuery(id));
        return ResultApi.Ok(result);
    }

    [HttpGet("doanh-nghiep/combobox")]
    [ProducesResponseType<ResultApi<List<ComboBoxDto<Guid>>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetCombobox([FromQuery] string? search)
    {
        var result = await Mediator.Send(new DoanhNghiepGetComboboxQuery(search));
        return ResultApi.Ok(result);
    }

    [HttpDelete("doanh-nghiep/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(Guid id)
    {
        await Mediator.Send(new DoanhNghiepDeleteCommand(id));
        return ResultApi.Ok();
    }
}