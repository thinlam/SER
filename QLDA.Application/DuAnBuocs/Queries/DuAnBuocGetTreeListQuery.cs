
using Microsoft.EntityFrameworkCore;
using QLDA.Application.DanhMucBuocs.DTOs;
using QLDA.Application.DuAnBuocs.DTOs;
using QLDA.Application.DuAnBuocs.Extensions;

namespace QLDA.Application.DuAnBuocs.Queries;

public class DuAnBuocGetTreeListQuery : IRequest<List<DuAnBuocStateDto>> {
    public Guid DuAnId { get; set; }
    public bool IsNoTracking { get; set; } = true;
}

internal class DuAnBuocGetTreeListQueryHandler(IServiceProvider serviceProvider)
    : IRequestHandler<DuAnBuocGetTreeListQuery, List<DuAnBuocStateDto>> {
    private readonly IRepository<DuAnBuoc, int> DuAnBuoc =
        serviceProvider.GetRequiredService<IRepository<DuAnBuoc, int>>();

    public async Task<List<DuAnBuocStateDto>> Handle(DuAnBuocGetTreeListQuery request,
        CancellationToken cancellationToken = default) {
        var queryable = DuAnBuoc.GetQueryableSet()
            .WhereFunc(request.IsNoTracking, q => q.AsNoTracking())
            .Include(e => e.Buoc!.GiaiDoan)
            .Include(e => e.Buoc!.QuyTrinh)
            .Include(e => e.DuAn)
            .Where(o => o.DuAnId == request.DuAnId);

        var all = await queryable.ToListAsync(cancellationToken: cancellationToken);

        var orderedSteps = all.ToSteps().ToTreeList();
        var result = orderedSteps.Join(all, step => step.BuocId, origin => origin.BuocId,
                (step, origin) => new { step, origin })
            .Select(e => new DuAnBuocStateDto() {
                Id = e.origin.Id,
                TenDuAn = e.origin.DuAn?.TenDuAn ?? ErrorMessageConstants.Unknown,
                TenQuyTrinh = e.origin.Buoc?.QuyTrinh?.Ten ?? ErrorMessageConstants.Unknown,
                TenGiaiDoan =  e.origin.Buoc?.GiaiDoan?.Ten ?? ErrorMessageConstants.Unknown,
                GiaiDoanId = e.origin.Buoc?.GiaiDoanId,
                BuocId = e.origin.BuocId,
                TenBuoc = e.step.Ten,
                QuyTrinhId = e.step.Id,
                ParentId = e.step.ParentId,
                Level = e.step.Level,
                PartialView = e.origin.PartialView ?? e.step.PartialView,
                Path = e.step.Path,
                Stt = e.step.Stt,
                GhiChu = e.origin.GhiChu,
                IsKetThuc = e.origin.IsKetThuc,
                NgayDuKienBatDau = e.origin.NgayDuKienBatDau,
                NgayDuKienKetThuc = e.origin.NgayDuKienKetThuc,
                NgayThucTeBatDau = e.origin.NgayThucTeBatDau,
                NgayThucTeKetThuc = e.origin.NgayThucTeKetThuc,
                TrachNhiemThucHien = e.origin.TrachNhiemThucHien,
                TrangThaiId = e.origin.TrangThaiId,
            }).ToList();

        return result;
    }
}