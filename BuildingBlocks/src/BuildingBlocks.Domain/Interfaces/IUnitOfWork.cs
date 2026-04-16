using System.Data;

namespace BuildingBlocks.Domain.Interfaces;

public interface IUnitOfWork {
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    Task<IDisposable> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default);
    public bool HasTransaction { get; }

    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    IRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
    where TEntity : class, IHasKey<TKey>, IAggregateRoot, new()
    where TKey : notnull;

    IJunctionRepository<TEntity> GetJunctionRepository<TEntity>() where TEntity : class;
}