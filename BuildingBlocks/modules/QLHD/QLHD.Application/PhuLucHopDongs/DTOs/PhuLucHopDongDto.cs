using BuildingBlocks.Application.Attachments.DTOs;
using BuildingBlocks.Application.Common.Interfaces;

namespace QLHD.Application.PhuLucHopDongs.DTOs;

/// <summary>
/// DTO cho phụ lục hợp đồng
/// </summary>
public class PhuLucHopDongDto : IHasKey<Guid>, IMayHaveAttachmentDto {
    public Guid Id { get; set; }
    public Guid HopDongId { get; set; }
    public string SoPhuLuc { get; set; } = string.Empty;
    public DateOnly NgayKy { get; set; }
    public string? NoiDungPhuLuc { get; set; }

    /// <summary>
    /// Danh sách tệp đính kèm
    /// </summary>
    public List<AttachmentDto>? DanhSachTepDinhKem { get; set; }

    /// <summary>
    /// Danh sách tệp đính kèm (alias for IMayHaveAttachmentDto)
    /// </summary>
    List<AttachmentDto>? IMayHaveAttachmentDto.DanhSachAttachment { get => DanhSachTepDinhKem; set => DanhSachTepDinhKem = value; }

}