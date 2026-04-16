using System.Data;
using BuildingBlocks.CrossCutting.Exceptions;
using BuildingBlocks.CrossCutting.ExtensionMethods;
using QLHD.Application.KeHoachThang_Versions.DTOs;
using QLHD.Domain.Entities;

namespace QLHD.Application.KeHoachThangs.Commands;

/// <summary>
/// Command to chot (snapshot) KeHoachThang data into version tables.
/// Supports multiple chot operations - each time refreshes the snapshot:
/// - Adds new plans not in version table
/// - Updates existing plans that changed
/// - Removes plans deleted from source
/// </summary>
public record KeHoachThangChotCommand : IRequest<KeHoachThang_VersionsSummaryDto> {
    public int KeHoachThangId { get; init; }
}

internal class KeHoachThangChotCommandHandler(
    IRepository<KeHoachThang, int> keHoachThangRepo,
    IRepository<DuAn_ThuTien, Guid> duAnThuTienRepo,
    IRepository<DuAn_XuatHoaDon, Guid> duAnXuatHoaDonRepo,
    IRepository<HopDong_ThuTien, Guid> hopDongThuTienRepo,
    IRepository<HopDong_XuatHoaDon, Guid> hopDongXuatHoaDonRepo,
    IRepository<HopDong_ChiPhi, Guid> hopDongChiPhiRepo,
    IRepository<DuAn_ThuTien_Version, Guid> duAnThuTienVersionRepo,
    IRepository<DuAn_XuatHoaDon_Version, Guid> duAnXuatHoaDonVersionRepo,
    IRepository<HopDong_ThuTien_Version, Guid> hopDongThuTienVersionRepo,
    IRepository<HopDong_XuatHoaDon_Version, Guid> hopDongXuatHoaDonVersionRepo,
    IRepository<HopDong_ChiPhi_Version, Guid> hopDongChiPhiVersionRepo,
    IUnitOfWork unitOfWork
) : IRequestHandler<KeHoachThangChotCommand, KeHoachThang_VersionsSummaryDto> {

    public async Task<KeHoachThang_VersionsSummaryDto> Handle(
        KeHoachThangChotCommand request,
        CancellationToken cancellationToken) {

        var keHoachThang = await keHoachThangRepo.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.KeHoachThangId, cancellationToken);
        ManagedException.ThrowIfNull(keHoachThang, "Không tìm thấy kế hoạch tháng");

        var tuNgay = keHoachThang.TuNgay;
        var denNgay = keHoachThang.DenNgay;
        var keHoachThangId = keHoachThang.Id;

        var summary = new KeHoachThang_VersionsSummaryDto {
            KeHoachThangId = keHoachThang.Id,
            TuThangDisplay = keHoachThang.TuThangDisplay,
            DenThangDisplay = keHoachThang.DenThangDisplay,
            CreatedAt = DateTimeOffset.UtcNow
        };

        using var tx = await unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);

        // Process each entity type: delete old → insert new
        summary.DuAnThuTienCount = await ProcessDuAnThuTien(keHoachThangId, tuNgay, denNgay, cancellationToken);
        summary.DuAnXuatHoaDonCount = await ProcessDuAnXuatHoaDon(keHoachThangId, tuNgay, denNgay, cancellationToken);
        summary.HopDongThuTienCount = await ProcessHopDongThuTien(keHoachThangId, tuNgay, denNgay, cancellationToken);
        summary.HopDongXuatHoaDonCount = await ProcessHopDongXuatHoaDon(keHoachThangId, tuNgay, denNgay, cancellationToken);
        summary.HopDongChiPhiCount = await ProcessHopDongChiPhi(keHoachThangId, tuNgay, denNgay, cancellationToken);

        summary.TotalRecords = summary.DuAnThuTienCount + summary.DuAnXuatHoaDonCount +
                               summary.HopDongThuTienCount + summary.HopDongXuatHoaDonCount +
                               summary.HopDongChiPhiCount;

        await unitOfWork.CommitTransactionAsync(cancellationToken);
        return summary;
    }

    private async Task<int> ProcessDuAnThuTien(int keHoachThangId, DateOnly tuNgay, DateOnly denNgay, CancellationToken ct) {
        // Delete existing
        var existing = await duAnThuTienVersionRepo.GetQueryableSet()
            .Where(v => v.KeHoachThangId == keHoachThangId).ToListAsync(ct);
        if (existing.Count != 0) duAnThuTienVersionRepo.BulkDelete(existing);

        // Insert new
        var sources = await duAnThuTienRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= tuNgay && e.ThoiGianKeHoach <= denNgay).ToListAsync(ct);
        if (sources.Count == 0) return 0;

        var versions = sources.Select(s => new DuAn_ThuTien_Version {
            Id = GuidExtensions.GetSequentialGuidId(),
            KeHoachThangId = keHoachThangId,
            SourceEntityId = s.Id,
            DuAnId = s.DuAnId,
            LoaiThanhToanId = s.LoaiThanhToanId,
            ThoiGianKeHoach = s.ThoiGianKeHoach,
            PhanTramKeHoach = s.PhanTramKeHoach,
            GiaTriKeHoach = s.GiaTriKeHoach,
            GhiChuKeHoach = s.GhiChuKeHoach
        }).ToList();
        duAnThuTienVersionRepo.BulkInsert(versions);
        return versions.Count;
    }

    private async Task<int> ProcessDuAnXuatHoaDon(int keHoachThangId, DateOnly tuNgay, DateOnly denNgay, CancellationToken ct) {
        var existing = await duAnXuatHoaDonVersionRepo.GetQueryableSet()
            .Where(v => v.KeHoachThangId == keHoachThangId).ToListAsync(ct);
        if (existing.Count != 0) duAnXuatHoaDonVersionRepo.BulkDelete(existing);

        var sources = await duAnXuatHoaDonRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= tuNgay && e.ThoiGianKeHoach <= denNgay).ToListAsync(ct);
        if (sources.Count == 0) return 0;

        var versions = sources.Select(s => new DuAn_XuatHoaDon_Version {
            Id = GuidExtensions.GetSequentialGuidId(),
            KeHoachThangId = keHoachThangId,
            SourceEntityId = s.Id,
            DuAnId = s.DuAnId,
            LoaiThanhToanId = s.LoaiThanhToanId,
            ThoiGianKeHoach = s.ThoiGianKeHoach,
            PhanTramKeHoach = s.PhanTramKeHoach,
            GiaTriKeHoach = s.GiaTriKeHoach,
            GhiChuKeHoach = s.GhiChuKeHoach
        }).ToList();
        duAnXuatHoaDonVersionRepo.BulkInsert(versions);
        return versions.Count;
    }

    private async Task<int> ProcessHopDongThuTien(int keHoachThangId, DateOnly tuNgay, DateOnly denNgay, CancellationToken ct) {
        var existing = await hopDongThuTienVersionRepo.GetQueryableSet()
            .Where(v => v.KeHoachThangId == keHoachThangId).ToListAsync(ct);
        if (existing.Count != 0) hopDongThuTienVersionRepo.BulkDelete(existing);

        var sources = await hopDongThuTienRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= tuNgay && e.ThoiGianKeHoach <= denNgay).ToListAsync(ct);
        if (sources.Count == 0) return 0;

        var versions = sources.Select(s => new HopDong_ThuTien_Version {
            Id = GuidExtensions.GetSequentialGuidId(),
            KeHoachThangId = keHoachThangId,
            SourceEntityId = s.Id,
            HopDongId = s.HopDongId,
            LoaiThanhToanId = s.LoaiThanhToanId,
            ThoiGianKeHoach = s.ThoiGianKeHoach,
            PhanTramKeHoach = s.PhanTramKeHoach,
            GiaTriKeHoach = s.GiaTriKeHoach,
            GhiChuKeHoach = s.GhiChuKeHoach
        }).ToList();
        hopDongThuTienVersionRepo.BulkInsert(versions);
        return versions.Count;
    }

    private async Task<int> ProcessHopDongXuatHoaDon(int keHoachThangId, DateOnly tuNgay, DateOnly denNgay, CancellationToken ct) {
        var existing = await hopDongXuatHoaDonVersionRepo.GetQueryableSet()
            .Where(v => v.KeHoachThangId == keHoachThangId).ToListAsync(ct);
        if (existing.Count != 0) hopDongXuatHoaDonVersionRepo.BulkDelete(existing);

        var sources = await hopDongXuatHoaDonRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= tuNgay && e.ThoiGianKeHoach <= denNgay).ToListAsync(ct);
        if (sources.Count == 0) return 0;

        var versions = sources.Select(s => new HopDong_XuatHoaDon_Version {
            Id = GuidExtensions.GetSequentialGuidId(),
            KeHoachThangId = keHoachThangId,
            SourceEntityId = s.Id,
            HopDongId = s.HopDongId,
            LoaiThanhToanId = s.LoaiThanhToanId,
            ThoiGianKeHoach = s.ThoiGianKeHoach,
            PhanTramKeHoach = s.PhanTramKeHoach,
            GiaTriKeHoach = s.GiaTriKeHoach,
            GhiChuKeHoach = s.GhiChuKeHoach
        }).ToList();
        hopDongXuatHoaDonVersionRepo.BulkInsert(versions);
        return versions.Count;
    }

    private async Task<int> ProcessHopDongChiPhi(int keHoachThangId, DateOnly tuNgay, DateOnly denNgay, CancellationToken ct) {
        var existing = await hopDongChiPhiVersionRepo.GetQueryableSet()
            .Where(v => v.KeHoachThangId == keHoachThangId).ToListAsync(ct);
        if (existing.Count != 0) hopDongChiPhiVersionRepo.BulkDelete(existing);

        var sources = await hopDongChiPhiRepo.GetQueryableSet()
            .Where(e => e.ThoiGianKeHoach >= tuNgay && e.ThoiGianKeHoach <= denNgay).ToListAsync(ct);
        if (sources.Count == 0) return 0;

        var versions = sources.Select(s => new HopDong_ChiPhi_Version {
            Id = GuidExtensions.GetSequentialGuidId(),
            KeHoachThangId = keHoachThangId,
            SourceEntityId = s.Id,
            HopDongId = s.HopDongId,
            LoaiChiPhiId = s.LoaiChiPhiId,
            Nam = s.Nam,
            LanChi = s.LanChi,
            ThoiGianKeHoach = s.ThoiGianKeHoach,
            PhanTramKeHoach = s.PhanTramKeHoach,
            GiaTriKeHoach = s.GiaTriKeHoach,
            GhiChuKeHoach = s.GhiChuKeHoach
        }).ToList();
        hopDongChiPhiVersionRepo.BulkInsert(versions);
        return versions.Count;
    }
}