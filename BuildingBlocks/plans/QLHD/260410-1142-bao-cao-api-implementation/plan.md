---
title: "QLHD BaoCaoController Implementation"
description: "Create BaoCaoController with ke-hoach-kinh-doanh-nam API endpoint"
status: completed
priority: P2
effort: 8h
branch: ChuyenDoiSo
tags: [qlhd, bao-cao, api, danh-muc]
created: 2026-04-10
completed: 2026-04-10
---

# QLHD BaoCaoController Implementation Plan

## Overview
Implement BaoCaoController with first API endpoint: `api/bao-cao/ke-hoach-kinh-doanh-nam` and create supporting DanhMucLoaiLai entity with CRUD functionality.

## Key Components

### 1. DanhMucLoaiLai Entity + CRUD
- Create DanhMucLoaiLai entity inheriting from DanhMuc<int>
- Standard CRUD operations following existing DanhMuc patterns
- Configuration with proper indexing

### 2. LoaiBaoCaoConstants
- Define report type constants (TongHop, ChiTiet)

### 3. BaoCaoController + Report Endpoint
- Create BaoCaoController
- Implement ke-hoach-kinh-doanh-nam report endpoint
- Request validation and processing

## Detailed Architecture

### Data Flow Diagram
```
Client Request -> BaoCaoController -> KeHoachKinhDoanhNamReportQuery -> Handler -> Business Logic -> Result
Client Request -> DanhMucLoaiLaiController -> CRUD Operations -> Repository -> Database
```

### Component Interactions
- **Controller Layer**: BaoCaoController, DanhMucLoaiLaiController
- **Application Layer**: Queries, Commands, Handlers, DTOs, Validators
- **Domain Layer**: Entities, Constants
- **Persistence Layer**: Configurations, Repositories

## Implementation Phases

### Phase 1: Domain Layer Setup (1 hour)
#### Files to Create
- `modules/QLHD/QLHD.Domain/Entities/DanhMuc/DanhMucLoaiLai.cs`
- `modules/QLHD/QLHD.Domain/Constants/LoaiBaoCaoConstants.cs`

#### Implementation Details

**DanhMucLoaiLai.cs**:
```csharp
namespace QLHD.Domain.Entities.DanhMuc;

/// <summary>
/// Danh mục loại lãi
/// </summary>
public class DanhMucLoaiLai : DanhMuc<int>, IAggregateRoot
{
    /// <summary>
    /// Loại mặc định
    /// </summary>
    public bool IsDefault { get; set; }
}
```

**LoaiBaoCaoConstants.cs**:
```csharp
namespace QLHD.Domain.Constants;

/// <summary>
/// Constants for report types - Loại báo cáo
/// </summary>
public static class LoaiBaoCaoConstants
{
    /// <summary>
    /// Báo cáo tổng hợp (Summary report)
    /// </summary>
    public const string TongHop = "TONGHOP";

    /// <summary>
    /// Báo cáo chi tiết (Detail report)
    /// </summary>
    public const string ChiTiet = "CHITIET";

    /// <summary>
    /// Display names for UI
    /// </summary>
    public static readonly string[] All = [TongHop, ChiTiet];
}
```

### Phase 2: Persistence Layer Setup (1 hour)
#### Files to Create
- `modules/QLHD/QLHD.Persistence/Configurations/DanhMuc/DanhMucLoaiLaiConfiguration.cs`

#### Implementation Details

**DanhMucLoaiLaiConfiguration.cs**:
```csharp
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLHD.Domain.Entities.DanhMuc;
using BuildingBlocks.Persistence.Configurations;

namespace QLHD.Persistence.Configurations.DanhMuc;

public class DanhMucLoaiLaiConfiguration : AggregateRootConfiguration<DanhMucLoaiLai>
{
    public override void Configure(EntityTypeBuilder<DanhMucLoaiLai> builder)
    {
        builder.ToTable("DanhMucLoaiLai");
        builder.ConfigureForDanhMuc(); // Handles Id, Ma, Ten, MoTa, Used, audit fields

        // Custom properties use column orders 5-19
        builder.Property(e => e.IsDefault)
            .HasColumnOrder(5)
            .HasDefaultValue(false);

        // Ensure only one IsDefault per table
        builder.HasIndex(e => e.IsDefault)
            .HasFilter("[IsDefault] = 1")
            .IsUnique();
    }
}
```

### Phase 3: Application Layer - DTOs and Models (1.5 hours)
#### Files to Create
- `modules/QLHD/QLHD.Application/DanhMucLoaiLais/DTOs/DanhMucLoaiLaiDto.cs`
- `modules/QLHD/QLHD.Application/DanhMucLoaiLais/DTOs/DanhMucLoaiLaiInsertModel.cs`
- `modules/QLHD/QLHD.Application/DanhMucLoaiLais/DTOs/DanhMucLoaiLaiUpdateModel.cs`
- `modules/QLHD/QLHD.Application/DanhMucLoaiLais/DTOs/DanhMucLoaiLaiMapping.cs`
- `modules/QLHD/QLHD.Application/DanhMucLoaiLais/DTOs/DanhMucLoaiLaiSearchModel.cs`

#### Implementation Details

**DanhMucLoaiLaiDto.cs**:
```csharp
namespace QLHD.Application.DanhMucLoaiLais.DTOs;

public class DanhMucLoaiLaiDto : IHasKey<int>
{
    public int Id { get; set; }
    public string? Ma { get; set; }
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public bool Used { get; set; }
    public bool IsDefault { get; set; }
}
```

**DanhMucLoaiLaiInsertModel.cs**:
```csharp
namespace QLHD.Application.DanhMucLoaiLais.DTOs;

public class DanhMucLoaiLaiInsertModel
{
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public bool Used { get; set; } = true;
    public bool IsDefault { get; set; }
}
```

**DanhMucLoaiLaiUpdateModel.cs**:
```csharp
namespace QLHD.Application.DanhMucLoaiLais.DTOs;

public class DanhMucLoaiLaiUpdateModel
{
    public string? Ma { get; set; }
    public string? Ten { get; set; }
    public string? MoTa { get; set; }
    public bool Used { get; set; }
    public bool IsDefault { get; set; }
}
```

**DanhMucLoaiLaiMapping.cs**:
```csharp
using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Application.DanhMucLoaiLais.DTOs;

public static class DanhMucLoaiLaiMapping
{
    public static DanhMucLoaiLai ToEntity(this DanhMucLoaiLaiInsertModel model) => new()
    {
        Ten = model.Ten,
        MoTa = model.MoTa,
        Used = model.Used,
        IsDefault = model.IsDefault
    };

    public static void UpdateFrom(this DanhMucLoaiLai entity, DanhMucLoaiLaiUpdateModel model)
    {
        entity.Ma = model.Ma;
        entity.Ten = model.Ten;
        entity.MoTa = model.MoTa;
        entity.Used = model.Used;
        entity.IsDefault = model.IsDefault;
    }

    public static DanhMucLoaiLaiDto ToDto(this DanhMucLoaiLai entity) => new()
    {
        Id = entity.Id,
        Ma = entity.Ma,
        Ten = entity.Ten,
        MoTa = entity.MoTa,
        Used = entity.Used,
        IsDefault = entity.IsDefault
    };
}
```

**DanhMucLoaiLaiSearchModel.cs**:
```csharp
using BuildingBlocks.Application.Common.DTOs;

namespace QLHD.Application.DanhMucLoaiLais.DTOs;

public class DanhMucLoaiLaiSearchModel : PagedSearchModel
{
    public string? Keyword { get; set; }
    public bool? Used { get; set; }
}
```

### Phase 4: Application Layer - Commands and Queries (1.5 hours)
#### Files to Create
- `modules/QLHD/QLHD.Application/DanhMucLoaiLais/Commands/DanhMucLoaiLaiInsertCommand.cs`
- `modules/QLHD/QLHD.Application/DanhMucLoaiLais/Commands/DanhMucLoaiLaiUpdateCommand.cs`
- `modules/QLHD/QLHD.Application/DanhMucLoaiLais/Commands/DanhMucLoaiLaiDeleteCommand.cs`
- `modules/QLHD/QLHD.Application/DanhMucLoaiLais/Queries/DanhMucLoaiLaiGetListQuery.cs`
- `modules/QLHD/QLHD.Application/DanhMucLoaiLais/Queries/DanhMucLoaiLaiGetByIdQuery.cs`
- `modules/QLHD/QLHD.Application/DanhMucLoaiLais/Queries/DanhMucLoaiLaiGetComboboxQuery.cs`

#### Implementation Details

**DanhMucLoaiLaiInsertCommand.cs** (follow DanhMucLoaiHopDongInsertCommand pattern):
```csharp
using MediatR;
using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Application.DanhMucLoaiLais.Commands;

public record DanhMucLoaiLaiInsertCommand(DanhMucLoaiLaiInsertModel Model) : IRequest<DanhMucLoaiLai>;

internal class DanhMucLoaiLaiInsertCommandHandler : IRequestHandler<DanhMucLoaiLaiInsertCommand, DanhMucLoaiLai>
{
    private readonly IRepository<DanhMucLoaiLai, int> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private const string MaPrefix = "LL";
    private const int MaNumberLength = 4;

    public DanhMucLoaiLaiInsertCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiLai, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<DanhMucLoaiLai> Handle(DanhMucLoaiLaiInsertCommand request, CancellationToken cancellationToken = default)
    {
        if (_unitOfWork.HasTransaction)
        {
            return await InsertAsync(request, cancellationToken);
        }

        using var tx = await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        var entity = await InsertAsync(request, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync(cancellationToken);
        return entity;
    }

    private async Task<DanhMucLoaiLai> InsertAsync(DanhMucLoaiLaiInsertCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Model.ToEntity();

        // Generate Ma if not provided
        if (string.IsNullOrEmpty(entity.Ma))
        {
            entity.Ma = await GenerateMaAsync(cancellationToken);
        }

        // If setting IsDefault to true, reset all others to false first
        if (entity.IsDefault)
        {
            await ResetIsDefaultAsync(cancellationToken);
        }

        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity;
    }

    private async Task ResetIsDefaultAsync(CancellationToken cancellationToken)
    {
        var defaultEntities = await _repository.GetQueryableSet()
            .Where(e => e.IsDefault)
            .ToListAsync(cancellationToken);

        foreach (var d in defaultEntities)
        {
            d.IsDefault = false;
        }
    }

    private async Task<string> GenerateMaAsync(CancellationToken cancellationToken)
    {
        var maxMa = await _repository.GetOriginalSet()
            .Where(x => x.Ma != null && x.Ma.StartsWith(MaPrefix))
            .MaxAsync(x => x.Ma, cancellationToken);

        var nextNumber = 1;
        if (!string.IsNullOrEmpty(maxMa))
        {
            var numberPart = maxMa.Substring(MaPrefix.Length);
            if (int.TryParse(numberPart, out var currentMax))
            {
                nextNumber = currentMax + 1;
            }
        }

        return $"{MaPrefix}{nextNumber.ToString().PadLeft(MaNumberLength, '0')}";
    }
}
```

**DanhMucLoaiLaiUpdateCommand.cs**:
```csharp
using MediatR;
using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Application.DanhMucLoaiLais.Commands;

public record DanhMucLoaiLaiUpdateCommand(int Id, DanhMucLoaiLaiUpdateModel Model) : IRequest<DanhMucLoaiLai>;

internal class DanhMucLoaiLaiUpdateCommandHandler : IRequestHandler<DanhMucLoaiLaiUpdateCommand, DanhMucLoaiLai>
{
    private readonly IRepository<DanhMucLoaiLai, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucLoaiLaiUpdateCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiLai, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<DanhMucLoaiLai> Handle(DanhMucLoaiLaiUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        ManagedException.ThrowIfNull(entity, "Không tìm thấy bản ghi");

        // If setting IsDefault to true, reset all others to false first
        if (request.Model.IsDefault && !entity.IsDefault)
        {
            await ResetIsDefaultAsync(cancellationToken);
        }

        entity.UpdateFrom(request.Model);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity;
    }

    private async Task ResetIsDefaultAsync(CancellationToken cancellationToken)
    {
        var defaultEntities = await _repository.GetQueryableSet()
            .Where(e => e.IsDefault)
            .ToListAsync(cancellationToken);

        foreach (var d in defaultEntities)
        {
            d.IsDefault = false;
        }
    }
}
```

**DanhMucLoaiLaiDeleteCommand.cs**:
```csharp
using MediatR;
using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Application.DanhMucLoaiLais.Commands;

public record DanhMucLoaiLaiDeleteCommand(int Id) : IRequest<Unit>;

internal class DanhMucLoaiLaiDeleteCommandHandler : IRequestHandler<DanhMucLoaiLaiDeleteCommand, Unit>
{
    private readonly IRepository<DanhMucLoaiLai, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucLoaiLaiDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiLai, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<Unit> Handle(DanhMucLoaiLaiDeleteCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
```

**DanhMucLoaiLaiGetListQuery.cs**:
```csharp
using MediatR;
using BuildingBlocks.Application.Common.DTOs;
using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Application.DanhMucLoaiLais.Queries;

public record DanhMucLoaiLaiGetListQuery(DanhMucLoaiLaiSearchModel SearchModel) : IRequest<PaginatedList<DanhMucLoaiLaiDto>>;

internal class DanhMucLoaiLaiGetListQueryHandler : IRequestHandler<DanhMucLoaiLaiGetListQuery, PaginatedList<DanhMucLoaiLaiDto>>
{
    private readonly IRepository<DanhMucLoaiLai, int> _repository;

    public DanhMucLoaiLaiGetListQueryHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiLai, int>>();
    }

    public async Task<PaginatedList<DanhMucLoaiLaiDto>> Handle(DanhMucLoaiLaiGetListQuery request, CancellationToken cancellationToken)
    {
        var query = _repository.GetQueryableSet();

        // Apply filters
        if (!string.IsNullOrEmpty(request.SearchModel.Keyword))
        {
            query = query.Where(e => e.Ma!.Contains(request.SearchModel.Keyword) || e.Ten!.Contains(request.SearchModel.Keyword));
        }

        if (request.SearchModel.Used.HasValue)
        {
            query = query.Where(e => e.Used == request.SearchModel.Used.Value);
        }

        // Project to DTO
        var dtoQuery = query.Select(e => e.ToDto());

        return await PaginatedList<DanhMucLoaiLaiDto>.CreateAsync(dtoQuery, request.SearchModel.PageNumber, request.SearchModel.PageSize);
    }
}
```

**DanhMucLoaiLaiGetByIdQuery.cs**:
```csharp
using MediatR;
using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Application.DanhMucLoaiLais.Queries;

public record DanhMucLoaiLaiGetByIdQuery(int Id) : IRequest<DanhMucLoaiLaiDto>;

internal class DanhMucLoaiLaiGetByIdQueryHandler : IRequestHandler<DanhMucLoaiLaiGetByIdQuery, DanhMucLoaiLaiDto>
{
    private readonly IRepository<DanhMucLoaiLai, int> _repository;

    public DanhMucLoaiLaiGetByIdQueryHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiLai, int>>();
    }

    public async Task<DanhMucLoaiLaiDto> Handle(DanhMucLoaiLaiGetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        ManagedException.ThrowIfNull(entity, "Không tìm thấy bản ghi");
        return entity.ToDto();
    }
}
```

**DanhMucLoaiLaiGetComboboxQuery.cs**:
```csharp
using MediatR;
using BuildingBlocks.Application.Common.DTOs;
using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Application.DanhMucLoaiLais.Queries;

public record DanhMucLoaiLaiGetComboboxQuery : IRequest<List<ComboBoxDto<int>>>;

internal class DanhMucLoaiLaiGetComboboxQueryHandler : IRequestHandler<DanhMucLoaiLaiGetComboboxQuery, List<ComboBoxDto<int>>>
{
    private readonly IRepository<DanhMucLoaiLai, int> _repository;

    public DanhMucLoaiLaiGetComboboxQueryHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiLai, int>>();
    }

    public async Task<List<ComboBoxDto<int>>> Handle(DanhMucLoaiLaiGetComboboxQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetQueryableSet()
            .Select(e => new ComboBoxDto<int> { Value = e.Id, Label = e.Ten ?? string.Empty })
            .ToListAsync(cancellationToken);
    }
}
```

### Phase 5: Application Layer - Validators (1 hour)
#### Files to Create
- `modules/QLHD/QLHD.Application/DanhMucLoaiLais/Validators/DanhMucLoaiLaiInsertCommandValidator.cs`
- `modules/QLHD/QLHD.Application/DanhMucLoaiLais/Validators/DanhMucLoaiLaiUpdateCommandValidator.cs`

#### Implementation Details

**DanhMucLoaiLaiInsertCommandValidator.cs**:
```csharp
using FluentValidation;

namespace QLHD.Application.DanhMucLoaiLais.Validators;

public class DanhMucLoaiLaiInsertCommandValidator : AbstractValidator<DanhMucLoaiLaiInsertCommand>
{
    public DanhMucLoaiLaiInsertCommandValidator()
    {
        RuleFor(x => x.Model.Ten)
            .NotEmpty().WithMessage("Tên loại lãi là bắt buộc")
            .MaximumLength(500).WithMessage("Tên loại lãi không được vượt quá 500 ký tự");

        RuleFor(x => x.Model.MoTa)
            .MaximumLength(2000).WithMessage("Mô tả không được vượt quá 2000 ký tự");
    }
}
```

**DanhMucLoaiLaiUpdateCommandValidator.cs**:
```csharp
using FluentValidation;

namespace QLHD.Application.DanhMucLoaiLais.Validators;

public class DanhMucLoaiLaiUpdateCommandValidator : AbstractValidator<DanhMucLoaiLaiUpdateCommand>
{
    public DanhMucLoaiLaiUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("ID phải lớn hơn 0");

        RuleFor(x => x.Model.Ten)
            .NotEmpty().WithMessage("Tên loại lãi là bắt buộc")
            .MaximumLength(500).WithMessage("Tên loại lãi không được vượt quá 500 ký tự");

        RuleFor(x => x.Model.MoTa)
            .MaximumLength(2000).WithMessage("Mô tả không được vượt quá 2000 ký tự");
    }
}
```

### Phase 6: Web API Layer - Controllers (1 hour)
#### Files to Create
- `modules/QLHD/QLHD.WebApi/Controllers/DanhMucLoaiLaiController.cs`
- `modules/QLHD/QLHD.WebApi/Controllers/BaoCaoController.cs`

#### Implementation Details

**DanhMucLoaiLaiController.cs**:
```csharp
using QLHD.Application.DanhMucLoaiLais.Commands;
using QLHD.Application.DanhMucLoaiLais.DTOs;
using QLHD.Application.DanhMucLoaiLais.Queries;

namespace QLHD.WebApi.Controllers;

[Tags("Danh mục loại lãi (danh-muc-loai-lai)")]
public class DanhMucLoaiLaiController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    [HttpPost("danh-muc-loai-lai/them-moi")]
    [ProducesResponseType<ResultApi<DanhMucLoaiLaiDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Create(
        [FromBody] DanhMucLoaiLaiInsertModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new DanhMucLoaiLaiInsertCommand(model), cancellationToken);
        return ResultApi.Ok(entity.ToDto());
    }

    [HttpPut("danh-muc-loai-lai/cap-nhat/{id}")]
    [ProducesResponseType<ResultApi<DanhMucLoaiLaiDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Update(
        int id,
        [FromBody] DanhMucLoaiLaiUpdateModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Mediator.Send(new DanhMucLoaiLaiUpdateCommand(id, model), cancellationToken);
        return ResultApi.Ok(entity.ToDto());
    }

    [HttpGet("danh-muc-loai-lai/danh-sach")]
    [ProducesResponseType<ResultApi<PaginatedList<DanhMucLoaiLaiDto>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetList([FromQuery] DanhMucLoaiLaiSearchModel searchModel)
    {
        var result = await Mediator.Send(new DanhMucLoaiLaiGetListQuery(searchModel));
        return ResultApi.Ok(result);
    }

    [HttpGet("danh-muc-loai-lai/chi-tiet/{id}")]
    [ProducesResponseType<ResultApi<DanhMucLoaiLaiDto>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetById(int id)
    {
        var result = await Mediator.Send(new DanhMucLoaiLaiGetByIdQuery(id));
        return ResultApi.Ok(result);
    }

    [HttpGet("danh-muc-loai-lai/combobox")]
    [ProducesResponseType<ResultApi<List<ComboBoxDto<int>>>>(StatusCodes.Status200OK)]
    public async Task<ResultApi> GetCombobox()
    {
        var result = await Mediator.Send(new DanhMucLoaiLaiGetComboboxQuery());
        return ResultApi.Ok(result);
    }

    [HttpDelete("danh-muc-loai-lai/xoa/{id}")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> Delete(int id)
    {
        await Mediator.Send(new DanhMucLoaiLaiDeleteCommand(id));
        return ResultApi.Ok();
    }
}
```

**BaoCaoController.cs**:
```csharp
using QLHD.Application.BaoCaos.Queries;
using BuildingBlocks.Domain.ValueTypes;
using System.ComponentModel;

namespace QLHD.WebApi.Controllers;

[Tags("Báo cáo (bao-cao)")]
public class BaoCaoController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider)
{
    [HttpPost("bao-cao/ke-hoach-kinh-doanh-nam")]
    [ProducesResponseType<ResultApi>(StatusCodes.Status200OK)]
    public async Task<ResultApi> KeHoachKinhDoanhNam(
        [FromBody] KeHoachKinhDoanhNamReportQuery query,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(query, cancellationToken);
        return ResultApi.Ok(result);
    }
}
```

### Phase 7: Application Layer - Report Query Implementation (1 hour)
#### Files to Create
- `modules/QLHD/QLHD.Application/BaoCaos/Queries/KeHoachKinhDoanhNamReportQuery.cs`
- `modules/QLHD/QLHD.Application/BaoCaos/Queries/KeHoachKinhDoanhNamReportQueryValidator.cs`

#### Implementation Details

**KeHoachKinhDoanhNamReportQuery.cs**:
```csharp
using MediatR;
using BuildingBlocks.Domain.ValueTypes;
using System.ComponentModel;

namespace QLHD.Application.BaoCaos.Queries;

public record KeHoachKinhDoanhNamReportQuery : IRequest<object>
{
    /// <summary>
    /// Từ tháng (required)
    /// </summary>
    public MonthYear TuThang { get; set; }

    /// <summary>
    /// Đến tháng (required)
    /// </summary>
    public MonthYear DenThang { get; set; }

    /// <summary>
    /// Bộ phận (optional)
    /// </summary>
    [Description("Bộ phận")]
    public long? PhongBanPhuTrachChinhId { get; set; }

    /// <summary>
    /// Người phụ trách chính (optional)
    /// </summary>
    public long? NguoiPhuTrachChinhId { get; set; }

    /// <summary>
    /// ID kế hoạch kinh doanh năm (required)
    /// </summary>
    public Guid KeHoachKinhDoanhNamId { get; set; }

    /// <summary>
    /// Loại lãi (optional) - references DanhMucLoaiLai
    /// </summary>
    public int? LoaiLaiId { get; set; }

    /// <summary>
    /// Năm báo cáo (optional)
    /// </summary>
    public int? NamBaoCao { get; set; }

    /// <summary>
    /// Loại báo cáo - determines response DTO type
    /// Use LoaiBaoCaoConstants.TongHop or LoaiBaoCaoConstants.ChiTiet
    /// </summary>
    public string LoaiBaoCao { get; set; } = string.Empty;
}
```

**KeHoachKinhDoanhNamReportQueryValidator.cs**:
```csharp
using FluentValidation;
using QLHD.Domain.Constants;

namespace QLHD.Application.BaoCaos.Queries;

public class KeHoachKinhDoanhNamReportQueryValidator : AbstractValidator<KeHoachKinhDoanhNamReportQuery>
{
    public KeHoachKinhDoanhNamReportQueryValidator()
    {
        RuleFor(x => x.KeHoachKinhDoanhNamId)
            .NotEmpty().WithMessage("ID kế hoạch kinh doanh năm là bắt buộc");

        RuleFor(x => x.LoaiBaoCao)
            .NotEmpty().WithMessage("Loại báo cáo là bắt buộc")
            .Must(type => type == LoaiBaoCaoConstants.TongHop || type == LoaiBaoCaoConstants.ChiTiet)
            .WithMessage($"Loại báo cáo phải là '{LoaiBaoCaoConstants.TongHop}' hoặc '{LoaiBaoCaoConstants.ChiTiet}'");

        // Validate month range: TuThang <= DenThang
        RuleFor(x => x)
            .Must(x => BeValidMonthRange(x.TuThang, x.DenThang))
            .WithMessage("Tháng bắt đầu phải nhỏ hơn hoặc bằng tháng kết thúc");
    }

    private static bool BeValidMonthRange(MonthYear tuThang, MonthYear denThang)
    {
        var tuDate = tuThang.ToDateOnly(1);
        var denDate = denThang.ToDateOnly(1);
        return tuDate <= denDate;
    }
}
```

## Migration Implementation

Since DanhMucLoaiLai is a new entity, create a migration using the QLHD.Migrator project:

```bash
# Scaffold migrations (ALWAYS with dbo schema per CLAUDE.md)
cd modules/QLHD/QLHD.Persistence
ConnectionStrings__Schema=dbo dotnet ef migrations add AddDanhMucLoaiLai \
  --startup-project ../QLHD.Migrator \
  --project ../QLHD.Migrator \
  --output-dir Migrations/dbo
```

## Dependencies
- BuildingBlocks cross-cutting, domain, application, persistence libraries
- MediatR for CQRS pattern
- FluentValidation for input validation
- MonthYear value type from BuildingBlocks.Domain.ValueTypes

## Test Matrix
- Unit tests for all validators
- Integration tests for all CRUD operations of DanhMucLoaiLai
- Integration test for KeHoachKinhDoanhNam report endpoint
- Edge case testing for invalid inputs and missing required fields

## Risk Assessment
- **Medium**: Integration with existing business logic for report generation
- **Low**: CRUD operations for DanhMucLoaiLai (follows existing patterns)

## Backwards Compatibility
- No breaking changes to existing APIs
- New endpoints are additive
- New entity does not affect existing functionality

## Rollback Plan
- Remove new controllers and their routes
- Drop the DanhMucLoaiLai table through migration rollback
- Remove all created files

## Success Criteria
- All new endpoints accessible and functional
- DanhMucLoaiLai CRUD operations work correctly
- KeHoachKinhDoanhNam report endpoint validates input properly
- All tests pass
- Code follows established patterns and conventions
- Migration runs successfully

## Files Summary

### New Files (20 files)

| Layer | File Path | Purpose |
|-------|-----------|---------|
| Domain | `QLHD.Domain/Entities/DanhMuc/DanhMucLoaiLai.cs` | DanhMucLoaiLai entity |
| Domain | `QLHD.Domain/Constants/LoaiBaoCaoConstants.cs` | Report type constants |
| Persistence | `QLHD.Persistence/Configurations/DanhMuc/DanhMucLoaiLaiConfiguration.cs` | EF Core configuration |
| Application | `QLHD.Application/DanhMucLoaiLais/DTOs/DanhMucLoaiLaiDto.cs` | DTO |
| Application | `QLHD.Application/DanhMucLoaiLais/DTOs/DanhMucLoaiLaiInsertModel.cs` | Insert model |
| Application | `QLHD.Application/DanhMucLoaiLais/DTOs/DanhMucLoaiLaiUpdateModel.cs` | Update model |
| Application | `QLHD.Application/DanhMucLoaiLais/DTOs/DanhMucLoaiLaiMapping.cs` | Mapping extensions |
| Application | `QLHD.Application/DanhMucLoaiLais/DTOs/DanhMucLoaiLaiSearchModel.cs` | Search model |
| Application | `QLHD.Application/DanhMucLoaiLais/Commands/DanhMucLoaiLaiInsertCommand.cs` | Insert command + handler |
| Application | `QLHD.Application/DanhMucLoaiLais/Commands/DanhMucLoaiLaiUpdateCommand.cs` | Update command + handler |
| Application | `QLHD.Application/DanhMucLoaiLais/Commands/DanhMucLoaiLaiDeleteCommand.cs` | Delete command + handler |
| Application | `QLHD.Application/DanhMucLoaiLais/Queries/DanhMucLoaiLaiGetListQuery.cs` | Get list query + handler |
| Application | `QLHD.Application/DanhMucLoaiLais/Queries/DanhMucLoaiLaiGetByIdQuery.cs` | Get by ID query + handler |
| Application | `QLHD.Application/DanhMucLoaiLais/Queries/DanhMucLoaiLaiGetComboboxQuery.cs` | Combobox query + handler |
| Application | `QLHD.Application/DanhMucLoaiLais/Validators/DanhMucLoaiLaiInsertCommandValidator.cs` | Insert validator |
| Application | `QLHD.Application/DanhMucLoaiLais/Validators/DanhMucLoaiLaiUpdateCommandValidator.cs` | Update validator |
| WebApi | `QLHD.WebApi/Controllers/DanhMucLoaiLaiController.cs` | DanhMucLoaiLai controller |
| WebApi | `QLHD.WebApi/Controllers/BaoCaoController.cs` | BaoCao controller |
| Application | `QLHD.Application/BaoCaos/Queries/KeHoachKinhDoanhNamReportQuery.cs` | Report query |
| Application | `QLHD.Application/BaoCaos/Queries/KeHoachKinhDoanhNamReportQueryValidator.cs` | Report validator |