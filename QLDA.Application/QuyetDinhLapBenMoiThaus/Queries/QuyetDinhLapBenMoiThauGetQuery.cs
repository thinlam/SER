using Microsoft.EntityFrameworkCore;

namespace QLDA.Application.QuyetDinhLapBenMoiThaus.Queries;

public class QuyetDinhLapBenMoiThauGetQuery : IRequest<QuyetDinhLapBenMoiThau> {
    public Guid Id { get; set; }
    public bool ThrowIfNull { get; set; } = true;
    public bool IsNoTracking { get; set; }
}

internal class QuyetDinhLapBenMoiThauGetQueryHandler(IServiceProvider serviceProvider)
    : IRequestHandler<QuyetDinhLapBenMoiThauGetQuery, QuyetDinhLapBenMoiThau> {
    private readonly IRepository<QuyetDinhLapBenMoiThau, Guid> QuyetDinhLapBenMoiThau =
        serviceProvider.GetRequiredService<IRepository<QuyetDinhLapBenMoiThau, Guid>>();

    public async Task<QuyetDinhLapBenMoiThau> Handle(QuyetDinhLapBenMoiThauGetQuery request,
        CancellationToken cancellationToken = default) {
        var queryable = QuyetDinhLapBenMoiThau.GetOrderedSet()
            .Where(e => e.Id == request.Id);

        if (request.IsNoTracking)
            queryable = queryable.AsNoTracking();


        var entity = await queryable
            .FirstOrDefaultAsync(cancellationToken);

        ManagedException.ThrowIf(request.ThrowIfNull && entity == null, "Không tìm thấy dữ liệu");

        return entity!;
    }
}