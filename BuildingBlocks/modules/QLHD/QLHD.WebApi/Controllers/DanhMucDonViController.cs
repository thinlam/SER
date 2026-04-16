using QLHD.Application.DanhMucDonVis.Queries;

namespace QLHD.WebApi.Controllers;

[Tags("Danh mục đơn vị (danh-muc-don-vi)")]
public class DanhMucDonViController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    [HttpGet("danh-muc-don-vi/combobox")]
    [ProducesResponseType<ResultApi<List<ComboBoxDto<long>>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetCombobox()
        => ResultApi.Ok(await Mediator.Send(new DanhMucDonViGetComboboxQuery()));

    [HttpGet("danh-muc-don-vi/danh-sach/phong-ban")]
    [ProducesResponseType<ResultApi<List<DanhMucDonViDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetPhongBanList()
        => ResultApi.Ok(await Mediator.Send(new DanhMucDonViGetPhongBanListQuery()));

    [HttpGet("danh-muc-don-vi/danh-sach/don-vi")]
    [ProducesResponseType<ResultApi<List<DanhMucDonViDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetDonViList()
        => ResultApi.Ok(await Mediator.Send(new DanhMucDonViGetDonViListQuery()));
}