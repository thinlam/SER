using QLHD.Application.DanhMucTrangThais.DTOs;

namespace QLHD.Application.DanhMucTrangThais.Queries;

public record DanhMucTrangThaiGetListQuery(DanhMucTrangThaiSearchModel SearchModel) : IRequest<PaginatedList<DanhMucTrangThaiDto>>;

public record DanhMucTrangThaiSearchModel : AggregateRootSearch, ISearchString
{
    public int? LoaiTrangThaiId { get; set; }
}

internal class DanhMucTrangThaiGetListQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucTrangThaiGetListQuery, PaginatedList<DanhMucTrangThaiDto>>
{
    private readonly IRepository<DanhMucTrangThai, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucTrangThai, int>>();

    public async Task<PaginatedList<DanhMucTrangThaiDto>> Handle(DanhMucTrangThaiGetListQuery request, CancellationToken cancellationToken = default)
    {
        var model = request.SearchModel;

        var query = _repository.GetQueryableSet()
            .WhereSearchString(model, e => e.Ma, e => e.Ten, e => e.MoTa)
            .Where(e => !model.LoaiTrangThaiId.HasValue || e.LoaiTrangThaiId == model.LoaiTrangThaiId)
            .OrderByDescending(e => e.CreatedAt)
            .Select(e => new DanhMucTrangThaiDto
            {
                Id = e.Id,
                Ma = e.Ma,
                Ten = e.Ten,
                MoTa = e.MoTa,
                Used = e.Used,
                LoaiTrangThaiId = e.LoaiTrangThaiId,
                MaLoaiTrangThai = e.MaLoaiTrangThai,
                TenLoaiTrangThai = e.TenLoaiTrangThai
            });

        return await query.PaginatedListAsync(model.Skip(), model.Take(), cancellationToken: cancellationToken);
    }
}