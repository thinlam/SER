namespace BuildingBlocks.Domain.Interfaces;

public interface IHasKey<TKey>
{
    TKey Id { get; set; }
}
