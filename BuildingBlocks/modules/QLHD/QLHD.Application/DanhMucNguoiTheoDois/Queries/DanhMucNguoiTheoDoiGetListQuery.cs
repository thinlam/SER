using QLHD.Application.DanhMucNguoiTheoDois.DTOs;

namespace QLHD.Application.DanhMucNguoiTheoDois.Queries;

public record DanhMucNguoiTheoDoiGetListQuery(DanhMucNguoiTheoDoiSearchModel SearchModel) : IRequest<PaginatedList<DanhMucNguoiTheoDoiDto>>;

public record DanhMucNguoiTheoDoiSearchModel : AggregateRootSearch, ISearchString;

internal class DanhMucNguoiTheoDoiGetListQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucNguoiTheoDoiGetListQuery, PaginatedList<DanhMucNguoiTheoDoiDto>>
{
    private readonly IRepository<DanhMucNguoiTheoDoi, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucNguoiTheoDoi, int>>();
    private readonly IRepository<UserMaster, long> _userMasterRepository = serviceProvider.GetRequiredService<IRepository<UserMaster, long>>();

    public async Task<PaginatedList<DanhMucNguoiTheoDoiDto>> Handle(DanhMucNguoiTheoDoiGetListQuery request, CancellationToken cancellationToken = default)
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
            .Select(x => new DanhMucNguoiTheoDoiDto
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