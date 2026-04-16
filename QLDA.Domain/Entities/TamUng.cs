
using QLDA.Domain.Interfaces;

namespace QLDA.Domain.Entities;

public class TamUng : Entity<Guid>, IAggregateRoot, ITienDo {
    /// <summary>
    /// Khoá ngoại tham chiếu đến Dự án
    /// </summary>
    public Guid DuAnId { get; set; }

    /// <summary>
    /// Khoá ngoại tham chiếu đến Bước (công đoạn)
    /// </summary>
    public int? BuocId { get; set; }

    /// <summary>
    /// Hợp đồng/ biên bản nghiệm thu
    /// </summary>
    public Guid HopDongId { get; set; }

    /// <summary>
    /// Số phiếu chi
    /// </summary>
    public string? SoPhieuChi { get; set; }

    /// <summary>
    /// Giá trị tạm ứng
    /// </summary>
    public long? GiaTri { get; set; }

    public string? NoiDung { get; set; }

    public DateTimeOffset? NgayTamUng { get; set; }

    #region Issue 9213
    /// <summary>
    /// Số bảo lãnh
    /// </summary>
    public string? SoBaoLanh { get; set; }
    /// <summary>
    /// Ngày bảo lãnh
    /// </summary>
    public DateTimeOffset? NgayBaoLanh { get; set; }
    /// <summary>
    /// Ngày kết thúc bảo lãnh
    /// </summary>
    public DateTimeOffset? NgayKetThucBaoLanh { get; set; }

    #endregion

    #region Navigation Properties

    public HopDong? HopDong { get; set; }
    public DuAn? DuAn { get; set; }
    public DuAnBuoc? DuAnBuoc { get; set; }

    #endregion
}