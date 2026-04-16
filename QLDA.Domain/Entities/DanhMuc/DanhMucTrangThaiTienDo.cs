namespace QLDA.Domain.Entities.DanhMuc;

/// <summary>
/// Danh mục trạng thái dự án
/// </summary>
public class DanhMucTrangThaiTienDo : DanhMuc<int>, IAggregateRoot, IMayHaveStt {
    public int? Stt { get; set; }

    #region Navigation Properties

    public ICollection<DuAn>? DuAns { get; set; } = [];
    public ICollection<DanhMucBuocTrangThaiTienDo>? DanhMucBuocTrangThaiTienDos { get; set; } = [];

    #endregion
}