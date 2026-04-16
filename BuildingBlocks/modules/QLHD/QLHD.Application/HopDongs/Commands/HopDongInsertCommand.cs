using QLHD.Application.HopDongs.DTOs;

namespace QLHD.Application.HopDongs.Commands;

public record HopDongInsertCommand(HopDongInsertModel Model) : IRequest<HopDongDto>;

internal class HopDongInsertCommandHandler : IRequestHandler<HopDongInsertCommand, HopDongDto> {
    private readonly IRepository<HopDong, Guid> _repository;
    private readonly IRepository<DuAn, Guid> _duAnRepository;
    private readonly IRepository<DmDonVi, long> _dmDonViRepository;
    private readonly IRepository<KhachHang, Guid> _khachHangRepository;
    private readonly IRepository<DanhMucLoaiHopDong, int> _loaiHopDongRepository;
    private readonly IRepository<DanhMucTrangThai, int> _trangThaiRepository;
    private readonly IRepository<DanhMucNguoiPhuTrach, int> _nguoiPhuTrachRepository;
    private readonly IRepository<DanhMucNguoiTheoDoi, int> _nguoiTheoDoiRepository;
    private readonly IRepository<DanhMucGiamDoc, int> _giamDocRepository;
    private readonly IUnitOfWork _unitOfWork;

    public HopDongInsertCommandHandler(IServiceProvider serviceProvider) {
        _repository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
        _duAnRepository = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        _dmDonViRepository = serviceProvider.GetRequiredService<IRepository<DmDonVi, long>>();
        _khachHangRepository = serviceProvider.GetRequiredService<IRepository<KhachHang, Guid>>();
        _loaiHopDongRepository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiHopDong, int>>();
        _trangThaiRepository = serviceProvider.GetRequiredService<IRepository<DanhMucTrangThai, int>>();
        _nguoiPhuTrachRepository = serviceProvider.GetRequiredService<IRepository<DanhMucNguoiPhuTrach, int>>();
        _nguoiTheoDoiRepository = serviceProvider.GetRequiredService<IRepository<DanhMucNguoiTheoDoi, int>>();
        _giamDocRepository = serviceProvider.GetRequiredService<IRepository<DanhMucGiamDoc, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<HopDongDto> Handle(HopDongInsertCommand request, CancellationToken cancellationToken = default) {
        if (_unitOfWork.HasTransaction) {
            return await InsertAsync(request, cancellationToken);
        }

        using var tx = await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        var dto = await InsertAsync(request, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync(cancellationToken);
        return dto;
    }

    private async Task<HopDongDto> InsertAsync(HopDongInsertCommand request, CancellationToken cancellationToken) {
        var entity = request.Model.ToEntity();

        // Add PhongBanPhoiHop if provided
        if (request.Model.PhongBanPhoiHopIds != null && request.Model.PhongBanPhoiHopIds.Count > 0) {
            // Fetch TenPhongBan from DmDonVi (legacy table)
            var phongBanDict = await _dmDonViRepository.GetQueryableSet()
                .Where(d => request.Model.PhongBanPhoiHopIds.Contains(d.Id))
                .ToDictionaryAsync(d => d.Id, d => d.TenDonVi ?? string.Empty, cancellationToken);

            entity.PhongBanPhoiHops = HopDongMapping.ToPhongBanPhoiHopEntities(phongBanDict, entity.Id);
        }

        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Update DuAn.HasHopDong flag (only if DuAnId is set)
        if (entity.DuAnId.HasValue && entity.DuAnId != Guid.Empty) {
            var duAn = await _duAnRepository.GetQueryableSet()
                .FirstOrDefaultAsync(e => e.Id == entity.DuAnId.Value, cancellationToken);
            if (duAn != null) {
                duAn.HasHopDong = true;
            }
        }

        // Build full DTO with display names
        return await BuildFullDtoAsync(entity, cancellationToken);
    }

    private async Task<HopDongDto> BuildFullDtoAsync(HopDong entity, CancellationToken cancellationToken) {
        // Fetch display names sequentially (DbContext is not thread-safe)
        var tenKhachHang = await _khachHangRepository.GetQueryableSet()
            .Where(k => k.Id == entity.KhachHangId)
            .Select(k => k.Ten)
            .FirstOrDefaultAsync(cancellationToken);

        var tenDuAn = entity.DuAnId.HasValue
            ? await _duAnRepository.GetQueryableSet()
                .Where(d => d.Id == entity.DuAnId.Value)
                .Select(d => d.Ten)
                .FirstOrDefaultAsync(cancellationToken)
            : null;

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
            HopDong_ThuTiens = entity.HopDong_ThuTiens?.Select(t => t.ToDto()).ToList(),
            HopDong_XuatHoaDons = entity.HopDong_XuatHoaDons?.Select(x => x.ToDto()).ToList()
        };
    }
}