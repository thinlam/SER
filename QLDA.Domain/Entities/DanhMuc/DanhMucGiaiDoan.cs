namespace QLDA.Domain.Entities.DanhMuc;

/// <summary>
/// Danh mục giai đoạn
/// </summary>
/// <remarks>
/// Quy trình - bước(thuộc giai đoạn) - tình trạng dự án
/// </remarks>
public class DanhMucGiaiDoan : DanhMuc<int>, IAggregateRoot, IMayHaveStt {
    public int? Stt { get; set; }

    #region Navigation Properties

    public ICollection<DanhMucBuoc>? DanhMucBuocs { get; set; }
    public ICollection<DuAn>? DuAns { get; set; }
    #endregion
}