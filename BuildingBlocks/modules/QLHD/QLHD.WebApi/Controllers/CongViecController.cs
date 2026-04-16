using QLHD.Application.CongViecs.Commands;
using QLHD.Application.CongViecs.DTOs;
using QLHD.Application.CongViecs.Queries;

namespace QLHD.WebApi.Controllers;

[Tags("Công việc (cong-viec)")]
public class CongViecController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    [HttpPost("cong-viec/them-moi")]
    [ProducesResponseType<ResultApi<CongViecDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Create(
        [FromBody] CongViecInsertModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new CongViecInsertCommand(model), cancellationToken);
        return ResultApi.Ok(entity.ToDto());
    }

    [HttpPut("cong-viec/cap-nhat/{id}")]
    [ProducesResponseType<ResultApi<CongViecDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Update(
        Guid id,
        [FromBody] CongViecUpdateModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new CongViecUpdateCommand(id, model), cancellationToken);
        return ResultApi.Ok(entity.ToDto());
    }

    [HttpGet("cong-viec/danh-sach")]
    [ProducesResponseType<ResultApi<PaginatedList<CongViecDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] CongViecSearchModel searchModel)
    {
        var result = await Mediator.Send(new CongViecGetListQuery(searchModel));
        return ResultApi.Ok(result);
    }

    [HttpDelete("cong-viec/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(Guid id)
    {
        await Mediator.Send(new CongViecDeleteCommand(id));
        return ResultApi.Ok();
    }

    [HttpGet("cong-viec/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<CongViecDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetById(Guid id)
    {
        var result = await Mediator.Send(new CongViecGetByIdQuery(id));
        return ResultApi.Ok(result);
    }
}