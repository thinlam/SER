using QLDA.Domain.Interfaces;

namespace QLDA.Domain.Entities;

public class PhuLucHopDong : Entity<Guid>, IAggregateRoot, ITienDo {
    /// <summary>
    /// Khoá ngoại tham chiếu đến Dự án
    /// </summary>
    public Guid DuAnId { get; set; }

    /// <summary>
    /// Khoá ngoại tham chiếu đến Bước (công đoạn)
    /// </summary>
    public int? BuocId { get; set; }

    /// <summary>
    /// Tên phụ lục hợp đồng
    /// </summary>
    public string? Ten { get; set; }

    /// <summary>
    /// Số hiệu phụ lục hợp đồng
    /// </summary>
    public string? SoPhuLucHopDong { get; set; }

    /// <summary>
    /// Nội dung chính phụ lục hợp đồng
    /// </summary>
    public string? NoiDung { get; set; }

    /// <summary>
    /// Ngày ban hành phụ lục hợp đồng
    /// </summary>
    public DateTimeOffset? Ngay { get; set; }

    /// <summary>
    /// Khoá ngoại tham chiếu đến Hợp đồng (nếu có)
    /// </summary>
    public Guid? HopDongId { get; set; }

    /// <summary>
    /// Giá trị phụ lục hợp đồng (tính theo đồng, không bao gồm thập phân)
    /// </summary>
    public long? GiaTri { get; set; }

    /// <summary>
    /// Ngày kết thúc hiệu lực của phụ lục hợp đồng (nếu có)
    /// </summary>
    public DateTimeOffset? NgayDuKienKetThuc { get; set; }

    #region Navigation Properties

    /// <summary>
    /// Đối tượng Hợp đồng (nếu HopDongId != null)
    /// </summary>
    public HopDong? HopDong { get; set; }
    public DuAn? DuAn { get; set; }
    public DuAnBuoc? DuAnBuoc { get; set; }
    public ICollection<NghiemThuPhuLucHopDong>? NghiemThuPhuLucHopDongs { get; set; }

    #endregion
}