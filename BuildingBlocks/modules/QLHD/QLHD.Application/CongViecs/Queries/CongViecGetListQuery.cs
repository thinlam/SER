using QLHD.Application.CongViecs.DTOs;

namespace QLHD.Application.CongViecs.Queries;

public record CongViecGetListQuery(CongViecSearchModel SearchModel) : IRequest<PaginatedList<CongViecDto>>;

public record CongViecSearchModel : AggregateRootSearch, ISearchString {
    public Guid DuAnId { get; set; }
}

internal class CongViecGetListQueryHandler : IRequestHandler<CongViecGetListQuery, PaginatedList<CongViecDto>> {
    private readonly IRepository<CongViec, Guid> _repository;

    public CongViecGetListQueryHandler(IServiceProvider serviceProvider) {
        _repository = serviceProvider.GetRequiredService<IRepository<CongViec, Guid>>();
    }

    public async Task<PaginatedList<CongViecDto>> Handle(CongViecGetListQuery request, CancellationToken cancellationToken = default) {
        var model = request.SearchModel;

        var query = _repository.GetQueryableSet()
            .Where(e => e.DuAnId == model.DuAnId)
            .WhereSearchString(model, e => e.NguoiThucHien, e => e.KeHoachCongViec, e => e.ThucTe)
            .OrderByDescending(e => e.CreatedAt)
            .Select(e => e.ToDto());

        return await query.PaginatedListAsync(model.Skip(), model.Take(), cancellationToken: cancellationToken);
    }
}