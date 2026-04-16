using QLHD.Application.KhoKhanVuongMacs.Commands;
using QLHD.Application.KhoKhanVuongMacs.DTOs;
using QLHD.Application.KhoKhanVuongMacs.Queries;

namespace QLHD.WebApi.Controllers;

[Tags("Khó khăn vướng mắc (kho-khan-vuong-mac)")]
public class KhoKhanVuongMacController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    [HttpPost("kho-khan-vuong-mac/them-moi")]
    [ProducesResponseType<ResultApi<KhoKhanVuongMacDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Create(
        [FromBody] KhoKhanVuongMacInsertModel model,
        CancellationToken cancellationToken = default)
    {
        var dto = await Mediator.Send(new KhoKhanVuongMacInsertCommand(model), cancellationToken);
        return ResultApi.Ok(dto);
    }

    [HttpPut("kho-khan-vuong-mac/cap-nhat/{id}")]
    [ProducesResponseType<ResultApi<KhoKhanVuongMacDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Update(
        Guid id,
        [FromBody] KhoKhanVuongMacUpdateModel model,
        CancellationToken cancellationToken = default)
    {
        var dto = await Mediator.Send(new KhoKhanVuongMacUpdateCommand(id, model), cancellationToken);
        return ResultApi.Ok(dto);
    }

    [HttpGet("kho-khan-vuong-mac/danh-sach")]
    [ProducesResponseType<ResultApi<List<KhoKhanVuongMacDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList(Guid hopDongId, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new KhoKhanVuongMacGetListQuery(hopDongId), cancellationToken);
        return ResultApi.Ok(result);
    }

    [HttpDelete("kho-khan-vuong-mac/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        await Mediator.Send(new KhoKhanVuongMacDeleteCommand(id), cancellationToken);
        return ResultApi.Ok();
    }

    [HttpGet("kho-khan-vuong-mac/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<KhoKhanVuongMacDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new KhoKhanVuongMacGetByIdQuery(id), cancellationToken);
        return ResultApi.Ok(result);
    }
}