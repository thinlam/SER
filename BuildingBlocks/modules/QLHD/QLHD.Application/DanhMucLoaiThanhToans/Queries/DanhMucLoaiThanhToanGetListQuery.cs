using QLHD.Application.DanhMucLoaiThanhToans.DTOs;

namespace QLHD.Application.DanhMucLoaiThanhToans.Queries;

public record DanhMucLoaiThanhToanGetListQuery(DanhMucLoaiThanhToanSearchModel SearchModel) : IRequest<PaginatedList<DanhMucLoaiThanhToanDto>>;

public record DanhMucLoaiThanhToanSearchModel : AggregateRootSearch, ISearchString;

internal class DanhMucLoaiThanhToanGetListQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucLoaiThanhToanGetListQuery, PaginatedList<DanhMucLoaiThanhToanDto>>
{
    private readonly IRepository<DanhMucLoaiThanhToan, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiThanhToan, int>>();

    public async Task<PaginatedList<DanhMucLoaiThanhToanDto>> Handle(DanhMucLoaiThanhToanGetListQuery request, CancellationToken cancellationToken = default)
    {
        var model = request.SearchModel;

        var query = _repository.GetQueryableSet()
            .WhereSearchString(model, e => e.Ma, e => e.Ten, e => e.MoTa)
            .OrderByDescending(e => e.CreatedAt)
            .Select(e => new DanhMucLoaiThanhToanDto
            {
                Id = e.Id,
                Ma = e.Ma,
                Ten = e.Ten,
                MoTa = e.MoTa,
                Used = e.Used,
                IsDefault = e.IsDefault
            });

        return await query.PaginatedListAsync(model.Skip(), model.Take(), cancellationToken: cancellationToken);
    }
}