using QLHD.Application.BaoCaoTienDos.DTOs;

namespace QLHD.Application.BaoCaoTienDos.Queries;

/// <summary>
/// Get list of pending reports for an approver
/// </summary>
public record BaoCaoTienDoGetPendingByNguoiDuyetQuery(long NguoiDuyetId) : IRequest<List<BaoCaoTienDoDto>>;

internal class BaoCaoTienDoGetPendingByNguoiDuyetQueryHandler : IRequestHandler<BaoCaoTienDoGetPendingByNguoiDuyetQuery, List<BaoCaoTienDoDto>>
{
    private readonly IRepository<BaoCaoTienDo, Guid> _repository;

    public BaoCaoTienDoGetPendingByNguoiDuyetQueryHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<BaoCaoTienDo, Guid>>();
    }

    public async Task<List<BaoCaoTienDoDto>> Handle(BaoCaoTienDoGetPendingByNguoiDuyetQuery request, CancellationToken cancellationToken = default)
    {
        return await _repository.GetQueryableSet()
            .Where(b => b.NguoiDuyetId == request.NguoiDuyetId
                     && b.CanDuyet
                     && !b.DaDuyet
                     && !b.IsDeleted)
            .Include(b => b.TienDo)
            .OrderByDescending(b => b.NgayBaoCao)
            .Select(b => b.ToDto())
            .ToListAsync(cancellationToken);
    }
}