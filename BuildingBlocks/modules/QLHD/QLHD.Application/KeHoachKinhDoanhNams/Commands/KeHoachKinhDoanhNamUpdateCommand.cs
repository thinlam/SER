using BuildingBlocks.Application.Common;
using BuildingBlocks.Domain.Constants;
using Microsoft.EntityFrameworkCore;
using QLHD.Application.KeHoachKinhDoanhNams.DTOs;

namespace QLHD.Application.KeHoachKinhDoanhNams.Commands;

public record KeHoachKinhDoanhNamUpdateCommand(Guid Id, KeHoachKinhDoanhNamUpdateModel Model) : IRequest<KeHoachKinhDoanhNam>;

internal class KeHoachKinhDoanhNamUpdateCommandHandler : IRequestHandler<KeHoachKinhDoanhNamUpdateCommand, KeHoachKinhDoanhNam> {
    private readonly IRepository<KeHoachKinhDoanhNam, Guid> _repository;
    private readonly IRepository<KeHoachKinhDoanhNam_BoPhan, Guid> _boPhanRepository;
    private readonly IRepository<KeHoachKinhDoanhNam_CaNhan, Guid> _caNhanRepository;
    private readonly IRepository<DmDonVi, long> _dmDonViRepository;
    private readonly IRepository<UserMaster, long> _userMasterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public KeHoachKinhDoanhNamUpdateCommandHandler(IServiceProvider serviceProvider) {
        _repository = serviceProvider.GetRequiredService<IRepository<KeHoachKinhDoanhNam, Guid>>();
        _boPhanRepository = serviceProvider.GetRequiredService<IRepository<KeHoachKinhDoanhNam_BoPhan, Guid>>();
        _caNhanRepository = serviceProvider.GetRequiredService<IRepository<KeHoachKinhDoanhNam_CaNhan, Guid>>();
        _dmDonViRepository = serviceProvider.GetRequiredService<IRepository<DmDonVi, long>>();
        _userMasterRepository = serviceProvider.GetRequiredService<IRepository<UserMaster, long>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<KeHoachKinhDoanhNam> Handle(KeHoachKinhDoanhNamUpdateCommand request, CancellationToken cancellationToken = default) {
        var entity = await _repository.GetQueryableSet()
            .Include(e => e.KeHoachKinhDoanhNam_BoPhans)
            .Include(e => e.KeHoachKinhDoanhNam_CaNhans)
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        ManagedException.ThrowIfNull(entity, "Không tìm thấy bản ghi");

        entity.UpdateFrom(request.Model);

        // Sync child collections using SyncHelper
        await SyncBoPhansAsync(entity, request.Model.BoPhans, cancellationToken);
        await SyncCaNhansAsync(entity, request.Model.CaNhans, cancellationToken);

        if (_unitOfWork.HasTransaction) {
            await _repository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity;
        }

        using var tx = await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync(cancellationToken);
        return entity;
    }

    private async Task SyncBoPhansAsync(
        KeHoachKinhDoanhNam entity,
        List<KeHoachKinhDoanhNam_BoPhanInsertOrUpdateModel>? models,
        CancellationToken cancellationToken) {
        if (models == null || models.Count == 0) {
            await SyncHelper.SyncCollection(_boPhanRepository, entity.KeHoachKinhDoanhNam_BoPhans, null, null, cancellationToken);
            return;
        }

        // Fetch Ten from DmDonVi for all DonViIds
        var donViIds = models.Select(m => m.DonViId).Distinct().ToList();
        var donViDict = await _dmDonViRepository.GetQueryableSet()
            .Where(d => donViIds.Contains(d.Id))
            .ToDictionaryAsync(d => d.Id, d => d.TenDonVi ?? string.Empty, cancellationToken);

        // Convert models to entities
        var requestEntities = models.Select(m => new KeHoachKinhDoanhNam_BoPhan {
            Id = m.Id ?? Guid.Empty,
            KeHoachKinhDoanhNamId = entity.Id,
            DonViId = m.DonViId,
            Ten = donViDict.GetValueOrDefault(m.DonViId) ?? DefaultConstants.UNKNOWN,
            DoanhKySo = m.DoanhKySo,
            LaiGopKy = m.LaiGopKy,
            DoanhSoXuatHoaDon = m.DoanhSoXuatHoaDon,
            LaiGopXuatHoaDon = m.LaiGopXuatHoaDon,
            ThuTien = m.ThuTien,
            LaiGopThuTien = m.LaiGopThuTien,
            ChiPhiTrucTiep = m.ChiPhiTrucTiep,
            ChiPhiPhanBo = m.ChiPhiPhanBo,
            LoiNhuan = m.LoiNhuan
        });

        await SyncHelper.SyncCollection(
            _boPhanRepository,
            entity.KeHoachKinhDoanhNam_BoPhans,
            requestEntities,
            (existing, model) => {
                existing.DonViId = model.DonViId;
                existing.Ten = model.Ten;
                existing.DoanhKySo = model.DoanhKySo;
                existing.LaiGopKy = model.LaiGopKy;
                existing.DoanhSoXuatHoaDon = model.DoanhSoXuatHoaDon;
                existing.LaiGopXuatHoaDon = model.LaiGopXuatHoaDon;
                existing.ThuTien = model.ThuTien;
                existing.LaiGopThuTien = model.LaiGopThuTien;
                existing.ChiPhiTrucTiep = model.ChiPhiTrucTiep;
                existing.ChiPhiPhanBo = model.ChiPhiPhanBo;
                existing.LoiNhuan = model.LoiNhuan;
            },
            cancellationToken);
    }

    private async Task SyncCaNhansAsync(
        KeHoachKinhDoanhNam entity,
        List<KeHoachKinhDoanhNam_CaNhanInsertOrUpdateModel>? models,
        CancellationToken cancellationToken) {
        if (models == null || models.Count == 0) {
            await SyncHelper.SyncCollection(_caNhanRepository, entity.KeHoachKinhDoanhNam_CaNhans, null, null, cancellationToken);
            return;
        }

        // Fetch Ten from UserMaster for all UserPortalIds
        var userIds = models.Select(m => m.UserPortalId).Distinct().ToList();
        var userDict = await _userMasterRepository.GetQueryableSet()
            .Where(u => userIds.Contains(u.Id))
            .ToDictionaryAsync(u => u.Id, u => u.HoTen ?? string.Empty, cancellationToken);

        // Convert models to entities
        var requestEntities = models.Select(m => new KeHoachKinhDoanhNam_CaNhan {
            Id = m.Id ?? Guid.Empty,
            KeHoachKinhDoanhNamId = entity.Id,
            UserPortalId = m.UserPortalId,
            Ten = userDict.GetValueOrDefault(m.UserPortalId) ?? DefaultConstants.UNKNOWN,
            DoanhKySo = m.DoanhKySo,
            LaiGopKy = m.LaiGopKy,
            DoanhSoXuatHoaDon = m.DoanhSoXuatHoaDon,
            LaiGopXuatHoaDon = m.LaiGopXuatHoaDon,
            ThuTien = m.ThuTien,
            LaiGopThuTien = m.LaiGopThuTien,
            ChiPhiTrucTiep = m.ChiPhiTrucTiep,
            ChiPhiPhanBo = m.ChiPhiPhanBo,
            LoiNhuan = m.LoiNhuan
        });

        await SyncHelper.SyncCollection(
            _caNhanRepository,
            entity.KeHoachKinhDoanhNam_CaNhans,
            requestEntities,
            (existing, model) => {
                existing.UserPortalId = model.UserPortalId;
                existing.Ten = model.Ten;
                existing.DoanhKySo = model.DoanhKySo;
                existing.LaiGopKy = model.LaiGopKy;
                existing.DoanhSoXuatHoaDon = model.DoanhSoXuatHoaDon;
                existing.LaiGopXuatHoaDon = model.LaiGopXuatHoaDon;
                existing.ThuTien = model.ThuTien;
                existing.LaiGopThuTien = model.LaiGopThuTien;
                existing.ChiPhiTrucTiep = model.ChiPhiTrucTiep;
                existing.ChiPhiPhanBo = model.ChiPhiPhanBo;
                existing.LoiNhuan = model.LoiNhuan;
            },
            cancellationToken);
    }
}