using BuildingBlocks.Application.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Application.Attachments.Commands;

public record AttachmentBulkInsertOrUpdateCommand : IRequest {
    public required string GroupId { get; set; }
    public required List<Attachment>? Attachments { get; set; }
    public bool KySo { get; set; }
}

internal class AttachmentBulkInsertOrUpdateCommandHandler(
    IRepository<Attachment, Guid> repository,
    IUnitOfWork unitOfWork,
    ILogger<AttachmentBulkInsertOrUpdateCommandHandler> logger) : IRequestHandler<AttachmentBulkInsertOrUpdateCommand> {
    private readonly IRepository<Attachment, Guid> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<AttachmentBulkInsertOrUpdateCommandHandler> _logger = logger;

    public async Task Handle(AttachmentBulkInsertOrUpdateCommand request,
        CancellationToken cancellationToken = default) {
        if (_unitOfWork.HasTransaction) {
            await InsertOrUpdateAsync(request, cancellationToken);
        } else {
            using var tx = await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
            await InsertOrUpdateAsync(request, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
    }

    #region Private helper methods

    /// <summary>
    /// Xoá mềm
    /// </summary>
    private async Task InsertOrUpdateAsync(AttachmentBulkInsertOrUpdateCommand request, CancellationToken cancellationToken = default) {
        var files = await _repository.GetQueryableSet()
            .Where(e => e.GroupId == request.GroupId)
            .ToListAsync(cancellationToken);

        await SyncHelper.SyncCollection(
            repository: _repository,
            existingEntities: files,
            requestEntities: request.Attachments,
            (existing, request) => {
                existing.Type = request.Type;
                existing.FileName = request.FileName;
                existing.OriginalName = request.OriginalName;
                existing.Path = request.Path;
                existing.Size = request.Size;
            },
            cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Xoá cứng
    /// </summary>
    private async Task InsertOrUpdateCascadeAsync(AttachmentBulkInsertOrUpdateCommand request, CancellationToken cancellationToken = default) {
        #region Không có file - xóa hết

        request.Attachments ??= [];
        if (request.Attachments.Count == 0) {
            await _repository.GetQueryableSet()
                .Where(e => e.GroupId == request.GroupId)
                .ExecuteDeleteAsync(cancellationToken);
            return;
        }

        #endregion

        #region Có file

        var requestIds = request.Attachments.Select(e => e.Id).ToList();

        var existing = await _repository.GetOrderedSet()
            .Where(e => e.GroupId == request.GroupId)
            .ToListAsync(cancellationToken);
        var existingIds = existing.Select(e => e.Id).ToList();

        var toAdd = request.Attachments
            .Where(e => !existingIds.Contains(e.Id)).ToList();

        var toUpdate = request.Attachments
            .Where(e => existingIds.Contains(e.Id)).ToList();

        var toRemove = existing
            .Where(e => !requestIds.Contains(e.Id))
            .ToList();

        if (toAdd.Count == 0 && toUpdate.Count == 0 && toRemove.Count == 0) return;

        if (toAdd.Count != 0) {
            _repository.BulkInsert(toAdd);
        }

        if (toUpdate.Count != 0) {
            _repository.BulkUpdate(toUpdate, x => new {
                x.Type,
                x.FileName,
                x.OriginalName,
                x.Path,
                x.Size
            });
        }

        if (toRemove.Count != 0 && !request.KySo)
            _repository.BulkDelete(toRemove);

        #endregion
    }

    #endregion
}