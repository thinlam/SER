
namespace QLHD.Domain.Entities;

public class KeHoachKinhDoanhNam : Entity<Guid>, IAggregateRoot {
    /// <summary>
    /// chỉ lưu tháng và năm, ngày sẽ mặc định là 01, ví dụ: 2024-01-01 đại diện cho tháng 1 năm 2024
    /// </summary>
    public DateOnly BatDau { get; set; }
    /// <summary>
    /// chỉ lưu tháng và năm, ngày sẽ mặc định là 01, ví dụ: 2024-12-01 đại diện cho tháng 12 năm 2024
    /// </summary>
    public DateOnly? KetThuc { get; set; }
    public string? GhiChu { get; set; }

    #region Navigation properties
    public List<KeHoachKinhDoanhNam_BoPhan>? KeHoachKinhDoanhNam_BoPhans { get; set; } = [];
    public List<KeHoachKinhDoanhNam_CaNhan>? KeHoachKinhDoanhNam_CaNhans { get; set; } = [];
    #endregion
}
