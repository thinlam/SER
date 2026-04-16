namespace BuildingBlocks.Domain.Interfaces;

public interface IMaterializedPathEntity<TKey> : IHasKey<TKey>
{
    TKey? ParentId { get; set; }
    string? Path { get; set; }
    int Level { get; set; }
}
