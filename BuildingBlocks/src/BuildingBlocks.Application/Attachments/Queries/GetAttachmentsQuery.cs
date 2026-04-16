using BuildingBlocks.Application.Attachments.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Application.Attachments.Queries;

public record GetAttachmentsQuery(List<string> GroupId, List<string>? GroupTypes = null) : IRequest<List<AttachmentDto>>;
public record GetAttachmentsQueryHandler(IServiceProvider ServiceProvider)
    : IRequestHandler<GetAttachmentsQuery, List<AttachmentDto>> {
    private readonly IRepository<Attachment, Guid> Attachment =
        ServiceProvider.GetRequiredService<IRepository<Attachment, Guid>>();

    public async Task<List<AttachmentDto>> Handle(GetAttachmentsQuery request,
        CancellationToken cancellationToken) {
        return await Attachment.GetQueryableSet()
            .WhereIf(request.GroupTypes != null && request.GroupTypes.Count != 0,
                o => request.GroupId.Contains(o.GroupId) && request.GroupTypes!.Contains(o.GroupType),
                o => request.GroupId.Contains(o.GroupId))
            .Select(e => e.ToDto())
            .ToListAsync(cancellationToken);
    }
}
