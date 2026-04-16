using System.ComponentModel;
using BuildingBlocks.CrossCutting.Exceptions;
using QLHD.Application.BaoCaos.DTOs;
using QLHD.Application.BaoCaos.Queries;
using QLHD.Domain.Constants;

namespace QLHD.WebApi.Controllers;

[Tags("Báo cáo (bao-cao)")]
public class BaoCaoController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    private static readonly string[] ValidLoaiBaoCao = [
        LoaiBaoCaoConstants.BaoCaoTongHop,
        LoaiBaoCaoConstants.BaoCaoThang,
        LoaiBaoCaoConstants.ChiTiet
    ];

    [HttpPost("bao-cao/ke-hoach-kinh-doanh-nam")]
    [Description("Báo cáo thực hiện kế hoạch năm")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> KeHoachKinhDoanhNam(
        [FromBody] KeHoachKinhDoanhNamReportSearchModel searchModel,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new KeHoachKinhDoanhNamReportQuery(searchModel), cancellationToken);
        return ResultApi.Ok(result);
    }

    /// <summary>
    /// Tổng hợp theo phòng ban/ (Báo cáo chi tiết bộ phận - phân trang theo dự án/hợp đồng)
    /// </summary>
    /// <param name="searchModel"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("bao-cao/ke-hoach-thang")]
    [Description("Báo cáo kế hoạch tháng")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> KeHoachThang(
        [FromBody] KeHoachThangSearchModel searchModel,
        CancellationToken cancellationToken = default)
    {
        if (searchModel.LoaiBaoCao == LoaiBaoCaoConstants.ChiTiet) 
            return ResultApi.Ok(await Mediator.Send(new ChiTietBoPhanReportQuery(searchModel), cancellationToken));
        return ResultApi.Ok(await Mediator.Send(new KeHoachThangReportQuery(searchModel), cancellationToken));
    }

    [HttpGet("bao-cao/ke-hoach-thu-tien")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Report(BaoCaoKeHoachThuTienSearchModel SearchModel)
    {
        var result = await Mediator.Send(new KeHoachThuTienReportQuery(SearchModel));
        return ResultApi.Ok(result);
    }
}