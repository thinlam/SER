namespace BuildingBlocks.Application.Common.Services;

public interface ICrudService<T, TKey>
    where T : class, IHasKey<TKey>, IAggregateRoot, new()
{
    Task<List<T>> GetAsync(CancellationToken cancellationToken = default);

    Task<T> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);

    Task AddOrUpdateAsync(T entity, bool isEnum = false, CancellationToken cancellationToken = default);

    Task AddAsync(T entity, CancellationToken cancellationToken = default);

    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
}
