using Microsoft.EntityFrameworkCore;
using QLDA.Application.Common.Mapping;
using QLDA.Application.TepDinhKems.DTOs;
using QLDA.Application.ThanhToans.DTOs;

namespace QLDA.Application.ThanhToans.Queries;

public record ThanhToanGetDanhSachQuery : AggregateRootPagination, IMayHaveGlobalFilter, IRequest<PaginatedList<ThanhToanDto>> {
    public Guid? DuAnId { get; set; }
    public int? BuocId { get; set; }
    public Guid? HopDongId { get; set; }
    public string? GlobalFilter { get; set; }
    public bool IsNoTracking { get; set; }
}

internal class
    ThanhToanGetDanhSachQueryHandler : IRequestHandler<ThanhToanGetDanhSachQuery,
    PaginatedList<ThanhToanDto>> {
    private readonly IRepository<ThanhToan, Guid> ThanhToan;
    private readonly IRepository<TepDinhKem, Guid> TepDinhKem;

    public ThanhToanGetDanhSachQueryHandler(IServiceProvider serviceProvider) {
        ThanhToan = serviceProvider.GetRequiredService<IRepository<ThanhToan, Guid>>();
        TepDinhKem = serviceProvider.GetRequiredService<IRepository<TepDinhKem, Guid>>();
    }

    public async Task<PaginatedList<ThanhToanDto>> Handle(ThanhToanGetDanhSachQuery request,
        CancellationToken cancellationToken = default) {
        var queryable = ThanhToan.GetQueryableSet().AsNoTracking()
            .Where(e => !e.IsDeleted)
            .Where(e => !e.DuAn!.IsDeleted)
            .WhereIf(request.DuAnId != null, e => e.DuAnId == request.DuAnId)
            .WhereIf(request.HopDongId != null, e => e.NghiemThu!.HopDongId == request.HopDongId)
            .WhereIf(request.BuocId > 0, e => e.BuocId == request.BuocId)
            .WhereGlobalFilter(
                request,
                e => e.SoHoaDon,
                e => e.NoiDung
            );

        return await queryable
            .Select(e => new ThanhToanDto() {
                Id = e.Id,
                DuAnId = e.DuAnId,
                BuocId = e.BuocId,
                SoHoaDon = e.SoHoaDon,
                NgayHoaDon = e.NgayHoaDon,
                GiaTri = e.GiaTri,
                NoiDung = e.NoiDung,
                NghiemThuId = e.NghiemThuId,
                DanhSachTepDinhKem = TepDinhKem.GetQueryableSet()
                    .Where(i => i.GroupId == e.Id.ToString())
                    .Select(i => i.ToDto()).ToList(),
            })
            .PaginatedListAsync(request.Skip(), request.Take(), cancellationToken: cancellationToken);
    }
}