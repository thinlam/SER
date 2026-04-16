using Microsoft.EntityFrameworkCore;
using QLDA.Application.Common;

namespace QLDA.Application.VanBanChuTruongs.Commands;

public record VanBanChuTruongDeleteCommand(Guid Id) : IRequest<int>
{
}

public record VanBanChuTruongDeleteCommandHandler : IRequestHandler<VanBanChuTruongDeleteCommand, int>
{
    private readonly IRepository<VanBanChuTruong, Guid> VanBanChuTruong;
    private readonly IRepository<TepDinhKem, Guid> TepDinhKem;
    private readonly IUnitOfWork _unitOfWork;

    public VanBanChuTruongDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        VanBanChuTruong =serviceProvider.GetRequiredService<IRepository<VanBanChuTruong, Guid>>();
        TepDinhKem = serviceProvider.GetRequiredService<IRepository<TepDinhKem, Guid>>();
        _unitOfWork = VanBanChuTruong.UnitOfWork;
    }

    public async Task<int> Handle(VanBanChuTruongDeleteCommand request, CancellationToken cancellationToken)
    {
        var entity = await VanBanChuTruong.GetOrderedSet()
            .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        ManagedException.ThrowIfNull(entity);
        
        entity.IsDeleted = true;

        await SyncHelper.SetDeleteWithRelatedFiles(TepDinhKem, [entity.Id.ToString()], cancellationToken);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}