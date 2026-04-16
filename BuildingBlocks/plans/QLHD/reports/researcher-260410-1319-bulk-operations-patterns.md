# Research Report: Command and Handler Patterns for Bulk Operations in QLHD and BuildingBlocks

## Executive Summary

This research analyzes the command and handler patterns for bulk operations in the QLHD and BuildingBlocks modules. The system uses a well-defined CQRS architecture with repository patterns, bulk operations, and transaction management through Unit of Work (UOW).

## 1. Repository Bulk Operations Patterns

### 1.1 BuildingBlocks IRepository Interface
The `IRepository<TEntity, TKey>` interface defines comprehensive bulk operations:

```csharp
void BulkInsert(IEnumerable<TEntity> entities, bool keepIdentity = false);
void BulkInsert(IEnumerable<TEntity> entities, Expression<Func<TEntity, object>> columnNamesSelector);
void BulkUpdate(IEnumerable<TEntity> entities, Expression<Func<TEntity, object>> columnNamesSelector);
void BulkDelete(IEnumerable<TEntity> entities);
void BulkMerge(IEnumerable<TEntity> entities, Expression<Func<TEntity, object>> idSelector,
    Expression<Func<TEntity, object>> updateColumnNamesSelector,
    Expression<Func<TEntity, object>> insertColumnNamesSelector);
```

### 1.2 Implementation Details
- Uses `EntityFrameworkCore.SqlServer.SimpleBulks` library for efficient bulk operations
- Built into the base `BuildingBlocks.Persistence.Repositories.Repository<TEntity, TKey>`
- QLHD modules use the base implementation (commented out custom implementation)

## 2. Command Handler Patterns

### 2.1 Transaction Management Pattern
The system follows a consistent transaction pattern:

```csharp
public async Task Handle(Command request, CancellationToken cancellationToken)
{
    if (_unitOfWork.HasTransaction)
    {
        // Already in transaction - perform operation directly
        await OperationAsync(request, cancellationToken);
    }
    else
    {
        // Start new transaction
        using var tx = await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        await OperationAsync(request, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync(cancellationToken);
    }
}
```

### 2.2 Multi-Repository Pattern
Complex handlers manage multiple repositories through dependency injection:

```csharp
internal class XuatHoaDonInsertOrUpdateCommandHandler : IRequestHandler<XuatHoaDonInsertOrUpdateCommand, XuatHoaDonDto>
{
    private readonly IRepository<HopDong, Guid> _hopDongRepository;
    private readonly IRepository<DuAn_XuatHoaDon, Guid> _duAnXuatHoaDonRepository;
    private readonly IRepository<HopDong_XuatHoaDon, Guid> _hopDongXuatHoaDonRepository;
    private readonly IUnitOfWork _unitOfWork;

    public XuatHoaDonInsertOrUpdateCommandHandler(IServiceProvider serviceProvider)
    {
        _hopDongRepository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
        _duAnXuatHoaDonRepository = serviceProvider.GetRequiredService<IRepository<DuAn_XuatHoaDon, Guid>>();
        _hopDongXuatHoaDonRepository = serviceProvider.GetRequiredService<IRepository<HopDong_XuatHoaDon, Guid>>();
        _unitOfWork = _hopDongRepository.UnitOfWork;
    }
}
```

## 3. Bulk Operation Command Patterns

### 3.1 Bulk Insert/Update Pattern (TepDinhKem/Attachment)
The `TepDinhKemBulkInsertOrUpdateCommand` demonstrates sophisticated sync patterns:

```csharp
private async Task InsertOrUpdateCascadeAsync(TepDinhKemBulkInsertOrUpdateCommand request, CancellationToken cancellationToken = default)
{
    // Get existing entities
    var existing = await _repository.GetOrderedSet()
        .Where(e => e.GroupId == request.GroupId)
        .ToListAsync(cancellationToken);
    
    var requestIds = request.Entities.Select(e => e.Id).ToList();
    var existingIds = existing.Select(e => e.Id).ToList();

    // Determine operations
    var toAdd = request.Entities.Where(e => !existingIds.Contains(e.Id)).ToList();
    var toUpdate = request.Entities.Where(e => existingIds.Contains(e.Id)).ToList();
    var toRemove = existing.Where(e => !requestIds.Contains(e.Id)).ToList();

    // Execute bulk operations
    if (toAdd.Count != 0) {
        _repository.BulkInsert(toAdd);
    }

    if (toUpdate.Count != 0) {
        _repository.BulkUpdate(toUpdate, x => new {
            x.Type, x.FileName, x.OriginalName, x.Path, x.Size
        });
    }

    if (toRemove.Count != 0 && !request.KySo) {
        _repository.BulkDelete(toRemove);
    }
}
```

### 3.2 Sync Helper Pattern
The `SyncHelper` class provides standardized synchronization for collections:

```csharp
public static async Task SyncCollection<T, TKey>(
    IRepository<T, TKey> repository,
    ICollection<T>? existingEntities,            
    IEnumerable<T>? requestEntities,             
    Action<T, T>? updateAction = null,
    CancellationToken cancellationToken = default
)
where T : class, IHasKey<TKey>, IMayHaveDelete, IAggregateRoot, new()
where TKey : notnull
```

## 4. Complex Business Logic Patterns

### 4.1 Conditional Routing Pattern
The system handles complex routing logic (e.g., `XuatHoaDonInsertOrUpdateCommand`):

```csharp
public async Task<XuatHoaDonDto> Handle(XuatHoaDonInsertOrUpdateCommand request, CancellationToken cancellationToken)
{
    var hopDong = await _hopDongRepository.GetQueryableSet()
        .FirstAsync(h => h.Id == model.HopDongId, cancellationToken);

    if (hopDong.DuAnId.HasValue) {
        // Route to DuAn_XuatHoaDon
        return await HandleDuAnXuatHoaDon(model, hopDong.DuAnId.Value, hopDong.Id, cancellationToken);
    } else {
        // Route to HopDong_XuatHoaDon
        return await HandleHopDongXuatHoaDon(model, hopDong.Id, cancellationToken);
    }
}
```

### 4.2 Junction Table Operations
Junction repositories handle many-to-many relationships:

```csharp
public interface IJunctionRepository<TEntity>
{
    Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool saveChanges = false, CancellationToken cancellationToken = default);
    // ... other operations
}
```

## 5. Transaction and Error Handling

### 5.1 Transaction Scope Management
- Automatic transaction detection using `_unitOfWork.HasTransaction`
- Proper isolation levels (`ReadCommitted`)
- Using statements for automatic disposal

### 5.2 Error Handling Patterns
- `ManagedException.ThrowIfNull()` for null validation
- FluentValidation for complex validation scenarios
- Centralized exception handling through pipeline behaviors

## 6. Recommendations for Bulk Copy Commands

### 6.1 Structuring Bulk Copy Command
```csharp
public record EntityBulkCopyCommand(List<Guid> SourceIds, Guid TargetParentId) : IRequest<List<EntityDto>>;

internal class EntityBulkCopyCommandHandler : IRequestHandler<EntityBulkCopyCommand, List<EntityDto>>
{
    private readonly IRepository<SourceEntity, Guid> _sourceRepository;
    private readonly IRepository<TargetEntity, Guid> _targetRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public async Task<List<EntityDto>> Handle(EntityBulkCopyCommand request, CancellationToken cancellationToken)
    {
        if (_unitOfWork.HasTransaction)
        {
            return await PerformCopyAsync(request, cancellationToken);
        }
        
        using var tx = await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        var result = await PerformCopyAsync(request, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync(cancellationToken);
        return result;
    }
}
```

### 6.2 Transaction Management Approach
- Always check `_unitOfWork.HasTransaction` before starting new transactions
- Use `IsolationLevel.ReadCommitted` for consistency
- Implement proper rollback through `using` statement scope

### 6.3 Error Handling Pattern
- Use specific validation in handlers
- Implement graceful failure recovery
- Log detailed error information for debugging

## 7. Validation Patterns
- Use FluentValidation in separate validator classes
- Validate cross-entity dependencies
- Check business rules before execution
- Separate validation from business logic

## 8. Key Takeaways

1. **Consistent Transaction Pattern**: Always check existing transaction state
2. **Multi-Repository Support**: Use Service Provider injection for multiple repositories
3. **Bulk Efficiency**: Leverage bulk operations for performance
4. **Sync Operations**: Use SyncHelper for collection synchronization
5. **Error Resilience**: Implement proper error handling and logging
6. **Modularity**: Keep commands focused on single responsibility
7. **Validation Separation**: Use dedicated validators for validation logic

## Unresolved Questions
- Are there any specific bulk copy operation patterns in other modules (DVDC, QLDA, NVTT)?
- What are the specific requirements for the bulk copy functionality being implemented?
- Are there any performance benchmarks for bulk operations in the system?

This analysis provides a comprehensive foundation for implementing bulk copy operations following established patterns in the codebase.