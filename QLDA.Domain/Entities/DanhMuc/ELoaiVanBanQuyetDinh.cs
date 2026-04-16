namespace QLDA.Domain.Entities.DanhMuc;

public class ELoaiVanBanQuyetDinh : EnumDb<int>, IAggregateRoot, IHasUsed {
    public bool Used { get; set; }
}