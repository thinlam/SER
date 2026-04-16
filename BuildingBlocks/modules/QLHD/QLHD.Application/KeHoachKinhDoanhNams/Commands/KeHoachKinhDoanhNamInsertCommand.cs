using QLHD.Application.KeHoachKinhDoanhNams.DTOs;

namespace QLHD.Application.KeHoachKinhDoanhNams.Commands;

public record KeHoachKinhDoanhNamInsertCommand(KeHoachKinhDoanhNamInsertModel Model) : IRequest<KeHoachKinhDoanhNam>;

internal class KeHoachKinhDoanhNamInsertCommandHandler : IRequestHandler<KeHoachKinhDoanhNamInsertCommand, KeHoachKinhDoanhNam>
{
    private readonly IRepository<KeHoachKinhDoanhNam, Guid> _repository;
    private readonly IRepository<DmDonVi, long> _dmDonViRepository;
    private readonly IRepository<UserMaster, long> _userMasterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public KeHoachKinhDoanhNamInsertCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<KeHoachKinhDoanhNam, Guid>>();
        _dmDonViRepository = serviceProvider.GetRequiredService<IRepository<DmDonVi, long>>();
        _userMasterRepository = serviceProvider.GetRequiredService<IRepository<UserMaster, long>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<KeHoachKinhDoanhNam> Handle(KeHoachKinhDoanhNamInsertCommand request, CancellationToken cancellationToken = default)
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

    private async Task<KeHoachKinhDoanhNam> InsertAsync(KeHoachKinhDoanhNamInsertCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Model.ToEntity();

        // Add BoPhan child collections with Ten from DmDonVi
        if (request.Model.BoPhans != null && request.Model.BoPhans.Count > 0)
        {
            var donViIds = request.Model.BoPhans.Select(b => b.DonViId).Distinct().ToList();
            var donViDict = await _dmDonViRepository.GetQueryableSet()
                .Where(d => donViIds.Contains(d.Id))
                .ToDictionaryAsync(d => d.Id, d => d.TenDonVi ?? string.Empty, cancellationToken);

            entity.KeHoachKinhDoanhNam_BoPhans = [.. request.Model.BoPhans
                .Select(b => b.ToEntity(entity.Id, donViDict.GetValueOrDefault(b.DonViId, string.Empty)))];
        }

        // Add CaNhan child collections with Ten from UserMaster
        if (request.Model.CaNhans != null && request.Model.CaNhans.Count > 0)
        {
            var userIds = request.Model.CaNhans.Select(c => c.UserPortalId).Distinct().ToList();
            var userDict = await _userMasterRepository.GetQueryableSet()
                .Where(u => userIds.Contains(u.Id))
                .ToDictionaryAsync(u => u.Id, u => u.HoTen ?? string.Empty, cancellationToken);

            entity.KeHoachKinhDoanhNam_CaNhans = [.. request.Model.CaNhans
                .Select(c => c.ToEntity(entity.Id, userDict.GetValueOrDefault(c.UserPortalId, string.Empty)))];
        }

        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity;
    }
}