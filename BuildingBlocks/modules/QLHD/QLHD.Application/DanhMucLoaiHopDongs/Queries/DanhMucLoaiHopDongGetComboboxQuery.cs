namespace QLHD.Application.DanhMucLoaiHopDongs.Queries;

public record DanhMucLoaiHopDongGetComboboxQuery : IRequest<List<ComboBoxDto<int>>>;

internal class DanhMucLoaiHopDongGetComboboxQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucLoaiHopDongGetComboboxQuery, List<ComboBoxDto<int>>>
{
    private readonly IRepository<DanhMucLoaiHopDong, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiHopDong, int>>();

    public async Task<List<ComboBoxDto<int>>> Handle(DanhMucLoaiHopDongGetComboboxQuery request, CancellationToken cancellationToken = default)
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