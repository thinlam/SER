using Microsoft.EntityFrameworkCore;
using QLDA.Application.Common.Mapping;
using QLDA.Application.DuAnBuocs.DTOs;

namespace QLDA.Application.DuAnBuocs.Queries;

public record DuAnBuocGetDanhSachQuery : AggregateRootPagination, IMayHaveGlobalFilter, IRequest<PaginatedList<DuAnBuocDto>> {
    public int? QuyTrinhId { get; set; }
    public Guid? DuAnId { get; set; }
    public string? GlobalFilter { get; set; }
}

public record DuAnBuocGetDanhSachQueryHandler(IServiceProvider ServiceProvider)
    : IRequestHandler<DuAnBuocGetDanhSachQuery, PaginatedList<DuAnBuocDto>> {
    private readonly IRepository<DuAnBuoc, int> DuAnBuoc =
        ServiceProvider.GetRequiredService<IRepository<DuAnBuoc, int>>();

    public async Task<PaginatedList<DuAnBuocDto>> Handle(DuAnBuocGetDanhSachQuery request,
        CancellationToken cancellationToken) {
        var query = DuAnBuoc.GetQueryableSet(
                    OnlyUsed: false
                )
                .AsNoTracking()
                .Where(e => !e.DuAn!.IsDeleted)
                .WhereIf(request.QuyTrinhId > 0, e => e.Buoc!.QuyTrinhId == request.QuyTrinhId)
                .WhereIf(request.DuAnId != null, e => e.DuAnId == request.DuAnId)
                .WhereGlobalFilter(
                    request,
                    e => e.TenBuoc
                )
            ;

        return await query
            .OrderBy(e => e.Buoc!.Level).ThenBy(e => e.Buoc!.Stt)
            .Select(entity => new DuAnBuocDto() {
                Id = entity.Id,
                DuAnId = entity.DuAnId,
                ParentId = entity.Buoc!.ParentId,
                GiaiDoanId = entity.Buoc.GiaiDoanId,
                Level = entity.Buoc.Level,
                Path = entity.Buoc.Path,
                Stt = entity.Buoc.Stt ?? 0,
                QuyTrinhId = entity.Buoc.QuyTrinhId,
                BuocId = entity.BuocId,
                TenBuoc = entity.TenBuoc ?? entity.Buoc.Ten,
                PartialView = entity.PartialView ?? entity.Buoc.PartialView,
                DanhSachManHinh = entity.DuAnBuocManHinhs!.Count != 0
                    ? entity.DuAnBuocManHinhs!.Select(i => i.ManHinhId).ToList()
                    : entity.Buoc.BuocManHinhs!.Select(i => i.ManHinhId).ToList()
            })
            .PaginatedListAsync(request.Skip(), request.Take(), cancellationToken);
    }
}