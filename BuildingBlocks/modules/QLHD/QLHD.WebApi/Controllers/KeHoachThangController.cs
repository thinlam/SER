using QLHD.Application.KeHoachThangs.DTOs;
using QLHD.Application.KeHoachThangs.Commands;
using QLHD.Application.KeHoachThangs.Queries;
using QLHD.Application.KeHoachThang_Versions.DTOs;

namespace QLHD.WebApi.Controllers;

[Tags("Kế hoạch tháng (ke-hoach-thang)")]
public class KeHoachThangController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    [HttpPost("ke-hoach-thang/them-moi")]
    [ProducesResponseType<ResultApi<KeHoachThangDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Create(
        [FromBody] KeHoachThangInsertModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new KeHoachThangInsertCommand(model), cancellationToken);
        return ResultApi.Ok(entity.ToDto());
    }

    [HttpPut("ke-hoach-thang/cap-nhat/{id}")]
    [ProducesResponseType<ResultApi<KeHoachThangDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Update(
        int id,
        [FromBody] KeHoachThangUpdateModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new KeHoachThangUpdateCommand(id, model), cancellationToken);
        return ResultApi.Ok(entity.ToDto());
    }

    [HttpGet("ke-hoach-thang/danh-sach")]
    [ProducesResponseType<ResultApi<PaginatedList<KeHoachThangDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] KeHoachThangSearchModel searchModel)
    {
        var result = await Mediator.Send(new KeHoachThangGetListQuery(searchModel));
        return ResultApi.Ok(result);
    }

    [HttpDelete("ke-hoach-thang/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(int id)
    {
        await Mediator.Send(new KeHoachThangDeleteCommand(id));
        return ResultApi.Ok();
    }

    [HttpGet("ke-hoach-thang/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<KeHoachThangDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetById(int id)
    {
        var result = await Mediator.Send(new KeHoachThangGetByIdQuery(id));
        return ResultApi.Ok(result);
    }

    [HttpGet("ke-hoach-thang/combobox")]
    [ProducesResponseType<ResultApi<List<ComboBoxDto<int>>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetCombobox()
    {
        var result = await Mediator.Send(new KeHoachThangGetComboboxQuery());
        return ResultApi.Ok(result);
    }

    /// <summary>
    /// Chốt kế hoạch tháng - tạo snapshot dữ liệu thu tiền, xuất hóa đơn, chi phí
    /// </summary>
    /// <param name="id">ID kế hoạch tháng</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Summary of snapshot counts per table</returns>
    [HttpPost("ke-hoach-thang/chot/{id}")]
    [ProducesResponseType<ResultApi<KeHoachThang_VersionsSummaryDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Chot(int id, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new KeHoachThangChotCommand { KeHoachThangId = id }, cancellationToken);
        return ResultApi.Ok(result);
    }
}