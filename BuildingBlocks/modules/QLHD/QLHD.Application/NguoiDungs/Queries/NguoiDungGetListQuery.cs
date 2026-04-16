namespace QLHD.Application.NguoiDungs.Queries;

public record NguoiDungGetListQuery(long? DonViId, long? PhongBanId) : IRequest<List<NguoiDungDto>>;

public class NguoiDungDto
{
    public long Id { get; set; }
    public string? UserName { get; set; }
    public string? HoTen { get; set; }
    public long? DonViId { get; set; }
    public string? TenDonVi { get; set; }
    public long? PhongBanId { get; set; }
    public string? TenPhongBan { get; set; }
}

internal class NguoiDungGetListQueryHandler(IServiceProvider serviceProvider)
    : IRequestHandler<NguoiDungGetListQuery, List<NguoiDungDto>>
{
    private readonly IRepository<UserMaster, long> _repository = serviceProvider.GetRequiredService<IRepository<UserMaster, long>>();
    private readonly IRepository<DmDonVi, long> _donViRepository = serviceProvider.GetRequiredService<IRepository<DmDonVi, long>>();

    public async Task<List<NguoiDungDto>> Handle(
        NguoiDungGetListQuery request,
        CancellationToken cancellationToken = default)
    {
        var query = _repository.GetQueryableSet()
            .Where(e => e.Used == true);

        if (request.DonViId.HasValue)
        {
            query = query.Where(e => e.DonViId == request.DonViId);
        }

        if (request.PhongBanId.HasValue)
        {
            query = query.Where(e => e.PhongBanId == request.PhongBanId);
        }

        // Use LeftOuterJoin for DonVi and PhongBan (legacy tables - no navigation)
        var donViQuery = _donViRepository.GetQueryableSet();

        var result = await query
            .LeftOuterJoin(
                donViQuery.Where(d => d.Used == true),
                u => u.DonViId,
                d => d.Id,
                (u, d) => new { User = u, TenDonVi = d.TenDonVi })
            .LeftOuterJoin(
                donViQuery.Where(p => p.Used == true),
                x => x.User.PhongBanId,
                p => p.Id,
                (x, p) => new NguoiDungDto
                {
                    Id = x.User.Id,
                    UserName = x.User.UserName,
                    HoTen = x.User.HoTen,
                    DonViId = x.User.DonViId,
                    TenDonVi = x.TenDonVi,
                    PhongBanId = x.User.PhongBanId,
                    TenPhongBan = p.TenDonVi
                })
            .OrderBy(d => d.HoTen)
            .ToListAsync(cancellationToken);

        return result;
    }
}