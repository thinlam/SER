using QLHD.Application.TienDos.Commands;
using QLHD.Application.TienDos.DTOs;
using QLHD.Application.TienDos.Queries;

namespace QLHD.WebApi.Controllers;

[Tags("Tiến độ (tien-do)")]
public class TienDoController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    [HttpPost("tien-do/them-moi")]
    [ProducesResponseType<ResultApi<TienDoDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Create(
        [FromBody] TienDoInsertModel model,
        CancellationToken cancellationToken = default)
    {
        var dto = await Mediator.Send(new TienDoInsertCommand(model), cancellationToken);
        return ResultApi.Ok(dto);
    }

    [HttpPut("tien-do/cap-nhat/{id}")]
    [ProducesResponseType<ResultApi<TienDoDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Update(
        Guid id,
        [FromBody] TienDoUpdateModel model,
        CancellationToken cancellationToken = default)
    {
        var dto = await Mediator.Send(new TienDoUpdateCommand(id, model), cancellationToken);
        return ResultApi.Ok(dto);
    }

    [HttpGet("tien-do/danh-sach")]
    [ProducesResponseType<ResultApi<List<TienDoDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList(Guid hopDongId, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new TienDoGetListQuery(hopDongId), cancellationToken);
        return ResultApi.Ok(result);
    }

    [HttpDelete("tien-do/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        await Mediator.Send(new TienDoDeleteCommand(id), cancellationToken);
        return ResultApi.Ok();
    }

    [HttpGet("tien-do/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<TienDoDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new TienDoGetByIdQuery(id), cancellationToken);
        return ResultApi.Ok(result);
    }
}