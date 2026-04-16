namespace QLHD.Application.DanhMucLoaiThanhToans.Queries;

public record DanhMucLoaiThanhToanGetComboboxQuery : IRequest<List<ComboBoxDto<int>>>;

internal class DanhMucLoaiThanhToanGetComboboxQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucLoaiThanhToanGetComboboxQuery, List<ComboBoxDto<int>>>
{
    private readonly IRepository<DanhMucLoaiThanhToan, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiThanhToan, int>>();

    public async Task<List<ComboBoxDto<int>>> Handle(DanhMucLoaiThanhToanGetComboboxQuery request, CancellationToken cancellationToken = default)
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