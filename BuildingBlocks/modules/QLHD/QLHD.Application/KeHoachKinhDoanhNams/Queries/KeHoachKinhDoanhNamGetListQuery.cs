using QLHD.Application.KeHoachKinhDoanhNams.DTOs;

namespace QLHD.Application.KeHoachKinhDoanhNams.Queries;

public record KeHoachKinhDoanhNamGetListQuery(KeHoachKinhDoanhNamSearchModel SearchModel) : IRequest<PaginatedList<KeHoachKinhDoanhNamDto>>;

public record KeHoachKinhDoanhNamSearchModel : AggregateRootSearch, ISearchString
{
}

internal class KeHoachKinhDoanhNamGetListQueryHandler : IRequestHandler<KeHoachKinhDoanhNamGetListQuery, PaginatedList<KeHoachKinhDoanhNamDto>>
{
    private readonly IRepository<KeHoachKinhDoanhNam, Guid> _repository;

    public KeHoachKinhDoanhNamGetListQueryHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<KeHoachKinhDoanhNam, Guid>>();
    }

    public async Task<PaginatedList<KeHoachKinhDoanhNamDto>> Handle(KeHoachKinhDoanhNamGetListQuery request, CancellationToken cancellationToken = default)
    {
        var model = request.SearchModel;

        var query = _repository.GetQueryableSet()
            .WhereSearchString(model, e => e.GhiChu!)
            .OrderByDescending(e => e.CreatedAt)
            .Select(e => e.ToDto());

        return await query.PaginatedListAsync(model.Skip(), model.Take(), cancellationToken: cancellationToken);
    }
}