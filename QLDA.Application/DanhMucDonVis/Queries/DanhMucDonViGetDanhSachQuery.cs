using Microsoft.EntityFrameworkCore;
using QLDA.Application.Common.Mapping;

namespace QLDA.Application.DanhMucDonVis.Queries;

public record DanhMucDonViGetDanhSachQuery : AggregateRootPagination, IRequest<PaginatedList<DanhMucDonVi>> {
    /// <summary>
    /// Cấp ???
    /// </summary>
    public int? Cap { get; set; }

    /// <summary>
    /// Cấp đơn vị
    /// </summary>
    public List<long?>? CapDonViIds { get; set; }

    public bool IsTracking { get; set; }
}

public record DanhMucDonViGetDanhSachQueryHandler(IServiceProvider ServiceProvider)
    : IRequestHandler<DanhMucDonViGetDanhSachQuery, PaginatedList<DanhMucDonVi>> {
    private readonly IRepository<DanhMucDonVi, long> DanhMucDonVi =
        ServiceProvider.GetRequiredService<IRepository<DanhMucDonVi, long>>();

    public async Task<PaginatedList<DanhMucDonVi>> Handle(DanhMucDonViGetDanhSachQuery request,
        CancellationToken cancellationToken) {
        var query = DanhMucDonVi.GetQueryableSet().AsNoTracking()
            .Where(e => e.Used == true)
            .WhereIf(request.Cap > 0, e => e.Cap == request.Cap)
            .WhereIf(request.CapDonViIds != null, e => request.CapDonViIds!.Contains(e.CapDonViId))
            .WhereFunc(request.IsTracking, e => e.AsNoTracking());


        return await query
            .PaginatedListAsync(request.Skip(), request.Take(), cancellationToken);
    }
}