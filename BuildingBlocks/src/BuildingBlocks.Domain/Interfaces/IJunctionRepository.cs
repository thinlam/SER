using System.Linq.Expressions;

namespace BuildingBlocks.Domain.Interfaces;

/// <summary>
/// Repository for junction entities that don't implement IAggregateRoot.
/// Provides delete operations for entities implementing IMayHaveDelete.
/// </summary>
public interface IJunctionRepository<TEntity>
    where TEntity : class {

    /// <summary>
    /// Hard-deletes (permanently removes) all junction entities matching the predicate.
    /// </summary>
    /// <param name="predicate">Filter expression for entities to hard-delete</param>
    /// <param name="saveChanges">If true, saves changes immediately. If false, caller must save via UnitOfWork.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Number of entities hard-deleted</returns>
    Task<int> DeleteAsync(
        Expression<Func<TEntity, bool>> predicate,
        bool saveChanges = false,
        CancellationToken cancellationToken = default);

    IQueryable<TEntity> GetQueryableSet();
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    void Delete(TEntity entity);
    void DeleteRange(IEnumerable<TEntity> entities);
}