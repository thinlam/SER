using QLHD.Application.DanhMucNguoiPhuTrachs.DTOs;

namespace QLHD.Application.DanhMucNguoiPhuTrachs.Queries;

public record DanhMucNguoiPhuTrachGetByIdQuery(int Id) : IRequest<DanhMucNguoiPhuTrachDto>;

internal class DanhMucNguoiPhuTrachGetByIdQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucNguoiPhuTrachGetByIdQuery, DanhMucNguoiPhuTrachDto>
{
    private readonly IRepository<DanhMucNguoiPhuTrach, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucNguoiPhuTrach, int>>();
    private readonly IRepository<UserMaster, long> _userMasterRepository = serviceProvider.GetRequiredService<IRepository<UserMaster, long>>();

    public async Task<DanhMucNguoiPhuTrachDto> Handle(DanhMucNguoiPhuTrachGetByIdQuery request, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetQueryableSet()
            .LeftOuterJoin(
                _userMasterRepository.GetQueryableSet(),
                e => e.UserPortalId,
                u => u.Id,
                (e, u) => new { Entity = e, User = u })
            .Where(x => x.Entity.Id == request.Id)
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
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new KeyNotFoundException($"Không tìm thấy bản ghi với ID: {request.Id}");

        return result;
    }
}