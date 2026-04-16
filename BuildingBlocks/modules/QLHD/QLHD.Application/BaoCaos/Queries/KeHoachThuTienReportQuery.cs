using QLHD.Application.BaoCaos.DTOs;

namespace QLHD.Application.BaoCaos.Queries;

public record KeHoachThuTienReportQuery(BaoCaoKeHoachThuTienSearchModel SearchModel) : IRequest<List<KeHoachThuTienReportDto>>;
