# Phase 06: Testing

**Priority:** High
**Status:** Pending
**Dependencies:** Phase 05

## Overview

Create integration tests for the Chot feature and verify functionality.

## Requirements

### Functional Requirements

1. Test Chot endpoint with valid KeHoachThangId
2. Test duplicate snapshot prevention
3. Test date range filtering accuracy
4. Test transaction rollback on error
5. Verify version record field accuracy

### Non-Functional Requirements

- Use existing test patterns from QLHD.Tests
- Test both success and failure scenarios
- Use in-memory or test database

## Architecture

### Test Cases

```csharp
public class KeHoachThangChotTests
{
    // Success scenarios
    [Fact] async Task Chot_WithValidKeHoachThang_ReturnsSummary()
    [Fact] async Task Chot_CopiesAllFieldsCorrectly()
    [Fact] async Task Chot_FiltersByDateRange()
    
    // Failure scenarios
    [Fact] async Task Chot_WithInvalidId_Returns404()
    [Fact] async Task Chot_AlreadyChoted_Returns400()
    [Fact] async Task Chot_NoRecordsInRange_ReturnsEmptySummary()
}
```

### Field Verification Test

```csharp
[Fact]
public async Task Chot_CopiesAllFieldsCorrectly()
{
    // Setup: Create source entity with all fields populated
    var source = new DuAn_ThuTien
    {
        DuAnId = duAnId,
        LoaiThanhToanId = loaiId,
        ThoiGianKeHoach = new DateOnly(2027, 1, 15),
        PhanTramKeHoach = 25.5m,
        GiaTriKeHoach = 1000000m,
        GhiChuKeHoach = "Test note",
        ThoiGianThucTe = new DateOnly(2027, 1, 20),
        GiaTriThucTe = 950000m,
        GhiChuThucTe = "Actual note",
        SoHoaDon = "HD001",
        KyHieuHoaDon = "K1",
        NgayHoaDon = new DateOnly(2027, 1, 21)
    };
    
    // Act: Call Chot
    var result = await _client.PostAsync("/ke-hoach-thang/chot/{id}", ...);
    
    // Assert: Verify version record has same values
    var version = await _dbContext.DuAn_ThuTien_Versions.FirstOrDefaultAsync();
    Assert.Equal(source.ThoiGianKeHoach, version.ThoiGianKeHoach);
    Assert.Equal(source.PhanTramKeHoach, version.PhanTramKeHoach);
    Assert.Equal(source.GiaTriKeHoach, version.GiaTriKeHoach);
    // ... verify all fields
}
```

## Implementation Steps

1. Create test file `KeHoachThangChotTests.cs`
2. Implement success test cases
3. Implement failure test cases
4. Run tests and verify all pass
5. Fix any issues discovered

## Todo List

- [ ] Create test class
- [ ] Implement valid Chot test
- [ ] Implement duplicate prevention test
- [ ] Implement date range filter test
- [ ] Implement field accuracy test
- [ ] Run all tests
- [ ] Fix failing tests

## Success Criteria

- All tests pass
- Field values copied correctly
- Date range filter works
- Duplicate prevention enforced
- Transaction handling verified

## Risk Assessment

| Risk | Mitigation |
|------|------------|
| Test data setup | Use seed data or create in test setup |
| Async timing | Use proper async test patterns |

## Final Verification

- [ ] Run `dotnet build BuildingBlocks.sln` - no compile errors
- [ ] Run `dotnet test` - all tests pass
- [ ] Manual test via Swagger - endpoint works
- [ ] Verify database - version tables populated