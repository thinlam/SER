using QLHD.Application.DanhMucGiamDocs.Commands;
using QLHD.Application.DanhMucGiamDocs.DTOs;
using QLHD.Application.DanhMucGiamDocs.Queries;

namespace QLHD.WebApi.Controllers;

[Tags("Danh mục giám đốc (danh-muc-giam-doc)")]
public class DanhMucGiamDocController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    [HttpPost("danh-muc-giam-doc/them-moi")]
    [ProducesResponseType<ResultApi<DanhMucGiamDocDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Create(
        [FromBody] DanhMucGiamDocInsertModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new DanhMucGiamDocInsertCommand(model), cancellationToken);
        return ResultApi.Ok(new DanhMucGiamDocDto
        {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Used = entity.Used,
            UserPortalId = entity.UserPortalId
        });
    }

    [HttpPut("danh-muc-giam-doc/cap-nhat/{id}")]
    [ProducesResponseType<ResultApi<DanhMucGiamDocDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Update(
        int id,
        [FromBody] DanhMucGiamDocUpdateModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new DanhMucGiamDocUpdateCommand(id, model), cancellationToken);
        return ResultApi.Ok(new DanhMucGiamDocDto
        {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Used = entity.Used,
            UserPortalId = entity.UserPortalId
        });
    }

    [HttpGet("danh-muc-giam-doc/danh-sach")]
    [ProducesResponseType<ResultApi<PaginatedList<DanhMucGiamDocDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] DanhMucGiamDocSearchModel searchModel)
    {
        var result = await Mediator.Send(new DanhMucGiamDocGetListQuery(searchModel));
        return ResultApi.Ok(result);
    }

    [HttpGet("danh-muc-giam-doc/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<DanhMucGiamDocDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetById(int id)
    {
        var result = await Mediator.Send(new DanhMucGiamDocGetByIdQuery(id));
        return ResultApi.Ok(result);
    }

    [HttpGet("danh-muc-giam-doc/combobox")]
    [ProducesResponseType<ResultApi<List<ComboBoxDto<int>>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetCombobox()
    {
        var result = await Mediator.Send(new DanhMucGiamDocGetComboboxQuery());
        return ResultApi.Ok(result);
    }

    [HttpDelete("danh-muc-giam-doc/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(int id)
    {
        await Mediator.Send(new DanhMucGiamDocDeleteCommand(id));
        return ResultApi.Ok();
    }
}