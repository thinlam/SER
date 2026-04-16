using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Persistence.Repositories;

/// <summary>
/// Implementation of IJunctionRepository for junction entity operations.
/// </summary>
public class JunctionRepository<TEntity>(DbContext dbContext) : IJunctionRepository<TEntity>
    where TEntity : class {
    private readonly DbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    private DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

    /// <inheritdoc />
    public async Task<int> DeleteAsync(
        Expression<Func<TEntity, bool>> predicate,
        bool saveChanges = false,
        CancellationToken cancellationToken = default) {
        var entities = await DbSet
            .Where(predicate)
            .ToListAsync(cancellationToken);

        DbSet.RemoveRange(entities);

        if (saveChanges) {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        return entities.Count;
    }

    public IQueryable<TEntity> GetQueryableSet() => DbSet;

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default) {
        await DbSet.AddAsync(entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) {
        await DbSet.AddRangeAsync(entities, cancellationToken);
    }

    public void Delete(TEntity entity) {
        DbSet.Remove(entity);
    }

    public void DeleteRange(IEnumerable<TEntity> entities) {
        DbSet.RemoveRange(entities);
    }
}