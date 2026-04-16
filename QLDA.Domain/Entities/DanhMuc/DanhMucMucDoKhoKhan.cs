namespace QLDA.Domain.Entities.DanhMuc;

/// <summary>
/// Danh mục mức độ khó khăn
/// </summary>
public class DanhMucMucDoKhoKhan : DanhMuc<int>, IAggregateRoot, IMayHaveStt {
    public int? Stt { get; set; }



    #region Navigation Properties

    public ICollection<BaoCaoKhoKhanVuongMac>? BaoCaoKhoKhanVuongMacs { get; set; }
    
    #endregion
}