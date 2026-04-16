namespace QLHD.Application.KeHoachKinhDoanhNams.DTOs;

public class KeHoachKinhDoanhNamDto : IHasKey<Guid>
{
    public Guid Id { get; set; }
    public DateOnly BatDau { get; set; }
    public DateOnly? KetThuc { get; set; }
    public string? GhiChu { get; set; }

    /// <summary>
    /// Danh sách kế hoạch kinh doanh năm theo bộ phận
    /// </summary>
    public List<KeHoachKinhDoanhNam_BoPhanDto>? BoPhans { get; set; }

    /// <summary>
    /// Danh sách kế hoạch kinh doanh năm theo cá nhân
    /// </summary>
    public List<KeHoachKinhDoanhNam_CaNhanDto>? CaNhans { get; set; }
}