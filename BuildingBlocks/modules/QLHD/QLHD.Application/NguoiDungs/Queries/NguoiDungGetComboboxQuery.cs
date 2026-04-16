namespace QLHD.Application.NguoiDungs.Queries;

public record NguoiDungGetComboboxQuery(long DonViId, long PhongBanId) : IRequest<List<ComboBoxDto<long>>>;

internal class NguoiDungGetComboboxQueryHandler(IServiceProvider serviceProvider)
    : IRequestHandler<NguoiDungGetComboboxQuery, List<ComboBoxDto<long>>>
{
    private readonly IRepository<UserMaster, long> _repository = serviceProvider.GetRequiredService<IRepository<UserMaster, long>>();

    public async Task<List<ComboBoxDto<long>>> Handle(
        NguoiDungGetComboboxQuery request,
        CancellationToken cancellationToken = default)
    {
        return await _repository.GetQueryableSet()
            .Where(e => e.Used == true)
            .Where(e => e.DonViId == request.DonViId)
            .Where(e => e.PhongBanId == request.PhongBanId)
            .OrderBy(e => e.HoTen)
            .Select(e => new ComboBoxDto<long>
            {
                Id = e.Id,
                Ten = e.HoTen
            })
            .ToListAsync(cancellationToken);
    }
}