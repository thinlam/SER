namespace QLDA.Domain.Entities;

/// <summary>
/// Quyết định duyệt - Kế hoạch lựa chọn nhà thầu
/// </summary>
public class QuyetDinhDuyetKHLCNT : VanBanQuyetDinh {

    public Guid? KeHoachLuaChonNhaThauId { get; set; }
    /// <summary>
    /// Số quyết định
    /// </summary>
    public string? CoQuanQuyetDinh { get; set; }

    #region Navigation Properties

    public KeHoachLuaChonNhaThau? KeHoachLuaChonNhaThau { get; set; }

    #endregion
}