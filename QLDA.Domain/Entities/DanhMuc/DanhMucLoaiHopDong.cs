namespace QLDA.Domain.Entities.DanhMuc;

/// <summary>
/// Danh mục trạng thái dự án
/// </summary>
public class DanhMucLoaiHopDong : DanhMuc<int>, IAggregateRoot, IMayHaveStt {
    public int? Stt { get; set; }

    #region Navigation Properties

    public ICollection<HopDong>? HopDongs { get; set; } = [];
    public ICollection<GoiThau>? GoiThaus { get; set; } = [];

    #endregion
}