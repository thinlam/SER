namespace QLDA.Domain.Entities;

/// <summary>
/// Bảng dự toán dự án
/// </summary>
public class DuToan : Entity<Guid>, IAggregateRoot {

    /// <summary>
    /// ID dự án
    /// </summary>
    public Guid DuAnId { get; set; }

    /// <summary>
    /// Số dự toán
    /// </summary>
    public long SoDuToan { get; set; }

    /// <summary>
    /// Năm dự toán
    /// </summary>
    public int NamDuToan { get; set; }

    /// <summary>
    /// Số quyết định dự toán
    /// </summary>
    public string? SoQuyetDinhDuToan { get; set; }

    /// <summary>
    /// Ngày ký dự toán
    /// </summary>
    public DateTimeOffset? NgayKyDuToan { get; set; }
    public string? GhiChu { get; set; }

    #region Navigation Properties

    /// <summary>
    /// Dự án
    /// </summary>
    public DuAn? DuAn { get; set; }

    #endregion
}