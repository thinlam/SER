using QLDA.Domain.Interfaces;

namespace QLDA.Domain.Entities;

public class QuyetDinhDuyetDuAn : VanBanQuyetDinh, ICoQuanQuyetDinhDauTu {
    public string? CoQuanQuyetDinhDauTu { get; set; }
    
    #region Navigation Properties
    public ICollection<QuyetDinhDuyetDuAnNguonVon>? QuyetDinhDuyetDuAnNguonVons { get; set; } = [];

    #endregion
}