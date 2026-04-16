using QLDA.Application.Dashboard.Queries;
using QLDA.Domain.DTOs;

namespace QLDA.WebApi.Controllers;

/// <summary>
/// API thống kê dashboard dự án
/// </summary>
[Tags("Thống kê")]
public class DashboardController(IServiceProvider serviceProvider)
    : AggregateRootController(serviceProvider) {

    /// <summary>
    /// Lấy tất cả thống kê dashboard trong 1 lần gọi API
    /// </summary>
    /// <param name="nam">Năm cần thống kê (bắt buộc)</param>
    /// <returns>Tổng hợp tất cả thống kê dashboard</returns>
    [HttpGet("api/thong-ke/tong-hop")]
    [ProducesResponseType<ResultApi<DashboardTongHopDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetTongHop([FromQuery] int nam) {
        var result = await Mediator.Send(new DashboardGetTongHopQuery(nam));
        return ResultApi.Ok(result);
    }

    /// <summary>
    /// Tổng số dự án trong năm
    /// </summary>
    /// <param name="nam">Năm cần thống kê (bắt buộc)</param>
    /// <returns>Tổng số dự án trong năm</returns>
    [HttpGet("api/thong-ke/tong-theo-nam")]
    [ProducesResponseType<ResultApi<DashboardTongDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetTongTheoNam([FromQuery] int nam) {
        var result = await Mediator.Send(new DashboardGetTongTheoNamQuery(nam));
        return ResultApi.Ok(result);
    }

    /// <summary>
    /// Thống kê dự án khởi công mới (KCM)
    /// </summary>
    /// <param name="nam">Năm cần thống kê (bắt buộc)</param>
    /// <returns>Danh sách thống kê dự án khởi công mới</returns>
    [HttpGet("api/thong-ke/khoi-cong-moi")]
    [ProducesResponseType<ResultApi<List<DashboardLoaiDuAnDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetKhoiCongMoi([FromQuery] int nam) {
        var result = await Mediator.Send(
            new DashboardGetLoaiDuAnQuery(nam, EnumLoaiDuAnTheoNam.KCM.ToString()));
        return ResultApi.Ok(result);
    }

    /// <summary>
    /// Thống kê dự án chuyển tiếp (CT)
    /// </summary>
    /// <param name="nam">Năm cần thống kê (bắt buộc)</param>
    /// <returns>Danh sách thống kê dự án chuyển tiếp</returns>
    [HttpGet("api/thong-ke/chuyen-tiep")]
    [ProducesResponseType<ResultApi<List<DashboardLoaiDuAnDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetChuyenTiep([FromQuery] int nam) {
        var result = await Mediator.Send(
            new DashboardGetLoaiDuAnQuery(nam, EnumLoaiDuAnTheoNam.CT.ToString()));
        return ResultApi.Ok(result);
    }

    /// <summary>
    /// Thống kê dự án tồn đọng (TD)
    /// </summary>
    /// <param name="nam">Năm cần thống kê (bắt buộc)</param>
    /// <returns>Danh sách thống kê dự án tồn đọng</returns>
    [HttpGet("api/thong-ke/ton-dong")]
    [ProducesResponseType<ResultApi<List<DashboardLoaiDuAnDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetTonDong([FromQuery] int nam) {
        var result = await Mediator.Send(
            new DashboardGetLoaiDuAnQuery(nam, EnumLoaiDuAnTheoNam.TD.ToString()));
        return ResultApi.Ok(result);
    }

    /// <summary>
    /// Thống kê dự án theo loại (KCM/CT/TD) - tổng hợp tất cả
    /// </summary>
    /// <param name="nam">Năm cần thống kê (bắt buộc)</param>
    /// <returns>Danh sách thống kê theo loại dự án</returns>
    [HttpGet("api/thong-ke/theo-loai")]
    [ProducesResponseType<ResultApi<List<DashboardLoaiDuAnDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetTheoLoai([FromQuery] int nam) {
        var result = await Mediator.Send(new DashboardGetLoaiDuAnQuery(nam));
        return ResultApi.Ok(result);
    }

    /// <summary>
    /// Thống kê dự án theo bước hiện tại (BuocHienTai)
    /// </summary>
    /// <param name="nam">Năm cần thống kê (bắt buộc)</param>
    /// <returns>Danh sách thống kê theo bước</returns>
    [HttpGet("api/thong-ke/theo-buoc")]
    [ProducesResponseType<ResultApi<List<DashboardTheoBuocDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetTheoBuoc([FromQuery] int nam) {
        var result = await Mediator.Send(new DashboardGetTheoBuocQuery(nam));
        return ResultApi.Ok(result);
    }

    /// <summary>
    /// Thống kê dự án theo giai đoạn hiện tại (GiaiDoanHienTai)
    /// </summary>
    /// <param name="nam">Năm cần thống kê (bắt buộc)</param>
    /// <returns>Danh sách thống kê theo giai đoạn</returns>
    [HttpGet("api/thong-ke/theo-giai-doan")]
    [ProducesResponseType<ResultApi<List<DashboardTheoGiaiDoanDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetTheoGiaiDoan([FromQuery] int nam) {
        var result = await Mediator.Send(new DashboardGetTheoGiaiDoanQuery(nam));
        return ResultApi.Ok(result);
    }
}