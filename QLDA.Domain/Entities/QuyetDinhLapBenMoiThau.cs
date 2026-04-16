using System.ComponentModel;

namespace QLDA.Domain.Entities;

[DisplayName("Quyết định thành lập Bên mời thầu")]
public class QuyetDinhLapBenMoiThau : VanBanQuyetDinh {
    public string? NoiDung { get; set; }
    
    
    #region Navigation Properties


    #endregion
}