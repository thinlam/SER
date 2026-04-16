namespace QLDA.Domain.Entities.DanhMuc;

/// <summary>
/// Danh mục chủ đầu tư
/// </summary>
public class DanhMucChuDauTu : DanhMuc<int>, IAggregateRoot, IMayHaveStt {


    #region Navigation Properties

    public ICollection<DuAn>? DuAns { get; set; } = [];
    public int? Stt { get; set; }


    #endregion
}