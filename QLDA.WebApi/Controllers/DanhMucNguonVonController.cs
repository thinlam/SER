using System.Net.Mime;
using QLDA.Application.DanhMucNguonVons.Queries;
using QLDA.Domain.Constants;
using QLDA.WebApi.Models.DanhMucNguonVons;
using QLDA.WebApi.Models.DanhMucNhaThaus;

namespace QLDA.WebApi.Controllers {
    [Tags("Danh mục nguồn vốn")]
    [Route("api/danh-muc-nguon-von")]
    public class DanhMucNguonVonController : AggregateRootController {
        public DanhMucNguonVonController(IServiceProvider serviceProvider) : base(serviceProvider) {
        }

        [ProducesResponseType<ResultApi<DanhMucNguonVonModel>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<ResultApi> Get(int id) {
            var entity = await Mediator.Send(new DanhMucGetQuery
                { Id = id.ToString(), DanhMuc = EDanhMuc.DanhMucNguonVon, ThrowIfNull = true, }) as DanhMucNguonVon;
            var model = entity!.ToModel();
            return ResultApi.Ok(model);
        }


        /// <summary>
        /// Tạm ẩn
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType<ResultApi<DanhMucNguonVon>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = RoleConstants.GroupAdminOrManager)]
        [HttpDelete("xoa-tam")]
        public async Task<ResultApi> SoftDelete(int id) {
            var entity = await Mediator.Send(new DanhMucGetQuery
                { Id = id.ToString(), DanhMuc = EDanhMuc.DanhMucNguonVon, ThrowIfNull = true, }) as DanhMucNguonVon;
            entity!.IsDeleted = true;
            await Mediator.Send(new DanhMucInsertOrUpdateCommand(entity, EDanhMuc.DanhMucNguonVon));
            return ResultApi.Ok(entity);
        }

        [ProducesResponseType<ResultApi<PaginatedList<DanhMucDto<int>>>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [HttpGet("danh-sach-day-du")]
        public async Task<ResultApi> GetAll([FromQuery] AggregateRootPagination req, string? globalFilter) {
            var res = await Mediator.Send(new DanhMucGetDanhSachQuery() {
                DanhMuc = EDanhMuc.DanhMucNguonVon,
                PageIndex = req.PageIndex, GlobalFilter = globalFilter,
                PageSize = req.PageSize,
                GetAll = true
            });
            return ResultApi.Ok(res);
        }

        [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [HttpGet("danh-sach")]
        public async Task<ResultApi> Get(string? duAnId = null,[FromQuery] List<long>? ids = null, bool getAll = false) {
            var res = await Mediator.Send(new DanhMucNguonVonGetDanhSachQuery() {
                DuAnId = duAnId,
                PageIndex = 0,
                PageSize = 0,
                Ids = ids, GetAll = getAll,
            });
            return ResultApi.Ok(res.Data);
        }


        [ProducesResponseType<ResultApi<int>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = RoleConstants.GroupAdminOrManager)]
        [HttpPost("them-moi")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ResultApi> Create([FromBody] DanhMucNguonVonModel model) {
            var entity = model.ToEntity();
            await Mediator.Send(new DanhMucInsertOrUpdateCommand(entity, EDanhMuc.DanhMucNguonVon));
            return ResultApi.Ok(1);
        }

        [ProducesResponseType<ResultApi<DanhMucNguonVonModel>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = RoleConstants.GroupAdminOrManager)]
        [HttpPut("cap-nhat")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ResultApi> Update([FromBody] DanhMucNguonVonModel model) {
            var entity = await Mediator.Send(new DanhMucGetQuery
                    { Id = model.GetId().ToString(), DanhMuc = EDanhMuc.DanhMucNguonVon, ThrowIfNull = true, }) as
                DanhMucNguonVon;

            entity!.Ma = model.Ma;
            entity.Ten = model.Ten;
            entity.MoTa = model.MoTa;
            entity.Stt = model.Stt;
            entity.Used = model.Used;

            await Mediator.Send(new DanhMucInsertOrUpdateCommand(entity, EDanhMuc.DanhMucNguonVon));

            return ResultApi.Ok(model);
        }
    }
}