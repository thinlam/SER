using System.ComponentModel;

namespace QLDA.Domain.Entities;

[DisplayName("Quyết định thành lập Hội đồng thẩm định")]
public class QuyetDinhLapHoiDongThamDinh : VanBanQuyetDinh {
    public string? NoiDung { get; set; }
    
    
    #region Navigation Properties


    #endregion
}