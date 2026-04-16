using System.Net.Mime;
using QLDA.Domain.Constants;
using QLDA.WebApi.Models.DmLinhVucs;

namespace QLDA.WebApi.Controllers {
    [Tags("Danh mục lĩnh vực")]
    [Route("api/danh-muc-linh-vuc")]
    public class DanhMucLinhVucController : AggregateRootController {
        public DanhMucLinhVucController(IServiceProvider serviceProvider) : base(serviceProvider) {
        }

        [ProducesResponseType<ResultApi<DanhMucLinhVucModel>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<ResultApi> Get(int id) {
            var entity = await Mediator.Send(new DanhMucGetQuery{Id = id.ToString(), DanhMuc = EDanhMuc.DanhMucLinhVuc,ThrowIfNull = true, }) as DanhMucLinhVuc;
            var model = entity!.ToModel();
            return ResultApi.Ok(model);
        }

        /// <summary>
        /// Tạm ẩn
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType<ResultApi<DanhMucLinhVuc>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = RoleConstants.GroupAdminOrManager)]
        [HttpDelete("xoa-tam")]
        public async Task<ResultApi> SoftDelete(int id) {
            var entity = await Mediator.Send(new DanhMucGetQuery{Id = id.ToString(), DanhMuc = EDanhMuc.DanhMucLinhVuc,ThrowIfNull = true, }) as DanhMucLinhVuc;
            entity!.IsDeleted = true;
            await Mediator.Send(new DanhMucInsertOrUpdateCommand(entity, EDanhMuc.DanhMucLinhVuc));
            return ResultApi.Ok(entity);
        }

        [ProducesResponseType<ResultApi<PaginatedList<DanhMucDto<int>>>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [HttpGet("danh-sach-day-du")]
        public async Task<ResultApi> GetAll([FromQuery] AggregateRootPagination req, string? globalFilter) {
            var res = await Mediator.Send(new DanhMucGetDanhSachQuery() {
                DanhMuc = EDanhMuc.DanhMucLinhVuc,
                PageIndex = req.PageIndex, GlobalFilter = globalFilter,
                PageSize = req.PageSize,
                GetAll = true
            });
            return ResultApi.Ok(res);
        }

        [ProducesResponseType<ResultApi<List<DanhMucDto<int>>>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [HttpGet("danh-sach")]
        public async Task<ResultApi> Get() {
            var res = await Mediator.Send(new DanhMucGetDanhSachQuery() {
                DanhMuc = EDanhMuc.DanhMucLinhVuc,
                PageIndex = 0,
                PageSize = 0,
            }) as PaginatedList<DanhMucDto<int>>;
            return ResultApi.Ok(res == null ? [] :res.Data);
        }


        [ProducesResponseType<ResultApi<int>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = RoleConstants.GroupAdminOrManager)]
        [HttpPost("them-moi")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ResultApi> Create([FromBody] DanhMucLinhVucModel model) {
            var entity = model.ToEntity();
            await Mediator.Send(new DanhMucInsertOrUpdateCommand(entity, EDanhMuc.DanhMucLinhVuc));
            return ResultApi.Ok(1);
        }

        [ProducesResponseType<ResultApi<DanhMucLinhVucModel>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = RoleConstants.GroupAdminOrManager)]
        [HttpPut("cap-nhat")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ResultApi> Update([FromBody] DanhMucLinhVucModel model) {
            var entity = await Mediator.Send(new DanhMucGetQuery{Id = model.GetId().ToString(), DanhMuc = EDanhMuc.DanhMucLinhVuc,ThrowIfNull = true, }) as DanhMucLinhVuc;


            entity!.Ma = model.Ma;
            entity.Ten = model.Ten;
            entity.MoTa = model.MoTa;
            entity.Stt = model.Stt;entity.Used = model.Used;

            await Mediator.Send(new DanhMucInsertOrUpdateCommand(entity, EDanhMuc.DanhMucLinhVuc));

            return ResultApi.Ok(model);
        }
    }
}