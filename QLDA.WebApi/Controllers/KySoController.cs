using System.Net.Mime;
using QLDA.Application.TepDinhKems.Commands;
using QLDA.Domain.Constants;
using QLDA.WebApi.Models.KySos;
using QLDA.WebApi.Models.TepDinhKems;

namespace QLDA.WebApi.Controllers;

/// <summary>
/// Lưu file ký s06ac6528-df5a-f011-a9bf-0050568a8a95
/// </summary>
/// <param name="serviceProvider"></param>
[Tags("Ký số")]
[Route("api/ky-so")]
public class KySoController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider) {
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// GroupId là id của dối tượng chính có file ký số - guid
    /// </remarks>
    /// <param name="model"></param>
    [ProducesResponseType<ResultApi<int>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
    [HttpPost("them-moi")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<ResultApi> Create([FromBody] KySoModel model) {
        ManagedException.ThrowIfNull(model.DanhSachTepDinhKem);
        ManagedException.ThrowIfNull(model.DanhSachTepDinhKem.Any(e => e.ParentId == null));
        model.DanhSachTepDinhKem ??= [];
        
        await Mediator.Send(new TepDinhKemBulkInsertOrUpdateCommand {
            KySo = true,
            GroupId = model.GroupId.ToString(),
            Entities = [.. model.DanhSachTepDinhKem.ToEntities(model.GroupId, GroupTypeConstants.KySo)]
        });
        return ResultApi.Ok(1);
    }
}