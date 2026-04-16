namespace QLHD.Application.DanhMucDonVis.Queries;

public record DanhMucDonViGetPhongBanListQuery : IRequest<List<DanhMucDonViDto>>;

public class DanhMucDonViDto
{
    public long Id { get; set; }
    public string? MaDonVi { get; set; }
    public string? TenDonVi { get; set; }
    public string? TenVietTat { get; set; }
    public long? DonViCapChaId { get; set; }
    public string? TenDonViCapCha { get; set; }
}

internal class DanhMucDonViGetPhongBanListQueryHandler(IServiceProvider serviceProvider)
    : IRequestHandler<DanhMucDonViGetPhongBanListQuery, List<DanhMucDonViDto>>
{
    private readonly IRepository<DmDonVi, long> _repository = serviceProvider.GetRequiredService<IRepository<DmDonVi, long>>();

    public async Task<List<DanhMucDonViDto>> Handle(
        DanhMucDonViGetPhongBanListQuery request,
        CancellationToken cancellationToken = default)
    {
        // Phong ban: DonViCapChaId != null (departments under a parent organization)
        var phongBans = await _repository.GetQueryableSet()
            .Where(e => e.Used == true)
            .Where(e => e.DonViCapChaId != null)
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

        // Get parent names
        var parentIds = phongBans
            .Where(p => p.DonViCapChaId.HasValue)
            .Select(p => p.DonViCapChaId!.Value)
            .Distinct()
            .ToList();

        var parents = await _repository.GetQueryableSet()
            .Where(e => parentIds.Contains(e.Id))
            .Select(e => new { e.Id, e.TenDonVi })
            .ToDictionaryAsync(e => e.Id, e => e.TenDonVi, cancellationToken);

        foreach (var phongBan in phongBans.Where(p => p.DonViCapChaId.HasValue))
        {
            phongBan.TenDonViCapCha = parents.GetValueOrDefault(phongBan.DonViCapChaId!.Value);
        }

        return phongBans;
    }
}