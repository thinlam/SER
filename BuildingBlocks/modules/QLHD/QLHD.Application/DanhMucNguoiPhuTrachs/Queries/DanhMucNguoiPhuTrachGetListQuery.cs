using QLHD.Application.DanhMucNguoiPhuTrachs.DTOs;

namespace QLHD.Application.DanhMucNguoiPhuTrachs.Queries;

public record DanhMucNguoiPhuTrachGetListQuery(DanhMucNguoiPhuTrachSearchModel SearchModel) : IRequest<PaginatedList<DanhMucNguoiPhuTrachDto>>;

public record DanhMucNguoiPhuTrachSearchModel : AggregateRootSearch, ISearchString;

internal class DanhMucNguoiPhuTrachGetListQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucNguoiPhuTrachGetListQuery, PaginatedList<DanhMucNguoiPhuTrachDto>>
{
    private readonly IRepository<DanhMucNguoiPhuTrach, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucNguoiPhuTrach, int>>();
    private readonly IRepository<UserMaster, long> _userMasterRepository = serviceProvider.GetRequiredService<IRepository<UserMaster, long>>();

    public async Task<PaginatedList<DanhMucNguoiPhuTrachDto>> Handle(DanhMucNguoiPhuTrachGetListQuery request, CancellationToken cancellationToken = default)
    {
        var model = request.SearchModel;

        var query = _repository.GetQueryableSet()
            .LeftOuterJoin(
                _userMasterRepository.GetQueryableSet(),
                e => e.UserPortalId,
                u => u.Id,
                (e, u) => new { Entity = e, User = u })
            .WhereSearchString(model, x => x.Entity.Ma, x => x.Entity.Ten, x => x.Entity.MoTa)
            .OrderByDescending(x => x.Entity.CreatedAt)
            .Select(x => new DanhMucNguoiPhuTrachDto
            {
                Id = x.Entity.Id,
                Ma = x.Entity.Ma,
                Ten = x.Entity.Ten,
                MoTa = x.Entity.MoTa,
                Used = x.Entity.Used,
                UserPortalId = x.Entity.UserPortalId,
                DonViId = x.Entity.DonViId,
                PhongBanId = x.Entity.PhongBanId,
                UserHoTen = x.User.HoTen,
                UserUserName = x.User.UserName
            });

        return await query.PaginatedListAsync(model.Skip(), model.Take(), cancellationToken: cancellationToken);
    }
}