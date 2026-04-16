using QLHD.Application.DuAn_ThuTiens.DTOs;
using QLHD.Application.DuAn_XuatHoaDons.DTOs;

namespace QLHD.Application.DuAns.Queries;

public record DuAnGetByIdQuery(Guid Id) : IRequest<DuAnDto>;

internal class DuAnGetByIdQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DuAnGetByIdQuery, DuAnDto> {
    private readonly IRepository<DuAn, Guid> _repository = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
    private readonly IRepository<DmDonVi, long> _dmDonViRepository = serviceProvider.GetRequiredService<IRepository<DmDonVi, long>>();

    public async Task<DuAnDto> Handle(DuAnGetByIdQuery request, CancellationToken cancellationToken = default) {
        var dto = await _repository.GetQueryableSet()
        .Where(e => e.Id == request.Id)
        .Join(_dmDonViRepository.GetQueryableSet(), da => da.PhongBanPhuTrachChinhId, pbptc => pbptc.Id, (da, pbptc) => new { da, pbptc })
        .Select(joinedData => new DuAnDto {
            Id = joinedData.da.Id,
            Ten = joinedData.da.Ten,
            KhachHangId = joinedData.da.KhachHangId,
            TenKhachHang = joinedData.da.KhachHang!.Ten,
            NgayLap = joinedData.da.NgayLap,
            GiaTriDuKien = joinedData.da.GiaTriDuKien,
            ThoiGianDuKien = joinedData.da.ThoiGianDuKien,
            PhongBanPhuTrachChinhId = joinedData.da.PhongBanPhuTrachChinhId,
            TenPhongBanPhuTrachChinh = joinedData.pbptc.TenDonVi,
            NguoiPhuTrachChinhId = joinedData.da.NguoiPhuTrachChinhId,
            NguoiTheoDoiId = joinedData.da.NguoiTheoDoiId,
            GiamDocId = joinedData.da.GiamDocId,
            GiaVon = joinedData.da.GiaVon,
            ThanhTien = joinedData.da.ThanhTien,
            TrangThaiId = joinedData.da.TrangThaiId,
            HasHopDong = joinedData.da.HasHopDong,
            GhiChu = joinedData.da.GhiChu,
            TenNguoiPhuTrach = joinedData.da.NguoiPhuTrach!.Ten,
            TenNguoiTheoDoi = joinedData.da.NguoiTheoDoi != null ? joinedData.da.NguoiTheoDoi.Ten : null,
            TenGiamDoc = joinedData.da.GiamDoc != null ? joinedData.da.GiamDoc.Ten : null,
            TenTrangThai = joinedData.da.TrangThai!.Ten,
            PhongBanPhoiHops = joinedData.da.PhongBanPhoiHops!.Select(p => p.ToDto()).ToList(),
            KeHoachThuTiens = joinedData.da.DuAn_ThuTiens!.Select(t => t.ToDto()).ToList(),
            KeHoachXuatHoaDons = joinedData.da.DuAn_XuatHoaDons!.Select(t => t.ToDto()).ToList()
        }).FirstOrDefaultAsync(cancellationToken);

        ManagedException.ThrowIfNull(dto, "Không tìm thấy dự án");

        return dto;
    }
}