namespace BuildingBlocks.Domain.Interfaces;

/// <summary>
/// Marker interface cho các entity có metadata cơ bản
/// Tách biệt khỏi các interface cụ thể để tuân thủ Interface Segregation Principle
/// </summary>
public interface IEntityMetadata
{
    // Marker interface - có thể thêm metadata properties riêng trong tương lai
}
