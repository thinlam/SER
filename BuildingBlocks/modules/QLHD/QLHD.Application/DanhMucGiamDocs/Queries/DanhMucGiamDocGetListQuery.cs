using QLHD.Application.DanhMucGiamDocs.DTOs;

namespace QLHD.Application.DanhMucGiamDocs.Queries;

public record DanhMucGiamDocGetListQuery(DanhMucGiamDocSearchModel SearchModel) : IRequest<PaginatedList<DanhMucGiamDocDto>>;

public record DanhMucGiamDocSearchModel : AggregateRootSearch, ISearchString;

internal class DanhMucGiamDocGetListQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucGiamDocGetListQuery, PaginatedList<DanhMucGiamDocDto>>
{
    private readonly IRepository<DanhMucGiamDoc, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucGiamDoc, int>>();
    private readonly IRepository<UserMaster, long> _userMasterRepository = serviceProvider.GetRequiredService<IRepository<UserMaster, long>>();

    public async Task<PaginatedList<DanhMucGiamDocDto>> Handle(DanhMucGiamDocGetListQuery request, CancellationToken cancellationToken = default)
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
            .Select(x => new DanhMucGiamDocDto
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