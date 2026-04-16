using QLHD.Application.DanhMucNguoiTheoDois.DTOs;

namespace QLHD.Application.DanhMucNguoiTheoDois.Queries;

public record DanhMucNguoiTheoDoiGetByIdQuery(int Id) : IRequest<DanhMucNguoiTheoDoiDto>;

internal class DanhMucNguoiTheoDoiGetByIdQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucNguoiTheoDoiGetByIdQuery, DanhMucNguoiTheoDoiDto>
{
    private readonly IRepository<DanhMucNguoiTheoDoi, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucNguoiTheoDoi, int>>();
    private readonly IRepository<UserMaster, long> _userMasterRepository = serviceProvider.GetRequiredService<IRepository<UserMaster, long>>();

    public async Task<DanhMucNguoiTheoDoiDto> Handle(DanhMucNguoiTheoDoiGetByIdQuery request, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetQueryableSet()
            .LeftOuterJoin(
                _userMasterRepository.GetQueryableSet(),
                e => e.UserPortalId,
                u => u.Id,
                (e, u) => new { Entity = e, User = u })
            .Where(x => x.Entity.Id == request.Id)
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
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new KeyNotFoundException($"Không tìm thấy bản ghi với ID: {request.Id}");

        return result;
    }
}