
using QLHD.Application.ThuTiens.Commands;
using QLHD.Application.ThuTiens.DTOs;
using QLHD.Application.ThuTiens.Queries;

namespace QLHD.WebApi.Controllers;

/// <summary>
/// API quản lý thu tiền
/// </summary>
[Tags("Thu tiền (thu-tien)")]
public class ThuTienController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider) {
    /// <summary>
    /// Lấy danh sách hợp đồng có kế hoạch thu tiền
    /// </summary>
    [HttpGet("thu-tien/danh-sach")]
    [ProducesResponseType<ResultApi<PaginatedList<HopDongThuTienDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] ThuTienSearchModel searchModel, CancellationToken cancellationToken = default) {
        var result = await Mediator.Send(new ThuTienGetListQuery(searchModel), cancellationToken);
        return ResultApi.Ok(result);
    }

    /// <summary>
    /// Lấy danh sách kế hoạch thu tiền left join với thực tế theo HopDongId
    /// </summary>
    [HttpGet("thu-tien/{hopDongId}/danh-sach")]
    [ProducesResponseType<ResultApi<List<ThuTienDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetByHopDong(Guid hopDongId, CancellationToken cancellationToken = default) {
        var result = await Mediator.Send(new ThuTienGetByHopDongQuery(hopDongId), cancellationToken);
        return ResultApi.Ok(result);
    }

    /// <summary>
    /// Thêm mới hoặc cập nhật thu tiền (kế hoạch + thực tế)
    /// KeHoachId null → insert, KeHoachId có giá trị → update
    /// </summary>
    [HttpPost("thu-tien/luu")]
    [ProducesResponseType<ResultApi<ThuTienDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> InsertOrUpdate([FromBody] ThuTienInsertOrUpdateModel model, CancellationToken cancellationToken = default) {
        var result = await Mediator.Send(new ThuTienInsertOrUpdateCommand(model), cancellationToken);
        return ResultApi.Ok(result);
    }

    /// <summary>
    /// Xóa thực tế thu tiền (cascade xóa kế hoạch)
    /// </summary>
    [HttpDelete("thu-tien/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(Guid id, CancellationToken cancellationToken = default) {
        await Mediator.Send(new ThuTienDeleteCommand(id), cancellationToken);
        return ResultApi.Ok();
    }

    /// <summary>
    /// Lấy chi tiết thu tiền theo ThucTeThuTienId hoặc KeHoachThuTienId
    /// </summary>
    [HttpGet("thu-tien/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<ThuTienDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetDetail(
        [FromRoute] Guid Id,
        CancellationToken cancellationToken = default) {
        var result = await Mediator.Send(new ThuTienGetDetailQuery(Id), cancellationToken);
        return ResultApi.Ok(result);
    }
}