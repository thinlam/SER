namespace QLDA.Domain.Entities.DanhMuc;

/// <summary>
/// Danh mục chức vụ
/// </summary>
public class DanhMucChucVu : DanhMuc<int>, IAggregateRoot, IMayHaveStt {
    public int? Stt { get; set; }

    #region Navigation Properties

    public ICollection<VanBanPhapLy>? VanBanPhapLys { get; set; } = [];
    public ICollection<VanBanChuTruong>? VanBanChuTruongs { get; set; } = [];
    public ICollection<PheDuyetDuToan>? PheDuyetDuToans { get; set; } = [];

    #endregion
}