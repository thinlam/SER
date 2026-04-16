using BuildingBlocks.Application.Attachments.DTOs;
using QLHD.Application.HopDongs.DTOs;

namespace QLHD.Application.HopDongs.Commands;

public record HopDongUpdateCommand(Guid Id, HopDongUpdateModel Model) : IRequest<HopDongDto>;

internal class HopDongUpdateCommandHandler : IRequestHandler<HopDongUpdateCommand, HopDongDto> {
    private readonly IRepository<HopDong, Guid> _repository;
    private readonly IRepository<Attachment, Guid> _attachmentRepository;
    private readonly IRepository<DmDonVi, long> _dmDonViRepository;
    private readonly IRepository<KhachHang, Guid> _khachHangRepository;
    private readonly IRepository<DuAn, Guid> _duAnRepository;
    private readonly IRepository<DanhMucLoaiHopDong, int> _loaiHopDongRepository;
    private readonly IRepository<DanhMucTrangThai, int> _trangThaiRepository;
    private readonly IRepository<DanhMucNguoiPhuTrach, int> _nguoiPhuTrachRepository;
    private readonly IRepository<DanhMucNguoiTheoDoi, int> _nguoiTheoDoiRepository;
    private readonly IRepository<DanhMucGiamDoc, int> _giamDocRepository;
    private readonly IUnitOfWork _unitOfWork;

    public HopDongUpdateCommandHandler(IServiceProvider serviceProvider) {
        _repository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
        _attachmentRepository = serviceProvider.GetRequiredService<IRepository<Attachment, Guid>>();
        _dmDonViRepository = serviceProvider.GetRequiredService<IRepository<DmDonVi, long>>();
        _khachHangRepository = serviceProvider.GetRequiredService<IRepository<KhachHang, Guid>>();
        _duAnRepository = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        _loaiHopDongRepository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiHopDong, int>>();
        _trangThaiRepository = serviceProvider.GetRequiredService<IRepository<DanhMucTrangThai, int>>();
        _nguoiPhuTrachRepository = serviceProvider.GetRequiredService<IRepository<DanhMucNguoiPhuTrach, int>>();
        _nguoiTheoDoiRepository = serviceProvider.GetRequiredService<IRepository<DanhMucNguoiTheoDoi, int>>();
        _giamDocRepository = serviceProvider.GetRequiredService<IRepository<DanhMucGiamDoc, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<HopDongDto> Handle(HopDongUpdateCommand request, CancellationToken cancellationToken = default) {
        var entity = await _repository.GetQueryableSet()
            .Include(e => e.PhongBanPhoiHops)
            .Include(e => e.HopDong_ThuTiens)
            .Include(e => e.HopDong_XuatHoaDons)
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException($"Không tìm thấy hợp đồng với ID: {request.Id}");

        // DuAnId is not editable after insert - one-to-one relationship constraint
        entity.UpdateFrom(request.Model);

        // Sync PhongBanPhoiHops (junction table - replace all)
        await SyncPhongBanPhoiHopsAsync(entity, request.Model.PhongBanPhoiHopIds, cancellationToken);

        // NOTE: Attachment handling moved to Controller/Caller
        // Use AttachmentBulkInsertOrUpdateCommand separately after this command completes

        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Build full DTO with display names
        return await BuildFullDtoAsync(entity, cancellationToken);
    }

    /// <summary>
    /// Syncs PhongBanPhoiHops collection by replacing all entries.
    /// Junction tables don't support soft delete, so we use replace strategy.
    /// </summary>
    private async Task SyncPhongBanPhoiHopsAsync(HopDong entity, List<long>? newPhongBanIds, CancellationToken cancellationToken) {
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
                entity.PhongBanPhoiHops.Add(new HopDongPhongBanPhoiHop {
                    LeftId = entity.Id,
                    RightId = phongBanId,
                    TenPhongBan = phongBanDict.GetValueOrDefault(phongBanId),
                });
            }
        }
    }

    private async Task<HopDongDto> BuildFullDtoAsync(HopDong entity, CancellationToken cancellationToken) {
        // Fetch display names sequentially (DbContext is not thread-safe)
        var tenKhachHang = await _khachHangRepository.GetQueryableSet()
            .Where(k => k.Id == entity.KhachHangId)
            .Select(k => k.Ten)
            .FirstOrDefaultAsync(cancellationToken);

        var tenDuAn = await _duAnRepository.GetQueryableSet()
            .Where(d => d.Id == entity.DuAnId)
            .Select(d => d.Ten)
            .FirstOrDefaultAsync(cancellationToken);

        var tenLoaiHopDong = await _loaiHopDongRepository.GetQueryableSet()
            .Where(l => l.Id == entity.LoaiHopDongId)
            .Select(l => l.Ten)
            .FirstOrDefaultAsync(cancellationToken);

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
            .FirstOrDefaultAsync(cancellationToken);

        var tenNguoiTheoDoi = entity.NguoiTheoDoiId.HasValue
            ? await _nguoiTheoDoiRepository.GetQueryableSet()
                .Where(n => n.Id == entity.NguoiTheoDoiId.Value)
                .Select(n => n.Ten)
                .FirstOrDefaultAsync(cancellationToken)
            : null;

        var tenGiamDoc = entity.GiamDocId.HasValue
            ? await _giamDocRepository.GetQueryableSet()
                .Where(g => g.Id == entity.GiamDocId.Value)
                .Select(g => g.Ten)
                .FirstOrDefaultAsync(cancellationToken)
            : null;

        var attachments = await _attachmentRepository.GetQueryableSet()
            .Where(t => t.GroupId == entity.Id.ToString())
            .Select(t => t.ToDto())
            .ToListAsync(cancellationToken);

        return new HopDongDto {
            Id = entity.Id,
            SoHopDong = entity.SoHopDong,
            Ten = entity.Ten,
            DuAnId = entity.DuAnId,
            TenDuAn = tenDuAn,
            KhachHangId = entity.KhachHangId,
            TenKhachHang = tenKhachHang,
            NgayKy = entity.NgayKy,
            SoNgay = entity.SoNgay,
            NgayNghiemThu = entity.NgayNghiemThu,
            LoaiHopDongId = entity.LoaiHopDongId,
            TenLoaiHopDong = tenLoaiHopDong,
            TrangThaiHopDongId = entity.TrangThaiId,
            TenTrangThai = tenTrangThai,
            NguoiPhuTrachChinhId = entity.NguoiPhuTrachChinhId,
            TenNguoiPhuTrach = tenNguoiPhuTrach,
            NguoiTheoDoiId = entity.NguoiTheoDoiId,
            TenNguoiTheoDoi = tenNguoiTheoDoi,
            GiamDocId = entity.GiamDocId,
            TenGiamDoc = tenGiamDoc,
            GiaTri = entity.GiaTri,
            TienThue = entity.TienThue,
            GiaTriSauThue = entity.GiaTriSauThue,
            PhongBanPhuTrachChinhId = entity.PhongBanPhuTrachChinhId,
            TenPhongBan = tenPhongBan,
            GiaTriBaoLanh = entity.GiaTriBaoLanh,
            NgayBaoLanhTu = entity.NgayBaoLanhTu,
            NgayBaoLanhDen = entity.NgayBaoLanhDen,
            ThoiHanBaoHanh = entity.ThoiHanBaoHanh,
            NgayBaoHanhTu = entity.NgayBaoHanhTu,
            NgayBaoHanhDen = entity.NgayBaoHanhDen,
            GhiChu = entity.GhiChu,
            TienDo = entity.TienDo,
            PhongBanPhoiHopIds = entity.PhongBanPhoiHops?.Select(p => p.RightId).ToList(),
            DanhSachTepDinhKem = attachments,
            HopDong_ThuTiens = entity.HopDong_ThuTiens?.Select(t => t.ToDto()).ToList(),
            HopDong_XuatHoaDons = entity.HopDong_XuatHoaDons?.Select(x => x.ToDto()).ToList()
        };
    }
}