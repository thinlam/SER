using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Application.TepDinhKems.Queries;

public record GetDanhSachTepDinhKemQuery : IRequest<List<TepDinhKem>>
{

    public required List<string> GroupId { get; set; } = [];
    public List<string> GroupTypes { get; set; } = [];
}

public record GetDanhSachTepDinhKemQueryHandler(IServiceProvider ServiceProvider)
    : IRequestHandler<GetDanhSachTepDinhKemQuery, List<TepDinhKem>>
{
    private readonly IRepository<TepDinhKem, Guid> TepDinhKem =
        ServiceProvider.GetRequiredService<IRepository<TepDinhKem, Guid>>();

    public async Task<List<TepDinhKem>> Handle(GetDanhSachTepDinhKemQuery request,
        CancellationToken cancellationToken)
    {
        return await TepDinhKem.GetQueryableSet()
            .WhereIf(request.GroupTypes.Count != 0,
                o => request.GroupId.Contains(o.GroupId) && (request.GroupTypes.Contains(o.GroupType) || o.GroupType == string.Empty),
                o => request.GroupId.Contains(o.GroupId))
            .ToListAsync(cancellationToken);
    }
}
