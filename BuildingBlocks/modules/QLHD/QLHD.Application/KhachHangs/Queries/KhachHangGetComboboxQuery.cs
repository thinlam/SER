namespace QLHD.Application.KhachHangs.Queries;

public record KhachHangGetComboboxQuery : IRequest<List<ComboBoxDto<Guid>>>;

internal class KhachHangGetComboboxQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<KhachHangGetComboboxQuery, List<ComboBoxDto<Guid>>>
{
    private readonly IRepository<KhachHang, Guid> _repository = serviceProvider.GetRequiredService<IRepository<KhachHang, Guid>>();

    public async Task<List<ComboBoxDto<Guid>>> Handle(KhachHangGetComboboxQuery request, CancellationToken cancellationToken = default)
    {
        return await _repository.GetQueryableSet()
            .OrderBy(e => e.Ten)
            .Select(e => new ComboBoxDto<Guid>
            {
                Id = e.Id,
                Ten = e.Ten,
                Ma = e.Ma
            })
            .ToListAsync(cancellationToken);
    }
}