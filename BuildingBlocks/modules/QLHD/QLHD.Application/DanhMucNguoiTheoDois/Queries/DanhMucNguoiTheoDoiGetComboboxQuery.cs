namespace QLHD.Application.DanhMucNguoiTheoDois.Queries;

public record DanhMucNguoiTheoDoiGetComboboxQuery : IRequest<List<ComboBoxDto<int>>>;

internal class DanhMucNguoiTheoDoiGetComboboxQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucNguoiTheoDoiGetComboboxQuery, List<ComboBoxDto<int>>>
{
    private readonly IRepository<DanhMucNguoiTheoDoi, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucNguoiTheoDoi, int>>();
    private readonly IRepository<UserMaster, long> _userMasterRepository = serviceProvider.GetRequiredService<IRepository<UserMaster, long>>();

    public async Task<List<ComboBoxDto<int>>> Handle(DanhMucNguoiTheoDoiGetComboboxQuery request, CancellationToken cancellationToken = default)
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