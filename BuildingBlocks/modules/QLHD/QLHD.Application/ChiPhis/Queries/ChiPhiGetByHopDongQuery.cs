using BuildingBlocks.Domain.ValueTypes;
using QLHD.Application.ChiPhis.DTOs;

namespace QLHD.Application.ChiPhis.Queries;

/// <summary>
/// Query lấy danh sách chi phí theo HopDongId
/// </summary>
public record ChiPhiGetByHopDongQuery(Guid HopDongId) : IRequest<List<ChiPhiDto>>;

internal class ChiPhiGetByHopDongQueryHandler : IRequestHandler<ChiPhiGetByHopDongQuery, List<ChiPhiDto>>
{
    private readonly IRepository<HopDong_ChiPhi, Guid> _repository;

    public ChiPhiGetByHopDongQueryHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<HopDong_ChiPhi, Guid>>();
    }

    public async Task<List<ChiPhiDto>> Handle(ChiPhiGetByHopDongQuery request, CancellationToken cancellationToken = default)
    {
        return await _repository.GetQueryableSet()
            .Where(e => e.HopDongId == request.HopDongId)
            .OrderBy(e => e.ThoiGianKeHoach)
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
                GhiChuThucTe = e.GhiChuThucTe
            })
            .ToListAsync(cancellationToken);
    }
}