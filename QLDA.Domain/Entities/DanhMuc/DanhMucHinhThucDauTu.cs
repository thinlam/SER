namespace QLDA.Domain.Entities.DanhMuc;

/// <summary>
/// Danh mục hình thức đầu tư
/// </summary>
public class DanhMucHinhThucDauTu : DanhMuc<int>, IAggregateRoot, IMayHaveStt {
    public int? Stt { get; set; }

    #region Navigation Properties

    public ICollection<DuAn>? DuAns { get; set; } = [];

    #endregion
}