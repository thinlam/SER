namespace QLHD.Domain.Interfaces;

/// <summary>
/// Interface đánh dấu có trường TrangThaiId (ID trạng thái)
/// - Dùng để đảm bảo consistency khi cần truy cập ID trạng thái trong các DTO
/// </summary>
public interface ITrangThai
{
    int TrangThaiId { get; set; }
}