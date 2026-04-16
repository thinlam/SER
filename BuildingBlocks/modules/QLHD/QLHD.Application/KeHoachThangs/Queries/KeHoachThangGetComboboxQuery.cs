using QLHD.Domain.Entities;

namespace QLHD.Application.KeHoachThangs.Queries;

public record KeHoachThangGetComboboxQuery : IRequest<List<ComboBoxDto<int>>>;

internal class KeHoachThangGetComboboxQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<KeHoachThangGetComboboxQuery, List<ComboBoxDto<int>>>
{
    private readonly IRepository<KeHoachThang, int> _repository = serviceProvider.GetRequiredService<IRepository<KeHoachThang, int>>();

    public async Task<List<ComboBoxDto<int>>> Handle(KeHoachThangGetComboboxQuery request, CancellationToken cancellationToken = default)
    {
        var query = _repository.GetQueryableSet()
            .OrderByDescending(e => e.TuNgay)
            .Select(e => new ComboBoxDto<int>
            {
                Id = e.Id,
                Ten = $"{e.TuThangDisplay} - {e.DenThangDisplay}"
            });

        return await query.ToListAsync(cancellationToken);
    }
}