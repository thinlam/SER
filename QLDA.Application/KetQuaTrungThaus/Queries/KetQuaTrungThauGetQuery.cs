using Microsoft.EntityFrameworkCore;

namespace QLDA.Application.KetQuaTrungThaus.Queries;

public class KetQuaTrungThauGetQuery : IRequest<KetQuaTrungThau> {
    public Guid Id { get; set; }
    public bool ThrowIfNull { get; set; } = true;
    public bool IsNoTracking { get; set; }
}

internal class KetQuaTrungThauGetQueryHandler(IServiceProvider serviceProvider)
    : IRequestHandler<KetQuaTrungThauGetQuery, KetQuaTrungThau> {
    private readonly IRepository<KetQuaTrungThau, Guid> KetQuaTrungThau =
        serviceProvider.GetRequiredService<IRepository<KetQuaTrungThau, Guid>>();
    public async Task<KetQuaTrungThau> Handle(KetQuaTrungThauGetQuery request,
        CancellationToken cancellationToken = default) {
        var queryable = KetQuaTrungThau.GetOrderedSet()
            .Where(e => e.Id == request.Id);

        if (request.IsNoTracking)
            queryable = queryable.AsNoTracking();


        var entity = await queryable
            .FirstOrDefaultAsync(cancellationToken);

        ManagedException.ThrowIf(request.ThrowIfNull && entity == null, "Không tìm thấy dữ liệu");

        return entity!;
    }
}