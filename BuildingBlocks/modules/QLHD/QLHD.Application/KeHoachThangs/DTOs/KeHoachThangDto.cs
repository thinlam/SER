namespace QLHD.Application.KeHoachThangs.DTOs;

public class KeHoachThangDto : IHasKey<int>
{
    public int Id { get; set; }

    /// <summary>
    /// Ngày bắt đầu (e.g., 2027-01-01)
    /// </summary>
    public DateOnly TuNgay { get; set; }

    /// <summary>
    /// Ngày kết thúc (e.g., 2027-12-01)
    /// </summary>
    public DateOnly DenNgay { get; set; }

    /// <summary>
    /// Hiển thị tháng bắt đầu (e.g., "Tháng 1 - 2027")
    /// </summary>
    public string TuThangDisplay { get; set; } = string.Empty;

    /// <summary>
    /// Hiển thị tháng kết thúc (e.g., "Tháng 12 - 2027")
    /// </summary>
    public string DenThangDisplay { get; set; } = string.Empty;

    public string? GhiChu { get; set; }
}