# Code Review: QLHD Integration Tests

## Scope
- Files: 26 test files (23 controllers + 3 infrastructure)
- LOC: ~350 lines
- Focus: Integration test quality, consistency, coverage

## Overall Assessment
Basic smoke tests for HTTP endpoints. Adequate for verifying API connectivity but lacks depth for production readiness. Missing critical test scenarios: validation failures, update operations, authentication boundaries, test isolation.

## Critical Issues

### 1. Test Isolation - Shared Database State (HIGH)
**Problem:** `IClassFixture<TestWebApplicationFactory>` shares single InMemory database across all test classes.

```csharp
// Current - all tests share same DB
public class HopDongControllerTests : IClassFixture<TestWebApplicationFactory>

// Seed data persists across ALL test classes
db.Set<DanhMucLoaiHopDong>().AddRange(...);
```

**Impact:**
- Tests can interfere with each other
- Order-dependent failures
- Create test in HopDongControllerTests affects DuAnControllerTests queries
- No cleanup between tests

**Fix:** Use `IAsyncLifetime` or collection fixtures with reset, or unique DB per test class:

```csharp
// Option A: Unique DB per test class
private static readonly string DatabaseName = $"QLHD_Test_{Guid.NewGuid()}";

// Option B: Reset before each test
public async Task InitializeAsync() => await ResetDatabase();
```

### 2. Missing HTTP Coverage (HIGH)
**Coverage gaps:**

| Method | Coverage |
|--------|----------|
| GET | Good (all endpoints) |
| POST | Partial (only DanhMucLoaiHopDong, HopDong) |
| PUT | **NONE** - 0 tests |
| DELETE | Partial (only HopDong, DuAn) |

**Missing tests:**
- Update operations for all entities
- Validation error responses (400 with model errors)
- Authentication failures (401/403)
- Duplicate key conflicts

### 3. Inconsistent API Response Expectations (MEDIUM)
**Problem:** Tests expect different responses for identical scenarios (non-existent ID).

| Controller | Non-existent ID Response |
|------------|-------------------------|
| DanhMucLoaiHopDong | `BadRequest` |
| DanhMucTrangThai | `OK` (with error message) |
| HopDong | `OK` (with error message) |
| DanhMucGiamDoc | `BadRequest` |

**Root cause:** API design inconsistency, not test issue. Tests correctly document actual behavior.

**Recommendation:** Standardize API response for missing entities:
- Option A: Return 404 NotFound (HTTP standard)
- Option B: Return 200 with `ResultApi.Fail("Not found")` (current pattern)

## High Priority

### 4. Assertion Depth - Surface-Level Only
**Problem:** Tests only verify HTTP success, not response content shape.

```csharp
// Current - only checks status code
response.Should().BeSuccessful();

// Should verify:
var result = await response.Content.ReadFromJsonAsync<ResultApi<List<Dto>>>();
result.Should().NotBeNull();
result!.Result.Should().BeTrue();
result.DataResult.Should().NotBeEmpty();  // For seeded data
```

**Impact:** API could return empty/malformed data and tests would pass.

### 5. Missing AAA Pattern Comments
**Inconsistency:** Some tests have `// Arrange, // Act, // Assert`, others don't.

```csharp
// ChiPhiControllerTests.cs - no AAA comments
[Fact]
public async Task GetList_ShouldReturnSuccess()
{
    var response = await _client.GetAsync("api/chi-phi/danh-sach");
    response.Should().BeSuccessful();
}

// HopDongControllerTests.cs - has AAA comments
[Fact]
public async Task GetById_NonExistentId_ShouldReturnSuccess()
{
    // Arrange
    var nonExistentId = Guid.NewGuid();
    // Act
    var response = await _client.GetAsync(...);
    // Assert
    response.StatusCode.Should().Be(HttpStatusCode.OK);
}
```

**Fix:** Standardize all tests with AAA comments for readability.

### 6. Test Data Dependency Chain
**Problem:** HopDongControllerTests.Create requires KhachHangId from seed data with hardcoded GUID.

```csharp
private static readonly Guid TestKhachHangId = Guid.Parse("00000000-0000-0000-0000-000000000001");
```

**Risk:** If TestDataSeeder changes GUID, test fails silently.

**Fix:** Either:
- Define constants in shared location (TestDataSeeder + tests)
- Or query seed data at test runtime

## Medium Priority

### 7. Unused ResultApi Type in Some Tests
**Problem:** DanhMucLoaiHopDongControllerTests declares `ResultApi` usage but others don't.

```csharp
// DanhMucLoaiHopDong - reads ResultApi
var result = await response.Content.ReadFromJsonAsync<ResultApi>();

// Others - don't read response content at all
```

**Fix:** All tests should deserialize and verify response shape.

### 8. Missing NguoiDungController Tests
**Coverage gap:** NguoiDungController exists in WebApi but no test file.

### 9. Hardcoded Non-Existent IDs
**Pattern:** `9999` for int IDs, `Guid.NewGuid()` for Guid IDs.

**Works but fragile:** If seed data reaches ID 9999, tests fail.

**Fix:** Use clearly impossible IDs or constants defined in test base.

## Low Priority

### 10. Inconsistent Assertion Style
**Two styles used:**

```csharp
// Style A: FluentAssertions extension
response.Should().BeSuccessful();

// Style B: Direct StatusCode check
response.StatusCode.Should().Be(HttpStatusCode.OK);
```

**Recommendation:** Prefer Style A for readability, Style B when specific status needed.

### 11. Comment Quality
**Good:** Most test classes have helpful XML comments explaining purpose.

```csharp
/// <summary>
/// Integration tests for TienDoController.
/// GetList requires hopDongId query parameter.
/// </summary>
```

**Improvement opportunity:** Add more context about endpoints tested.

## Edge Cases Not Tested

| Scenario | Coverage |
|----------|----------|
| Invalid model validation | None |
| Authentication failure | None |
| Authorization boundary | None |
| Concurrency conflicts | None |
| Large payload | None |
| Unicode/special chars | None |
| Null required fields | None |
| FK constraint violations | None |
| Pagination limits | None |

## Positive Observations

1. **Consistent naming pattern:** `{Method}_{Scenario}_Should{Outcome}`
2. **Good endpoint discovery:** Tests cover all major Vietnamese-named endpoints (`danh-sach`, `chi-tiet`, `them-moi`, `xoa`)
3. **Proper HTTP client usage:** `PostAsJsonAsync`, `ReadFromJsonAsync`
4. **Test infrastructure:** Clean separation (factory, auth, seeder)
5. **Mock auth:** Comprehensive role claims for full access testing
6. **UTC timestamps in seed:** `SeedCreatedAt` properly uses `TimeSpan.Zero`

## Recommended Actions

1. **P1: Test isolation** - Implement database reset per test/class
2. **P1: Add PUT tests** - Cover update operations for all entities
3. **P2: Verify response content** - Deserialize and check `ResultApi` shape
4. **P2: Add validation tests** - Test 400 responses for invalid models
5. **P2: Standardize AAA comments** - Consistent across all tests
6. **P3: Add NguoiDungController tests** - Complete coverage
7. **P3: Extract test constants** - Centralize hardcoded IDs

## Metrics

| Metric | Value |
|--------|-------|
| Test Classes | 23 |
| Total Tests | ~70 |
| HTTP Methods Covered | GET, POST, DELETE (missing PUT) |
| Assertion Depth | Low (status codes only) |
| Test Isolation | None (shared DB) |
| AAA Pattern Usage | ~50% |

## Unresolved Questions

1. Should API standardize to HTTP 404 for missing entities vs current `ResultApi.Fail` pattern?
2. Should tests use shared collection fixture with reset or isolated DB per test class?
3. Is NguoiDungController intentionally excluded (requires auth context)?