# Audit Control Guide (Hướng Dẫn Kiểm Soát Audit Log)

## Overview

Hệ thống audit log hỗ trợ việc kiểm soát audit ở **entity level** thông qua interface `IConditionalAuditable`. Điều này cho phép từng entity tự quyết định có audit hay không mà **không can thiệp vào SaveChanges interceptor**.

## 1. Interface IAuditable - Audit Đầy Đủ

### Mục đích
Đánh dấu entity sẽ được audit đầy đủ tất cả các thay đổi.

### Cách sử dụng
```csharp
public class MyEntity : Entity<Guid>, IAuditable
{
    // Entity này sẽ được audit tất cả thay đổi
}
```

### Khi nào sử dụng
- Entity quan trọng cần theo dõi đầy đủ lịch sử thay đổi
- Entity chứa dữ liệu nhạy cảm cần audit trail
- Entity nghiệp vụ chính của hệ thống

## 2. Interface IConditionalAuditable - Điều Kiện Audit (Khuyến nghị)

### Mục đích
Cho phép entity tự quyết định có audit hay không dựa trên logic business, với khả năng override từ bên ngoài thông qua property `_auditDisabled`.

### Cách sử dụng
```csharp
public class Document : Entity<Guid>, IAuditable, IConditionalAuditable
{
    private bool _auditDisabled;

    public string Status { get; set; } // Draft, Published, Archived
    public bool IsSystemGenerated { get; set; }

    // Method mặc định - sử dụng logic bên trong
    public bool ShouldAudit()
    {
        // Không audit nếu bị disable hoặc là draft/system generated
        return !_auditDisabled && Status != "Draft" && !IsSystemGenerated;
    }

    // Overload method - cho phép override từ bên ngoài (nếu cần)
    public bool ShouldAudit(bool? forceAudit)
    {
        if (forceAudit.HasValue)
        {
            return forceAudit.Value;
        }
        return ShouldAudit();
    }

    // Methods để kiểm soát audit từ command handlers
    public void DisableAudit() => _auditDisabled = true;
    public void EnableAudit() => _auditDisabled = false;
}
```

### Khi nào sử dụng
- **Khuyến nghị cho hầu hết trường hợp** - clean, không can thiệp vào interceptor
- Entity có logic phức tạp để quyết định audit
- Muốn audit dựa trên trạng thái của entity
- Muốn audit dựa trên business rules
- **Muốn bỏ qua audit hoàn toàn**: gọi `entity.DisableAudit()` trước khi save

## 3. Sử Dụng Trong Command Handlers

### Entity Level Control (Khuyến nghị)
```csharp
public async Task ProcessDocumentsAsync(List<Document> documents)
{
    // Tắt audit cho từng entity
    foreach (var doc in documents)
    {
        doc.DisableAudit();
    }

    // Thực hiện operations - không tạo audit logs
    foreach (var doc in documents)
    {
        await _repository.AddAsync(doc);
    }
    await _unitOfWork.SaveChangesAsync();
}
```

### SyncCollection với DisableAudit
```csharp
await SyncHelper.SyncCollection(
    repository: _repository,
    existingEntities: existingCollection,
    requestEntities: newEntities,
    updateAction: (existing, request) => {
        existing.Name = request.Name;
    },
    disableAudit: true, // Tự động disable audit cho tất cả entities
    cancellationToken: cancellationToken);
```

## 4. Legacy - IUnitOfWork Level (Không khuyến nghị)

### Không khuyến nghị sử dụng
Cách này can thiệp vào SaveChanges interceptor và có thể gây ra vấn đề. Sử dụng entity-level control thay thế.

```csharp
// Không khuyến nghị - can thiệp vào interceptor
using (_unitOfWork.BeginAuditDisabledScope())
{
    // Operations
}
```

## 5. Best Practices

### Nên làm
- Sử dụng `IAuditable` cho entities cần audit đầy đủ
- Sử dụng `IConditionalAuditable` cho logic audit phức tạp hoặc bỏ qua audit
- Gọi trực tiếp `DisableAudit()` trên entities khi cần tắt audit cụ thể (khuyến nghị)
- Gọi `DisableAudit()` trước khi thực hiện bulk operations
- Implement cả hai overload methods trong `IConditionalAuditable` để linh hoạt
- Sử dụng internal state (`_auditDisabled`) để kiểm soát audit từ command handlers

### Không nên làm
- Không sử dụng `IUnitOfWork.BeginAuditDisabledScope()` (can thiệp vào interceptor)
- Không implement `IConditionalAuditable` với logic quá phức tạp
- Không quên gọi `DisableAudit()` trước khi save entities
- Không để `_auditDisabled` state tồn tại ngoài scope sử dụng
- Không can thiệp vào SaveChanges interceptor

## 6. Performance Considerations

| Method | Overhead |
|--------|----------|
| `IAuditable` | Audit đầy đủ, có overhead tạo audit log |
| `IConditionalAuditable.ShouldAudit()` | Kiểm tra điều kiện, overhead tối thiểu |
| `IConditionalAuditable.ShouldAudit(bool? forceAudit)` | Override từ bên ngoài, overhead tối thiểu |
| `DisableAudit()` trên entities | Không có overhead audit, entities bị skip hoàn toàn |
| Legacy scope pattern | Can thiệp vào interceptor, không khuyến nghị |

## 7. Implementation Pattern

### Thêm IConditionalAuditable vào Entity
```csharp
public class MyEntity : Entity<Guid>, IAggregateRoot, IAuditable, IConditionalAuditable
{
    #region Internal State for Audit Control
    private bool _auditDisabled;
    #endregion

    // ... entity properties

    #region IConditionalAuditable Implementation
    public bool ShouldAudit() => !_auditDisabled;
    public bool ShouldAudit(bool? forceAudit) => forceAudit ?? ShouldAudit();
    public void DisableAudit() => _auditDisabled = true;
    public void EnableAudit() => _auditDisabled = false;
    #endregion
}
```

### Sử dụng trong Command Handlers
```csharp
// Tắt audit cho entities trước khi bulk operations
foreach (var entity in entities)
{
    entity.DisableAudit();
}

// Thực hiện operations - không tạo audit logs
await _repository.AddRangeAsync(entities);
await _unitOfWork.SaveChangesAsync();
```

---

**Last Updated:** 2026-03-20
**Source:** Migrated from DVDC local BuildingBlocks