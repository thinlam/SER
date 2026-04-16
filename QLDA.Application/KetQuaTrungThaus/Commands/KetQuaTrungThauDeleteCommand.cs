using Microsoft.EntityFrameworkCore;
using QLDA.Application.Common;

namespace QLDA.Application.KetQuaTrungThaus.Commands;

public record KetQuaTrungThauDeleteCommand(Guid Id) : IRequest<int> {
}

public record KetQuaTrungThauDeleteCommandHandler : IRequestHandler<KetQuaTrungThauDeleteCommand, int> {
    private readonly IRepository<KetQuaTrungThau, Guid> KetQuaTrungThau;
    private readonly IRepository<TepDinhKem, Guid> TepDinhKem;
    private readonly IUnitOfWork _unitOfWork;

    public KetQuaTrungThauDeleteCommandHandler(IServiceProvider serviceProvider) {
        KetQuaTrungThau = serviceProvider.GetRequiredService<IRepository<KetQuaTrungThau, Guid>>();
        TepDinhKem = serviceProvider.GetRequiredService<IRepository<TepDinhKem, Guid>>();
        _unitOfWork = KetQuaTrungThau.UnitOfWork;
    }

    public async Task<int> Handle(KetQuaTrungThauDeleteCommand request, CancellationToken cancellationToken) {
        var entity = await KetQuaTrungThau.GetOrderedSet()
            // .Include(o => o.DanhSachToTrinh)
            .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        ManagedException.ThrowIfNull(entity);

        entity.IsDeleted = true;

        await SyncHelper.SetDeleteWithRelatedFiles(TepDinhKem, [entity.Id.ToString()], cancellationToken);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}