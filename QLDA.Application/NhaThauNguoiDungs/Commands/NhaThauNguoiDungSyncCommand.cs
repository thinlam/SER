using Microsoft.EntityFrameworkCore;

namespace QLDA.Application.NhaThauNguoiDungs.Commands;

/// <summary>
/// Sync (bulk insert/delete) NguoiDung list for a NhaThau
/// </summary>
public class NhaThauNguoiDungSyncCommand : IRequest<int> {
    public Guid NhaThauId { get; set; }
    public List<long> NguoiDungIds { get; set; } = [];
}

internal class NhaThauNguoiDungSyncCommandHandler(IServiceProvider serviceProvider)
    : IRequestHandler<NhaThauNguoiDungSyncCommand, int> {
    private readonly IRepository<NhaThauNguoiDung, int> _repository =
        serviceProvider.GetRequiredService<IRepository<NhaThauNguoiDung, int>>();

    public async Task<int> Handle(NhaThauNguoiDungSyncCommand request,
        CancellationToken cancellationToken = default) {

        var existing = await _repository.GetQueryableSet()
            .AsNoTracking()
            .Where(e => e.NhaThauId == request.NhaThauId)
            .ToListAsync(cancellationToken);

        var existingIds = existing.Select(e => e.NguoiDungId).ToHashSet();
        var requestIds = request.NguoiDungIds.ToHashSet();

        // Add new
        var toAdd = requestIds.Except(existingIds)
            .Select(nguoiDungId => new NhaThauNguoiDung {
                NhaThauId = request.NhaThauId,
                NguoiDungId = nguoiDungId
            }).ToList();

        if (toAdd.Count > 0)
            _repository.BulkInsert(toAdd);

        // Remove deleted
        var toRemove = existing.Where(e => !requestIds.Contains(e.NguoiDungId)).ToList();
        if (toRemove.Count > 0)
            _repository.BulkDelete(toRemove);

        return toAdd.Count + toRemove.Count;
    }
}
