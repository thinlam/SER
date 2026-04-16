namespace QLHD.Domain.Interfaces;

/// <summary>
/// Interface đánh dấu có trường GiaTri (giá trị)
/// - Dùng để đảm bảo consistency khi cần truy cập giá trị trong các DTO
/// </summary>
public interface IGiaTri
{
    decimal GiaTri { get; set; }
}
