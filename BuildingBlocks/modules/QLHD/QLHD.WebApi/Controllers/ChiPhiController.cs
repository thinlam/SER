using QLHD.Application.ChiPhis.Commands;
using QLHD.Application.ChiPhis.DTOs;
using QLHD.Application.ChiPhis.Queries;

namespace QLHD.WebApi.Controllers;

/// <summary>
/// API quản lý chi phí - Đánh giá hiệu quả
/// </summary>
[Tags("Chi phí (chi-phi)")]
public class ChiPhiController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    /// <summary>
    /// Lấy danh sách hợp đồng có chi phí
    /// </summary>
    [HttpGet("chi-phi/danh-sach")]
    [ProducesResponseType<ResultApi<PaginatedList<HopDongCoChiPhiDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] ChiPhiSearchModel searchModel, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new ChiPhiGetListQuery(searchModel), cancellationToken);
        return ResultApi.Ok(result);
    }

    /// <summary>
    /// Lấy danh sách chi phí theo HopDongId
    /// </summary>
    [HttpGet("chi-phi/{hopDongId}/danh-sach")]
    [ProducesResponseType<ResultApi<List<ChiPhiDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetByHopDong(Guid hopDongId, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new ChiPhiGetByHopDongQuery(hopDongId), cancellationToken);
        return ResultApi.Ok(result);
    }

    /// <summary>
    /// Thêm mới hoặc cập nhật chi phí (kế hoạch + thực tế)
    /// Id null -> insert, Id có giá trị -> update
    /// </summary>
    [HttpPost("chi-phi/luu")]
    [ProducesResponseType<ResultApi<ChiPhiDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> InsertOrUpdate([FromBody] ChiPhiInsertOrUpdateModel model, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new ChiPhiInsertOrUpdateCommand(model), cancellationToken);
        return ResultApi.Ok(result);
    }

    /// <summary>
    /// Xóa chi phí
    /// </summary>
    [HttpDelete("chi-phi/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        await Mediator.Send(new ChiPhiDeleteCommand(id), cancellationToken);
        return ResultApi.Ok();
    }

    /// <summary>
    /// Lấy chi tiết chi phí theo Id
    /// </summary>
    [HttpGet("chi-phi/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<ChiPhiDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetDetail(
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new ChiPhiGetDetailQuery(id), cancellationToken);
        return ResultApi.Ok(result);
    }
}