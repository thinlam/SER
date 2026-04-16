using Microsoft.EntityFrameworkCore;
using QLDA.Application.BaoCaoTienDos.DTOs;

namespace QLDA.Application.BaoCaoTienDos.Commands;

public record BaoCaoTienDoImportRangeCommand(List<BaoCaoTienDoImportDto> Imports) : IRequest {
}

public record BaoCaoTienDoImportRangeCommandHandler(IServiceProvider ServiceProvider)
    : IRequestHandler<BaoCaoTienDoImportRangeCommand> {
    private readonly IRepository<BaoCaoTienDo, Guid> BaoCaoTienDo =
        ServiceProvider.GetRequiredService<IRepository<BaoCaoTienDo, Guid>>();

    private readonly IRepository<DuAn, Guid> DuAn = ServiceProvider.GetRequiredService<IRepository<DuAn, Guid>>();

    private readonly IRepository<DuAnBuoc, int> DuAnBuoc =
        ServiceProvider.GetRequiredService<IRepository<DuAnBuoc, int>>();

    public async Task Handle(BaoCaoTienDoImportRangeCommand request, CancellationToken cancellationToken) {
        var duAnNames = request.Imports.Select(e => e.TenDuAn).ToList();
        // var buocNames = request.Imports.Select(e => e.TenBuoc).ToList();

        var duAns = await DuAn.GetOrderedSet()
            .Where(e => duAnNames.Contains(e.TenDuAn!))
            .Select(e => new { e.TenDuAn, e.Id }).ToListAsync(cancellationToken);
        var duAnDict = duAns.DistinctBy(e => e.TenDuAn).ToDictionary(g => g.TenDuAn!, g => g.Id);

        // var buocIds = await DuAnBuoc.GetOriginalSet()
        //     .Select(e => new { TenBuoc = e.TenBuoc ?? e.Buoc!.Ten, e.Id, e.DuAnId })
        //     .Where(e => buocNames.Contains(e.TenBuoc)).ToListAsync(cancellationToken);
        // var buocDict = buocIds.DistinctBy(e => new { e.TenBuoc, e.DuAnId })
        //     .ToDictionary(g => (g.TenBuoc, g.DuAnId), g => g.Id);

        foreach (var item in request.Imports) {
            if (!duAnDict.TryGetValue(item.TenDuAn ?? string.Empty, out var duAnId))
                continue;

            // int? buocId = null;
            // if (buocDict.TryGetValue((item.TenBuoc, duAnId), out var tmpBuocId))
            //     buocId = tmpBuocId;

            await BaoCaoTienDo.AddAsync(new BaoCaoTienDo {
                DuAnId = duAnId,
                // BuocId = buocId,
                Ngay = item.NgayBaoCao,
                NoiDung = item.NoiDung
            }, cancellationToken);
        }


        await BaoCaoTienDo.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}