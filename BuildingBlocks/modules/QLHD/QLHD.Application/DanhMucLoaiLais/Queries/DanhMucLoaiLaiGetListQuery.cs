using QLHD.Application.DanhMucLoaiLais.DTOs;
using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Application.DanhMucLoaiLais.Queries;

public record DanhMucLoaiLaiGetListQuery(DanhMucLoaiLaiSearchModel SearchModel) : IRequest<PaginatedList<DanhMucLoaiLaiDto>>;

internal class DanhMucLoaiLaiGetListQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucLoaiLaiGetListQuery, PaginatedList<DanhMucLoaiLaiDto>>
{
    private readonly IRepository<DanhMucLoaiLai, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiLai, int>>();

    public async Task<PaginatedList<DanhMucLoaiLaiDto>> Handle(DanhMucLoaiLaiGetListQuery request, CancellationToken cancellationToken = default)
    {
        var model = request.SearchModel;

        var query = _repository.GetQueryableSet()
            .WhereSearchString(model, e => e.Ma, e => e.Ten, e => e.MoTa)
            .OrderByDescending(e => e.CreatedAt)
            .Select(e => new DanhMucLoaiLaiDto
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