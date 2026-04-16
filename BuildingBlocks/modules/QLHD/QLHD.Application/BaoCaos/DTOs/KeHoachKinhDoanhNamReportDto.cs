using QLHD.Application.KeHoachKinhDoanhNams.DTOs;

namespace QLHD.Application.BaoCaos.DTOs;

/// <summary>
/// DTO for Ke Hoach Kinh Doanh Nam Report containing filtered BoPhan and CaNhan lists
/// </summary>
public class KeHoachKinhDoanhNamReportDto
{
    /// <summary>
    /// Danh sách kế hoạch kinh doanh năm theo bộ phận (filtered by PhongBanPhuTrachChinhId)
    /// </summary>
    public List<KeHoachKinhDoanhNam_BoPhanDto>? BoPhans { get; set; } = [];

    /// <summary>
    /// Danh sách kế hoạch kinh doanh năm theo cá nhân (filtered by NguoiPhuTrachChinhId)
    /// </summary>
    public List<KeHoachKinhDoanhNam_CaNhanDto>? CaNhans { get; set; } = [];
}