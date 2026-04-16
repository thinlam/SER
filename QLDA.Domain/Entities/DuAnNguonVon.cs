using QLDA.Domain.Entities.DanhMuc;
using QLDA.Domain.Interfaces;

namespace QLDA.Domain.Entities;

public class DuAnNguonVon : IJunctionEntity, IAggregateRoot {
    public Guid DuAnId { get; set; }
    public int NguonVonId { get; set; }

    #region Navigation Properties

    public DuAn? DuAn { get; set; }
    public DanhMucNguonVon? NguonVon { get; set; }

    #endregion
}