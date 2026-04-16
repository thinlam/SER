using Microsoft.EntityFrameworkCore;

namespace QLDA.Application.QuyetDinhLapBanQLDAs.Queries;

public class QuyetDinhLapBanQldaGetQuery : IRequest<QuyetDinhLapBanQLDA> {
    public Guid Id { get; set; }
    public bool ThrowIfNull { get; set; } = true;
    public bool IncludeThanhVien { get; set; } 
    public bool IsNoTracking { get; set; }
}

internal class QuyetDinhLapBanQldaGetQueryHandler(IServiceProvider serviceProvider)
    : IRequestHandler<QuyetDinhLapBanQldaGetQuery, QuyetDinhLapBanQLDA> {
    private readonly IRepository<QuyetDinhLapBanQLDA, Guid> QuyetDinhLapBanQLDA =
        serviceProvider.GetRequiredService<IRepository<QuyetDinhLapBanQLDA, Guid>>();

    public async Task<QuyetDinhLapBanQLDA> Handle(QuyetDinhLapBanQldaGetQuery request,
        CancellationToken cancellationToken = default) {
        var queryable = QuyetDinhLapBanQLDA.GetOrderedSet()
            .WhereFunc(request.IncludeThanhVien,e=>e.Include(i=>i.ThanhViens))
            .Where(e => e.Id == request.Id);

        if (request.IsNoTracking)
            queryable = queryable.AsNoTracking();


        var entity = await queryable
            .FirstOrDefaultAsync(cancellationToken);

        ManagedException.ThrowIf(request.ThrowIfNull && entity == null, "Không tìm thấy dữ liệu");

        return entity!;
    }
}