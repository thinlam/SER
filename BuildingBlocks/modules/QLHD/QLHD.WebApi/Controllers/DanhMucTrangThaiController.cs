using QLHD.Application.DanhMucTrangThais.Commands;
using QLHD.Application.DanhMucTrangThais.DTOs;
using QLHD.Application.DanhMucTrangThais.Queries;

namespace QLHD.WebApi.Controllers;

[Tags("Danh mục trạng thái (danh-muc-trang-thai)")]
public class DanhMucTrangThaiController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider) {
    [HttpPost("danh-muc-trang-thai/them-moi")]
    [ProducesResponseType<ResultApi<DanhMucTrangThaiDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Create(
        [FromBody] DanhMucTrangThaiInsertModel model,
        CancellationToken cancellationToken = default) {
        var entity = await Mediator.Send(new DanhMucTrangThaiInsertCommand(model), cancellationToken);
        return ResultApi.Ok(new DanhMucTrangThaiDto {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Used = entity.Used,
            LoaiTrangThaiId = entity.LoaiTrangThaiId,
            MaLoaiTrangThai = entity.MaLoaiTrangThai,
            TenLoaiTrangThai = entity.TenLoaiTrangThai
        });
    }

    [HttpPut("danh-muc-trang-thai/cap-nhat/{id}")]
    [ProducesResponseType<ResultApi<DanhMucTrangThaiDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Update(
        int id,
        [FromBody] DanhMucTrangThaiUpdateModel model,
        CancellationToken cancellationToken = default) {
        var entity = await Mediator.Send(new DanhMucTrangThaiUpdateCommand(id, model), cancellationToken);
        return ResultApi.Ok(new DanhMucTrangThaiDto {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Used = entity.Used,
            LoaiTrangThaiId = entity.LoaiTrangThaiId,
            MaLoaiTrangThai = entity.MaLoaiTrangThai,
            TenLoaiTrangThai = entity.TenLoaiTrangThai
        });
    }

    [HttpGet("danh-muc-trang-thai/danh-sach")]
    [ProducesResponseType<ResultApi<PaginatedList<DanhMucTrangThaiDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] DanhMucTrangThaiSearchModel searchModel) {
        var result = await Mediator.Send(new DanhMucTrangThaiGetListQuery(searchModel));
        return ResultApi.Ok(result);
    }

    [HttpGet("danh-muc-trang-thai/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<DanhMucTrangThaiDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetById(int id) {
        var result = await Mediator.Send(new DanhMucTrangThaiGetByIdQuery(id));
        return ResultApi.Ok(result);
    }

    [HttpGet("danh-muc-trang-thai/combobox")]
    [ProducesResponseType<ResultApi<List<ComboBoxDto<int>>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetCombobox([FromQuery] int? loaiTrangThaiId = null, [FromQuery] string? maLoaiTrangThai = null) {
        var result = await Mediator.Send(new DanhMucTrangThaiGetComboboxQuery(loaiTrangThaiId, maLoaiTrangThai));
        return ResultApi.Ok(result);
    }

    [HttpDelete("danh-muc-trang-thai/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(int id) {
        await Mediator.Send(new DanhMucTrangThaiDeleteCommand(id));
        return ResultApi.Ok();
    }
}