namespace QLHD.Application.DanhMucLoaiChiPhis.Queries;

public record DanhMucLoaiChiPhiGetComboboxQuery : IRequest<List<ComboBoxDto<int>>>;

internal class DanhMucLoaiChiPhiGetComboboxQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucLoaiChiPhiGetComboboxQuery, List<ComboBoxDto<int>>>
{
    private readonly IRepository<DanhMucLoaiChiPhi, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiChiPhi, int>>();

    public async Task<List<ComboBoxDto<int>>> Handle(DanhMucLoaiChiPhiGetComboboxQuery request, CancellationToken cancellationToken = default)
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