namespace QLHD.Application.DanhMucDonVis.Queries;

public record DanhMucDonViGetDonViListQuery : IRequest<List<DanhMucDonViDto>>;

internal class DanhMucDonViGetDonViListQueryHandler(IServiceProvider serviceProvider)
    : IRequestHandler<DanhMucDonViGetDonViListQuery, List<DanhMucDonViDto>>
{
    private readonly IRepository<DmDonVi, long> _repository = serviceProvider.GetRequiredService<IRepository<DmDonVi, long>>();

    public async Task<List<DanhMucDonViDto>> Handle(
        DanhMucDonViGetDonViListQuery request,
        CancellationToken cancellationToken = default)
    {
        // Don vi: DonViCapChaId == null (top-level organizations)
        return await _repository.GetQueryableSet()
            .Where(e => e.Used == true)
            .Where(e => e.DonViCapChaId == null)
            .OrderBy(e => e.TenDonVi)
            .Select(e => new DanhMucDonViDto
            {
                Id = e.Id,
                MaDonVi = e.MaDonVi,
                TenDonVi = e.TenDonVi,
                TenVietTat = e.TenVietTat,
                DonViCapChaId = e.DonViCapChaId
            })
            .ToListAsync(cancellationToken);
    }
}