using Microsoft.EntityFrameworkCore;

namespace QLDA.Application.QuyetDinhDuyetQuyetToans.Queries;

public class QuyetDinhDuyetQuyetToanGetQuery : IRequest<QuyetDinhDuyetQuyetToan> {
    public Guid Id { get; set; }
    public bool ThrowIfNull { get; set; } = true;
    public bool IsNoTracking { get; set; }
}

internal class QuyetDinhDuyetQuyetToanGetQueryHandler(IServiceProvider serviceProvider)
    : IRequestHandler<QuyetDinhDuyetQuyetToanGetQuery, QuyetDinhDuyetQuyetToan> {
    private readonly IRepository<QuyetDinhDuyetQuyetToan, Guid> QuyetDinhDuyetQuyetToan =
        serviceProvider.GetRequiredService<IRepository<QuyetDinhDuyetQuyetToan, Guid>>();

    private readonly IRepository<TepDinhKem, Guid> TepDinhKem =
        serviceProvider.GetRequiredService<IRepository<TepDinhKem, Guid>>();


    public async Task<QuyetDinhDuyetQuyetToan> Handle(QuyetDinhDuyetQuyetToanGetQuery request,
        CancellationToken cancellationToken = default) {
        var queryable = QuyetDinhDuyetQuyetToan.GetOrderedSet()
            .Where(e => e.Id == request.Id);

        if (request.IsNoTracking)
            queryable = queryable.AsNoTracking();


        var entity = await queryable
            .FirstOrDefaultAsync(cancellationToken);

        ManagedException.ThrowIf(request.ThrowIfNull && entity == null, "Không tìm thấy dữ liệu");

        return entity!;
    }
}