namespace QLHD.Domain.Interfaces;

/// <summary>
/// Interface đánh dấu có trường DuAnId (ID dự án)
/// - Nullable vì hợp đồng có thể độc lập (không thuộc dự án nào)
/// - Dùng để đảm bảo consistency khi cần truy cập ID dự án trong các DTO
/// </summary>
public interface IDuAnKey
{
    Guid? DuAnId { get; set; }
}
