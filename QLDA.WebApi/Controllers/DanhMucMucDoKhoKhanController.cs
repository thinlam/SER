using System.Net.Mime;
using QLDA.Domain.Constants;
using QLDA.WebApi.Models.DanhMucMucDoKhoKhans;

namespace QLDA.WebApi.Controllers {
    [Tags("Danh mục mức độ khó khăn")]
    [Route("api/danh-muc-muc-do-kho-khan")]
    [Authorize(Roles = RoleConstants.GroupAdminOrManager)]
    public class DanhMucMucDoKhoKhanController : AggregateRootController {
        public DanhMucMucDoKhoKhanController(IServiceProvider serviceProvider) : base(serviceProvider) {
        }

        [ProducesResponseType<ResultApi<DanhMucMucDoKhoKhanModel>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<ResultApi> Get(int id) {
            var entity = await Mediator.Send(new DanhMucGetQuery{ Id = id.ToString(),DanhMuc = EDanhMuc.DanhMucMucDoKhoKhan,ThrowIfNull = true}) as DanhMucMucDoKhoKhan;
            var model = entity!.ToModel();
            return ResultApi.Ok(model);
        }

        

        /// <summary>
        /// Tạm ẩn
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType<ResultApi<DanhMucMucDoKhoKhan>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [HttpDelete("xoa-tam")]
        public async Task<ResultApi> SoftDelete(int id) {
            var entity = await Mediator.Send(new DanhMucGetQuery{ Id = id.ToString(),DanhMuc = EDanhMuc.DanhMucMucDoKhoKhan,ThrowIfNull = true}) as DanhMucMucDoKhoKhan;
            entity!.IsDeleted = true;
            await Mediator.Send(new DanhMucInsertOrUpdateCommand(entity, EDanhMuc.DanhMucMucDoKhoKhan));
            return ResultApi.Ok(entity);
        }

        [ProducesResponseType<ResultApi<PaginatedList<DanhMucDto<int>>>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [HttpGet("danh-sach-day-du")]
        public async Task<ResultApi> GetAll([FromQuery] AggregateRootPagination req, string? globalFilter) {
            var res = await Mediator.Send(new DanhMucGetDanhSachQuery() {
                DanhMuc = EDanhMuc.DanhMucMucDoKhoKhan,
                PageIndex = req.PageIndex, GlobalFilter = globalFilter,
                PageSize = req.PageSize,
                GetAll = true
            });
            return ResultApi.Ok(res);
        }

        [ProducesResponseType<ResultApi<List<DanhMucDto<int>>>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [HttpGet("danh-sach")]
        public async Task<ResultApi> Get([FromQuery] List<long>? ids = null, bool getAll = false) {
            var res = await Mediator.Send(new DanhMucGetDanhSachQuery() {
                DanhMuc = EDanhMuc.DanhMucMucDoKhoKhan,
                PageIndex = 0,
                PageSize = 0,
                Ids = ids, GetAll = getAll,
            }) as PaginatedList<DanhMucDto<int>>;
            return ResultApi.Ok(res == null ? [] :res.Data);
        }


        [ProducesResponseType<ResultApi<int>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [HttpPost("them-moi")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ResultApi> Create([FromBody] DanhMucMucDoKhoKhanModel model) {
            var entity = model.ToEntity();
            await Mediator.Send(new DanhMucInsertOrUpdateCommand(entity, EDanhMuc.DanhMucMucDoKhoKhan));
            return ResultApi.Ok(1);
        }

        [ProducesResponseType<ResultApi<DanhMucMucDoKhoKhanModel>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [HttpPut("cap-nhat")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ResultApi> Update([FromBody] DanhMucMucDoKhoKhanModel model) {
            var entity = await Mediator.Send(new DanhMucGetQuery{ Id = model.GetId().ToString(),DanhMuc = EDanhMuc.DanhMucMucDoKhoKhan,ThrowIfNull = true}) as DanhMucMucDoKhoKhan;

            entity!.Ma = model.Ma;
            entity.Ten = model.Ten;
            entity.MoTa = model.MoTa;
            entity.Stt = model.Stt;entity.Used = model.Used;

            await Mediator.Send(new DanhMucInsertOrUpdateCommand(entity, EDanhMuc.DanhMucMucDoKhoKhan));

            return ResultApi.Ok(model);
        }
    }
}