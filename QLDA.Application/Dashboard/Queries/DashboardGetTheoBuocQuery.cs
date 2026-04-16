using QLDA.Domain.Interfaces;

namespace QLDA.Application.Dashboard.Queries;

/// <summary>
/// Query lấy thống kê dự án theo bước hiện tại
/// </summary>
/// <param name="Nam">Năm cần thống kê (bắt buộc)</param>
public record DashboardGetTheoBuocQuery(int Nam) : IRequest<List<DashboardTheoBuocDto>>;

internal class DashboardGetTheoBuocQueryHandler
    : IRequestHandler<DashboardGetTheoBuocQuery, List<DashboardTheoBuocDto>> {

    private readonly IDashboardRepository _dashboard;

    public DashboardGetTheoBuocQueryHandler(IServiceProvider serviceProvider) {
        _dashboard = serviceProvider.GetRequiredService<IDashboardRepository>();
    }

    public async Task<List<DashboardTheoBuocDto>> Handle(
        DashboardGetTheoBuocQuery request,
        CancellationToken cancellationToken) {

        return await _dashboard.GetTheoBuocAsync(request.Nam, cancellationToken);
    }
}