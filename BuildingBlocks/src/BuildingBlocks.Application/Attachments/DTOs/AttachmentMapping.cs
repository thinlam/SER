namespace BuildingBlocks.Application.Attachments.DTOs;

public static class AttachmentMapping
{
    public static List<AttachmentDto> ToListDto(this IEnumerable<Attachment> danhSachAttachment)
        => [.. danhSachAttachment.Select(o => o.ToDto())];

    public static AttachmentDto ToDto(this Attachment entity)
        => new()
        {
            Id = entity.Id,
            ParentId = entity.ParentId,
            GroupId = entity.GroupId,
            GroupType = entity.GroupType,
            Path = entity.Path,
            Size = entity.Size,
            Type = entity.Type,
            FileName = entity.FileName,
            OriginalName = entity.OriginalName,
        };

    private static Attachment ToEntity(this AttachmentInsertModel model, string groupId, string groupType = "")
        => new()
        {
            Id = GuidExtensions.GetSequentialGuidId(),
            ParentId = model.ParentId,
            GroupId = groupId,
            GroupType = groupType,
            Type = model.Type,
            FileName = model.FileName,
            OriginalName = model.OriginalName,
            Path = model.Path,
            Size = model.Size,
        };

    private static Attachment ToEntity(this AttachmentInsertOrUpdateModel model, string groupId, string groupType = "")
        => new()
        {
            Id = model.Id.GetId(),
            ParentId = model.ParentId,
            GroupId = groupId,
            GroupType = groupType,
            Type = model.Type,
            FileName = model.FileName,
            OriginalName = model.OriginalName,
            Path = model.Path,
            Size = model.Size,
        };

    /// <summary>
    /// Chuyển đổi danh sách AttachmentInsertModel thành entities
    /// </summary>
    public static IEnumerable<Attachment> ToEntities(
        this List<AttachmentInsertModel> data,
        string groupId,
        string groupType = "")
    {
        return data.Select(m => ToEntity(m, groupId, groupType));
    }

    /// <summary>
    /// Chuyển đổi danh sách AttachmentInsertOrUpdateModel thành entities
    /// </summary>
    public static IEnumerable<Attachment> ToEntities(
        this List<AttachmentInsertOrUpdateModel> data,
        string groupId,
        string groupType = "")
    {
        return data.Select(m => ToEntity(m, groupId, groupType));
    }
}