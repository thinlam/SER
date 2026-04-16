
namespace BuildingBlocks.Domain.Interfaces;

public interface IMayHaveDelete
{
    /// <summary>
    /// Đã bị xoá
    /// </summary>
    bool IsDeleted { get; set; }
}
