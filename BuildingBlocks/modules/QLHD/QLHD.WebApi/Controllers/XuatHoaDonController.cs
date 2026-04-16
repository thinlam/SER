using QLHD.Application.XuatHoaDons.Commands;
using QLHD.Application.XuatHoaDons.DTOs;
using QLHD.Application.XuatHoaDons.Queries;

namespace QLHD.WebApi.Controllers;

/// <summary>
/// API quản lý xuất hóa đơn
/// </summary>
[Tags("Xuất hóa đơn (xuat-hoa-don)")]
public class XuatHoaDonController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider) {
    /// <summary>
    /// Lấy danh sách hợp đồng có kế hoạch xuất hóa đơn
    /// </summary>
    [HttpGet("xuat-hoa-don/danh-sach")]
    [ProducesResponseType<ResultApi<PaginatedList<HopDongXuatHoaDonDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] XuatHoaDonSearchModel searchModel, CancellationToken cancellationToken = default) {
        var result = await Mediator.Send(new XuatHoaDonGetListQuery(searchModel), cancellationToken);
        return ResultApi.Ok(result);
    }

    /// <summary>
    /// Lấy danh sách kế hoạch xuất hóa đơn left join với thực tế theo HopDongId
    /// </summary>
    [HttpGet("xuat-hoa-don/{hopDongId}/danh-sach")]
    [ProducesResponseType<ResultApi<List<XuatHoaDonDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetByHopDong(Guid hopDongId, CancellationToken cancellationToken = default) {
        var result = await Mediator.Send(new XuatHoaDonGetByHopDongQuery(hopDongId), cancellationToken);
        return ResultApi.Ok(result);
    }

    /// <summary>
    /// Thêm mới hoặc cập nhật xuất hóa đơn (kế hoạch + thực tế)
    /// KeHoachId null → insert, KeHoachId có giá trị → update
    /// </summary>
    [HttpPost("xuat-hoa-don/luu")]
    [ProducesResponseType<ResultApi<XuatHoaDonDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> InsertOrUpdate([FromBody] XuatHoaDonInsertOrUpdateModel model, CancellationToken cancellationToken = default) {
        var result = await Mediator.Send(new XuatHoaDonInsertOrUpdateCommand(model), cancellationToken);
        return ResultApi.Ok(result);
    }

    /// <summary>
    /// Xóa xuất hóa đơn theo Id và HopDongId (routing)
    /// </summary>
    [HttpDelete("xuat-hoa-don/{hopDongId}/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(Guid hopDongId, Guid id, CancellationToken cancellationToken = default) {
        await Mediator.Send(new XuatHoaDonDeleteCommand(id, hopDongId), cancellationToken);
        return ResultApi.Ok();
    }

    /// <summary>
    /// Lấy chi tiết xuất hóa đơn theo Id 
    /// </summary>
    [HttpGet("xuat-hoa-don/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<XuatHoaDonDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetDetail( Guid id, CancellationToken cancellationToken = default) {
        var result = await Mediator.Send(new XuatHoaDonGetDetailQuery(id), cancellationToken);
        return ResultApi.Ok(result);
    }
}