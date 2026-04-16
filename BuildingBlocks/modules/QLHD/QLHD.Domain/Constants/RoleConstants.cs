namespace QLHD.Domain.Constants;

/// <summary>
/// Role constants for QLHD (Quản lý hợp đồng) module.
/// </summary>
public static class RoleConstants
{
    /// <summary>
    /// Full access to all QLHD features
    /// </summary>
    public const string QLHD_All = "QLHD_All";

    /// <summary>
    /// Quản trị hệ thống QLHD
    /// </summary>
    public const string QLHD_QuanTri = "QLHD_QuanTri";

    /// <summary>
    /// Chuyên viên - xem và cập nhật hợp đồng
    /// </summary>
    public const string QLHD_ChuyenVien = "QLHD_ChuyenVien";

    /// <summary>
    /// Lãnh đạo - phê duyệt hợp đồng
    /// </summary>
    public const string QLHD_LanhDao = "QLHD_LanhDao";

    /// <summary>
    /// Lãnh đạo đơn vị - quản lý hợp đồng đơn vị
    /// </summary>
    public const string QLHD_LanhDaoDonVi = "QLHD_LanhDaoDonVi";

    /// <summary>
    /// Kế toán - quản lý thu tiền, xuất hóa đơn
    /// </summary>
    public const string QLHD_KeToan = "QLHD_KeToan";

    /// <summary>
    /// Group for admin or manager roles
    /// </summary>
    public const string GroupAdminOrManager = $"{QLHD_All},{QLHD_QuanTri},{QLHD_LanhDaoDonVi}";
}