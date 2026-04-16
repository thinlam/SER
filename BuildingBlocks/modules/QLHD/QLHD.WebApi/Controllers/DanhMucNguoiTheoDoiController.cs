using QLHD.Application.DanhMucNguoiTheoDois.Commands;
using QLHD.Application.DanhMucNguoiTheoDois.DTOs;
using QLHD.Application.DanhMucNguoiTheoDois.Queries;

namespace QLHD.WebApi.Controllers;

[Tags("Danh mục người theo dõi (danh-muc-nguoi-theo-doi)")]
public class DanhMucNguoiTheoDoiController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    [HttpPost("danh-muc-nguoi-theo-doi/them-moi")]
    [ProducesResponseType<ResultApi<DanhMucNguoiTheoDoiDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Create(
        [FromBody] DanhMucNguoiTheoDoiInsertModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new DanhMucNguoiTheoDoiInsertCommand(model), cancellationToken);
        return ResultApi.Ok(new DanhMucNguoiTheoDoiDto
        {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Used = entity.Used,
            UserPortalId = entity.UserPortalId
        });
    }

    [HttpPut("danh-muc-nguoi-theo-doi/cap-nhat/{id}")]
    [ProducesResponseType<ResultApi<DanhMucNguoiTheoDoiDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Update(
        int id,
        [FromBody] DanhMucNguoiTheoDoiUpdateModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new DanhMucNguoiTheoDoiUpdateCommand(id, model), cancellationToken);
        return ResultApi.Ok(new DanhMucNguoiTheoDoiDto
        {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Used = entity.Used,
            UserPortalId = entity.UserPortalId
        });
    }

    [HttpGet("danh-muc-nguoi-theo-doi/danh-sach")]
    [ProducesResponseType<ResultApi<PaginatedList<DanhMucNguoiTheoDoiDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] DanhMucNguoiTheoDoiSearchModel searchModel)
    {
        var result = await Mediator.Send(new DanhMucNguoiTheoDoiGetListQuery(searchModel));
        return ResultApi.Ok(result);
    }

    [HttpGet("danh-muc-nguoi-theo-doi/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<DanhMucNguoiTheoDoiDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetById(int id)
    {
        var result = await Mediator.Send(new DanhMucNguoiTheoDoiGetByIdQuery(id));
        return ResultApi.Ok(result);
    }

    [HttpGet("danh-muc-nguoi-theo-doi/combobox")]
    [ProducesResponseType<ResultApi<List<ComboBoxDto<int>>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetCombobox()
    {
        var result = await Mediator.Send(new DanhMucNguoiTheoDoiGetComboboxQuery());
        return ResultApi.Ok(result);
    }

    [HttpDelete("danh-muc-nguoi-theo-doi/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(int id)
    {
        await Mediator.Send(new DanhMucNguoiTheoDoiDeleteCommand(id));
        return ResultApi.Ok();
    }
}