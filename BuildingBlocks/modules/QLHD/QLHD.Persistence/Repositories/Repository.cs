// using System.Linq.Expressions;
// using BuildingBlocks.Domain.Constants;
// using BuildingBlocks.Domain.Interfaces;
// using EntityFrameworkCore.SqlServer.SimpleBulks.BulkDelete;
// using EntityFrameworkCore.SqlServer.SimpleBulks.BulkInsert;
// using EntityFrameworkCore.SqlServer.SimpleBulks.BulkUpdate;

// namespace QLHD.Persistence.Repositories;

// public class Repository<TEntity, TKey>(AppDbContext dbContext) : IRepository<TEntity, TKey>
//     where TEntity : class, IHasKey<TKey>, IAggregateRoot, new()
//     where TKey : notnull
// {
//     private readonly AppDbContext _dbContext = dbContext;
//     private DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

//     public IUnitOfWork UnitOfWork => _dbContext;

//     #region CRUD Operations
//     public async Task AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
//     {
//         if (entity.Id!.Equals(default(TKey)))
//         {
//             await AddAsync(entity, cancellationToken);
//         }
//         else
//         {
//             await UpdateAsync(entity, cancellationToken);
//         }
//     }

//     public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
//     {
//         await DbSet.AddAsync(entity, cancellationToken);
//     }

//     public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
//     {
//         await DbSet.AddRangeAsync(entities, cancellationToken);
//     }

//     public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
//     {
//         DbSet.Update(entity);
//         return Task.CompletedTask;
//     }

//     public void Delete(TEntity entity)
//     {
//         DbSet.Remove(entity);
//     }
//     #endregion

//     #region Querying
//     public IQueryable<TEntity> GetQueryableSet(
//         bool OnlyUsed = true,
//         bool OnlyNotDeleted = true,
//         bool OrderByDescIndex = true
//     )
//     {
//         IQueryable<TEntity> query = DbSet;

//         // Soft delete filter
//         if (OnlyNotDeleted)
//         {
//             var isDeletedProperty = typeof(TEntity).GetProperty(EntityPropertyNames.IsDeleted);
//             if (isDeletedProperty != null)
//             {
//                 var parameter = Expression.Parameter(typeof(TEntity), "e");
//                 var property = Expression.Property(parameter, EntityPropertyNames.IsDeleted);
//                 var notExpression = Expression.Not(property);
//                 var whereLambda = Expression.Lambda<Func<TEntity, bool>>(notExpression, parameter);
//                 query = query.Where(whereLambda);
//             }
//         }

//         // Used filter
//         if (OnlyUsed)
//         {
//             var usedProperty = typeof(TEntity).GetProperty(EntityPropertyNames.Used);
//             if (usedProperty != null)
//             {
//                 var parameter = Expression.Parameter(typeof(TEntity), "e");
//                 var property = Expression.Property(parameter, EntityPropertyNames.Used);
//                 // Handle nullable bool by using the property's actual type
//                 var trueConstant = Expression.Constant(true, property.Type);
//                 var equalExpression = Expression.Equal(property, trueConstant);
//                 var whereLambda = Expression.Lambda<Func<TEntity, bool>>(equalExpression, parameter);
//                 query = query.Where(whereLambda);
//             }
//         }

//         // Order by Index descending
//         if (OrderByDescIndex && typeof(IUnixTimeIndex).IsAssignableFrom(typeof(TEntity)))
//         {
//             query = query.OrderByDescending(e => ((IUnixTimeIndex)e).Index);
//         }

//         return query;
//     }

//     public IQueryable<TEntity> GetQueryableSet() => GetQueryableSet(true, true, true);

//     public IQueryable<TEntity> GetOrderedSet() => DbSet;

//     public IQueryable<TEntity> GetOriginalSet() => DbSet;
//     #endregion

//     #region Bulk Operations
//     public void BulkInsert(IEnumerable<TEntity> entities, bool keepIdentity = false)
//     {
//         _dbContext.BulkInsert(entities, options => { options.KeepIdentity = keepIdentity; });
//     }

//     public void BulkInsert(IEnumerable<TEntity> entities, Expression<Func<TEntity, object>> columnNamesSelector)
//     {
//         _dbContext.BulkInsert(entities, columnNamesSelector);
//     }

//     public void BulkUpdate(IEnumerable<TEntity> entities, Expression<Func<TEntity, object>> columnNamesSelector)
//     {
//         _dbContext.BulkUpdate(entities, columnNamesSelector);
//     }

//     public void BulkDelete(IEnumerable<TEntity> entities)
//     {
//         _dbContext.BulkDelete(entities, options => { });
//     }

//     public void BulkMerge(IEnumerable<TEntity> entities, Expression<Func<TEntity, object>> idSelector,
//         Expression<Func<TEntity, object>> updateColumnNamesSelector, Expression<Func<TEntity, object>> insertColumnNamesSelector)
//     {
//         // Will be implemented when needed
//         throw new NotImplementedException("BulkMerge not yet implemented for QLHD");
//     }
//     #endregion

//     #region MaterializedPath Operations
//     public bool IsMaterializedPath() => typeof(IMaterializedPathEntity<TKey>).IsAssignableFrom(typeof(TEntity));

//     public void InitializeNode(TEntity entity, TEntity? parent)
//     {
//         // Will be implemented when needed
//         throw new NotImplementedException("InitializeNode not yet implemented for QLHD");
//     }

//     public Task MoveNodeAsync(TEntity entity, TEntity? parent, CancellationToken cancellationToken = default)
//     {
//         // Will be implemented when needed
//         throw new NotImplementedException("MoveNodeAsync not yet implemented for QLHD");
//     }

//     public Task<List<IMaterializedPathEntity<TKey>>> GetAncestorsAsync(TKey id, CancellationToken cancellationToken = default)
//     {
//         // Will be implemented when needed
//         return Task.FromResult<List<IMaterializedPathEntity<TKey>>>([]);
//     }

//     public Task<List<IMaterializedPathEntity<TKey>>> GetDescendantsAsync(TKey id, CancellationToken cancellationToken = default)
//     {
//         // Will be implemented when needed
//         return Task.FromResult<List<IMaterializedPathEntity<TKey>>>([]);
//     }

//     public void ResetMaterializedPathsInMemory(
//         List<TEntity> allNodes,
//         Func<TEntity, TKey> getId,
//         Func<TEntity, TKey?> getParentId,
//         Action<TEntity, string> setPath,
//         Action<TEntity, int> setLevel,
//         Action<TEntity, TKey?> setParentId)
//     {
//         // Will be implemented when needed
//     }
//     #endregion
// }