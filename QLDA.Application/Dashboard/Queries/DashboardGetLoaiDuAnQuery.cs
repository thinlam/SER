using QLDA.Domain.Interfaces;

namespace QLDA.Application.Dashboard.Queries;

/// <summary>
/// Query lấy thống kê theo loại dự án theo năm (KCM/CT/TD)
/// </summary>
/// <param name="Nam">Năm cần thống kê (bắt buộc)</param>
/// <param name="Ma">Mã loại dự án (optional: KCM, CT, TD). Nếu null thì lấy tất cả</param>
public record DashboardGetLoaiDuAnQuery(int Nam, string? Ma = null)
    : IRequest<List<DashboardLoaiDuAnDto>>;

internal class DashboardGetLoaiDuAnQueryHandler
    : IRequestHandler<DashboardGetLoaiDuAnQuery, List<DashboardLoaiDuAnDto>> {

    private readonly IDashboardRepository _dashboard;

    public DashboardGetLoaiDuAnQueryHandler(IServiceProvider serviceProvider) {
        _dashboard = serviceProvider.GetRequiredService<IDashboardRepository>();
    }

    public async Task<List<DashboardLoaiDuAnDto>> Handle(
        DashboardGetLoaiDuAnQuery request,
        CancellationToken cancellationToken) {

        return await _dashboard.GetTheoLoaiAsync(request.Nam, request.Ma, cancellationToken);
    }
}