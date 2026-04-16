using QLHD.Application.DanhMucLoaiLais.Commands;
using QLHD.Application.DanhMucLoaiLais.DTOs;
using QLHD.Application.DanhMucLoaiLais.Queries;

namespace QLHD.WebApi.Controllers;

[Tags("Danh mục loại lãi (danh-muc-loai-lai)")]
public class DanhMucLoaiLaiController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    [HttpPost("danh-muc-loai-lai/them-moi")]
    [ProducesResponseType<ResultApi<DanhMucLoaiLaiDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Create(
        [FromBody] DanhMucLoaiLaiInsertModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new DanhMucLoaiLaiInsertCommand(model), cancellationToken);
        return ResultApi.Ok(new DanhMucLoaiLaiDto
        {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Used = entity.Used,
            IsDefault = entity.IsDefault
        });
    }

    [HttpPut("danh-muc-loai-lai/cap-nhat/{id}")]
    [ProducesResponseType<ResultApi<DanhMucLoaiLaiDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Update(
        int id,
        [FromBody] DanhMucLoaiLaiUpdateModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new DanhMucLoaiLaiUpdateCommand(id, model), cancellationToken);
        return ResultApi.Ok(new DanhMucLoaiLaiDto
        {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Used = entity.Used,
            IsDefault = entity.IsDefault
        });
    }

    [HttpGet("danh-muc-loai-lai/danh-sach")]
    [ProducesResponseType<ResultApi<PaginatedList<DanhMucLoaiLaiDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] DanhMucLoaiLaiSearchModel searchModel)
    {
        var result = await Mediator.Send(new DanhMucLoaiLaiGetListQuery(searchModel));
        return ResultApi.Ok(result);
    }

    [HttpGet("danh-muc-loai-lai/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<DanhMucLoaiLaiDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetById(int id)
    {
        var result = await Mediator.Send(new DanhMucLoaiLaiGetByIdQuery(id));
        return ResultApi.Ok(result);
    }

    [HttpGet("danh-muc-loai-lai/combobox")]
    [ProducesResponseType<ResultApi<List<ComboBoxDto<int>>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetCombobox()
    {
        var result = await Mediator.Send(new DanhMucLoaiLaiGetComboboxQuery());
        return ResultApi.Ok(result);
    }

    [HttpDelete("danh-muc-loai-lai/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(int id)
    {
        await Mediator.Send(new DanhMucLoaiLaiDeleteCommand(id));
        return ResultApi.Ok();
    }
}