using System.ComponentModel.DataAnnotations;
using BuildingBlocks.Domain.ValueTypes;

namespace QLHD.Application.KeHoachThangs.DTOs;

public class KeHoachThangUpdateModel
{
    public int Id { get; set; }

    /// <summary>
    /// Tháng bắt đầu định dạng MM-yyyy (e.g., "01-2027")
    /// </summary>
    [Required]
    public MonthYear TuNgay { get; set; }

    /// <summary>
    /// Tháng kết thúc định dạng MM-yyyy (e.g., "12-2027")
    /// </summary>
    [Required]
    public MonthYear DenNgay { get; set; }

    public string? GhiChu { get; set; }
}