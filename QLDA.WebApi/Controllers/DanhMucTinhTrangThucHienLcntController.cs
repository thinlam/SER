using System.Net.Mime;
using QLDA.Application.DanhMucTinhTrangThucHienLcnts.Commands;
using QLDA.Application.DanhMucTinhTrangThucHienLcnts.DTOs;
using QLDA.Domain.Constants;
using QLDA.WebApi.Models.DanhMucTinhTrangThucHienLcnts;

namespace QLDA.WebApi.Controllers;

[Tags("Danh mục tình trạng thực hiện LCNT")]
[Route("api/danh-muc-tinh-trang-thuc-hien-lcnt")]
[Authorize(Roles = RoleConstants.GroupAdminOrManager)]
public class DanhMucTinhTrangThucHienLcntController(IServiceProvider serviceProvider)
    : AggregateRootController(serviceProvider)
{
    [ProducesResponseType<ResultApi<DanhMucTinhTrangThucHienLcntModel>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
    [HttpGet("{id}")]
    public async Task<ResultApi> Get(int id)
    {
        var entity = await Mediator.Send(new DanhMucGetQuery
        {
            DanhMuc = EDanhMuc.DanhMucTinhTrangThucHienLcnt,
            Id = id.ToString(),
            ThrowIfNull = true,
        }) as DanhMucTinhTrangThucHienLcnt;
        var model = entity!.ToModel();

        return ResultApi.Ok(model);
    }

    [ProducesResponseType<ResultApi<PaginatedList<DanhMucDto<int>>>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
    [HttpGet("danh-sach")]
    public async Task<ResultApi> GetAll([FromQuery] AggregateRootPagination req, string? globalFilter)
    {
        var res = await Mediator.Send(new DanhMucGetDanhSachQuery
        {
            DanhMuc = EDanhMuc.DanhMucTinhTrangThucHienLcnt,
            GlobalFilter = globalFilter,
            PageIndex = req.PageIndex,
            PageSize = req.PageSize,
            GetAll = true
        });
        return ResultApi.Ok(res);
    }

    [ProducesResponseType<ResultApi<List<DanhMucDto<int>>>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
    [HttpGet("combobox")]
    public async Task<ResultApi> Get(string? globalFilter = null, [FromQuery] List<long>? ids = null, bool getAll = false)
    {
        var res = await Mediator.Send(new DanhMucGetDanhSachQuery
        {
            GlobalFilter = globalFilter,
            DanhMuc = EDanhMuc.DanhMucTinhTrangThucHienLcnt,
            PageIndex = 0,
            PageSize = 0,
            Ids = ids,
            GetAll = getAll,
        }) as PaginatedList<DanhMucDto<int>>;
        return ResultApi.Ok(res == null ? [] : res.Data);
    }

    [ProducesResponseType<ResultApi<DanhMucTinhTrangThucHienLcntModel>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
    [HttpPost("them-moi")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<ResultApi> Create([FromBody] DanhMucTinhTrangThucHienLcntInsertDto dto)
    {
        var entity = await Mediator.Send(new DanhMucTinhTrangThucHienLcntInsertCommand(dto));
        var model = entity.ToModel();
        return ResultApi.Ok(model);
    }

    [ProducesResponseType<ResultApi<DanhMucTinhTrangThucHienLcntModel>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
    [HttpPut("cap-nhat")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<ResultApi> Update([FromBody] DanhMucTinhTrangThucHienLcntUpdateDto dto)
    {
        var entity = await Mediator.Send(new DanhMucTinhTrangThucHienLcntUpdateCommand(dto));
        var model = entity.ToModel();
        return ResultApi.Ok(model);
    }

    [ProducesResponseType<ResultApi<DanhMucTinhTrangThucHienLcnt>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
    [HttpDelete("xoa-tam")]
    public async Task<ResultApi> SoftDelete(int id)
    {
        var entity = await Mediator.Send(new DanhMucGetQuery
        {
            Id = id.ToString(),
            DanhMuc = EDanhMuc.DanhMucTinhTrangThucHienLcnt,
            ThrowIfNull = true
        }) as DanhMucTinhTrangThucHienLcnt;
        entity!.IsDeleted = true;
        await Mediator.Send(new DanhMucInsertOrUpdateCommand(entity, EDanhMuc.DanhMucTinhTrangThucHienLcnt));
        return ResultApi.Ok(entity);
    }
}
