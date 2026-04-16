using QLHD.Application.DuAns.Commands;
using QLHD.Application.DuAns.DTOs;
using QLHD.Application.DuAns.Queries;

namespace QLHD.WebApi.Controllers;

[Tags("Dự án (du-an)")]
public class DuAnController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    [HttpPost("du-an/them-moi")]
    [ProducesResponseType<ResultApi<DuAnDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Create(
        [FromBody] DuAnInsertModel model,
        CancellationToken cancellationToken = default)
    {
        var dto = await Mediator.Send(new DuAnInsertCommand(model), cancellationToken);
        return ResultApi.Ok(dto);
    }

    [HttpPut("du-an/cap-nhat/{id}")]
    [ProducesResponseType<ResultApi<DuAnDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Update(
        Guid id,
        [FromBody] DuAnUpdateModel model,
        CancellationToken cancellationToken = default)
    {
        var dto = await Mediator.Send(new DuAnUpdateCommand(id, model), cancellationToken);
        return ResultApi.Ok(dto);
    }

    [HttpGet("du-an/danh-sach")]
    [ProducesResponseType<ResultApi<PaginatedList<DuAnDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] DuAnSearchModel searchModel)
    {
        var result = await Mediator.Send(new DuAnGetListQuery(searchModel));
        return ResultApi.Ok(result);
    }

    [HttpDelete("du-an/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(Guid id)
    {
        await Mediator.Send(new DuAnDeleteCommand(id));
        return ResultApi.Ok();
    }

    [HttpGet("du-an/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<DuAnDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetById(Guid id)
    {
        var result = await Mediator.Send(new DuAnGetByIdQuery(id));
        return ResultApi.Ok(result);
    }
}