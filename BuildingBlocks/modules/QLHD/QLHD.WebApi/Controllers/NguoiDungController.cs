using QLHD.Application.NguoiDungs.Queries;

namespace QLHD.WebApi.Controllers;

[Tags("Người dùng (nguoi-dung)")]
public class NguoiDungController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    [HttpGet("nguoi-dung/combobox")]
    [ProducesResponseType<ResultApi<List<ComboBoxDto<long>>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetCombobox([FromQuery] long donViId, [FromQuery] long phongBanId)
        => ResultApi.Ok(await Mediator.Send(new NguoiDungGetComboboxQuery(donViId, phongBanId)));

    [HttpGet("nguoi-dung/danh-sach")]
    [ProducesResponseType<ResultApi<List<NguoiDungDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] long? donViId, [FromQuery] long? phongBanId)
        => ResultApi.Ok(await Mediator.Send(new NguoiDungGetListQuery(donViId, phongBanId)));
}