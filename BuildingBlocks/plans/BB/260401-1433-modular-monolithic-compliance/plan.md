# Plan: Modular Monolithic Architecture Compliance

## Context

User requested analysis of current source code compliance with Modular Monolithic standards. The assessment revealed:

- **Score: 6/10** → Target **8/10** after implementation
- **Strengths:** Clean Architecture layers, separate DbContext per module, no direct cross-module domain references
- **Weaknesses:** Skeleton modules incomplete, no integration events

### Current Architecture Summary

| Module | Location | Layers | Status |
|--------|----------|--------|--------|
| BuildingBlocks | `src/` | 5 layers | ✅ Complete |
| QLHD | `modules/QLHD/` | Full DDD | ✅ Complete (newest, inside BB) |
| DVDC | `DichVuDungChung/SER/` | Full DDD | ✅ Complete |
| NVTT | `NhiemVuTrongTam/SER/` | Full DDD | ✅ Complete |
| QLDA | `QuanLyDuAn/SER/` | Full DDD | ✅ Complete |

### User Decisions

| Decision | Choice | Notes |
|----------|--------|-------|
| Module Location | Keep External for now | Future modules will be inside BB; existing modules may migrate later |
| Integration Events | **Implement** | Add domain/integration event infrastructure |
| Schema Separation | Not needed | dbo = production, dev = sandbox; all modules share same schema |

### Solution Structure (BuildingBlocks.sln)

The solution already integrates all modules under solution folders:
- `src/` → BuildingBlocks layers
- `modules/DVDC/` → References external `DichVuDungChung/SER/` projects
- `modules/QLDA/` → References external `QuanLyDuAn/SER/` projects
- `modules/NVTT/` → References external `NhiemVuTrongTam/SER/` projects
- `modules/QLHD/` → Proper structure inside BuildingBlocks (template for future modules)

---

## Phase 1: Clean Up Skeleton Modules

### Goal
Remove incomplete skeleton module folders to eliminate confusion.

### Tasks

1. **Delete skeleton folders:**
   - `modules/DVDC/DVDC.Application/`
   - `modules/NVTT/NVTT.Application/`
   - `modules/QLDA/QLDA.Application/`

2. **Update BuildingBlocks.sln:**
   - Remove solution folder entries for skeleton projects
   - Keep existing references to complete modules (`DichVuDungChung/SER/`, etc.)

### Files to Modify
- `BuildingBlocks.sln` - Remove skeleton project entries
- Delete: `modules/DVDC/`, `modules/NVTT/`, `modules/QLDA/` folders

### Risk: Low
No production code affected, only unused skeleton files.

---

## Phase 2: Add Integration Event Infrastructure

### Goal
Enable cross-module communication via domain/integration events.

### Architecture

```
┌─────────────────────────────────────────────────────────────┐
│                     BuildingBlocks.Domain                    │
│  ┌─────────────────────────────────────────────────────────┐│
│  │ Events/                                                 ││
│  │   IDomainEvent : INotification                         ││
│  │   IntegrationEvent : IDomainEvent                      ││
│  │   IHasDomainEvents (interface for entities)            ││
│  └─────────────────────────────────────────────────────────┘│
└─────────────────────────────────────────────────────────────┘
                              │
                              ▼
┌─────────────────────────────────────────────────────────────┐
│                  BuildingBlocks.Application                  │
│  ┌─────────────────────────────────────────────────────────┐│
│  │ Behaviors/                                               ││
│  │   DomainEventBehavior<TRequest, TResponse>              ││
│  │   - Collects events from entities                       ││
│  │   - Dispatches via IPublisher after SaveChanges         ││
│  └─────────────────────────────────────────────────────────┘│
└─────────────────────────────────────────────────────────────┘
```

### Files to Create

| File | Purpose |
|------|---------|
| `src/BuildingBlocks.Domain/Events/IDomainEvent.cs` | Marker interface for domain events |
| `src/BuildingBlocks.Domain/Events/IntegrationEvent.cs` | Base class for cross-module events |
| `src/BuildingBlocks.Domain/Events/IHasDomainEvents.cs` | Interface for entities that raise events |
| `src/BuildingBlocks.Application/Behaviors/DomainEventBehavior.cs` | Pipeline behavior to dispatch events |

### Implementation Pattern

```csharp
// 1. Entity raises event
public class HopDong : Entity<Guid>, IHasDomainEvents
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent @event) => _domainEvents.Add(@event);
    public void ClearDomainEvents() => _domainEvents.Clear();

    public void MarkAsCompleted()
    {
        // Business logic...
        AddDomainEvent(new HopDongCompletedEvent(Id, Ten, GiaTri));
    }
}

// 2. Integration event (cross-module)
public record HopDongCompletedEvent(Guid HopDongId, string Ten, decimal GiaTri) : IntegrationEvent;

// 3. Handler in another module
public class HopDongCompletedEventHandler : INotificationHandler<HopDongCompletedEvent>
{
    public async Task Handle(HopDongCompletedEvent notification, CancellationToken ct)
    {
        // DVDC module reacts to QLHD event
    }
}
```

### Tasks

1. **Create event interfaces** (BuildingBlocks.Domain/Events/)
   - `IDomainEvent.cs` - Marker interface extending `INotification`
   - `IntegrationEvent.cs` - Base class with Id, OccurredOn
   - `IHasDomainEvents.cs` - Interface for entities

2. **Create DomainEventBehavior** (BuildingBlocks.Application/Behaviors/)
   - Add to MediatR pipeline
   - Dispatch events after successful SaveChanges

3. **Document usage** in CLAUDE.md
   - When to use domain events vs direct calls
   - Example implementation

### Risk: Medium
Requires changes to base infrastructure, but MediatR already in place.

---

## Phase 3: Documentation Updates

### Goal
Document Modular Monolithic architecture decisions and patterns.

### Files to Update

| File | Changes |
|------|---------|
| `docs/system-architecture.md` | Add bounded context diagram, integration events section |
| `CLAUDE.md` | Add integration event usage guidelines |

### Content

1. **Bounded Context Diagram** - Module responsibilities and boundaries
2. **Shared Kernel** - Entities in BuildingBlocks.Domain
3. **Integration Events** - When and how to use

### Risk: Low
Documentation only, no code changes.

---

## Phase 4: Future - Module Migration (Deferred)

### Goal
When time permits, migrate external modules into BuildingBlocks.

### Pattern
Use QLHD as template:
- Physical location: `BuildingBlocks/modules/{ModuleName}/`
- Layers: Domain, Application, Persistence, Infrastructure, WebApi, Migrator
- All new modules after QLHD follow this pattern

### Tasks (Future)
1. Create `modules/{ModuleName}/` folder structure
2. Move code from external location
3. Update project references in .sln
4. Test migrations and builds

---

## Verification

| Test | Command | Expected Result |
|------|---------|-----------------|
| Build | `dotnet build BuildingBlocks.sln` | Success, 0 errors |
| Tests | `dotnet test` | All tests pass |
| Event Test | Create test event, publish, verify handler receives | Event dispatched correctly |

---

## Implementation Order

| Phase | Priority | Effort |
|-------|----------|--------|
| 1: Clean Skeletons | High | 30 min |
| 2: Integration Events | High | 2-4 hours |
| 3: Documentation | Medium | 1 hour |
| 4: Module Migration | Low (future) | TBD |

---

## Success Criteria

After implementation:
- [ ] No skeleton module folders remain
- [ ] Integration event infrastructure available
- [ ] Example event documented
- [ ] Architecture score: **8/10**