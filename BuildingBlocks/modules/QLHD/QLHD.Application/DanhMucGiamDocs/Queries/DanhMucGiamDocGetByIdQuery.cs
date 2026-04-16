using QLHD.Application.DanhMucGiamDocs.DTOs;

namespace QLHD.Application.DanhMucGiamDocs.Queries;

public record DanhMucGiamDocGetByIdQuery(int Id) : IRequest<DanhMucGiamDocDto>;

internal class DanhMucGiamDocGetByIdQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucGiamDocGetByIdQuery, DanhMucGiamDocDto>
{
    private readonly IRepository<DanhMucGiamDoc, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucGiamDoc, int>>();
    private readonly IRepository<UserMaster, long> _userMasterRepository = serviceProvider.GetRequiredService<IRepository<UserMaster, long>>();

    public async Task<DanhMucGiamDocDto> Handle(DanhMucGiamDocGetByIdQuery request, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetQueryableSet()
            .LeftOuterJoin(
                _userMasterRepository.GetQueryableSet(),
                e => e.UserPortalId,
                u => u.Id,
                (e, u) => new { Entity = e, User = u })
            .Where(x => x.Entity.Id == request.Id)
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
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new KeyNotFoundException($"Không tìm thấy bản ghi với ID: {request.Id}");

        return result;
    }
}