using QLHD.Application.DanhMucLoaiChiPhis.Commands;
using QLHD.Application.DanhMucLoaiChiPhis.DTOs;
using QLHD.Application.DanhMucLoaiChiPhis.Queries;

namespace QLHD.WebApi.Controllers;

[Tags("Danh mục loại chi phí (danh-muc-loai-chi-phi)")]
public class DanhMucLoaiChiPhiController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    [HttpPost("danh-muc-loai-chi-phi/them-moi")]
    [ProducesResponseType<ResultApi<DanhMucLoaiChiPhiDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Create(
        [FromBody] DanhMucLoaiChiPhiInsertModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new DanhMucLoaiChiPhiInsertCommand(model), cancellationToken);
        return ResultApi.Ok(new DanhMucLoaiChiPhiDto
        {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Used = entity.Used,
            IsDefault = entity.IsDefault
        });
    }

    [HttpPut("danh-muc-loai-chi-phi/cap-nhat/{id}")]
    [ProducesResponseType<ResultApi<DanhMucLoaiChiPhiDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Update(
        int id,
        [FromBody] DanhMucLoaiChiPhiUpdateModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new DanhMucLoaiChiPhiUpdateCommand(id, model), cancellationToken);
        return ResultApi.Ok(new DanhMucLoaiChiPhiDto
        {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Used = entity.Used,
            IsDefault = entity.IsDefault
        });
    }

    [HttpGet("danh-muc-loai-chi-phi/danh-sach")]
    [ProducesResponseType<ResultApi<PaginatedList<DanhMucLoaiChiPhiDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] DanhMucLoaiChiPhiSearchModel searchModel)
    {
        var result = await Mediator.Send(new DanhMucLoaiChiPhiGetListQuery(searchModel));
        return ResultApi.Ok(result);
    }

    [HttpGet("danh-muc-loai-chi-phi/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<DanhMucLoaiChiPhiDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetById(int id)
    {
        var result = await Mediator.Send(new DanhMucLoaiChiPhiGetByIdQuery(id));
        return ResultApi.Ok(result);
    }

    [HttpGet("danh-muc-loai-chi-phi/combobox")]
    [ProducesResponseType<ResultApi<List<ComboBoxDto<int>>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetCombobox()
    {
        var result = await Mediator.Send(new DanhMucLoaiChiPhiGetComboboxQuery());
        return ResultApi.Ok(result);
    }

    [HttpDelete("danh-muc-loai-chi-phi/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(int id)
    {
        await Mediator.Send(new DanhMucLoaiChiPhiDeleteCommand(id));
        return ResultApi.Ok();
    }
}