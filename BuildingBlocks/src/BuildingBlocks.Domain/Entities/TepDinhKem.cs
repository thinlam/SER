using BuildingBlocks.Domain.Interfaces;
using SequentialGuid;

namespace BuildingBlocks.Domain.Entities;

/// <summary>
/// Tệp đính kèm
/// </summary>
public class TepDinhKem : Entity<Guid>, IAggregateRoot {
    public Guid? ParentId { get; set; }

    /// <summary>
    /// Id của bảng có tệp đính kèm
    /// </summary>
    public string GroupId { get; set; } = SequentialGuidGenerator.Instance.NewGuid().ToString();

    /// <summary>
    /// Là bảng nào (tên bảng)
    /// </summary>
    public string GroupType { get; set; } = string.Empty;

    /// <summary>
    /// Loại tệp
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Tên tệp mới
    /// </summary>
    public string? FileName { get; set; }

    /// <summary>
    /// Tên tệp gốc
    /// </summary>
    public string? OriginalName { get; set; }


    /// <summary>
    /// Đường dẫn lưu tệp
    /// </summary>
    public string? Path { get; set; }


    /// <summary>
    /// Kích thước
    /// </summary>
    public long Size { get; set; }
}
