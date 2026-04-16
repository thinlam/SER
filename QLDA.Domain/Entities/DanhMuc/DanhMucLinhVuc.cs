namespace QLDA.Domain.Entities.DanhMuc;

/// <summary>
/// Danh mục lĩnh vực
/// </summary>
public class DanhMucLinhVuc : DanhMuc<int> , IAggregateRoot, IMayHaveStt{
    public int? Stt { get; set; }

    #region Navigation Properties

    public ICollection<DuAn>? DuAns { get; set; } = [];

    #endregion
}