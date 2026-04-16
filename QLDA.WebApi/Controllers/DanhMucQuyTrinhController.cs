using System.Net.Mime;
using QLDA.Application.DanhMucQuyTrinhs.Commands;
using QLDA.Application.DanhMucQuyTrinhs.DTOs;
using QLDA.Application.DanhMucQuyTrinhs.Queries;
using QLDA.Domain.Constants;

namespace QLDA.WebApi.Controllers {
    [Tags("Danh mục quy trình")]
    [Route("api/danh-muc-quy-trinh")]
    public class DanhMucQuyTrinhController : AggregateRootController {
        // GET
        public DanhMucQuyTrinhController(IServiceProvider serviceProvider) : base(serviceProvider) {
        }
        [ProducesResponseType<ResultApi<DanhMucQuyTrinhDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<ResultApi> Get(int id) {
            var dto = await Mediator.Send(new DanhMucQuyTrinhGetQuery(id));
            return ResultApi.Ok(dto);
        }


        /// <summary>
        /// Xóa tạm thời
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType<ResultApi<int>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = RoleConstants.GroupAdminOrManager)]
        [HttpDelete("xoa-tam")]
        public async Task<ResultApi> SoftDelete(int id) {
            var result = await Mediator.Send(new DanhMucQuyTrinhDeleteCommand(id));
            return ResultApi.Ok(result);
        }

        [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [HttpGet("danh-sach-day-du")]
        public async Task<ResultApi> GetAll([FromQuery] AggregateRootPagination req, string? globalFilter) {
            var res = await Mediator.Send(new DanhMucQuyTrinhGetDanhSachQuery() {
                PageIndex = req.PageIndex,
                GlobalFilter = globalFilter,
                PageSize = req.PageSize
            });
            return ResultApi.Ok(res);
        }

        /// <summary>
        /// Dùng để load combobox
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [ResponseCache(CacheProfileName = "Combobox")]
        [HttpGet("danh-sach")]
        public async Task<ResultApi> Get([FromQuery] List<int>? ids = null, bool? hasStep = false) {
            var res = await Mediator.Send(new DanhMucQuyTrinhGetDanhSachQuery() {
                PageIndex = 0,
                PageSize = 0,
                Ids = ids,
                IsCbo = true,
                HasStep = hasStep ?? true,
            });
            return ResultApi.Ok(res.Data);
        }


        [ProducesResponseType<ResultApi<DanhMucQuyTrinhDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = RoleConstants.GroupAdminOrManager)]
        [HttpPost("them-moi")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ResultApi> Create([FromBody] DanhMucQuyTrinhDto dto) {
            var result = await Mediator.Send(new DanhMucQuyTrinhInsertCommand(dto));
            return ResultApi.Ok(result);
        }

        [ProducesResponseType<ResultApi<DanhMucQuyTrinhDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = RoleConstants.GroupAdminOrManager)]
        [HttpPut("cap-nhat")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ResultApi> Update([FromBody] DanhMucQuyTrinhDto dto) {
            var result = await Mediator.Send(new DanhMucQuyTrinhUpdateCommand(dto));
            return ResultApi.Ok(result);
        }
    }
}