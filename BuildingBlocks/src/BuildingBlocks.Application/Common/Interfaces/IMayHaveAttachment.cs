using BuildingBlocks.Application.Attachments.DTOs;

namespace BuildingBlocks.Application.Common.Interfaces;

/// <summary>
/// DTO có danh sách tệp đính kèm
/// </summary>
public interface IMayHaveAttachmentDto
{
    public List<AttachmentDto>? DanhSachAttachment { get; set; }
}

/// <summary>
/// Chỉ thêm file
/// </summary>
public interface IMayHaveAttachmentInsertModel
{
    public List<AttachmentInsertModel>? DanhSachAttachment { get; set; }
}

/// <summary>
/// Thêm sửa xoá file <br/>
/// - Thêm: id giá trị null hoặc default
/// - Sửa: có id
/// - Xoá: không gửi lại id từ danh sách đã trả về
/// </summary>
public interface IMayHaveAttachmentInsertOrUpdateModel
{
    public List<AttachmentInsertOrUpdateModel>? DanhSachAttachment { get; set; }
}