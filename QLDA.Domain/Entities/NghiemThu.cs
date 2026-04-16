using QLDA.Domain.Interfaces;

namespace QLDA.Domain.Entities;

public class NghiemThu : Entity<Guid>, IAggregateRoot, ITienDo {
    /// <summary>
    /// Khoá ngoại tham chiếu đến Dự án
    /// </summary>
    public Guid DuAnId { get; set; }

    /// <summary>
    /// Khoá ngoại tham chiếu đến Bước (công đoạn)
    /// </summary>
    public int? BuocId { get; set; }
    public Guid HopDongId { get; set; }
    /// <summary>
    /// Số Biên bản nghiệm thu
    /// </summary>
    public string? SoBienBan { get; set; }

    /// <summary>
    /// Đợt nghiệm thu (Ví dụ: "Đợt 1", "Đợt 2"…)
    /// </summary>
    public string? Dot { get; set; }

    /// <summary>
    /// Ngày thực hiện nghiệm thu
    /// </summary>
    public DateTimeOffset? Ngay { get; set; }

    /// <summary>
    /// Nội dung chính của buổi nghiệm thu
    /// </summary>
    public string? NoiDung { get; set; }
    #region  Issue 9211
    /// <summary>
    /// Giá trị
    /// </summary>
    public long GiaTri { get; set; }

    #endregion

    #region Navigation Properties

    public DuAn? DuAn { get; set; }
    public DuAnBuoc? DuAnBuoc { get; set; }
    public HopDong? HopDong { get; set; }
    public ThanhToan? ThanhToan { get; set; }
    public ICollection<NghiemThuPhuLucHopDong>? NghiemThuPhuLucHopDongs { get; set; }

    #endregion
}