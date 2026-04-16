using BuildingBlocks.Domain.ValueTypes;
using QLHD.Application.ChiPhis.DTOs;

namespace QLHD.Application.ChiPhis.Commands;

/// <summary>
/// Command thêm mới/cập nhật chi phí
/// </summary>
public record ChiPhiInsertOrUpdateCommand(ChiPhiInsertOrUpdateModel Model) : IRequest<ChiPhiDto>;

internal class ChiPhiInsertOrUpdateCommandHandler : IRequestHandler<ChiPhiInsertOrUpdateCommand, ChiPhiDto>
{
    private readonly IRepository<HopDong, Guid> _hopDongRepository;
    private readonly IRepository<HopDong_ChiPhi, Guid> _chiPhiRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChiPhiInsertOrUpdateCommandHandler(IServiceProvider serviceProvider)
    {
        _hopDongRepository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
        _chiPhiRepository = serviceProvider.GetRequiredService<IRepository<HopDong_ChiPhi, Guid>>();
        _unitOfWork = _hopDongRepository.UnitOfWork;
    }

    public async Task<ChiPhiDto> Handle(ChiPhiInsertOrUpdateCommand request, CancellationToken cancellationToken)
    {
        var model = request.Model;

        // Validate HopDong exists
        var hopDong = await _hopDongRepository.GetQueryableSet()
            .FirstOrDefaultAsync(h => h.Id == model.HopDongId, cancellationToken);
        ManagedException.ThrowIfNull(hopDong, "Không tìm thấy hợp đồng");

        HopDong_ChiPhi entity;

        if (model.Id.HasValue && model.Id != Guid.Empty)
        {
            // Update existing
            var existingEntity = await _chiPhiRepository.GetQueryableSet()
                .FirstOrDefaultAsync(e => e.Id == model.Id.Value, cancellationToken);
            ManagedException.ThrowIfNull(existingEntity, "Không tìm thấy chi phí");
            entity = existingEntity!;

            entity.LoaiChiPhiId = model.LoaiChiPhiId;
            entity.Nam = model.Nam;
            entity.LanChi = model.LanChi;
            entity.ThoiGianKeHoach = model.ThoiGianKeHoach.ToDateOnly();
            entity.PhanTramKeHoach = model.PhanTramKeHoach;
            entity.GiaTriKeHoach = model.GiaTriKeHoach;
            entity.GhiChuKeHoach = model.GhiChuKeHoach;

            // Update actual fields if provided
            if (model.GiaTriThucTe.HasValue ||
                model.ThoiGianThucTe.HasValue ||
                !string.IsNullOrWhiteSpace(model.GhiChuThucTe))
            {
                entity.ThoiGianThucTe = model.ThoiGianThucTe;
                entity.GiaTriThucTe = model.GiaTriThucTe;
                entity.GhiChuThucTe = model.GhiChuThucTe;
            }
        }
        else
        {
            // Insert new
            entity = new HopDong_ChiPhi
            {
                HopDongId = hopDong.Id,
                LoaiChiPhiId = model.LoaiChiPhiId,
                Nam = model.Nam,
                LanChi = model.LanChi,
                ThoiGianKeHoach = model.ThoiGianKeHoach.ToDateOnly(),
                PhanTramKeHoach = model.PhanTramKeHoach,
                GiaTriKeHoach = model.GiaTriKeHoach,
                GhiChuKeHoach = model.GhiChuKeHoach
            };

            // Set actual fields if provided
            if (model.GiaTriThucTe.HasValue ||
                model.ThoiGianThucTe.HasValue ||
                !string.IsNullOrWhiteSpace(model.GhiChuThucTe))
            {
                entity.ThoiGianThucTe = model.ThoiGianThucTe;
                entity.GiaTriThucTe = model.GiaTriThucTe;
                entity.GhiChuThucTe = model.GhiChuThucTe;
            }

            await _chiPhiRepository.AddAsync(entity, cancellationToken);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new ChiPhiDto
        {
            Id = entity.Id,
            HopDongId = hopDong.Id,
            LoaiChiPhiId = entity.LoaiChiPhiId,
            TenLoaiChiPhi = entity.LoaiChiPhi?.Ten,
            Nam = entity.Nam,
            LanChi = entity.LanChi,
            ThoiGianKeHoach = MonthYear.FromDateOnly(entity.ThoiGianKeHoach),
            PhanTramKeHoach = entity.PhanTramKeHoach,
            GiaTriKeHoach = entity.GiaTriKeHoach,
            GhiChuKeHoach = entity.GhiChuKeHoach,
            ThoiGianThucTe = entity.ThoiGianThucTe,
            GiaTriThucTe = entity.GiaTriThucTe,
            GhiChuThucTe = entity.GhiChuThucTe,
            TenHopDong = hopDong.Ten,
            SoHopDong = hopDong.SoHopDong,
        };
    }
}