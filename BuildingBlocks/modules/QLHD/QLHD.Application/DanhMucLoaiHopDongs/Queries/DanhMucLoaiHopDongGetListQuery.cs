using QLHD.Application.DanhMucLoaiHopDongs.DTOs;

namespace QLHD.Application.DanhMucLoaiHopDongs.Queries;

public record DanhMucLoaiHopDongGetListQuery(DanhMucLoaiHopDongSearchModel SearchModel) : IRequest<PaginatedList<DanhMucLoaiHopDongDto>>;

public record DanhMucLoaiHopDongSearchModel : AggregateRootSearch, ISearchString;

internal class DanhMucLoaiHopDongGetListQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucLoaiHopDongGetListQuery, PaginatedList<DanhMucLoaiHopDongDto>>
{
    private readonly IRepository<DanhMucLoaiHopDong, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiHopDong, int>>();

    public async Task<PaginatedList<DanhMucLoaiHopDongDto>> Handle(DanhMucLoaiHopDongGetListQuery request, CancellationToken cancellationToken = default)
    {
        var model = request.SearchModel;

        var query = _repository.GetQueryableSet()
            .WhereSearchString(model, e => e.Ma, e => e.Ten, e => e.MoTa)
            .OrderByDescending(e => e.CreatedAt)
            .Select(e => new DanhMucLoaiHopDongDto
            {
                Id = e.Id,
                Ma = e.Ma,
                Ten = e.Ten,
                MoTa = e.MoTa,
                Used = e.Used,
                Symbol = e.Symbol,
                Prefix = e.Prefix,
                IsDefault = e.IsDefault
            });

        return await query.PaginatedListAsync(model.Skip(), model.Take(), cancellationToken: cancellationToken);
    }
}