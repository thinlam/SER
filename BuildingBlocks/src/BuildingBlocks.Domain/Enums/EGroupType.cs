namespace BuildingBlocks.Domain.Enums;

/// <summary>
/// Loại đính kèm
/// </summary>
[Obsolete("Use GroupTypeConstants string constants instead. This enum will be removed in a future version.")]
public enum EGroupType {
    /// <summary>
    /// File lỗi
    /// </summary>
    None = 0,

    #region DVDC
    /// <summary>
    /// Cấp phát
    /// </summary>
    CapPhat,

    /// <summary>
    /// Yêu cầu
    /// </summary>
    YeuCau,

    /// <summary>
    /// Yêu cầu
    /// </summary>
    QuaTrinhXuLyYeuCau,

    /// <summary>
    /// Báo cáo tiến độ
    /// </summary>
    BaoCaoTienDo,

    /// <summary>
    /// Phân loại yêu cầu sự cố
    /// </summary>
    PhanLoaiYeuCauSuCo,

    /// <summary>
    /// Hệ thống dùng chung (DmHeThongDungChung)
    /// </summary>
    DmHeThongDungChung,
    #endregion

    #region NVTT
    NhiemVu,
    NhiemVuBaoCao,
    BaoCaoPhanHoi,
    GiaHan,
    VanBanChiDao
    #endregion
}
