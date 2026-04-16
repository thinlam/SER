using QLHD.Application.DuAn_ThuTiens.DTOs;
using QLHD.Application.DuAn_XuatHoaDons.DTOs;

namespace QLHD.Application.DuAns.Commands;

public record DuAnInsertCommand(DuAnInsertModel Model) : IRequest<DuAnDto>;

internal class DuAnInsertCommandHandler : IRequestHandler<DuAnInsertCommand, DuAnDto> {
    private readonly IRepository<DuAn, Guid> _repository;
    private readonly IRepository<DanhMucTrangThai, int> _trangThaiRepository;
    private readonly IRepository<DmDonVi, long> _dmDonViRepository;
    private readonly IRepository<KhachHang, Guid> _khachHangRepository;
    private readonly IRepository<DanhMucNguoiPhuTrach, int> _nguoiPhuTrachRepository;
    private readonly IRepository<DanhMucNguoiTheoDoi, int> _nguoiTheoDoiRepository;
    private readonly IRepository<DanhMucGiamDoc, int> _giamDocRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DuAnInsertCommandHandler(IServiceProvider serviceProvider) {
        _repository = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
        _trangThaiRepository = serviceProvider.GetRequiredService<IRepository<DanhMucTrangThai, int>>();
        _dmDonViRepository = serviceProvider.GetRequiredService<IRepository<DmDonVi, long>>();
        _khachHangRepository = serviceProvider.GetRequiredService<IRepository<KhachHang, Guid>>();
        _nguoiPhuTrachRepository = serviceProvider.GetRequiredService<IRepository<DanhMucNguoiPhuTrach, int>>();
        _nguoiTheoDoiRepository = serviceProvider.GetRequiredService<IRepository<DanhMucNguoiTheoDoi, int>>();
        _giamDocRepository = serviceProvider.GetRequiredService<IRepository<DanhMucGiamDoc, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<DuAnDto> Handle(DuAnInsertCommand request, CancellationToken cancellationToken = default) {
        // Get default TrangThaiId if not provided
        int trangThaiId = request.Model.TrangThaiId ?? await GetDefaultTrangThaiIdAsync(cancellationToken);

        if (_unitOfWork.HasTransaction) {
            return await InsertAsync(request, trangThaiId, cancellationToken);
        }

        using var tx = await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        var dto = await InsertAsync(request, trangThaiId, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync(cancellationToken);
        return dto;
    }

    private async Task<DuAnDto> InsertAsync(DuAnInsertCommand request, int trangThaiId, CancellationToken cancellationToken) {
        var entity = request.Model.ToEntity(trangThaiId);

        // Add PhongBanPhoiHop if provided
        if (request.Model.PhongBanPhoiHopIds != null && request.Model.PhongBanPhoiHopIds.Count > 0) {
            // Fetch TenPhongBan from DmDonVi (legacy table)
            var phongBanDict = await _dmDonViRepository.GetQueryableSet()
                .Where(d => request.Model.PhongBanPhoiHopIds.Contains(d.Id))
                .ToDictionaryAsync(d => d.Id, d => d.TenDonVi ?? string.Empty, cancellationToken);

            entity.PhongBanPhoiHops = phongBanDict.ToPhongBanPhoiHopEntities(entity.Id);
        }

        // Add child collections (DuAn_ThuTien, DuAn_XuatHoaDon) with DuAnId
        if (request.Model.KeHoachThuTiens != null && request.Model.KeHoachThuTiens.Count > 0) {
            entity.DuAn_ThuTiens = [.. request.Model.KeHoachThuTiens.Select(t => t.ToEntity(entity.Id))];
        }

        if (request.Model.KeHoachXuatHoaDons != null && request.Model.KeHoachXuatHoaDons.Count > 0) {
            entity.DuAn_XuatHoaDons = [.. request.Model.KeHoachXuatHoaDons.Select(t => t.ToEntity(entity.Id))];
        }

        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Build full DTO with display names
        return await BuildFullDtoAsync(entity, cancellationToken);
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

    private async Task<int> GetDefaultTrangThaiIdAsync(CancellationToken cancellationToken) {
        // Get the default status for KeHoach type (Ma = "KHOACH")
        const string maLoaiTrangThaiKhoach = LoaiTrangThaiConstants.KeHoach;

        var defaultTrangThai = await _trangThaiRepository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.IsDefault && e.MaLoaiTrangThai == maLoaiTrangThaiKhoach, cancellationToken);

        if (defaultTrangThai == null) {
            // Fallback: get first status of KeHoach type
            defaultTrangThai = await _trangThaiRepository.GetQueryableSet()
                .FirstOrDefaultAsync(e => e.MaLoaiTrangThai == maLoaiTrangThaiKhoach, cancellationToken);
        }

        if (defaultTrangThai == null) {
            throw new ManagedException($"Không tìm thấy trạng thái mặc định cho loại kế hoạch (KHOACH)");
        }

        return defaultTrangThai.Id;
    }
}