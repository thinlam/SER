namespace QLDA.Domain.Entities.DanhMuc;

public class DanhMucManHinh : EnumDb<int>, IAggregateRoot, IHasUsed {

    public bool Used { get; set; }
    public string? Label { get; set; }
    public string? Title { get; set; }

    #region Navigation Properties

    public ICollection<DanhMucBuocManHinh>? DanhMucBuocManHinhs { get; set; } = [];
    public ICollection<DuAnBuocManHinh>? DuAnBuocManHinhs { get; set; } = [];

    #endregion

}