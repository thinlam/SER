using QLHD.Application.CongViecs.DTOs;

namespace QLHD.Application.CongViecs.Commands;

public record CongViecUpdateCommand(Guid Id, CongViecUpdateModel Model) : IRequest<CongViec>;

internal class CongViecUpdateCommandHandler : IRequestHandler<CongViecUpdateCommand, CongViec> {
    private readonly IRepository<CongViec, Guid> _repository;
    private readonly IRepository<DmDonVi, long> _dmDonViRepository;
    private readonly IRepository<DanhMucTrangThai, int> _trangThaiRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CongViecUpdateCommandHandler(IServiceProvider serviceProvider) {
        _repository = serviceProvider.GetRequiredService<IRepository<CongViec, Guid>>();
        _dmDonViRepository = serviceProvider.GetRequiredService<IRepository<DmDonVi, long>>();
        _trangThaiRepository = serviceProvider.GetRequiredService<IRepository<DanhMucTrangThai, int>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<CongViec> Handle(CongViecUpdateCommand request, CancellationToken cancellationToken = default) {
        var entity = (await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken))!;

        var (tenDonVi, tenPhongBan) = await GetDonViInfoAsync(request.Model.DonViId, request.Model.PhongBanId, cancellationToken);
        var tenTrangThai = await GetTenTrangThaiAsync(request.Model.TrangThaiId, cancellationToken);
        entity.UpdateFrom(request.Model, tenTrangThai, tenDonVi, tenPhongBan);

        if (_unitOfWork.HasTransaction) {
            await _repository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity;
        }

        using var tx = await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync(cancellationToken);
        return entity;
    }

    private async Task<(string TenDonVi, string? TenPhongBan)> GetDonViInfoAsync(long donViId, long phongBanId, CancellationToken cancellationToken) {
        var donViIds = new List<long> { donViId, phongBanId }.Distinct().ToList();
        var donViDict = await _dmDonViRepository.GetQueryableSet()
            .Where(d => donViIds.Contains(d.Id))
            .ToDictionaryAsync(d => d.Id, d => d.TenDonVi ?? string.Empty, cancellationToken);

        var tenDonVi = donViDict.GetValueOrDefault(donViId);
        var tenPhongBan = donViDict.GetValueOrDefault(phongBanId);

        return (tenDonVi ?? string.Empty, tenPhongBan ?? string.Empty);
    }

    private async Task<string> GetTenTrangThaiAsync(int trangThaiId, CancellationToken cancellationToken) {
        var trangThai = await _trangThaiRepository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == trangThaiId, cancellationToken);
        return trangThai!.Ten ?? string.Empty;
    }
}