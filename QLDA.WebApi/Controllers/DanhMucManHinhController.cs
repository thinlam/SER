using System.Net.Mime;
using QLDA.Application.DanhMucManHinhs;
using QLDA.Application.DanhMucManHinhs.Commands;
using QLDA.Application.DanhMucManHinhs.DTOs;
using QLDA.Application.DanhMucManHinhs.Queries;
using QLDA.Domain.Constants;

namespace QLDA.WebApi.Controllers {
    [Tags("Danh mục màn hình")]
    [Route("api/danh-muc-man-hinh")]
    [Authorize(Roles = RoleConstants.GroupAdminOrManager)]
    public class DanhMucManHinhController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider) {
        [ProducesResponseType<ResultApi<DanhMucManHinhDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<ResultApi> Get(int id) {
            var entity =
                await Mediator.Send(new DanhMucGetQuery() {
                    Id = id.ToString(),
                    DanhMuc = EDanhMuc.DanhMucManHinh,
                    ThrowIfNull = true,
                    Enum = true
                }) as DanhMucManHinh;
            var Dto = entity!.ToDto();
            return ResultApi.Ok(Dto);
        }

        // [ProducesResponseType<ResultApi<int>>(StatusCodes.Status200OK)]
        // [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        // [HttpDelete("xoa")]
        // public async Task<ResultApi> Delete(int id) {
        //     var entity =
        //         await Mediator.Send(new DanhMucGetQuery() {
        //             Id = id.ToString(),
        //             DanhMuc = EDanhMuc.DanhMucManHinh,
        //             ThrowIfNull = true,
        //             Enum = true
        //         }) as DanhMucManHinh;
        //     await Mediator.Send(new DanhMucDeleteCommand(entity!, EDanhMuc.DanhMucManHinh, true));
        //     return ResultApi.Ok(1);
        // }

        [ProducesResponseType<ResultApi<PaginatedList<DanhMucManHinhDto>>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [HttpGet("danh-sach")]
        public async Task<ResultApi> GetAll([FromQuery] AggregateRootPagination req, string? globalFilter) {
            var res = await Mediator.Send(new DanhMucManHinhGetDanhSachQuery() {
                PageIndex = req.PageIndex,
                GlobalFilter = globalFilter,
                PageSize = req.PageSize,

            });
            return ResultApi.Ok(res);
        }

        [ProducesResponseType<ResultApi<PaginatedList<DanhMucManHinhDto>>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [ResponseCache(CacheProfileName = "Combobox")]
        [HttpGet("combobox")]
        public async Task<ResultApi> Get() {
            var res = await Mediator.Send(new DanhMucManHinhGetDanhSachQuery() {
                PageIndex = 0,
                PageSize = 0,
                IsCbo = true
            });
            return ResultApi.Ok(res);
        }


        [ProducesResponseType<ResultApi<int>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [HttpPost("them-moi")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ResultApi> Create([FromBody] DanhMucManHinhInsertDto insertDto) {
            var entity = await Mediator.Send(new DanhMucManHinhInsertCommand(insertDto));
            return ResultApi.Ok(entity.Id);
        }

        [ProducesResponseType<ResultApi<DanhMucManHinhDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [HttpPut("cap-nhat")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ResultApi> Update([FromBody] DanhMucManHinhUpdateDto updateDto) {
            var entity = await Mediator.Send(new DanhMucManHinhUpdateCommand(updateDto));
            return ResultApi.Ok(entity.ToDto());
        }
    }
}