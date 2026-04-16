namespace QLDA.Domain.Entities.DanhMuc;
/// <summary>
/// Danh mục trạng thái dự án
/// </summary>
public class DanhMucLoaiVanBan : DanhMuc<int>, IAggregateRoot, IMayHaveStt {
    public int? Stt { get; set; }

    #region Navigation Properties

    public ICollection<VanBanPhapLy>? VanBanPhapLys { get; set; } = [];
    public ICollection<VanBanChuTruong>? VanBanChuTruongs { get; set; } = [];

    #endregion
}