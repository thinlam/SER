using System.Linq.Expressions;

namespace BuildingBlocks.Domain.Interfaces;

public interface IRepository<TEntity, TKey> : IMaterializedPathRepository<TEntity, TKey>
    where TEntity : class, IHasKey<TKey>, IAggregateRoot, new()
    where TKey : notnull {
    IUnitOfWork UnitOfWork {
        get;
    }

    /// <summary>
    /// Query đã lọc ra đã xoá (IsDeleted), không còn sử dụng (Used) và sắp xếp mới nhất lên đầu trang
    /// </summary>
    /// <param name="OnlyUsed">True: chỉ lấy còn sử dụng, False: lấy luôn cả không còn sử dụng</param>
    /// <param name="OnlyNotDeleted"></param>
    /// <param name="OrderByIndex"></param>
    /// <returns></returns>
    IQueryable<TEntity> GetQueryableSet(
       bool OnlyUsed = true,
       bool OnlyNotDeleted = true,
       bool OrderByIndex = true
    );

    /// <summary>
    /// Query đã lọc ra đã xoá (IsDeleted), còn sử dụng (Used = true) và sắp xếp mới nhất lên đầu trang
    /// </summary>
    /// <returns></returns>
    IQueryable<TEntity> GetQueryableSet();
    /// <summary>
    /// IQueryable đã sắp xếp mới nhất lên đầu trang
    /// </summary>
    /// <returns></returns>
    IQueryable<TEntity> GetOrderedSet();

    /// <summary>
    /// IQueryable gốc
    /// </summary>
    /// <returns></returns>
    IQueryable<TEntity> GetOriginalSet();

    Task AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    void Delete(TEntity entity);

    void BulkInsert(IEnumerable<TEntity> entities, bool keepIdentity = false);

    void BulkInsert(IEnumerable<TEntity> entities, Expression<Func<TEntity, object>> columnNamesSelector);

    void BulkUpdate(IEnumerable<TEntity> entities, Expression<Func<TEntity, object>> columnNamesSelector);

    void BulkMerge(IEnumerable<TEntity> entities, Expression<Func<TEntity, object>> idSelector,
        Expression<Func<TEntity, object>> updateColumnNamesSelector,
        Expression<Func<TEntity, object>> insertColumnNamesSelector);

    void BulkDelete(IEnumerable<TEntity> entities);

}
