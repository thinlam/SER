using System.ComponentModel;

namespace QLDA.Domain.Entities;

[DisplayName("Quyết định thành lập Ban quản lý dự án")]
public class QuyetDinhLapBanQLDA : VanBanQuyetDinh {
    
    
    
    
    #region Navigation Properties

    public ICollection<ThanhVienBanQLDA> ThanhViens { get; set; } = [];

    #endregion
}