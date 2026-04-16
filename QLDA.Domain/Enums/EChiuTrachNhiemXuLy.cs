using System.ComponentModel;

namespace QLDA.Domain.Enums;

/// <summary>
/// LanhDaoPhuTrach: Lãnh đạo phụ trách <br/>
/// DonViPhuTrachChinh: Đơn vị phụ trách <br/>
/// DonViPhoiHop: Đơn vị phối hợp <br/>
/// </summary>
public enum EChiuTrachNhiemXuLy {
    [Description("Đơn vị phối hợp")] DonViPhoiHop,
    [Description("Đơn vị theo dõi")] DonViTheoDoi,
}