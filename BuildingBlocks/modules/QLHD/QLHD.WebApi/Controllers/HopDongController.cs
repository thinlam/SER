using BuildingBlocks.Application.Attachments.Commands;
using BuildingBlocks.Application.Attachments.Queries;
using QLHD.Application.HopDongs.Commands;
using QLHD.Application.HopDongs.DTOs;
using QLHD.Application.HopDongs.Queries;
using QLHD.Domain.Constants;

namespace QLHD.WebApi.Controllers;

[Tags("Hợp đồng (hop-dong)")]
public class HopDongController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider) {
    [HttpPost("hop-dong/them-moi")]
    [ProducesResponseType<ResultApi<HopDongDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Create(
        [FromBody] HopDongInsertModel model,
        CancellationToken cancellationToken = default) {
        var dto = await Mediator.Send(new HopDongInsertCommand(model), cancellationToken);

        var files = model.DanhSachTepDinhKem?.ToEntities(dto.Id.ToString(), GroupTypeConstants.HopDong).ToList();
        if (files != null && files.Count > 0)
            await Mediator.Send(new AttachmentInsertCommand(files), cancellationToken);

        dto.DanhSachTepDinhKem = files?.ToListDto();
        return ResultApi.Ok(dto);
    }

    [HttpPut("hop-dong/cap-nhat/{id}")]
    [ProducesResponseType<ResultApi<HopDongDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Update(
        Guid id,
        [FromBody] HopDongUpdateModel model,
        CancellationToken cancellationToken = default) {
        var dto = await Mediator.Send(new HopDongUpdateCommand(id, model), cancellationToken);

        var files = model.DanhSachTepDinhKem?.ToEntities(dto.Id.ToString(), GroupTypeConstants.HopDong).ToList();
        await Mediator.Send(new AttachmentBulkInsertOrUpdateCommand {
            GroupId = dto.Id.ToString(),
            Attachments = files,
        }, cancellationToken);

        dto.DanhSachTepDinhKem = await Mediator.Send(new GetAttachmentsQuery([dto.Id.ToString()]), cancellationToken);
        return ResultApi.Ok(dto);
    }

    [HttpGet("hop-dong/danh-sach")]
    [ProducesResponseType<ResultApi<PaginatedList<HopDongDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] HopDongSearchModel searchModel) {
        var result = await Mediator.Send(new HopDongGetListQuery(searchModel));
        return ResultApi.Ok(result);
    }

    [HttpDelete("hop-dong/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(Guid id) {
        await Mediator.Send(new HopDongDeleteCommand(id));
        return ResultApi.Ok();
    }

    [HttpGet("hop-dong/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<HopDongDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetById(Guid id) {
        var result = await Mediator.Send(new HopDongGetByIdQuery(id));
        return ResultApi.Ok(result);
    }
}