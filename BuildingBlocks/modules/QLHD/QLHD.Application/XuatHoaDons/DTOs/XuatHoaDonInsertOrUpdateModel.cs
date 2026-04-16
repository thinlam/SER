using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BuildingBlocks.Domain.ValueTypes;

namespace QLHD.Application.XuatHoaDons.DTOs;

/// <summary>
/// Model thêm mới/cập nhật xuất hóa đơn (merged entity structure)
/// </summary>
public class XuatHoaDonInsertOrUpdateModel
{
    /// <summary>
    /// ID hợp đồng (FK to HopDong) - Bắt buộc
    /// </summary>
    [Required] public Guid HopDongId { get; set; }

    /// <summary>
    /// Khi null hoặc empty → insert mới <br/>
    /// Có giá trị → cập nhật bản ghi hiện có
    /// </summary>
    [DefaultValue("00000000-0000-0000-0000-000000000000")]
    public Guid? Id { get; set; }

    #region Plan fields (required at creation)

    [Required] public int LoaiThanhToanId { get; set; }

    /// <summary>
    /// Thời gian kế hoạch
    /// </summary>
    [Required] public MonthYear ThoiGianKeHoach { get; set; }

    /// <summary>
    /// Phần trăm kế hoạch (0-100)
    /// </summary>
    [Required] public decimal PhanTramKeHoach { get; set; }

    /// <summary>
    /// Giá trị kế hoạch
    /// </summary>
    public decimal GiaTriKeHoach { get; set; }

    /// <summary>
    /// Ghi chú kế hoạch
    /// </summary>
    public string? GhiChuKeHoach { get; set; }

    /// <summary>
    /// Ghi chú thực tế
    /// </summary>
    public string? GhiChuThucTe { get; set; }

    #endregion

    #region Actual fields (nullable - filled when executed)

    public DateOnly? ThoiGianThucTe { get; set; }
    public decimal? GiaTriThucTe { get; set; }

    #region Invoice fields

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