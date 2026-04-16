using Microsoft.EntityFrameworkCore;

namespace QLDA.Application.TepDinhKems.Queries;

public record GetDanhSachTepDinhKemQuery : IRequest<List<TepDinhKem>> {

    public required List<string> GroupId { get; set; } = [];
    public List<string> EGroupTypes { get; set; } = [];
}

public record GetDanhSachTepDinhKemQueryHandler(IServiceProvider ServiceProvider)
    : IRequestHandler<GetDanhSachTepDinhKemQuery, List<TepDinhKem>> {
    private readonly IRepository<TepDinhKem, Guid> TepDinhKem =
        ServiceProvider.GetRequiredService<IRepository<TepDinhKem, Guid>>();

    public async Task<List<TepDinhKem>> Handle(GetDanhSachTepDinhKemQuery request,
        CancellationToken cancellationToken) {
        return await TepDinhKem.GetQueryableSet()
            .WhereIf(request.EGroupTypes.Count != 0,
                o => request.GroupId.Contains(o.GroupId) && request.EGroupTypes.Contains(o.GroupType),
                o => request.GroupId.Contains(o.GroupId))
            .ToListAsync(cancellationToken);
    }
}