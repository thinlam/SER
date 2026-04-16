using QLHD.Application.DanhMucNguoiPhuTrachs.Commands;
using QLHD.Application.DanhMucNguoiPhuTrachs.DTOs;
using QLHD.Application.DanhMucNguoiPhuTrachs.Queries;

namespace QLHD.WebApi.Controllers;

[Tags("Danh mục người phụ trách (danh-muc-nguoi-phu-trach)")]
public class DanhMucNguoiPhuTrachController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    [HttpPost("danh-muc-nguoi-phu-trach/them-moi")]
    [ProducesResponseType<ResultApi<DanhMucNguoiPhuTrachDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Create(
        [FromBody] DanhMucNguoiPhuTrachInsertModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new DanhMucNguoiPhuTrachInsertCommand(model), cancellationToken);
        return ResultApi.Ok(new DanhMucNguoiPhuTrachDto
        {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Used = entity.Used,
            UserPortalId = entity.UserPortalId
        });
    }

    [HttpPut("danh-muc-nguoi-phu-trach/cap-nhat/{id}")]
    [ProducesResponseType<ResultApi<DanhMucNguoiPhuTrachDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Update(
        int id,
        [FromBody] DanhMucNguoiPhuTrachUpdateModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new DanhMucNguoiPhuTrachUpdateCommand(id, model), cancellationToken);
        return ResultApi.Ok(new DanhMucNguoiPhuTrachDto
        {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Used = entity.Used,
            UserPortalId = entity.UserPortalId
        });
    }

    [HttpGet("danh-muc-nguoi-phu-trach/danh-sach")]
    [ProducesResponseType<ResultApi<PaginatedList<DanhMucNguoiPhuTrachDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] DanhMucNguoiPhuTrachSearchModel searchModel)
    {
        var result = await Mediator.Send(new DanhMucNguoiPhuTrachGetListQuery(searchModel));
        return ResultApi.Ok(result);
    }

    [HttpGet("danh-muc-nguoi-phu-trach/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<DanhMucNguoiPhuTrachDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetById(int id)
    {
        var result = await Mediator.Send(new DanhMucNguoiPhuTrachGetByIdQuery(id));
        return ResultApi.Ok(result);
    }

    [HttpGet("danh-muc-nguoi-phu-trach/combobox")]
    [ProducesResponseType<ResultApi<List<ComboBoxDto<int>>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetCombobox()
    {
        var result = await Mediator.Send(new DanhMucNguoiPhuTrachGetComboboxQuery());
        return ResultApi.Ok(result);
    }

    [HttpDelete("danh-muc-nguoi-phu-trach/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(int id)
    {
        await Mediator.Send(new DanhMucNguoiPhuTrachDeleteCommand(id));
        return ResultApi.Ok();
    }
}