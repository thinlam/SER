# Phase 04: API Models & Controller

## Context

- Base controller: `QLDA.WebApi.Controllers.AggregateRootController`
- Reference: `QLDA.WebApi.Controllers.DanhMucGiaiDoanController.cs`
- Models location: `QLDA.WebApi/Models/DanhMucTinhTrangThucHienLcnts/`

## Overview

**Priority:** High
**Status:** Completed

Create API models and controller for HTTP endpoints.

## Implementation Steps

### 1. Create Model

**File:** `QLDA.WebApi/Models/DanhMucTinhTrangThucHienLcnts/DanhMucTinhTrangThucHienLcntModel.cs`

```csharp
namespace QLDA.WebApi.Models.DanhMucTinhTrangThucHienLcnts;

public class DanhMucTinhTrangThucHienLcntModel : DanhMucModel
{
    // Inherits all properties from DanhMucModel:
    // - Id, Ma, Ten, MoTa, Stt, Used
}
```

### 2. Create Mapping Configuration

**File:** `QLDA.WebApi/Models/DanhMucTinhTrangThucHienLcnts/DanhMucTinhTrangThucHienLcntMappingConfiguration.cs`

```csharp
namespace QLDA.WebApi.Models.DanhMucTinhTrangThucHienLcnts;

public static class DanhMucTinhTrangThucHienLcntMappingConfiguration
{
    public static DanhMucTinhTrangThucHienLcntModel ToModel(this DanhMucTinhTrangThucHienLcnt entity)
        => new()
        {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Stt = entity.Stt,
            Used = entity.Used
        };

    public static DanhMucTinhTrangThucHienLcnt ToEntity(this DanhMucTinhTrangThucHienLcntModel model)
        => new()
        {
            Id = model.GetId(),
            Ma = model.Ma,
            Ten = model.Ten,
            MoTa = model.MoTa,
            Stt = model.Stt,
            Used = model.Used
        };
}
```

### 3. Create Controller

**File:** `QLDA.WebApi/Controllers/DanhMucTinhTrangThucHienLcntController.cs`

```csharp
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLDA.Domain.Constants;
using QLDA.WebApi.Models.DanhMucTinhTrangThucHienLcnts;

namespace QLDA.WebApi.Controllers;

[Tags("Danh mục tình trạng thực hiện LCNT")]
[Route("api/danh-muc-tinh-trang-thuc-hien-lcnt")]
[Authorize(Roles = RoleConstants.GroupAdminOrManager)]
public class DanhMucTinhTrangThucHienLcntController(IServiceProvider serviceProvider)
    : AggregateRootController(serviceProvider)
{
    [ProducesResponseType<ResultApi<DanhMucTinhTrangThucHienLcntModel>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
    [HttpGet("{id}")]
    public async Task<ResultApi> Get(int id)
    {
        var entity = await Mediator.Send(new DanhMucGetQuery
        {
            DanhMuc = EDanhMuc.DanhMucTinhTrangThucHienLcnt,
            Id = id.ToString(),
            ThrowIfNull = true,
        }) as DanhMucTinhTrangThucHienLcnt;
        var model = entity!.ToModel();

        return ResultApi.Ok(model);
    }

    [ProducesResponseType<ResultApi<PaginatedList<DanhMucDto<int>>>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
    [HttpGet("danh-sach")]
    public async Task<ResultApi> GetAll([FromQuery] PaginationRecord req, string? globalFilter)
    {
        var res = await Mediator.Send(new DanhMucGetDanhSachQuery
        {
            DanhMuc = EDanhMuc.DanhMucTinhTrangThucHienLcnt,
            GlobalFilter = globalFilter,
            PageIndex = req.PageIndex,
            PageSize = req.PageSize,
            GetAll = true
        });
        return ResultApi.Ok(res);
    }

    [ProducesResponseType<ResultApi<List<DanhMucDto<int>>>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
    [HttpGet("combobox")]
    public async Task<ResultApi> Get(string? globalFilter = null, [FromQuery] List<long>? ids = null, bool getAll = false)
    {
        var res = await Mediator.Send(new DanhMucGetDanhSachQuery
        {
            GlobalFilter = globalFilter,
            DanhMuc = EDanhMuc.DanhMucTinhTrangThucHienLcnt,
            PageIndex = 0,
            PageSize = 0,
            Ids = ids,
            GetAll = getAll,
        }) as PaginatedList<DanhMucDto<int>>;
        return ResultApi.Ok(res == null ? [] : res.Data);
    }

    [ProducesResponseType<ResultApi<int>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
    [HttpPost("them-moi")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<ResultApi> Create([FromBody] DanhMucTinhTrangThucHienLcntModel model)
    {
        var entity = model.ToEntity();
        await Mediator.Send(new DanhMucInsertOrUpdateCommand(entity, EDanhMuc.DanhMucTinhTrangThucHienLcnt));
        return ResultApi.Ok(1);
    }

    [ProducesResponseType<ResultApi<DanhMucTinhTrangThucHienLcntModel>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
    [HttpPut("cap-nhat")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<ResultApi> Update([FromBody] DanhMucTinhTrangThucHienLcntModel model)
    {
        var entity = await Mediator.Send(new DanhMucGetQuery
        {
            Id = model.GetId().ToString(),
            ThrowIfNull = true,
            DanhMuc = EDanhMuc.DanhMucTinhTrangThucHienLcnt
        }) as DanhMucTinhTrangThucHienLcnt;

        entity!.Ma = model.Ma;
        entity.Ten = model.Ten;
        entity.MoTa = model.MoTa;
        entity.Stt = model.Stt;
        entity.Used = model.Used;

        await Mediator.Send(new DanhMucInsertOrUpdateCommand(entity, EDanhMuc.DanhMucTinhTrangThucHienLcnt));
        return ResultApi.Ok(model);
    }

    [ProducesResponseType<ResultApi<DanhMucTinhTrangThucHienLcnt>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
    [HttpDelete("xoa-tam")]
    public async Task<ResultApi> SoftDelete(int id)
    {
        var entity = await Mediator.Send(new DanhMucGetQuery
        {
            Id = id.ToString(),
            DanhMuc = EDanhMuc.DanhMucTinhTrangThucHienLcnt,
            ThrowIfNull = true
        }) as DanhMucTinhTrangThucHienLcnt;
        entity!.IsDeleted = true;
        await Mediator.Send(new DanhMucInsertOrUpdateCommand(entity, EDanhMuc.DanhMucTinhTrangThucHienLcnt));
        return ResultApi.Ok(entity);
    }
}
```

## Success Criteria

- Controller compiles
- All endpoints defined (GET, POST, PUT, DELETE)
- Uses kebab-case route: `danh-muc-tinh-trang-thuc-hien-lcnt`
- Authorization applied

## Files to Create

- `QLDA.WebApi/Models/DanhMucTinhTrangThucHienLcnts/DanhMucTinhTrangThucHienLcntModel.cs`
- `QLDA.WebApi/Models/DanhMucTinhTrangThucHienLcnts/DanhMucTinhTrangThucHienLcntMappingConfiguration.cs`
- `QLDA.WebApi/Controllers/DanhMucTinhTrangThucHienLcntController.cs`
