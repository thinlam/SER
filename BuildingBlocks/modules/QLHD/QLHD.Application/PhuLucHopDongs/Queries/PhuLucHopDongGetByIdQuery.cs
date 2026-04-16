using BuildingBlocks.Application.Attachments.DTOs;
using QLHD.Application.PhuLucHopDongs.DTOs;

namespace QLHD.Application.PhuLucHopDongs.Queries;

/// <summary>
/// Query lấy chi tiết phụ lục hợp đồng theo Id
/// </summary>
public record PhuLucHopDongGetByIdQuery(Guid Id) : IRequest<PhuLucHopDongDto>;

internal class PhuLucHopDongGetByIdQueryHandler : IRequestHandler<PhuLucHopDongGetByIdQuery, PhuLucHopDongDto>
{
    private readonly IRepository<PhuLucHopDong, Guid> _repository;
    private readonly IRepository<Attachment, Guid> _attachmentRepository;

    public PhuLucHopDongGetByIdQueryHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<PhuLucHopDong, Guid>>();
        _attachmentRepository = serviceProvider.GetRequiredService<IRepository<Attachment, Guid>>();
    }

    public async Task<PhuLucHopDongDto> Handle(PhuLucHopDongGetByIdQuery request, CancellationToken cancellationToken)
    {
        var dto = await _repository.GetQueryableSet()
            .Where(e => e.Id == request.Id)
            .Select(e => new PhuLucHopDongDto
            {
                Id = e.Id,
                HopDongId = e.HopDongId,
                SoPhuLuc = e.SoPhuLuc,
                NgayKy = e.NgayKy,
                NoiDungPhuLuc = e.NoiDungPhuLuc,
                DanhSachTepDinhKem = _attachmentRepository.GetQueryableSet()
                    .Where(f => f.GroupId == e.Id.ToString())
                    .Select(f => f.ToDto())
                    .ToList()
            })
            .FirstOrDefaultAsync(cancellationToken);

        ManagedException.ThrowIfNull(dto, "Không tìm thấy phụ lục hợp đồng");

        return dto;
    }
}