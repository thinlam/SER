using QLHD.Application.DanhMucLoaiChiPhis.DTOs;

namespace QLHD.Application.DanhMucLoaiChiPhis.Commands;

public record DanhMucLoaiChiPhiInsertCommand(DanhMucLoaiChiPhiInsertModel Model) : IRequest<DanhMucLoaiChiPhi>;

internal class DanhMucLoaiChiPhiInsertCommandHandler : IRequestHandler<DanhMucLoaiChiPhiInsertCommand, DanhMucLoaiChiPhi>
{
    private readonly IRepository<DanhMucLoaiChiPhi, int> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private const string MaPrefix = "LCP";
    private const int MaNumberLength = 4;

    public DanhMucLoaiChiPhiInsertCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiChiPhi, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<DanhMucLoaiChiPhi> Handle(DanhMucLoaiChiPhiInsertCommand request, CancellationToken cancellationToken = default)
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

    private async Task<DanhMucLoaiChiPhi> InsertAsync(DanhMucLoaiChiPhiInsertCommand request, CancellationToken cancellationToken)
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
    /// Generates the next Ma value (LCP0001, LCP0002, ...)
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