using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Domain.Entities;

/// <summary>
/// Bảng dự án
/// </summary>
public class VanBanChuTruong : VanBanQuyetDinh {
    public int? LoaiVanBanId { get; set; }

    /// <summary>
    /// Danh mục chức vụ
    /// </summary>
    public int? ChucVuId { get; set; }

    #region Navigation Properties

    public DanhMucLoaiVanBan? LoaiVanBan { get; set; }
    public DanhMucChucVu? ChucVu { get; set; }

    #endregion
}