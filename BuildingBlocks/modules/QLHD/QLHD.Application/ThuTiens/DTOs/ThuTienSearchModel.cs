using QLHD.Application.Common.DTOs;

namespace QLHD.Application.ThuTiens.DTOs;

/// <summary>
/// Search model cho danh sách thu tiền
/// </summary>
public record ThuTienSearchModel : HopDongKeHoachSearchModel
{
    /// <summary>
    /// Lọc theo ID loại thanh toán
    /// </summary>
    public int? LoaiThanhToanId { get; set; }
}