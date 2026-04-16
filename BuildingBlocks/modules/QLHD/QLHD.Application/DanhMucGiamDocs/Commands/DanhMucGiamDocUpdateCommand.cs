using QLHD.Application.DanhMucGiamDocs.DTOs;

namespace QLHD.Application.DanhMucGiamDocs.Commands;

public record DanhMucGiamDocUpdateCommand(int Id, DanhMucGiamDocUpdateModel Model) : IRequest<DanhMucGiamDoc>;

internal class DanhMucGiamDocUpdateCommandHandler : IRequestHandler<DanhMucGiamDocUpdateCommand, DanhMucGiamDoc>
{
    private readonly IRepository<DanhMucGiamDoc, int> _repository;
    private readonly IRepository<UserMaster, long> _userMasterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DanhMucGiamDocUpdateCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<DanhMucGiamDoc, int>>();
        _userMasterRepository = serviceProvider.GetRequiredService<IRepository<UserMaster, long>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<DanhMucGiamDoc> Handle(DanhMucGiamDocUpdateCommand request, CancellationToken cancellationToken = default)
    {
        var entity = (await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken))!;

        var model = request.Model;

        // Get user info from USER_MASTER (validator ensures user exists)
        var user = (await _userMasterRepository.GetQueryableSet()
            .FirstOrDefaultAsync(u => u.Id == model.UserPortalId, cancellationToken))!;

        entity.UpdateFrom(model);
        entity.Ten = user.HoTen; // Auto-fill Ten from USER_MASTER.HoTen
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity;
    }
}