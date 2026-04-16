using QLHD.Application.BaoCaoTienDos.Commands;
using QLHD.Application.BaoCaoTienDos.DTOs;
using QLHD.Application.BaoCaoTienDos.Queries;

namespace QLHD.WebApi.Controllers;

[Tags("Báo cáo tiến độ (bao-cao-tien-do)")]
public class BaoCaoTienDoController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    [HttpPost("bao-cao-tien-do/them-moi")]
    [ProducesResponseType<ResultApi<BaoCaoTienDoDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Create(
        [FromBody] BaoCaoTienDoInsertModel model,
        CancellationToken cancellationToken = default)
    {
        var dto = await Mediator.Send(new BaoCaoTienDoInsertCommand(model), cancellationToken);
        return ResultApi.Ok(dto);
    }

    [HttpPut("bao-cao-tien-do/cap-nhat/{id}")]
    [ProducesResponseType<ResultApi<BaoCaoTienDoDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Update(
        Guid id,
        [FromBody] BaoCaoTienDoUpdateModel model,
        CancellationToken cancellationToken = default)
    {
        var dto = await Mediator.Send(new BaoCaoTienDoUpdateCommand(id, model), cancellationToken);
        return ResultApi.Ok(dto);
    }

    [HttpGet("bao-cao-tien-do/danh-sach")]
    [ProducesResponseType<ResultApi<List<BaoCaoTienDoDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList(Guid tienDoId, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new BaoCaoTienDoGetListQuery(tienDoId), cancellationToken);
        return ResultApi.Ok(result);
    }

    [HttpDelete("bao-cao-tien-do/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        await Mediator.Send(new BaoCaoTienDoDeleteCommand(id), cancellationToken);
        return ResultApi.Ok();
    }

    [HttpGet("bao-cao-tien-do/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<BaoCaoTienDoDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new BaoCaoTienDoGetByIdQuery(id), cancellationToken);
        return ResultApi.Ok(result);
    }

    [HttpGet("bao-cao-tien-do/cho-duyet")]
    [ProducesResponseType<ResultApi<List<BaoCaoTienDoDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetPending(long nguoiDuyetId, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new BaoCaoTienDoGetPendingByNguoiDuyetQuery(nguoiDuyetId), cancellationToken);
        return ResultApi.Ok(result);
    }

    [HttpPost("bao-cao-tien-do/duyet/{id}")]
    [ProducesResponseType<ResultApi<BaoCaoTienDoDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Duyet(
        Guid id,
        [FromBody] BaoCaoTienDoDuyetModel model,
        CancellationToken cancellationToken = default)
    {
        var dto = await Mediator.Send(new BaoCaoTienDoDuyetCommand(id, model.NguoiDuyetId, model.Duyet), cancellationToken);
        return ResultApi.Ok(dto);
    }
}

public record BaoCaoTienDoDuyetModel(long NguoiDuyetId, bool Duyet);