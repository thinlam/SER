using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BuildingBlocks.Domain.ValueTypes;

namespace QLHD.Application.ThuTiens.DTOs;

/// <summary>
/// Model thêm mới thu tiền (gồm kế hoạch và thực tế)
/// </summary>
public class ThuTienInsertOrUpdateModel {
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

    [Required] public int LoaiThanhToanId { get; set; }
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

    #region Hoá đơn

    /// <summary>
    /// Số hóa đơn
    /// </summary>
    public string? SoHoaDon { get; set; }

    /// <summary>
    /// Ký hiệu hóa đơn
    /// </summary>
    public string? KyHieuHoaDon { get; set; }

    /// <summary>
    /// Ngày hóa đơn
    /// </summary>
    public DateOnly? NgayHoaDon { get; set; }

    #endregion

    #endregion


}