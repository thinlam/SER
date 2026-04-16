using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BuildingBlocks.Domain.ValueTypes;

namespace QLHD.Application.ChiPhis.DTOs;

/// <summary>
/// Model thêm mới chi phí (gồm kế hoạch và thực tế)
/// </summary>
public class ChiPhiInsertOrUpdateModel
{
    /// <summary>
    /// ID hợp đồng (FK to HopDong) - Bắt buộc
    /// </summary>
    [Required] public Guid HopDongId { get; set; }

    /// <summary>
    /// Khi kế hoạch null -> insert <br/>
    /// Có kế hoạch -> cập nhật kế hoạch + insert thực tế
    /// </summary>
    [DefaultValue("00000000-0000-0000-0000-000000000000")]
    public Guid? Id { get; set; }

    #region Kế hoạch

    [Required] public int LoaiChiPhiId { get; set; }
    /// <summary>
    /// Năm chi phí (ví dụ: 2024)
    /// </summary>
    [Required] public short Nam { get; set; }
    /// <summary>
    /// Lần chi phí (ví dụ: 1, 2, 3...)
    /// </summary>
    [Required] public byte LanChi { get; set; }
    /// <summary>
    /// Thời gian kế hoạch
    /// </summary>
    [Required] public MonthYear ThoiGianKeHoach { get; set; }
    /// <summary>
    /// Phần trăm kế hoạch
    /// </summary>
    [Required] public decimal PhanTramKeHoach { get; set; }
    /// <summary>
    /// Kế hoạch giá trị
    /// </summary>
    public decimal GiaTriKeHoach { get; set; }
    /// <summary>
    /// Kế hoạch ghi chú
    /// </summary>
    public string? GhiChuKeHoach { get; set; }
    #endregion

    #region Thực tế
    public DateOnly? ThoiGianThucTe { get; set; }
    public decimal? GiaTriThucTe { get; set; }
    public string? GhiChuThucTe { get; set; }
    #endregion
}