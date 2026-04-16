namespace QLDA.Domain.Entities.DanhMuc;
/// <summary>
/// Danh mục trạng thái dự án
/// </summary>
public class DanhMucTrangThaiDuAn : DanhMuc<int>, IAggregateRoot, IMayHaveStt {
    public int? Stt { get; set; }
    public ICollection<DuAn>? DuAns { get; set; } = [];
}