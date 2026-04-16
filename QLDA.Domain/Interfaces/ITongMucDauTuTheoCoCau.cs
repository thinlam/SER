namespace QLDA.Domain.Interfaces;

/// <summary>
/// Tổng mức đầu tư theo cơ cấu
/// </summary>
public interface ITongMucDauTuTheoCoCau {
    /// <summary>
    /// Xây lắp
    /// </summary>
    public long? XayLap { get; set; }
    /// <summary>
    /// Thiết bị
    /// </summary>
    public long? ThietBi { get; set; }
    /// <summary>
    /// Giải phóng mặt bằng
    /// </summary>
    public long? GiaiPhongMatBang { get; set; }
    /// <summary>
    /// Quản lý dự án
    /// </summary>
    public long? QuanLyDuAn { get; set; }
    /// <summary>
    /// Tư vấn
    /// </summary>
    public long? TuVan { get; set; }
    /// <summary>
    /// Dự phòng
    /// </summary>
    public long? DuPhong { get; set; }
    /// <summary>
    /// Khác
    /// </summary>
    public long? Khac { get; set; }
    public long? TongMucDauTu { get; set; }
}