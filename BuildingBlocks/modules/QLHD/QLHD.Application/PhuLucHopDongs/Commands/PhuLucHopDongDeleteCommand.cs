namespace QLHD.Application.PhuLucHopDongs.Commands;

/// <summary>
/// Command xóa phụ lục hợp đồng
/// </summary>
public record PhuLucHopDongDeleteCommand(Guid Id) : IRequest;

internal class PhuLucHopDongDeleteCommandHandler : IRequestHandler<PhuLucHopDongDeleteCommand>
{
    private readonly IRepository<PhuLucHopDong, Guid> _repository;
    private readonly IRepository<Attachment, Guid> _attachmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PhuLucHopDongDeleteCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<PhuLucHopDong, Guid>>();
        _attachmentRepository = serviceProvider.GetRequiredService<IRepository<Attachment, Guid>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task Handle(PhuLucHopDongDeleteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        ManagedException.ThrowIfNull(entity, "Không tìm thấy phụ lục hợp đồng");

        // Delete associated Attachments
        var attachments = await _attachmentRepository.GetQueryableSet()
            .Where(t => t.GroupId == entity.Id.ToString())
            .ToListAsync(cancellationToken);

        if (attachments.Count > 0)
        {
            _attachmentRepository.BulkDelete(attachments);
        }

        _repository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}