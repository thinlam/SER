# Plan: QLHD WebApi Integration Tests

## Context

QLHD.WebApi has NO existing test project. Controllers are thin MediatR wrappers - real logic in Application layer handlers. Need integration tests to validate HTTP contract, auth, validation, middleware pipeline.

**Current State:**
- Only `BuildingBlocks.Tests/SharedKernel.Tests` exists (unit tests for Domain value types)
- QLHD controllers: HopDong, DuAn, KhachHang, ThuTien, ChiPhi, etc.
- WebApi uses JWT auth, MediatR CQRS, schema-aware EF Core migrations

**Test Pyramid:**
| Layer | Test Type | Priority | Effort |
|-------|-----------|----------|--------|
| Controllers | Integration (WebApplicationFactory) | High | Medium |
| Handlers | Unit (MediatR mock) | Medium | Low |

---

## Phase 1: Setup Test Project

### Goal
Create `QLHD.Tests` project with proper structure and dependencies.

### Tasks

1. Create test project structure:
   ```
   tests/QLHD.Tests/
   ├── QLHD.Tests.csproj
   ├── Integration/
   │   ├── Controllers/
   │   │   ├── HopDongControllerTests.cs
   │   │   ├── DuAnControllerTests.cs
   │   │   └── DanhMucControllerTests.cs
   │   └── Infrastructure/
   │   │   ├── TestWebApplicationFactory.cs
   │   │   ├── MockAuthenticationHandler.cs
   │   │   └── TestDataSeeder.cs
   └── Unit/
       └── Handlers/
   ```

2. Add project references:
   - `QLHD.WebApi`
   - `QLHD.Application`
   - `QLHD.Persistence`
   - `BuildingBlocks.Domain`
   - `BuildingBlocks.Application`

3. Add NuGet packages:
   - `xunit` (2.6.6)
   - `Microsoft.AspNetCore.Mvc.Testing` (8.0.x)
   - `FluentAssertions` (6.x)
   - `Microsoft.EntityFrameworkCore.InMemory` (for fast tests)

### Files to Create

| File | Purpose |
|------|---------|
| `tests/QLHD.Tests/QLHD.Tests.csproj` | Project definition |
| `tests/QLHD.Tests/GlobalUsings.cs` | Common imports |

### Risk: Low
Standard project setup, no production code changes.

---

## Phase 2: Test Infrastructure

### Goal
Build WebApplicationFactory with mock auth and test DB.

### Architecture

```
TestWebApplicationFactory<Program>
    │
    ├── ConfigureTestServices:
    │   ├── Replace DbContext → InMemory or SQLite
    │   ├── Replace JWT auth → MockAuthenticationHandler
    │   └── Seed test data
    │
    └── Client:
        ├── Auto-authorized requests
        └── No real JWT validation
```

### Implementation Pattern

```csharp
// TestWebApplicationFactory.cs
public class TestWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Remove real DbContext
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
            if (descriptor != null) services.Remove(descriptor);

            // Add InMemory DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("TestDb"));

            // Mock authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "TestScheme";
                options.DefaultChallengeScheme = "TestScheme";
            })
            .AddScheme<AuthenticationSchemeOptions, MockAuthenticationHandler>(
                "TestScheme", null);
        });
    }
}

// MockAuthenticationHandler.cs
public class MockAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public MockAuthenticationHandler(...) : base(...) { }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, "test-user"),
            new Claim(ClaimConstants.Permission, "QLHD_VIEW"),
            new Claim(ClaimConstants.Permission, "QLHD_EDIT")
        };
        var identity = new ClaimsIdentity(claims, "TestScheme");
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, "TestScheme");

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}
```

### Tasks

1. Create `TestWebApplicationFactory.cs`
   - InMemory DB configuration
   - Mock auth replacement
   - Seed minimal DanhMuc data

2. Create `MockAuthenticationHandler.cs`
   - Bypass JWT validation
   - Pre-configured test claims (permissions)

3. Create `TestDataSeeder.cs`
   - Seed `DanhMucTrangThai`, `DanhMucLoaiHopDong` for referential integrity

### Files to Create

| File | Purpose |
|------|---------|
| `Integration/Infrastructure/TestWebApplicationFactory.cs` | Factory setup |
| `Integration/Infrastructure/MockAuthenticationHandler.cs` | Auth bypass |
| `Integration/Infrastructure/TestDataSeeder.cs` | Seed test data |

### Risk: Low
Isolated test infrastructure, no production impact.

---

## Phase 3: Integration Tests

### Goal
Write tests for key controllers (HopDong, DuAn, DanhMuc).

### Test Pattern

```csharp
public class HopDongControllerTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;

    public HopDongControllerTests(TestWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetList_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("hop-dong/danh-sach");
        response.Should().BeSuccessful();
    }

    [Fact]
    public async Task GetById_InvalidId_ShouldReturnNotFound()
    {
        var response = await _client.GetAsync($"hop-dong/chi-tiet/{Guid.NewGuid()}");
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task Create_ValidModel_ShouldReturnCreatedDto()
    {
        var model = new HopDongInsertModel { Ten = "Test Contract", ... };
        var response = await _client.PostAsJsonAsync("hop-dong/them-moi", model);
        response.Should().BeSuccessful();
        var dto = await response.Content.ReadFromJsonAsync<ResultApi<HopDongDto>>();
        dto.Data.Ten.Should().Be("Test Contract");
    }
}
```

### Tasks

1. **DanhMuc tests** (simplest, good starting point)
   - `DanhMucLoaiHopDongControllerTests.cs`
   - Test: GetList returns success

2. **HopDong tests** (core entity)
   - `HopDongControllerTests.cs`
   - Tests: GetList, GetById, Create, Update, Delete
   - Negative tests: InvalidId, validation errors

3. **DuAn tests**
   - `DuAnControllerTests.cs`
   - Tests: GetList, GetById

### Files to Create

| File | Tests |
|------|-------|
| `Integration/Controllers/DanhMucLoaiHopDongControllerTests.cs` | GetList |
| `Integration/Controllers/HopDongControllerTests.cs` | CRUD + validation |
| `Integration/Controllers/DuAnControllerTests.cs` | GetList, GetById |

### Risk: Low
Tests only, no production code.

---

## Phase 4: Add to Solution & Verify

### Goal
Include test project in solution, run tests, fix issues.

### Tasks

1. Add `QLHD.Tests` to `BuildingBlocks.sln` under `tests` solution folder

2. Run tests:
   ```bash
   dotnet test tests/QLHD.Tests/QLHD.Tests.csproj
   ```

3. Fix any failing tests (validation missing, seed data incomplete)

4. Add test run to CI/CD (optional, future)

### Files to Modify

| File | Changes |
|------|---------|
| `BuildingBlocks.sln` | Add QLHD.Tests project reference |

### Risk: Low
Solution file update only.

---

## Verification

| Test | Command | Expected |
|------|---------|----------|
| Build | `dotnet build tests/QLHD.Tests` | Success |
| Run Tests | `dotnet test tests/QLHD.Tests` | All pass |
| In IDE | Visual Studio Test Explorer | Tests visible |

---

## Implementation Order

| Phase | Priority | Effort |
|-------|----------|--------|
| 1: Setup Project | High | 15 min |
| 2: Test Infrastructure | High | 45 min |
| 3: Integration Tests | High | 1-2 hours |
| 4: Solution & Verify | High | 15 min |

**Total: ~2-3 hours**

---

## Success Criteria

- [x] `QLHD.Tests` project exists with proper structure
- [x] WebApplicationFactory with mock auth works
- [x] DanhMuc tests pass
- [x] HopDong CRUD tests pass
- [x] Test project in solution file
- [x] `dotnet test` runs successfully

---

## Notes

**Why InMemory DB:** Fast, no external dependency, suitable for integration tests focused on HTTP contract.

**Why not Testcontainers:** Adds complexity, requires Docker, PG-specific features (schema-aware) not needed for basic API tests.

**Future consideration:** Add unit tests for complex handlers (e.g., HopDongInsertCommandHandler) if business logic grows.