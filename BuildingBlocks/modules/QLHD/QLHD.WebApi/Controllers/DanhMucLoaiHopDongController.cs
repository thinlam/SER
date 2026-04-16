using QLHD.Application.DanhMucLoaiHopDongs.Commands;
using QLHD.Application.DanhMucLoaiHopDongs.DTOs;
using QLHD.Application.DanhMucLoaiHopDongs.Queries;

namespace QLHD.WebApi.Controllers;

[Tags("Danh mục loại hợp đồng (danh-muc-loai-hop-dong)")]
public class DanhMucLoaiHopDongController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    [HttpPost("danh-muc-loai-hop-dong/them-moi")]
    [ProducesResponseType<ResultApi<DanhMucLoaiHopDongDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Create(
        [FromBody] DanhMucLoaiHopDongInsertModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new DanhMucLoaiHopDongInsertCommand(model), cancellationToken);
        return ResultApi.Ok(new DanhMucLoaiHopDongDto
        {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Used = entity.Used,
            Symbol = entity.Symbol,
            Prefix = entity.Prefix,
            IsDefault = entity.IsDefault
        });
    }

    [HttpPut("danh-muc-loai-hop-dong/cap-nhat/{id}")]
    [ProducesResponseType<ResultApi<DanhMucLoaiHopDongDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Update(
        int id,
        [FromBody] DanhMucLoaiHopDongUpdateModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new DanhMucLoaiHopDongUpdateCommand(id, model), cancellationToken);
        return ResultApi.Ok(new DanhMucLoaiHopDongDto
        {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Used = entity.Used,
            Symbol = entity.Symbol,
            Prefix = entity.Prefix,
            IsDefault = entity.IsDefault
        });
    }

    [HttpGet("danh-muc-loai-hop-dong/danh-sach")]
    [ProducesResponseType<ResultApi<PaginatedList<DanhMucLoaiHopDongDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] DanhMucLoaiHopDongSearchModel searchModel)
    {
        var result = await Mediator.Send(new DanhMucLoaiHopDongGetListQuery(searchModel));
        return ResultApi.Ok(result);
    }

    [HttpGet("danh-muc-loai-hop-dong/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<DanhMucLoaiHopDongDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetById(int id)
    {
        var result = await Mediator.Send(new DanhMucLoaiHopDongGetByIdQuery(id));
        return ResultApi.Ok(result);
    }

    [HttpGet("danh-muc-loai-hop-dong/combobox")]
    [ProducesResponseType<ResultApi<List<ComboBoxDto<int>>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetCombobox()
    {
        var result = await Mediator.Send(new DanhMucLoaiHopDongGetComboboxQuery());
        return ResultApi.Ok(result);
    }

    [HttpDelete("danh-muc-loai-hop-dong/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(int id)
    {
        await Mediator.Send(new DanhMucLoaiHopDongDeleteCommand(id));
        return ResultApi.Ok();
    }
}