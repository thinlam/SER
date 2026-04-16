using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BuildingBlocks.Application.Attachments.DTOs;
using BuildingBlocks.Application.Common.Interfaces;

namespace QLHD.Application.PhuLucHopDongs.DTOs;

/// <summary>
/// Model thêm mới/cập nhật phụ lục hợp đồng
/// </summary>
public class PhuLucHopDongInsertModel : IMayHaveAttachmentInsertModel {
    /// <summary>
    /// ID hợp đồng (FK to HopDong) - Bắt buộc
    /// </summary>
    [Required]
    public Guid HopDongId { get; set; }

    /// <summary>
    /// Số phụ lục hợp đồng
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string SoPhuLuc { get; set; } = string.Empty;

    /// <summary>
    /// Ngày ký phụ lục
    /// </summary>
    [Required]
    public DateOnly NgayKy { get; set; }

    /// <summary>
    /// Nội dung phụ lục
    /// </summary>
    [MaxLength(4000)]
    public string? NoiDungPhuLuc { get; set; }

    /// <summary>
    /// Danh sách tệp đính kèm (GroupId sẽ được tự động set)
    /// </summary>
    public List<AttachmentInsertModel>? DanhSachTepDinhKem { get; set; }

    /// <summary>
    /// Danh sách tệp đính kèm (alias for IMayHaveAttachmentInsertModel)
    /// </summary>
    List<AttachmentInsertModel>? IMayHaveAttachmentInsertModel.DanhSachAttachment { get => DanhSachTepDinhKem; set => DanhSachTepDinhKem = value; }

}