using QLHD.Application.DanhMucLoaiThanhToans.DTOs;

namespace QLHD.Application.DanhMucLoaiThanhToans.Commands;

public record DanhMucLoaiThanhToanInsertCommand(DanhMucLoaiThanhToanInsertModel Model) : IRequest<DanhMucLoaiThanhToan>;

internal class DanhMucLoaiThanhToanInsertCommandHandler : IRequestHandler<DanhMucLoaiThanhToanInsertCommand, DanhMucLoaiThanhToan>
{
    private readonly IRepository<DanhMucLoaiThanhToan, int> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private const string MaPrefix = "LTT";
    private const int MaNumberLength = 4;

    public DanhMucLoaiThanhToanInsertCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiThanhToan, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<DanhMucLoaiThanhToan> Handle(DanhMucLoaiThanhToanInsertCommand request, CancellationToken cancellationToken = default)
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

    private async Task<DanhMucLoaiThanhToan> InsertAsync(DanhMucLoaiThanhToanInsertCommand request, CancellationToken cancellationToken)
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

    /// <summary>
    /// Generates the next Ma value (LTT0001, LTT0002, ...)
    /// </summary>
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