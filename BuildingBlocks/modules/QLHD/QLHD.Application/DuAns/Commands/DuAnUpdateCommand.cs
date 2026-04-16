using QLHD.Application.DuAn_ThuTiens.DTOs;
using QLHD.Application.DuAn_XuatHoaDons.DTOs;

namespace QLHD.Application.DuAns.Commands;

public record DuAnUpdateCommand(Guid Id, DuAnUpdateModel Model) : IRequest<DuAnDto>;

internal class DuAnUpdateCommandHandler : IRequestHandler<DuAnUpdateCommand, DuAnDto> {
    private readonly IRepository<DuAn, Guid> _repository;
    private readonly IRepository<DmDonVi, long> _dmDonViRepository;
    private readonly IRepository<KhachHang, Guid> _khachHangRepository;
    private readonly IRepository<DanhMucTrangThai, int> _trangThaiRepository;
    private readonly IRepository<DanhMucNguoiPhuTrach, int> _nguoiPhuTrachRepository;
    private readonly IRepository<DanhMucNguoiTheoDoi, int> _nguoiTheoDoiRepository;
    private readonly IRepository<DanhMucGiamDoc, int> _giamDocRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DuAnUpdateCommandHandler(IServiceProvider serviceProvider) {
        _repository = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        _dmDonViRepository = serviceProvider.GetRequiredService<IRepository<DmDonVi, long>>();
        _khachHangRepository = serviceProvider.GetRequiredService<IRepository<KhachHang, Guid>>();
        _trangThaiRepository = serviceProvider.GetRequiredService<IRepository<DanhMucTrangThai, int>>();
        _nguoiPhuTrachRepository = serviceProvider.GetRequiredService<IRepository<DanhMucNguoiPhuTrach, int>>();
        _nguoiTheoDoiRepository = serviceProvider.GetRequiredService<IRepository<DanhMucNguoiTheoDoi, int>>();
        _giamDocRepository = serviceProvider.GetRequiredService<IRepository<DanhMucGiamDoc, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<DuAnDto> Handle(DuAnUpdateCommand request, CancellationToken cancellationToken = default) {
        var entity = await _repository.GetQueryableSet()
            .Include(e => e.DuAn_ThuTiens)
            .Include(e => e.DuAn_XuatHoaDons)
            .Include(e => e.PhongBanPhoiHops)
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException($"Không tìm thấy dự án với ID: {request.Id}");

        entity.UpdateFrom(request.Model);

        // Sync PhongBanPhoiHops (junction table - replace all)
        // Child collections (ThuTiens, XuatHoaDons, ChiPhis) are updated via separate CRUD endpoints
        await SyncPhongBanPhoiHopsAsync(entity, request.Model.PhongBanPhoiHopIds, cancellationToken);

        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Build full DTO with display names
        return await BuildFullDtoAsync(entity, cancellationToken);
    }

    /// <summary>
    /// Syncs PhongBanPhoiHops collection by replacing all entries.
    /// Junction tables don't support soft delete, so we use replace strategy.
    /// </summary>
    private async Task SyncPhongBanPhoiHopsAsync(DuAn entity, List<long>? newPhongBanIds, CancellationToken cancellationToken) {
        // Clear existing if null or empty
        if (newPhongBanIds == null || newPhongBanIds.Count == 0) {
            entity.PhongBanPhoiHops?.Clear();
            return;
        }

        // Initialize collection if null
        entity.PhongBanPhoiHops ??= [];

        // Get current PhongBanIds
        var existingIds = entity.PhongBanPhoiHops.Select(p => p.RightId).ToHashSet();
        var newIds = newPhongBanIds.ToHashSet();

        // Remove items not in new list
        var toRemove = entity.PhongBanPhoiHops.Where(p => !newIds.Contains(p.RightId)).ToList();
        foreach (var item in toRemove) {
            entity.PhongBanPhoiHops.Remove(item);
        }

        // Add items not in existing list
        var toAdd = newIds.Except(existingIds).ToList();
        if (toAdd.Count > 0) {
            // Fetch TenPhongBan from DmDonVi (legacy table)
            var phongBanDict = await _dmDonViRepository.GetQueryableSet()
                .Where(d => toAdd.Contains(d.Id))
                .ToDictionaryAsync(d => d.Id, d => d.TenDonVi ?? string.Empty, cancellationToken);

            foreach (var phongBanId in toAdd) {
                entity.PhongBanPhoiHops.Add(new DuAnPhongBanPhoiHop {
                    LeftId = entity.Id,
                    RightId = phongBanId,
                    TenPhongBan = phongBanDict.GetValueOrDefault(phongBanId)
                });
            }
        }
    }

    private async Task<DuAnDto> BuildFullDtoAsync(DuAn entity, CancellationToken cancellationToken) {
        // Fetch display names sequentially (DbContext is not thread-safe)
        var tenKhachHang = await _khachHangRepository.GetQueryableSet()
            .Where(k => k.Id == entity.KhachHangId)
            .Select(k => k.Ten)
            .FirstAsync(cancellationToken);

        var tenTrangThai = await _trangThaiRepository.GetQueryableSet()
            .Where(t => t.Id == entity.TrangThaiId)
            .Select(t => t.Ten)
            .FirstOrDefaultAsync(cancellationToken);

        var tenPhongBan = await _dmDonViRepository.GetQueryableSet()
            .Where(d => d.Id == entity.PhongBanPhuTrachChinhId)
            .Select(d => d.TenDonVi)
            .FirstOrDefaultAsync(cancellationToken);

        var tenNguoiPhuTrach = await _nguoiPhuTrachRepository.GetQueryableSet()
            .Where(n => n.Id == entity.NguoiPhuTrachChinhId)
            .Select(n => n.Ten)
            .FirstAsync(cancellationToken);

        var tenNguoiTheoDoi = await _nguoiTheoDoiRepository.GetQueryableSet()
            .Where(n => n.Id == entity.NguoiTheoDoiId)
            .Select(n => n.Ten)
            .FirstOrDefaultAsync(cancellationToken);

        var tenGiamDoc = await _giamDocRepository.GetQueryableSet()
            .Where(g => g.Id == entity.GiamDocId)
            .Select(g => g.Ten)
            .FirstOrDefaultAsync(cancellationToken);

        var displayNames = new DuAnDisplayNames(
            tenKhachHang, tenTrangThai, tenPhongBan,
            tenNguoiPhuTrach, tenNguoiTheoDoi, tenGiamDoc);

        return entity.ToFullDto(displayNames);
    }
}