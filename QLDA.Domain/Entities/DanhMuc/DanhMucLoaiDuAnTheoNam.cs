namespace QLDA.Domain.Entities.DanhMuc;

public class DanhMucLoaiDuAnTheoNam : DanhMuc<int>, IAggregateRoot, IMayHaveStt {
    public int? Stt { get; set; }

    #region Navigation Properties

    public ICollection<DuAn>? DuAns { get; set; } = [];

    #endregion
}