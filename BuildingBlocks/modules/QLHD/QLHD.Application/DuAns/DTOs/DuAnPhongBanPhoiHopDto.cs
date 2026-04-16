namespace QLHD.Application.DuAns.DTOs;

/// <summary>
/// DTO cho phòng ban phối hợp trong dự án
/// </summary>
public class DuAnPhongBanPhoiHopDto
{
    /// <summary>
    /// ID phòng ban (FK to DmDonVi)
    /// </summary>
    public long PhongBanId { get; set; }

    /// <summary>
    /// Tên phòng ban (denormalized from DmDonVi.TenDonVi)
    /// </summary>
    public string? TenPhongBan { get; set; }
}