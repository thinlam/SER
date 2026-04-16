namespace QLHD.Application.DanhMucDonVis.Queries;

public record DanhMucDonViGetComboboxQuery : IRequest<List<ComboBoxDto<long>>>;

internal class DanhMucDonViGetComboboxQueryHandler(IServiceProvider serviceProvider)
    : IRequestHandler<DanhMucDonViGetComboboxQuery, List<ComboBoxDto<long>>>
{
    private readonly IRepository<DmDonVi, long> _repository = serviceProvider.GetRequiredService<IRepository<DmDonVi, long>>();

    public async Task<List<ComboBoxDto<long>>> Handle(
        DanhMucDonViGetComboboxQuery request,
        CancellationToken cancellationToken = default)
    {
        return await _repository.GetQueryableSet()
            .Where(e => e.Used == true)
            .OrderBy(e => e.TenDonVi)
            .Select(e => new ComboBoxDto<long>
            {
                Id = e.Id,
                Ten = e.TenDonVi
            })
            .ToListAsync(cancellationToken);
    }
}