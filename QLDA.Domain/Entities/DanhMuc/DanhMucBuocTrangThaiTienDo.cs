namespace QLDA.Domain.Entities.DanhMuc;

/// <summary>
/// Danh mục bước - tình trạng dự án
/// </summary>
/// <remarks>
/// Quy trình - bước - tình trạng dự án
/// </remarks>
public class DanhMucBuocTrangThaiTienDo : DanhMuc<int>, IAggregateRoot, IMayHaveStt {
    public int BuocId { get; set; }
    /// <summary>
    /// Trạng thái tiến độ công việc
    /// </summary>
    public int TrangThaiId { get; set; }

    #region Navigation Properties

    public DanhMucBuoc? Buoc { get; set; }
    public DanhMucTrangThaiTienDo? TrangThaiTienDo { get; set; }
    public int? Stt { get; set; }


    #endregion
}