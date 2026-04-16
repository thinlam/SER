using QLHD.Application.DanhMucNguoiPhuTrachs.DTOs;

namespace QLHD.Application.DanhMucNguoiPhuTrachs.Commands;

public record DanhMucNguoiPhuTrachInsertCommand(DanhMucNguoiPhuTrachInsertModel Model) : IRequest<DanhMucNguoiPhuTrach>;

internal class DanhMucNguoiPhuTrachInsertCommandHandler : IRequestHandler<DanhMucNguoiPhuTrachInsertCommand, DanhMucNguoiPhuTrach>
{
    private readonly IRepository<DanhMucNguoiPhuTrach, int> _repository;
    private readonly IRepository<UserMaster, long> _userMasterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucNguoiPhuTrachInsertCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucNguoiPhuTrach, int>>();
        _userMasterRepository = serviceProvider.GetRequiredService<IRepository<UserMaster, long>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<DanhMucNguoiPhuTrach> Handle(DanhMucNguoiPhuTrachInsertCommand request, CancellationToken cancellationToken = default)
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

    private async Task<DanhMucNguoiPhuTrach> InsertAsync(DanhMucNguoiPhuTrachInsertCommand request, CancellationToken cancellationToken)
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