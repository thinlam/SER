namespace QLHD.Domain.Constants;

/// <summary>
/// Constants for distinguishing DuAn vs HopDong in report queries.
/// <para>
/// DuAn và HopDong thực chất là 1 thực thể kinh doanh:
///   - DuAn (Dự án) = Kế hoạch — có trước, đại diện cho dữ liệu dự kiến
///   - HopDong (Hợp đồng) = Thực tế — có sau, đại diện cho dữ liệu thực tế
/// HopDong có thể tạo độc lập không cần DuAn.
/// </para>
/// </summary>
public static class LoaiDuAnHopDongConstants
{
    /// <summary>
    /// Dự án (Project) - represents planned data (KeHoach).
    /// DuAn có trước, là mặt "Kế hoạch" của thực thể DuAn-HopDong.
    /// </summary>
    public const string DuAn = "DU_AN";

    /// <summary>
    /// Hợp đồng (Contract) - represents actual data (ThucTe).
    /// HopDong có sau, là mặt "Thực tế" của thực thể DuAn-HopDong.
    /// Có thể tạo độc lập (DuAnId = null) không cần dự án.
    /// </summary>
    public const string HopDong = "HOP_DONG";
}