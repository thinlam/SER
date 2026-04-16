using BuildingBlocks.Application.Attachments.DTOs;
using QLHD.Application.HopDongs.DTOs;
using QLHD.Application.PhuLucHopDongs.DTOs;

namespace QLHD.Application.HopDongs.Queries;

public record HopDongGetByIdQuery(Guid Id) : IRequest<HopDongDto>;

internal class HopDongGetByIdQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<HopDongGetByIdQuery, HopDongDto> {
    private readonly IRepository<HopDong, Guid> _repository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
    private readonly IRepository<DmDonVi, long> _dmDonViRepository = serviceProvider.GetRequiredService<IRepository<DmDonVi, long>>();
    private readonly IRepository<Attachment, Guid> _attachmentRepository = serviceProvider.GetRequiredService<IRepository<Attachment, Guid>>();
    private readonly IRepository<HopDong_ChiPhi, Guid> _chiPhiRepository = serviceProvider.GetRequiredService<IRepository<HopDong_ChiPhi, Guid>>();
    private readonly IRepository<HopDong_ThuTien, Guid> _hopDongThuTienRepository = serviceProvider.GetRequiredService<IRepository<HopDong_ThuTien, Guid>>();
    private readonly IRepository<DuAn_ThuTien, Guid> _duAnThuTienRepository = serviceProvider.GetRequiredService<IRepository<DuAn_ThuTien, Guid>>();

    public async Task<HopDongDto> Handle(HopDongGetByIdQuery request, CancellationToken cancellationToken = default) {
        var dto = await _repository.GetQueryableSet()
        .Where(e => e.Id == request.Id)
        .Join(_dmDonViRepository.GetQueryableSet(), hd => hd.PhongBanPhuTrachChinhId, pbptc => pbptc.Id, (hd, pbptc) => new { hd, pbptc })
        .Select(joinedData => new HopDongDto {
            Id = joinedData.hd.Id,
            SoHopDong = joinedData.hd.SoHopDong,
            Ten = joinedData.hd.Ten,
            DuAnId = joinedData.hd.DuAnId,
            KhachHangId = joinedData.hd.KhachHangId,
            NgayKy = joinedData.hd.NgayKy,
            SoNgay = joinedData.hd.SoNgay,
            NgayNghiemThu = joinedData.hd.NgayNghiemThu,
            LoaiHopDongId = joinedData.hd.LoaiHopDongId,
            TrangThaiHopDongId = joinedData.hd.TrangThaiId,
            NguoiPhuTrachChinhId = joinedData.hd.NguoiPhuTrachChinhId,
            NguoiTheoDoiId = joinedData.hd.NguoiTheoDoiId,
            GiamDocId = joinedData.hd.GiamDocId,
            GiaTri = joinedData.hd.GiaTri,
            TienThue = joinedData.hd.TienThue,
            GiaTriSauThue = joinedData.hd.GiaTriSauThue,
            PhongBanPhuTrachChinhId = joinedData.hd.PhongBanPhuTrachChinhId,
            GiaTriBaoLanh = joinedData.hd.GiaTriBaoLanh,
            NgayBaoLanhTu = joinedData.hd.NgayBaoLanhTu,
            NgayBaoLanhDen = joinedData.hd.NgayBaoLanhDen,
            ThoiHanBaoHanh = joinedData.hd.ThoiHanBaoHanh,
            NgayBaoHanhTu = joinedData.hd.NgayBaoHanhTu,
            NgayBaoHanhDen = joinedData.hd.NgayBaoHanhDen,
            GhiChu = joinedData.hd.GhiChu,
            TienDo = joinedData.hd.TienDo,
            TenKhachHang = joinedData.hd.KhachHang!.Ten,
            TenDuAn = joinedData.hd.DuAn != null ? joinedData.hd.DuAn.Ten : null,
            TenLoaiHopDong = joinedData.hd.LoaiHopDong!.Ten,
            TenTrangThai = joinedData.hd.TrangThai!.Ten,
            TenNguoiPhuTrach = joinedData.hd.NguoiPhuTrach!.Ten,
            TenNguoiTheoDoi = joinedData.hd.NguoiTheoDoi != null ? joinedData.hd.NguoiTheoDoi.Ten : null,
            TenGiamDoc = joinedData.hd.GiamDoc != null ? joinedData.hd.GiamDoc.Ten : null,
            TenPhongBan = joinedData.pbptc.TenDonVi,
            PhongBanPhoiHopIds = joinedData.hd.PhongBanPhoiHops!.Select(p => p.RightId).ToList(),
            DanhSachTepDinhKem = _attachmentRepository.GetQueryableSet().Where(f => f.GroupId == joinedData.hd.Id.ToString()).Select(e => e.ToDto()).ToList(),
            HopDong_ThuTiens = joinedData.hd.HopDong_ThuTiens!.Select(t => t.ToDto()).ToList(),
            HopDong_XuatHoaDons = joinedData.hd.HopDong_XuatHoaDons!.Select(x => x.ToDto()).ToList(),
            PhuLucHopDongs = joinedData.hd.PhuLucHopDongs!.Select(p => p.ToSimpleDto()).ToList(),
            // Financial summary computed via subqueries
            TongChiPhi = _chiPhiRepository.GetQueryableSet().Where(c => c.HopDongId == joinedData.hd.Id).Sum(c => c.GiaTriKeHoach),
            PhanTramLoiNhuan = 100 - _chiPhiRepository.GetQueryableSet().Where(c => c.HopDongId == joinedData.hd.Id).Sum(c => c.PhanTramKeHoach),
            LoiNhuanTruocThue = joinedData.hd.GiaTri - _chiPhiRepository.GetQueryableSet().Where(c => c.HopDongId == joinedData.hd.Id).Sum(c => c.GiaTriKeHoach),
            TongTienDaThu = joinedData.hd.DuAnId == null
                ? _hopDongThuTienRepository.GetQueryableSet().Where(t => t.HopDongId == joinedData.hd.Id && t.GiaTriThucTe.HasValue).Sum(t => t.GiaTriThucTe!.Value)
                : _duAnThuTienRepository.GetQueryableSet().Where(t => t.DuAnId == joinedData.hd.DuAnId && t.GiaTriThucTe.HasValue).Sum(t => t.GiaTriThucTe!.Value)
        }).FirstOrDefaultAsync(cancellationToken);

        ManagedException.ThrowIfNull(dto, "Không tìm thấy hợp đồng");

        return dto;
    }
}