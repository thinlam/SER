using Microsoft.EntityFrameworkCore;
using QLDA.Application.Common;

namespace QLDA.Application.NghiemThus.Commands;

public record NghiemThuDeleteCommand(Guid Id) : IRequest {
}

public record NghiemThuDeleteCommandHandler : IRequestHandler<NghiemThuDeleteCommand> {
    private readonly IRepository<NghiemThu, Guid> NghiemThu;
    private readonly IRepository<TepDinhKem, Guid> TepDinhKem;
    private readonly IUnitOfWork _unitOfWork;

    public NghiemThuDeleteCommandHandler(IServiceProvider serviceProvider) {
        NghiemThu = serviceProvider.GetRequiredService<IRepository<NghiemThu, Guid>>();
        TepDinhKem = serviceProvider.GetRequiredService<IRepository<TepDinhKem, Guid>>();
        _unitOfWork = NghiemThu.UnitOfWork;
    }

    public async Task Handle(NghiemThuDeleteCommand request, CancellationToken cancellationToken) {
        var entity = await NghiemThu.GetOrderedSet()
           .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        ManagedException.ThrowIfNull(entity);
        
        entity.IsDeleted = true;

        await SyncHelper.SetDeleteWithRelatedFiles(TepDinhKem, [entity.Id.ToString()], cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}