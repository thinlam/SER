namespace QLDA.Domain.Constants;

public static class RoleConstants {
    /// <summary>
    /// Quyền Administrator - Toàn quyền trong hệ thống
    /// </summary>
    public const string QLDA_TatCa = "QLDA_TatCa";
    /// <summary>
    /// Quyền Quản trị hệ thống
    /// </summary>
    public const string QLDA_QuanTri = "QLDA_QuanTri";
    /// <summary>
    /// Quyền Nhân viên
    /// </summary>
    public const string QLDA_ChuyenVien = "QLDA_ChuyenVien";
    /// <summary>
    /// Lãnh đạo
    /// </summary>
    public const string QLDA_LD = "QLDA_LD";
    /// <summary>
    /// Lãnh đạo đơn vị
    /// </summary>
    public const string QLDA_LDDV = "QLDA_LDDV";
    /// <summary>
    /// Quyền Admin hoặc Manager
    /// </summary>
    public const string GroupAdminOrManager = $"{QLDA_TatCa},{QLDA_QuanTri},{QLDA_LDDV}";
}