using Microsoft.EntityFrameworkCore;
using QLDA.Application.Common;

namespace QLDA.Application.VanBanPhapLys.Commands;

public record VanBanPhapLyDeleteCommand(Guid Id) : IRequest<int> {
}

public record VanBanPhapLyDeleteCommandHandler : IRequestHandler<VanBanPhapLyDeleteCommand, int> {
    private readonly IRepository<VanBanPhapLy, Guid> VanBanPhapLy;
    private readonly IRepository<TepDinhKem, Guid> TepDinhKem;
    private readonly IUnitOfWork _unitOfWork;

    public VanBanPhapLyDeleteCommandHandler(IServiceProvider serviceProvider) {
        VanBanPhapLy = serviceProvider.GetRequiredService<IRepository<VanBanPhapLy, Guid>>();
        TepDinhKem = serviceProvider.GetRequiredService<IRepository<TepDinhKem, Guid>>();
        _unitOfWork = VanBanPhapLy.UnitOfWork;
    }

    public async Task<int> Handle(VanBanPhapLyDeleteCommand request, CancellationToken cancellationToken) {
        var entity = await VanBanPhapLy.GetOrderedSet()
            .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        ManagedException.ThrowIfNull(entity);

        entity.IsDeleted = true;

        await SyncHelper.SetDeleteWithRelatedFiles(TepDinhKem, [entity.Id.ToString()], cancellationToken);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}