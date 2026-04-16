namespace QLDA.Domain.Entities.DanhMuc;

/// <summary>
/// Danh mục tình trạng thực hiện LCNT (Lựa chọn nhà thầu)
/// </summary>
public class DanhMucTinhTrangThucHienLcnt : DanhMuc<int>, IAggregateRoot, IMayHaveStt
{
    public int? Stt { get; set; }
    // No additional properties needed - inherits from DanhMuc<int>
    // Add navigation properties here if needed in future
}
