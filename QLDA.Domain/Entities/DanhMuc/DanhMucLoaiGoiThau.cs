namespace QLDA.Domain.Entities.DanhMuc;
public class DanhMucLoaiGoiThau : DanhMuc<int>, IAggregateRoot, IMayHaveStt
{
    public int? Stt { get; set; }

    #region Navigation Properties

    public ICollection<KetQuaTrungThau>? KetQuaTrungThaus { get; set; } = [];

    #endregion
}