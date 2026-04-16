using System.ComponentModel;

namespace QLDA.Domain.Entities;

[DisplayName("Quyết định thành lập Ban quản lý dự án")]
public class ThanhVienBanQLDA : Entity<int>, IAggregateRoot {
    public Guid QuyetDinhId { get; set; }
    public string? Ten { get; set; }
    public string? ChucVu { get; set; }
    public string? VaiTro { get; set; }

    #region Navigation Properties

    public QuyetDinhLapBanQLDA? QuyetDinhLapBanQLDA { get; set; }

    #endregion
}