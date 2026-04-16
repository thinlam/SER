using Microsoft.EntityFrameworkCore;

namespace QLDA.Application.DuAnBuocs.Queries;

public class DuAnBuocGetQuery : IRequest<DuAnBuoc> {
    public int Id { get; set; }
    public bool IsNoTracking { get; set; }
    public bool IncludeDuAn { get; set; }
    public bool IncludeManHinh { get; set; }
}

internal class DuAnBuocGetDQueryHandler(IServiceProvider serviceProvider)
    : IRequestHandler<DuAnBuocGetQuery, DuAnBuoc> {
    private readonly IRepository<DuAnBuoc, int> DuAnBuoc =
        serviceProvider.GetRequiredService<IRepository<DuAnBuoc, int>>();

    public async Task<DuAnBuoc> Handle(DuAnBuocGetQuery request,
        CancellationToken cancellationToken = default) {
        var entity = await DuAnBuoc.GetOrderedSet()
            .Include(e => e.Buoc!.BuocManHinhs.OrderBy(b => b.Stt))
            .WhereFunc(request.IsNoTracking, q => q.AsNoTracking())
            .WhereFunc(request.IncludeDuAn, q => q.Include(e => e.DuAn))
            .WhereFunc(request.IncludeManHinh, q => q.Include(e => e.DuAnBuocManHinhs.OrderBy(b => b.Stt)))
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        ManagedException.ThrowIf(entity == null, "Không tìm thấy dữ liệu");

        return entity;
    }
}