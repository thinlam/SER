namespace QLHD.Domain.Interfaces;

/// <summary>
/// Interface đánh dấu có trường Ten (tên)
/// - Dùng để đảm bảo consistency khi cần truy cập tên trong các DTO
/// </summary>
public interface ITen
{
    string? Ten { get; set; }
}