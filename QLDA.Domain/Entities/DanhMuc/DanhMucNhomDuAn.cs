namespace QLDA.Domain.Entities.DanhMuc;

public class DanhMucNhomDuAn : DanhMuc<int>, IAggregateRoot, IMayHaveStt {
    public int? Stt { get; set; }

    #region Navigation Properties

    public ICollection<DuAn>? DuAns { get; set; } = [];

    #endregion
}