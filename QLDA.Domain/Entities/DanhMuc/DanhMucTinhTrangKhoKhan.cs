namespace QLDA.Domain.Entities.DanhMuc;

/// <summary>
/// Cân lưu lại id để load màn hình đã chọn
/// </summary>
public class DanhMucTinhTrangKhoKhan : DanhMuc<int>, IAggregateRoot, IMayHaveStt {
    public int? Stt { get; set; }

    #region Navigation Properties

    public ICollection<BaoCaoKhoKhanVuongMac>? KhoKhanVuongMacs { get; set; } = [];

    #endregion
}