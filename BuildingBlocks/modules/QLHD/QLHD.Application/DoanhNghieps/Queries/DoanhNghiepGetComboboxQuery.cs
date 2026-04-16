namespace QLHD.Application.DoanhNghieps.Queries;

public record DoanhNghiepGetComboboxQuery(string? Search) : IRequest<List<ComboBoxDto<Guid>>>;

internal class DoanhNghiepGetComboboxQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DoanhNghiepGetComboboxQuery, List<ComboBoxDto<Guid>>>
{
    private readonly IRepository<DoanhNghiep, Guid> _repository = serviceProvider.GetRequiredService<IRepository<DoanhNghiep, Guid>>();

    public async Task<List<ComboBoxDto<Guid>>> Handle(DoanhNghiepGetComboboxQuery request, CancellationToken cancellationToken = default)
    {
        var query = _repository.GetQueryableSet()
            .Where(e => e.IsActive);

        if (!string.IsNullOrEmpty(request.Search))
        {
            var search = request.Search.ToLower();
            query = query.Where(e => (e.TaxCode != null && e.TaxCode.ToLower().Contains(search)) ||
                                     (e.Ten != null && e.Ten.ToLower().Contains(search)));
        }

        return await query
            .OrderBy(e => e.Ten)
            .Select(e => new ComboBoxDto<Guid>
            {
                Id = e.Id,
                Ten = e.Ten ?? string.Empty,
                Ma = e.TaxCode
            })
            .Take(100)
            .ToListAsync(cancellationToken);
    }
}