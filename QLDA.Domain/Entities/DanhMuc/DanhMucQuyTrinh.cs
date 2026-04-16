namespace QLDA.Domain.Entities.DanhMuc;

/// <summary>
/// Danh mục quy trình
/// </summary>
/// <remarks>
/// Quy trình - bước - tình trạng dự án
/// </remarks>
public class DanhMucQuyTrinh : DanhMuc<int>, IAggregateRoot, IMayHaveStt {
    public int? Stt { get; set; }
    /// <summary>
    /// Là quy trình mặc định khi load
    /// </summary>
    public bool MacDinh { get; set; }
    #region Navigation Properties

    public ICollection<DuAn>? DuAns { get; set; } = [];

    public ICollection<DanhMucBuoc>? Buocs { get; set; } = [];

    #endregion
}