using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Domain.Entities;

/// <summary>
/// Bảng dự án
/// </summary>
public class VanBanPhapLy : VanBanQuyetDinh {

    public int? LoaiVanBanId { get; set; }
    /// <summary>
    /// Danh mục chức vụ
    /// </summary>
    public int? ChucVuId { get; set; }

    #region Navigation Properties

    public DanhMucLoaiVanBan? LoaiVanBan { get; set; }
    public DanhMucChuDauTu? ChuDauTu { get; set; }
    public DanhMucChucVu? ChucVu { get; set; }

    #endregion
}