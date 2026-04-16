using QLHD.Application.KhachHangs.DTOs;

namespace QLHD.Application.KhachHangs.Commands;

public record KhachHangInsertCommand(KhachHangInsertModel Model) : IRequest<KhachHang>;

internal class KhachHangInsertCommandHandler : IRequestHandler<KhachHangInsertCommand, KhachHang>
{
    private readonly IRepository<KhachHang, Guid> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private const string MaPrefix = "KH";
    private const int MaNumberLength = 5;

    public KhachHangInsertCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<KhachHang, Guid>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<KhachHang> Handle(KhachHangInsertCommand request, CancellationToken cancellationToken = default)
    {
        if (_unitOfWork.HasTransaction)
        {
            return await InsertAsync(request, cancellationToken);
        }

        using var tx = await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);
        var entity = await InsertAsync(request, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync(cancellationToken);
        return entity;
    }

    private async Task<KhachHang> InsertAsync(KhachHangInsertCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Model.ToEntity();

        // Auto-generate Ma
        entity.Ma = await GenerateMaAsync(cancellationToken);

        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity;
    }

    /// <summary>
    /// Generates the next Ma value (KH00001, KH00002, ...)
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