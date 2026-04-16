using QLHD.Application.KhachHangs.Commands;
using QLHD.Application.KhachHangs.DTOs;
using QLHD.Application.KhachHangs.Queries;

namespace QLHD.WebApi.Controllers;

[Tags("Khách hàng (khach-hang)")]
public class KhachHangController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    [HttpPost("khach-hang/them-moi")]
    [ProducesResponseType<ResultApi<KhachHangDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Create(
        [FromBody] KhachHangInsertModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new KhachHangInsertCommand(model), cancellationToken);
        return ResultApi.Ok(new KhachHangDto
        {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            IsPersonal = entity.IsPersonal,
            DateOfBirth = entity.DateOfBirth,
            TaxCode = entity.TaxCode,
            ContactPerson = entity.ContactPerson,
            Address = entity.Address,
            Phone = entity.Phone,
            Email = entity.Email,
            DistrictId = entity.DistrictId,
            DistrictName = entity.DistrictName,
            CityId = entity.CityId,
            CityName = entity.CityName,
            CountryId = entity.CountryId,
            CountryName = entity.CountryName,
            IsDefault = entity.IsDefault,
            Used = entity.Used,
            DonViId = entity.DonViId,
            DoanhNghiepId = entity.DoanhNghiepId
        });
    }

    [HttpPut("khach-hang/cap-nhat/{id}")]
    [ProducesResponseType<ResultApi<KhachHangDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Update(
        Guid id,
        [FromBody] KhachHangUpdateModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new KhachHangUpdateCommand(id, model), cancellationToken);
        return ResultApi.Ok(new KhachHangDto
        {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            IsPersonal = entity.IsPersonal,
            DateOfBirth = entity.DateOfBirth,
            TaxCode = entity.TaxCode,
            ContactPerson = entity.ContactPerson,
            Address = entity.Address,
            Phone = entity.Phone,
            Email = entity.Email,
            DistrictId = entity.DistrictId,
            DistrictName = entity.DistrictName,
            CityId = entity.CityId,
            CityName = entity.CityName,
            CountryId = entity.CountryId,
            CountryName = entity.CountryName,
            IsDefault = entity.IsDefault,
            Used = entity.Used,
            DonViId = entity.DonViId,
            DoanhNghiepId = entity.DoanhNghiepId
        });
    }

    [HttpGet("khach-hang/danh-sach")]
    [ProducesResponseType<ResultApi<PaginatedList<KhachHangDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] KhachHangSearchModel searchModel)
    {
        var result = await Mediator.Send(new KhachHangGetListQuery(searchModel));
        return ResultApi.Ok(result);
    }

    [HttpGet("khach-hang/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<KhachHangDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetById(Guid id)
    {
        var result = await Mediator.Send(new KhachHangGetByIdQuery(id));
        return ResultApi.Ok(result);
    }

    [HttpGet("khach-hang/combobox")]
    [ProducesResponseType<ResultApi<List<ComboBoxDto<Guid>>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetCombobox()
    {
        var result = await Mediator.Send(new KhachHangGetComboboxQuery());
        return ResultApi.Ok(result);
    }

    [HttpDelete("khach-hang/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(Guid id)
    {
        await Mediator.Send(new KhachHangDeleteCommand(id));
        return ResultApi.Ok();
    }
}