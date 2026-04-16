using QLHD.Application.KeHoachKinhDoanhNams.Commands;
using QLHD.Application.KeHoachKinhDoanhNams.DTOs;
using QLHD.Application.KeHoachKinhDoanhNams.Queries;

namespace QLHD.WebApi.Controllers;

[Tags("Kế hoạch kinh doanh năm (ke-hoach-kinh-doanh-nam)")]
public class KeHoachKinhDoanhNamController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    [HttpPost("ke-hoach-kinh-doanh-nam/them-moi")]
    [ProducesResponseType<ResultApi<KeHoachKinhDoanhNamDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Create(
        [FromBody] KeHoachKinhDoanhNamInsertModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new KeHoachKinhDoanhNamInsertCommand(model), cancellationToken);
        return ResultApi.Ok(entity.ToDto());
    }

    [HttpPut("ke-hoach-kinh-doanh-nam/cap-nhat/{id}")]
    [ProducesResponseType<ResultApi<KeHoachKinhDoanhNamDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Update(
        Guid id,
        [FromBody] KeHoachKinhDoanhNamUpdateModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new KeHoachKinhDoanhNamUpdateCommand(id, model), cancellationToken);
        return ResultApi.Ok(entity.ToDto());
    }

    [HttpGet("ke-hoach-kinh-doanh-nam/danh-sach")]
    [ProducesResponseType<ResultApi<PaginatedList<KeHoachKinhDoanhNamDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] KeHoachKinhDoanhNamSearchModel searchModel)
    {
        var result = await Mediator.Send(new KeHoachKinhDoanhNamGetListQuery(searchModel));
        return ResultApi.Ok(result);
    }

    [HttpDelete("ke-hoach-kinh-doanh-nam/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(Guid id)
    {
        await Mediator.Send(new KeHoachKinhDoanhNamDeleteCommand(id));
        return ResultApi.Ok();
    }

    [HttpGet("ke-hoach-kinh-doanh-nam/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<KeHoachKinhDoanhNamDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetById(Guid id)
    {
        var result = await Mediator.Send(new KeHoachKinhDoanhNamGetByIdQuery(id));
        return ResultApi.Ok(result);
    }
}