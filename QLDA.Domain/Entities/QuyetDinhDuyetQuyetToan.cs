namespace QLDA.Domain.Entities;

/// <summary>
/// Quyết định duyệt quyết toán
/// </summary>
public class QuyetDinhDuyetQuyetToan : VanBanQuyetDinh {
    public string? CoQuanQuyetDinh { get; set; }
    public long? GiaTri { get; set; }
    
    #region Navigation Properties


    #endregion
}