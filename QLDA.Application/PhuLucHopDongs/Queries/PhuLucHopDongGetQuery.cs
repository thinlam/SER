using Microsoft.EntityFrameworkCore;

namespace QLDA.Application.PhuLucHopDongs.Queries;

public class PhuLucHopDongGetQuery : IRequest<PhuLucHopDong> {
    public Guid Id { get; set; }
    public bool ThrowIfNull { get; set; } = true;
    public bool IsNoTracking { get; set; }
}

internal class PhuLucHopDongGetQueryHandler(IServiceProvider serviceProvider)
    : IRequestHandler<PhuLucHopDongGetQuery, PhuLucHopDong> {
    private readonly IRepository<PhuLucHopDong, Guid> PhuLucHopDong =
        serviceProvider.GetRequiredService<IRepository<PhuLucHopDong, Guid>>();

    private readonly IRepository<TepDinhKem, Guid> TepDinhKem =
        serviceProvider.GetRequiredService<IRepository<TepDinhKem, Guid>>();


    public async Task<PhuLucHopDong> Handle(PhuLucHopDongGetQuery request,
        CancellationToken cancellationToken = default) {
        var queryable = PhuLucHopDong.GetOrderedSet()
            .Where(e => e.Id == request.Id);

        if (request.IsNoTracking)
            queryable = queryable.AsNoTracking();


        var entity = await queryable
            .FirstOrDefaultAsync(cancellationToken);

        ManagedException.ThrowIf(request.ThrowIfNull && entity == null, "Không tìm thấy dữ liệu");

        return entity!;
    }
}