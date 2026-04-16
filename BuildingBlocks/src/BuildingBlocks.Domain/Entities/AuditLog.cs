using BuildingBlocks.Domain.Interfaces;

namespace BuildingBlocks.Domain.Entities;

/// <summary>
/// Lưu trữ lịch sử thay đổi của các entity
/// </summary>
public class AuditLog : Entity<Guid>, IAggregateRoot
{
    /// <summary>
    /// Tên entity (ví dụ: CapPhatDuongTruyen)
    /// </summary>
    public string EntityName { get; set; } = default!;

    /// <summary>
    /// Id của entity bị thay đổi
    /// </summary>
    public string EntityId { get; set; } = default!;

    /// <summary>
    /// Loại thao tác: Insert, Update, Delete
    /// </summary>
    public string Action { get; set; } = default!;

    /// <summary>
    /// Dữ liệu trước khi thay đổi (JSON)
    /// </summary>
    public string? OldValues { get; set; }

    /// <summary>
    /// Dữ liệu sau khi thay đổi (JSON)
    /// </summary>
    public string? NewValues { get; set; }

    /// <summary>
    /// Giá trị hiện tại đầy đủ của entity (JSON) - snapshot toàn bộ entity
    /// </summary>
    public string? CurrentValues { get; set; }

    /// <summary>
    /// Các trường đã thay đổi (JSON array)
    /// </summary>
    public string? ChangedColumns { get; set; }
}
