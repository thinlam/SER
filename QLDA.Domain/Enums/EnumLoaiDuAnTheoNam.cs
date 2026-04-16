using System.ComponentModel;

namespace QLDA.Domain.Enums;

/// <summary>
/// Loại dự án theo năm tài chính
/// </summary>
/// <remarks>
/// Giá trị Ma trong bảng DanhMucLoaiDuAnTheoNam phải khớp với enum này
/// </remarks>
public enum EnumLoaiDuAnTheoNam {
    [Description("Khởi công mới")] KCM,
    [Description("Chuyển tiếp")] CT,
    [Description("Tồn đọng")] TD
}