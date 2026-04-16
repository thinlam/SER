using QLHD.Application.Common.DTOs;

namespace QLHD.Application.ChiPhis.DTOs;

/// <summary>
/// Search model cho danh sách chi phí
/// </summary>
public record ChiPhiSearchModel : HopDongKeHoachSearchModel
{
    /// <summary>
    /// Lọc theo ID loại chi phí
    /// </summary>
    public int? LoaiChiPhiId { get; set; }
}