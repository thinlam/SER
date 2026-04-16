using QLHD.Application.DanhMucGiamDocs.DTOs;

namespace QLHD.Application.DanhMucGiamDocs.Commands;

public record DanhMucGiamDocInsertCommand(DanhMucGiamDocInsertModel Model) : IRequest<DanhMucGiamDoc>;

internal class DanhMucGiamDocInsertCommandHandler : IRequestHandler<DanhMucGiamDocInsertCommand, DanhMucGiamDoc>
{
    private readonly IRepository<DanhMucGiamDoc, int> _repository;
    private readonly IRepository<UserMaster, long> _userMasterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucGiamDocInsertCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucGiamDoc, int>>();
        _userMasterRepository = serviceProvider.GetRequiredService<IRepository<UserMaster, long>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<DanhMucGiamDoc> Handle(DanhMucGiamDocInsertCommand request, CancellationToken cancellationToken = default)
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

    private async Task<DanhMucGiamDoc> InsertAsync(DanhMucGiamDocInsertCommand request, CancellationToken cancellationToken)
    {
        var model = request.Model;

        // Get user info from USER_MASTER (validator ensures user exists)
        var user = (await _userMasterRepository.GetQueryableSet()
            .FirstOrDefaultAsync(u => u.Id == model.UserPortalId, cancellationToken))!;

        var entity = model.ToEntity();
        entity.Ten = user.HoTen; // Auto-fill Ten from USER_MASTER.HoTen
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity;
    }
}