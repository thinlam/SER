using QLHD.Application.KeHoachThangs.DTOs;
using QLHD.Domain.Entities;

namespace QLHD.Application.KeHoachThangs.Queries;

public record KeHoachThangGetListQuery(KeHoachThangSearchModel SearchModel) : IRequest<PaginatedList<KeHoachThangDto>>;

public record KeHoachThangSearchModel : AggregateRootSearch, ISearchString
{
    /// <summary>
    /// Lọc theo năm (khớp với TuNgay hoặc DenNgay)
    /// </summary>
    public int? Nam { get; set; }
}

internal class KeHoachThangGetListQueryHandler : IRequestHandler<KeHoachThangGetListQuery, PaginatedList<KeHoachThangDto>>
{
    private readonly IRepository<KeHoachThang, int> _repository;

    public KeHoachThangGetListQueryHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<KeHoachThang, int>>();
    }

    public async Task<PaginatedList<KeHoachThangDto>> Handle(KeHoachThangGetListQuery request, CancellationToken cancellationToken = default)
    {
        var model = request.SearchModel;

        var query = _repository.GetQueryableSet()
            .WhereIf(model.Nam.HasValue, e => e.TuNgay.Year == model.Nam || e.DenNgay.Year == model.Nam)
            .WhereSearchString(model, e => e.TuThangDisplay!)
            .OrderByDescending(e => e.CreatedAt)
            .Select(e => e.ToDto());

        return await query.PaginatedListAsync(model.Skip(), model.Take(), cancellationToken: cancellationToken);
    }
}