using QLHD.Application.CongViecs.DTOs;

namespace QLHD.Application.CongViecs.Commands;

public record CongViecInsertCommand(CongViecInsertModel Model) : IRequest<CongViec>;

internal class CongViecInsertCommandHandler : IRequestHandler<CongViecInsertCommand, CongViec> {
    private readonly IRepository<CongViec, Guid> _repository;
    private readonly IRepository<DanhMucTrangThai, int> _trangThaiRepository;
    private readonly IRepository<DmDonVi, long> _dmDonViRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CongViecInsertCommandHandler(IServiceProvider serviceProvider) {
        _repository = serviceProvider.GetRequiredService<IRepository<CongViec, Guid>>();
        _trangThaiRepository = serviceProvider.GetRequiredService<IRepository<DanhMucTrangThai, int>>();
        _dmDonViRepository = serviceProvider.GetRequiredService<IRepository<DmDonVi, long>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<CongViec> Handle(CongViecInsertCommand request, CancellationToken cancellationToken = default) {
        if (_unitOfWork.HasTransaction) {
            return await InsertAsync(request, cancellationToken);
        }

        using var tx = await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        var entity = await InsertAsync(request, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync(cancellationToken);
        return entity;
    }

    private async Task<CongViec> InsertAsync(CongViecInsertCommand request, CancellationToken cancellationToken) {
        var tenTrangThai = await GetTenTrangThaiAsync(request.Model.TrangThaiId, cancellationToken);
        var (tenDonVi, tenPhongBan) = await GetDonViInfoAsync(request.Model.DonViId, request.Model.PhongBanId, cancellationToken);

        var entity = request.Model.ToEntity(tenTrangThai, tenDonVi, tenPhongBan);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity;
    }

    private async Task<string> GetTenTrangThaiAsync(int trangThaiId, CancellationToken cancellationToken) {
        var trangThai = await _trangThaiRepository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == trangThaiId, cancellationToken);
        return trangThai!.Ten ?? string.Empty;
    }

    private async Task<(string TenDonVi, string? TenPhongBan)> GetDonViInfoAsync(long donViId, long? phongBanId, CancellationToken cancellationToken) {
        var donViIds = new List<long> { donViId };
        if (phongBanId.HasValue)
            donViIds.Add(phongBanId.Value);

        var donViDict = await _dmDonViRepository.GetQueryableSet()
            .Where(d => donViIds.Contains(d.Id))
            .ToDictionaryAsync(d => d.Id, d => d.TenDonVi ?? string.Empty, cancellationToken);

        var tenDonVi = donViDict.GetValueOrDefault(donViId);
        var tenPhongBan = phongBanId.HasValue ? donViDict.GetValueOrDefault(phongBanId.Value) : null;

        return (tenDonVi ?? string.Empty, tenPhongBan ?? string.Empty);
    }
}