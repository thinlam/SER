using QLHD.Application.DanhMucLoaiTrangThais.DTOs;

namespace QLHD.Application.DanhMucLoaiTrangThais.Queries;

public record DanhMucLoaiTrangThaiGetListQuery(DanhMucLoaiTrangThaiSearchModel SearchModel) : IRequest<PaginatedList<DanhMucLoaiTrangThaiDto>>;

public record DanhMucLoaiTrangThaiSearchModel : AggregateRootSearch, ISearchString;

internal class DanhMucLoaiTrangThaiGetListQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucLoaiTrangThaiGetListQuery, PaginatedList<DanhMucLoaiTrangThaiDto>>
{
    private readonly IRepository<DanhMucLoaiTrangThai, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiTrangThai, int>>();

    public async Task<PaginatedList<DanhMucLoaiTrangThaiDto>> Handle(DanhMucLoaiTrangThaiGetListQuery request, CancellationToken cancellationToken = default)
    {
        var model = request.SearchModel;

        var query = _repository.GetQueryableSet()
            .WhereSearchString(model, e => e.Ma, e => e.Ten, e => e.MoTa)
            .OrderByDescending(e => e.CreatedAt)
            .Select(e => new DanhMucLoaiTrangThaiDto
            {
                Id = e.Id,
                Ma = e.Ma,
                Ten = e.Ten,
                MoTa = e.MoTa,
                Used = e.Used
            });

        return await query.PaginatedListAsync(model.Skip(), model.Take(), cancellationToken: cancellationToken);
    }
}