using QLHD.Application.BaoCaos.DTOs;
using QLHD.Application.KeHoachKinhDoanhNams.DTOs;

namespace QLHD.Application.BaoCaos.Queries;

/// <summary>
/// Query for ke hoach kinh doanh nam report
/// </summary>
public record KeHoachKinhDoanhNamReportQuery(KeHoachKinhDoanhNamReportSearchModel SearchModel) : IRequest<KeHoachKinhDoanhNamReportDto>;

/// <summary>
/// Handler for ke hoach kinh doanh nam report query
/// </summary>
internal class KeHoachKinhDoanhNamReportQueryHandler(
    IRepository<KeHoachKinhDoanhNam_BoPhan, Guid> BoPhanRepository,
    IRepository<KeHoachKinhDoanhNam_CaNhan, Guid> CaNhanRepository
) : IRequestHandler<KeHoachKinhDoanhNamReportQuery, KeHoachKinhDoanhNamReportDto> {
    public async Task<KeHoachKinhDoanhNamReportDto> Handle(KeHoachKinhDoanhNamReportQuery request, CancellationToken cancellationToken) {
        var model = request.SearchModel;

        // Query BoPhan (filtered by PhongBanPhuTrachChinhId -> DonViId)
        var boPhans = await BoPhanRepository.GetQueryableSet()
            .WhereIf(model.PhongBanPhuTrachChinhId.HasValue, x => x.DonViId == model.PhongBanPhuTrachChinhId!.Value)
            .Where(x => x.KeHoachKinhDoanhNamId == model.KeHoachKinhDoanhNamId)
            .Select(x => new KeHoachKinhDoanhNam_BoPhanDto {
                Id = x.Id,
                KeHoachKinhDoanhNamId = x.KeHoachKinhDoanhNamId,
                DonViId = x.DonViId,
                Ten = x.Ten,
                DoanhKySo = x.DoanhKySo,
                LaiGopKy = x.LaiGopKy,
                DoanhSoXuatHoaDon = x.DoanhSoXuatHoaDon,
                LaiGopXuatHoaDon = x.LaiGopXuatHoaDon,
                ThuTien = x.ThuTien,
                LaiGopThuTien = x.LaiGopThuTien,
                ChiPhiTrucTiep = x.ChiPhiTrucTiep,
                ChiPhiPhanBo = x.ChiPhiPhanBo,
                LoiNhuan = x.LoiNhuan
            })
            .ToListAsync(cancellationToken);

        // Query CaNhan (filtered by NguoiPhuTrachChinhId -> UserPortalId)
        var caNhans = await CaNhanRepository.GetQueryableSet()
            .WhereIf(model.NguoiPhuTrachChinhId.HasValue, x => x.UserPortalId == model.NguoiPhuTrachChinhId!.Value)
            .Where(x => x.KeHoachKinhDoanhNamId == model.KeHoachKinhDoanhNamId)
            .Select(x => new KeHoachKinhDoanhNam_CaNhanDto {
                Id = x.Id,
                KeHoachKinhDoanhNamId = x.KeHoachKinhDoanhNamId,
                UserPortalId = x.UserPortalId,
                Ten = x.Ten,
                DoanhKySo = x.DoanhKySo,
                LaiGopKy = x.LaiGopKy,
                DoanhSoXuatHoaDon = x.DoanhSoXuatHoaDon,
                LaiGopXuatHoaDon = x.LaiGopXuatHoaDon,
                ThuTien = x.ThuTien,
                LaiGopThuTien = x.LaiGopThuTien,
                ChiPhiTrucTiep = x.ChiPhiTrucTiep,
                ChiPhiPhanBo = x.ChiPhiPhanBo,
                LoiNhuan = x.LoiNhuan
            })
            .ToListAsync(cancellationToken);

        return new KeHoachKinhDoanhNamReportDto {
            BoPhans = boPhans,
            CaNhans = caNhans
        };
    }
}