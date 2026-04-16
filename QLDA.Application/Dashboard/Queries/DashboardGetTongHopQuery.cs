using QLDA.Domain.Interfaces;

namespace QLDA.Application.Dashboard.Queries;

/// <summary>
/// Query lấy tất cả thống kê dashboard trong 1 lần gọi
/// </summary>
/// <param name="Nam">Năm cần thống kê (bắt buộc)</param>
public record DashboardGetTongHopQuery(int Nam) : IRequest<DashboardTongHopDto>;

internal class DashboardGetTongHopQueryHandler
    : IRequestHandler<DashboardGetTongHopQuery, DashboardTongHopDto> {

    private readonly IDashboardRepository _dashboard;

    public DashboardGetTongHopQueryHandler(IServiceProvider serviceProvider) {
        _dashboard = serviceProvider.GetRequiredService<IDashboardRepository>();
    }

    public async Task<DashboardTongHopDto> Handle(
        DashboardGetTongHopQuery request,
        CancellationToken cancellationToken) {

        return await _dashboard.GetTongHopAsync(request.Nam, cancellationToken);
    }
}