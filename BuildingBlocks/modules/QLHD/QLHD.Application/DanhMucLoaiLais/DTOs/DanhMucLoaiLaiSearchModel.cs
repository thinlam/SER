using BuildingBlocks.Domain.DTOs;

namespace QLHD.Application.DanhMucLoaiLais.DTOs;

/// <summary>
/// Search model cho danh sách loại lãi
/// </summary>
public record DanhMucLoaiLaiSearchModel : AggregateRootSearch
{
    /// <summary>
    /// Lọc theo trạng thái sử dụng
    /// </summary>
    public bool? Used { get; set; }
}