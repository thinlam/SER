namespace QLHD.Domain.Interfaces;

/// <summary>
/// Interface đánh dấu có trường SoHopDong (số hợp đồng)
/// - Dùng để đảm bảo consistency khi cần truy cập số hợp đồng trong các DTO
/// </summary>
public interface ISoHopDong
{
    string? SoHopDong { get; set; }
}
