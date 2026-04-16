using QLDA.Domain.Enums;
using QLDA.Domain.Interfaces;

namespace QLDA.Domain.Entities;

public class DuAnChiuTrachNhiemXuLy : IJunctionEntity, IAggregateRoot {
    public Guid DuAnId { get; set; }
    /// <summary>
    /// DonViPhoiHop: Đơn vị phối hợp <br/>
    /// DonViTheoDoi: Đơn vị theo dõi <br/>
    /// </summary>
    public EChiuTrachNhiemXuLy Loai { get; set; } = EChiuTrachNhiemXuLy.DonViPhoiHop;
    public long ChiuTrachNhiemXuLyId { get; set; }

    #region Navigation Properties

    public DuAn? DuAn { get; set; }

    #endregion
}