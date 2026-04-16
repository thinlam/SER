namespace QLHD.Application.DanhMucNguoiPhuTrachs.Queries;

public record DanhMucNguoiPhuTrachGetComboboxQuery : IRequest<List<ComboBoxDto<int>>>;

internal class DanhMucNguoiPhuTrachGetComboboxQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucNguoiPhuTrachGetComboboxQuery, List<ComboBoxDto<int>>>
{
    private readonly IRepository<DanhMucNguoiPhuTrach, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucNguoiPhuTrach, int>>();
    private readonly IRepository<UserMaster, long> _userMasterRepository = serviceProvider.GetRequiredService<IRepository<UserMaster, long>>();

    public async Task<List<ComboBoxDto<int>>> Handle(DanhMucNguoiPhuTrachGetComboboxQuery request, CancellationToken cancellationToken = default)
    {
        var query = _repository.GetQueryableSet()
            .LeftOuterJoin(
                _userMasterRepository.GetQueryableSet(),
                e => e.UserPortalId,
                u => u.Id,
                (e, u) => new { Entity = e, User = u })
            .Where(x => !x.Entity.IsDeleted && x.Entity.Used)
            .OrderBy(x => x.User.HoTen)
            .Select(x => new ComboBoxDto<int>
            {
                Id = x.Entity.Id,
                Ten = x.User.HoTen ?? x.Entity.Ten
            });

        return await query.ToListAsync(cancellationToken);
    }
}