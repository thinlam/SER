namespace QLHD.Domain.Constants;

/// <summary>
/// Constants for PhongBan report types - Loại báo cáo theo phòng ban
/// Used by PhongBanReportDto.Type property
/// </summary>
public static class PhongBanReportTypeConstants
{
    /// <summary>
    /// Doanh số - Sales volume
    /// </summary>
    public const string DoanhSo = "DOANH_SO";

    /// <summary>
    /// Thu tiền - Payment collection
    /// </summary>
    public const string ThuTien = "THU_TIEN";

    /// <summary>
    /// Xuất hoá đơn - Invoice issuance
    /// </summary>
    public const string XuatHoaDon = "XUAT_HOA_DON";

    /// <summary>
    /// Chi phí - Cost/Expense
    /// </summary>
    public const string ChiPhi = "CHI_PHI";
}