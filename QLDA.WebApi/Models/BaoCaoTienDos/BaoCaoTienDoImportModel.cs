using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QLDA.WebApi.Models.BaoCaoTienDos;

public class BaoCaoTienDoImportModel {
    /// <summary>
    /// Tên dự án
    /// </summary>
    [Required]
    [Description("Tên dự án")]
    public string TenDuAn { get; set; } = string.Empty;

    // [Description("Tên bước")] public string? TenBuoc { get; set; }
    [Description("Ngày báo cáo")] public DateTimeOffset? NgayBaoCao { get; set; }
    [Description("Nội dung báo cáo")]
    public string? NoiDung { get; set; }
}