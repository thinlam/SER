using QLDA.Domain.Interfaces;

namespace QLDA.Application.Dashboard.Queries;

/// <summary>
/// Query lấy tổng số dự án trong năm
/// </summary>
/// <param name="Nam">Năm cần thống kê (bắt buộc)</param>
public record DashboardGetTongTheoNamQuery(int Nam) : IRequest<DashboardTongDto>;

internal class DashboardGetTongTheoNamQueryHandler
    : IRequestHandler<DashboardGetTongTheoNamQuery, DashboardTongDto> {

    private readonly IDashboardRepository _dashboard;

    public DashboardGetTongTheoNamQueryHandler(IServiceProvider serviceProvider) {
        _dashboard = serviceProvider.GetRequiredService<IDashboardRepository>();
    }

    public async Task<DashboardTongDto> Handle(
        DashboardGetTongTheoNamQuery request,
        CancellationToken cancellationToken) {

        var count = await _dashboard.CountTongTheoNamAsync(request.Nam, cancellationToken);

        return new DashboardTongDto {
            Nam = request.Nam,
            TongSoDuAn = count
        };
    }
}