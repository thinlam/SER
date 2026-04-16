# Phase 04: API Endpoint

**Priority:** High
**Status:** Pending
**Dependencies:** Phase 03

## Overview

Add API endpoint to KeHoachThangController for triggering the Chot operation.

## Requirements

### Functional Requirements

1. Add POST endpoint: `/ke-hoach-thang/chot/{id}`
2. Accept KeHoachThangId in route parameter
3. Return VersionsSummaryDto with snapshot results
4. Handle errors with appropriate HTTP status codes

### Non-Functional Requirements

- Require authentication
- Use async/await pattern
- Follow existing controller patterns
- Return proper HTTP responses (200, 400, 404, 500)

## Architecture

### Endpoint Definition

```csharp
/// <summary>
/// Chốt kế hoạch tháng - tạo snapshot dữ liệu thu tiền, xuất hóa đơn, chi phí
/// </summary>
/// <param name="id">ID kế hoạch tháng</param>
/// <returns>Summary of snapshot counts per table</returns>
[HttpPost("chot/{id}")]
[ProducesResponseType(typeof(KeHoachThang_VersionsSummaryDto), StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public async Task<ActionResult<KeHoachThang_VersionsSummaryDto>> Chot(int id, CancellationToken cancellationToken)
{
    var result = await Mediator.Send(new KeHoachThangChotCommand { KeHoachThangId = id }, cancellationToken);
    return Ok(result);
}
```

### Response DTO

```csharp
public class KeHoachThang_VersionsSummaryDto
{
    public int KeHoachThangId { get; set; }
    public string TuThangDisplay { get; set; } = string.Empty;
    public string DenThangDisplay { get; set; } = string.Empty;
    
    // Snapshot counts
    public int DuAnThuTienCount { get; set; }
    public int DuAnXuatHoaDonCount { get; set; }
    public int HopDongThuTienCount { get; set; }
    public int HopDongXuatHoaDonCount { get; set; }
    public int HopDongChiPhiCount { get; set; }
    
    public int TotalRecords { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
```

## Implementation Steps

1. Open `KeHoachThangController.cs`
2. Add `[HttpPost("chot/{id}")]` endpoint
3. Inject Mediator and call KeHoachThangChotCommand
4. Return Ok with summary DTO
5. Add proper documentation comments

## Todo List

- [ ] Add Chot endpoint to KeHoachThangController
- [ ] Add response type attributes
- [ ] Add XML documentation comment

## Success Criteria

- Endpoint accessible at `/ke-hoach-thang/chot/{id}`
- Returns 200 with summary DTO on success
- Returns 400/404 for invalid requests
- Swagger documentation generated

## Next Steps

After API endpoint added → Phase 05: Migration