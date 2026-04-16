using QLDA.Domain.Interfaces;

namespace QLDA.Application.Dashboard.Queries;

/// <summary>
/// Query lấy thống kê dự án theo giai đoạn hiện tại
/// </summary>
/// <param name="Nam">Năm cần thống kê (bắt buộc)</param>
public record DashboardGetTheoGiaiDoanQuery(int Nam) : IRequest<List<DashboardTheoGiaiDoanDto>>;

internal class DashboardGetTheoGiaiDoanQueryHandler
    : IRequestHandler<DashboardGetTheoGiaiDoanQuery, List<DashboardTheoGiaiDoanDto>> {

    private readonly IDashboardRepository _dashboard;

    public DashboardGetTheoGiaiDoanQueryHandler(IServiceProvider serviceProvider) {
        _dashboard = serviceProvider.GetRequiredService<IDashboardRepository>();
    }

    public async Task<List<DashboardTheoGiaiDoanDto>> Handle(
        DashboardGetTheoGiaiDoanQuery request,
        CancellationToken cancellationToken) {

        return await _dashboard.GetTheoGiaiDoanAsync(request.Nam, cancellationToken);
    }
}