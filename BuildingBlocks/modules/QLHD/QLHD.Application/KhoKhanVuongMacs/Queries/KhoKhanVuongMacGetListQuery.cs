using QLHD.Application.KhoKhanVuongMacs.DTOs;

namespace QLHD.Application.KhoKhanVuongMacs.Queries;

public record KhoKhanVuongMacGetListQuery(Guid HopDongId) : IRequest<List<KhoKhanVuongMacDto>>;

internal class KhoKhanVuongMacGetListQueryHandler : IRequestHandler<KhoKhanVuongMacGetListQuery, List<KhoKhanVuongMacDto>>
{
    private readonly IRepository<KhoKhanVuongMac, Guid> _repository;

    public KhoKhanVuongMacGetListQueryHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<KhoKhanVuongMac, Guid>>();
    }

    public async Task<List<KhoKhanVuongMacDto>> Handle(KhoKhanVuongMacGetListQuery request, CancellationToken cancellationToken = default)
    {
        return await _repository.GetQueryableSet()
            .Where(k => k.HopDongId == request.HopDongId)
            .Include(k => k.TienDo)
            .Include(k => k.TrangThai)
            .OrderByDescending(k => k.NgayPhatHien)
            .Select(k => k.ToDto())
            .ToListAsync(cancellationToken);
    }
}