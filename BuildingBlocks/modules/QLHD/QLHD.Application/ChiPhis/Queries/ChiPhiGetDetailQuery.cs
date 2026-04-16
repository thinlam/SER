using BuildingBlocks.Domain.ValueTypes;
using QLHD.Application.ChiPhis.DTOs;

namespace QLHD.Application.ChiPhis.Queries;

/// <summary>
/// Query lấy chi tiết chi phí theo Id
/// </summary>
public record ChiPhiGetDetailQuery(Guid Id) : IRequest<ChiPhiDto?>;

internal class ChiPhiGetDetailQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<ChiPhiGetDetailQuery, ChiPhiDto?>
{
    private readonly IRepository<HopDong_ChiPhi, Guid> _chiPhiRepository = serviceProvider.GetRequiredService<IRepository<HopDong_ChiPhi, Guid>>();

    public async Task<ChiPhiDto?> Handle(ChiPhiGetDetailQuery request, CancellationToken cancellationToken = default)
    {
        return await _chiPhiRepository.GetQueryableSet()
            .Where(e => e.Id == request.Id)
            .Select(e => new ChiPhiDto
            {
                Id = e.Id,
                HopDongId = e.HopDongId,
                LoaiChiPhiId = e.LoaiChiPhiId,
                TenLoaiChiPhi = e.LoaiChiPhi!.Ten,
                Nam = e.Nam,
                LanChi = e.LanChi,
                ThoiGianKeHoach = MonthYear.FromDateOnly(e.ThoiGianKeHoach),
                PhanTramKeHoach = e.PhanTramKeHoach,
                GiaTriKeHoach = e.GiaTriKeHoach,
                GhiChuKeHoach = e.GhiChuKeHoach,
                ThoiGianThucTe = e.ThoiGianThucTe,
                GiaTriThucTe = e.GiaTriThucTe,
                GhiChuThucTe = e.GhiChuThucTe,
                TenHopDong = e.HopDong!.Ten,
                SoHopDong = e.HopDong!.SoHopDong,
            }).FirstOrDefaultAsync(cancellationToken);
    }
}