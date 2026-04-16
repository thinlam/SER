namespace QLDA.Domain.Entities.DanhMuc;

/// <summary>
/// Danh mục hình thức quản lý
/// </summary>
public class DanhMucHinhThucQuanLy : DanhMuc<int>, IAggregateRoot, IMayHaveStt {
    public int? Stt { get; set; }

    #region Navigation Properties

    public ICollection<DuAn>? DuAns { get; set; } = [];

    #endregion
}