namespace QLDA.WebApi.Controllers;

/// <summary>
/// Controller xử lý các chức năng xác thực người dùng bao gồm đăng nhập, làm mới token và đăng xuất
/// Handles user authentication functions including login, token refresh, and logout
/// </summary>
[Tags("Bảo trì")]
[ApiController]
[Route("api/maintenance")]
public class MaintenanceController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider) {
    /// <summary>
    /// Tính toán và xây dựng lại toàn bộ Materialized Path cho cây dữ liệu.
    /// Hành động này tốn nhiều tài nguyên và có thể ảnh hưởng hiệu năng.
    /// </summary>
    /// <param name="quyTrinhId"></param>
    /// <param name="types">DanhMucBuoc, DuAn</param>
    [HttpGet("actions/rebuild-tree-paths")] // Sử dụng POST vì nó làm thay đổi trạng thái của toàn bộ hệ thống
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ResultApi> RebuildTreePaths(
        [FromQuery] int? quyTrinhId = null,
        [FromQuery] List<EMaterializedPathEntity>? types = null
        ) {
        await Mediator.Send(new MaintenanceFixTreePathCommand(quyTrinhId, types));
        return ResultApi.Ok("Cây dữ liệu đã được xây dựng lại thành công.");
    }
}
