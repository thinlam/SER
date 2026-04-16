namespace QLHD.Application.KeHoachThang_Versions.DTOs;

/// <summary>
/// Summary DTO for KeHoachThang chot (snapshot) operation
/// </summary>
public class KeHoachThang_VersionsSummaryDto
{
    public int KeHoachThangId { get; set; }
    public string TuThangDisplay { get; set; } = string.Empty;
    public string DenThangDisplay { get; set; } = string.Empty;

    // Snapshot counts
    public int DuAnThuTienCount { get; set; }
    public int DuAnXuatHoaDonCount { get; set; }
    public int HopDongThuTienCount { get; set; }
    public int HopDongXuatHoaDonCount { get; set; }
    public int HopDongChiPhiCount { get; set; }

    public int TotalRecords { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}