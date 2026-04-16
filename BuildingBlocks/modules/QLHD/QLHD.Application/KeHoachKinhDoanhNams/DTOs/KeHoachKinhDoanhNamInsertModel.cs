using System.ComponentModel.DataAnnotations;

namespace QLHD.Application.KeHoachKinhDoanhNams.DTOs;

public class KeHoachKinhDoanhNamInsertModel {
    [Required]
    public DateOnly BatDau { get; set; }

    public DateOnly? KetThuc { get; set; }

    [MaxLength(1000)]
    public string? GhiChu { get; set; }

    /// <summary>
    /// Danh sách kế hoạch kinh doanh năm theo bộ phận
    /// </summary>
    public List<KeHoachKinhDoanhNam_BoPhanInsertOrUpdateModel>? BoPhans { get; set; }

    /// <summary>
    /// Danh sách kế hoạch kinh doanh năm theo cá nhân
    /// </summary>
    public List<KeHoachKinhDoanhNam_CaNhanInsertOrUpdateModel>? CaNhans { get; set; }
}