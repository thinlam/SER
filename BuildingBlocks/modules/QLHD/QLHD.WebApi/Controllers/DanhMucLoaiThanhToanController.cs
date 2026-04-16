using QLHD.Application.DanhMucLoaiThanhToans.Commands;
using QLHD.Application.DanhMucLoaiThanhToans.DTOs;
using QLHD.Application.DanhMucLoaiThanhToans.Queries;

namespace QLHD.WebApi.Controllers;

[Tags("Danh mục loại thanh toán (danh-muc-loai-thanh-toan)")]
public class DanhMucLoaiThanhToanController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    [HttpPost("danh-muc-loai-thanh-toan/them-moi")]
    [ProducesResponseType<ResultApi<DanhMucLoaiThanhToanDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Create(
        [FromBody] DanhMucLoaiThanhToanInsertModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new DanhMucLoaiThanhToanInsertCommand(model), cancellationToken);
        return ResultApi.Ok(new DanhMucLoaiThanhToanDto
        {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Used = entity.Used,
            IsDefault = entity.IsDefault
        });
    }

    [HttpPut("danh-muc-loai-thanh-toan/cap-nhat/{id}")]
    [ProducesResponseType<ResultApi<DanhMucLoaiThanhToanDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Update(
        int id,
        [FromBody] DanhMucLoaiThanhToanUpdateModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new DanhMucLoaiThanhToanUpdateCommand(id, model), cancellationToken);
        return ResultApi.Ok(new DanhMucLoaiThanhToanDto
        {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Used = entity.Used,
            IsDefault = entity.IsDefault
        });
    }

    [HttpGet("danh-muc-loai-thanh-toan/danh-sach")]
    [ProducesResponseType<ResultApi<PaginatedList<DanhMucLoaiThanhToanDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] DanhMucLoaiThanhToanSearchModel searchModel)
    {
        var result = await Mediator.Send(new DanhMucLoaiThanhToanGetListQuery(searchModel));
        return ResultApi.Ok(result);
    }

    [HttpGet("danh-muc-loai-thanh-toan/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<DanhMucLoaiThanhToanDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetById(int id)
    {
        var result = await Mediator.Send(new DanhMucLoaiThanhToanGetByIdQuery(id));
        return ResultApi.Ok(result);
    }

    [HttpGet("danh-muc-loai-thanh-toan/combobox")]
    [ProducesResponseType<ResultApi<List<ComboBoxDto<int>>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetCombobox()
    {
        var result = await Mediator.Send(new DanhMucLoaiThanhToanGetComboboxQuery());
        return ResultApi.Ok(result);
    }

    [HttpDelete("danh-muc-loai-thanh-toan/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(int id)
    {
        await Mediator.Send(new DanhMucLoaiThanhToanDeleteCommand(id));
        return ResultApi.Ok();
    }
}