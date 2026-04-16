using QLHD.Application.DanhMucLoaiChiPhis.DTOs;

namespace QLHD.Application.DanhMucLoaiChiPhis.Queries;

public record DanhMucLoaiChiPhiGetListQuery(DanhMucLoaiChiPhiSearchModel SearchModel) : IRequest<PaginatedList<DanhMucLoaiChiPhiDto>>;

public record DanhMucLoaiChiPhiSearchModel : AggregateRootSearch, ISearchString;

internal class DanhMucLoaiChiPhiGetListQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucLoaiChiPhiGetListQuery, PaginatedList<DanhMucLoaiChiPhiDto>>
{
    private readonly IRepository<DanhMucLoaiChiPhi, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiChiPhi, int>>();

    public async Task<PaginatedList<DanhMucLoaiChiPhiDto>> Handle(DanhMucLoaiChiPhiGetListQuery request, CancellationToken cancellationToken = default)
    {
        var model = request.SearchModel;

        var query = _repository.GetQueryableSet()
            .WhereSearchString(model, e => e.Ma, e => e.Ten, e => e.MoTa)
            .OrderByDescending(e => e.CreatedAt)
            .Select(e => new DanhMucLoaiChiPhiDto
            {
                Id = e.Id,
                Ma = e.Ma,
                Ten = e.Ten,
                MoTa = e.MoTa,
                Used = e.Used,
                IsDefault = e.IsDefault,
                IsMajor = e.IsMajor
            });

        return await query.PaginatedListAsync(model.Skip(), model.Take(), cancellationToken: cancellationToken);
    }
}