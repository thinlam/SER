using QLHD.Application.DanhMucLoaiTrangThais.Commands;
using QLHD.Application.DanhMucLoaiTrangThais.DTOs;
using QLHD.Application.DanhMucLoaiTrangThais.Queries;

namespace QLHD.WebApi.Controllers;

[Tags("Danh mục loại trạng thái (danh-muc-loai-trang-thai)")]
public class DanhMucLoaiTrangThaiController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    [HttpPost("danh-muc-loai-trang-thai/them-moi")]
    [ProducesResponseType<ResultApi<DanhMucLoaiTrangThaiDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Create(
        [FromBody] DanhMucLoaiTrangThaiInsertModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new DanhMucLoaiTrangThaiInsertCommand(model), cancellationToken);
        return ResultApi.Ok(new DanhMucLoaiTrangThaiDto
        {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Used = entity.Used
        });
    }

    [HttpPut("danh-muc-loai-trang-thai/cap-nhat/{id}")]
    [ProducesResponseType<ResultApi<DanhMucLoaiTrangThaiDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Update(
        int id,
        [FromBody] DanhMucLoaiTrangThaiUpdateModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new DanhMucLoaiTrangThaiUpdateCommand(id, model), cancellationToken);
        return ResultApi.Ok(new DanhMucLoaiTrangThaiDto
        {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Used = entity.Used
        });
    }

    [HttpGet("danh-muc-loai-trang-thai/danh-sach")]
    [ProducesResponseType<ResultApi<PaginatedList<DanhMucLoaiTrangThaiDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] DanhMucLoaiTrangThaiSearchModel searchModel)
    {
        var result = await Mediator.Send(new DanhMucLoaiTrangThaiGetListQuery(searchModel));
        return ResultApi.Ok(result);
    }

    [HttpGet("danh-muc-loai-trang-thai/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<DanhMucLoaiTrangThaiDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetById(int id)
    {
        var result = await Mediator.Send(new DanhMucLoaiTrangThaiGetByIdQuery(id));
        return ResultApi.Ok(result);
    }

    [HttpGet("danh-muc-loai-trang-thai/combobox")]
    [ProducesResponseType<ResultApi<List<ComboBoxDto<int>>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetCombobox()
    {
        var result = await Mediator.Send(new DanhMucLoaiTrangThaiGetComboboxQuery());
        return ResultApi.Ok(result);
    }

    [HttpDelete("danh-muc-loai-trang-thai/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(int id)
    {
        await Mediator.Send(new DanhMucLoaiTrangThaiDeleteCommand(id));
        return ResultApi.Ok();
    }
}