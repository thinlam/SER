namespace BuildingBlocks.Domain.Interfaces;

/// <summary>
/// Interface cho các entity có thuộc tính Used để lọc theo trạng thái sử dụng
/// </summary>
public interface IMayHaveUsed
{
    /// <summary>
    /// Trạng thái sử dụng - true: đang sử dụng, false: không sử dụng
    /// </summary>
    bool? Used { get; set; }
}
