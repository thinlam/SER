using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Application.DanhMucLoaiLais.Queries;

public record DanhMucLoaiLaiGetComboboxQuery : IRequest<List<ComboBoxDto<int>>>;

internal class DanhMucLoaiLaiGetComboboxQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucLoaiLaiGetComboboxQuery, List<ComboBoxDto<int>>>
{
    private readonly IRepository<DanhMucLoaiLai, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiLai, int>>();

    public async Task<List<ComboBoxDto<int>>> Handle(DanhMucLoaiLaiGetComboboxQuery request, CancellationToken cancellationToken = default)
    {
        var query = _repository.GetQueryableSet()
            .OrderBy(e => e.Ten)
            .Select(e => new ComboBoxDto<int>
            {
                Id = e.Id,
                Ten = e.Ten
            });

        return await query.ToListAsync(cancellationToken);
    }
}