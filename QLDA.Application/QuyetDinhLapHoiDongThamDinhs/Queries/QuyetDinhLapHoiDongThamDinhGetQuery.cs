using Microsoft.EntityFrameworkCore;

namespace QLDA.Application.QuyetDinhLapHoiDongThamDinhs.Queries;

public class QuyetDinhLapHoiDongThamDinhGetQuery : IRequest<QuyetDinhLapHoiDongThamDinh> {
    public Guid Id { get; set; }
    public bool ThrowIfNull { get; set; } = true;
    public bool IsNoTracking { get; set; }
}

internal class QuyetDinhLapHoiDongThamDinhGetQueryHandler(IServiceProvider serviceProvider)
    : IRequestHandler<QuyetDinhLapHoiDongThamDinhGetQuery, QuyetDinhLapHoiDongThamDinh> {
    private readonly IRepository<QuyetDinhLapHoiDongThamDinh, Guid> QuyetDinhLapHoiDongThamDinh =
        serviceProvider.GetRequiredService<IRepository<QuyetDinhLapHoiDongThamDinh, Guid>>();

    public async Task<QuyetDinhLapHoiDongThamDinh> Handle(QuyetDinhLapHoiDongThamDinhGetQuery request,
        CancellationToken cancellationToken = default) {
        var queryable = QuyetDinhLapHoiDongThamDinh.GetOrderedSet()
            .Where(e => e.Id == request.Id);

        if (request.IsNoTracking)
            queryable = queryable.AsNoTracking();


        var entity = await queryable
            .FirstOrDefaultAsync(cancellationToken);

        ManagedException.ThrowIf(request.ThrowIfNull && entity == null, "Không tìm thấy dữ liệu");

        return entity!;
    }
}