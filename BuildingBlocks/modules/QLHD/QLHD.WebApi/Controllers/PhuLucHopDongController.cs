using BuildingBlocks.Application.Attachments.Commands;
using BuildingBlocks.Application.Attachments.Queries;
using BuildingBlocks.Domain.DTOs;
using QLHD.Application.PhuLucHopDongs.Commands;
using QLHD.Application.PhuLucHopDongs.DTOs;
using QLHD.Application.PhuLucHopDongs.Queries;
using QLHD.Domain.Constants;

namespace QLHD.WebApi.Controllers;

/// <summary>
/// API quản lý phụ lục hợp đồng
/// </summary>
[Tags("Phụ lục hợp đồng (phu-luc-hop-dong)")]
public class PhuLucHopDongController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    /// <summary>
    /// Lấy danh sách hợp đồng có phụ lục hợp đồng
    /// </summary>
    [HttpGet("phu-luc-hop-dong/danh-sach")]
    [ProducesResponseType<ResultApi<PaginatedList<HopDongCoPhuLucDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] AggregateRootSearch searchModel, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new PhuLucHopDongGetListQuery(searchModel), cancellationToken);
        return ResultApi.Ok(result);
    }

    /// <summary>
    /// Lấy danh sách phụ lục hợp đồng theo HopDongId
    /// </summary>
    [HttpGet("phu-luc-hop-dong/{hopDongId}/danh-sach")]
    [ProducesResponseType<ResultApi<List<PhuLucHopDongDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetByHopDong(Guid hopDongId, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new PhuLucHopDongGetByHopDongQuery(hopDongId), cancellationToken);
        return ResultApi.Ok(result);
    }

    /// <summary>
    /// Lấy chi tiết phụ lục hợp đồng theo Id
    /// </summary>
    [HttpGet("phu-luc-hop-dong/{id}")]
    [ProducesResponseType<ResultApi<PhuLucHopDongDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new PhuLucHopDongGetByIdQuery(id), cancellationToken);
        return ResultApi.Ok(result);
    }

    /// <summary>
    /// Thêm mới phụ lục hợp đồng
    /// </summary>
    [HttpPost("phu-luc-hop-dong/them")]
    [ProducesResponseType<ResultApi<PhuLucHopDongDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Insert([FromBody] PhuLucHopDongInsertModel model, CancellationToken cancellationToken = default)
    {
        var dto = await Mediator.Send(new PhuLucHopDongInsertCommand(model), cancellationToken);

        var files = model.DanhSachTepDinhKem?.ToEntities(dto.Id.ToString(), GroupTypeConstants.PhuLucHopDong).ToList();
        if (files != null && files.Count > 0)
            await Mediator.Send(new AttachmentInsertCommand(files), cancellationToken);

        dto.DanhSachTepDinhKem = files?.ToListDto();
        return ResultApi.Ok(dto);
    }

    /// <summary>
    /// Cập nhật phụ lục hợp đồng
    /// </summary>
    [HttpPut("phu-luc-hop-dong/cap-nhat/{id}")]
    [ProducesResponseType<ResultApi<PhuLucHopDongDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Update(Guid id, [FromBody] PhuLucHopDongInsertModel model, CancellationToken cancellationToken = default)
    {
        var dto = await Mediator.Send(new PhuLucHopDongUpdateCommand(id, model), cancellationToken);

        var files = model.DanhSachTepDinhKem?.ToEntities(dto.Id.ToString(), GroupTypeConstants.PhuLucHopDong).ToList();
        await Mediator.Send(new AttachmentBulkInsertOrUpdateCommand() {
            GroupId = dto.Id.ToString(),
            Attachments = files,
        }, cancellationToken);

        dto.DanhSachTepDinhKem = await Mediator.Send(new GetAttachmentsQuery([dto.Id.ToString()]), cancellationToken);
        return ResultApi.Ok(dto);
    }

    /// <summary>
    /// Xóa phụ lục hợp đồng
    /// </summary>
    [HttpDelete("phu-luc-hop-dong/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        await Mediator.Send(new PhuLucHopDongDeleteCommand(id), cancellationToken);
        return ResultApi.Ok();
    }
}