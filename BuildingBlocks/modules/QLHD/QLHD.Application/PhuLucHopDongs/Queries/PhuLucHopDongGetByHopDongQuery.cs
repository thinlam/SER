using BuildingBlocks.Application.Attachments.DTOs;
using QLHD.Application.PhuLucHopDongs.DTOs;

namespace QLHD.Application.PhuLucHopDongs.Queries;

/// <summary>
/// Query lấy danh sách phụ lục hợp đồng theo HopDongId
/// </summary>
public record PhuLucHopDongGetByHopDongQuery(Guid HopDongId) : IRequest<List<PhuLucHopDongDto>>;

internal class PhuLucHopDongGetByHopDongQueryHandler : IRequestHandler<PhuLucHopDongGetByHopDongQuery, List<PhuLucHopDongDto>>
{
    private readonly IRepository<PhuLucHopDong, Guid> _repository;
    private readonly IRepository<Attachment, Guid> _attachmentRepository;

    public PhuLucHopDongGetByHopDongQueryHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<PhuLucHopDong, Guid>>();
        _attachmentRepository = serviceProvider.GetRequiredService<IRepository<Attachment, Guid>>();
    }

    public async Task<List<PhuLucHopDongDto>> Handle(PhuLucHopDongGetByHopDongQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetQueryableSet()
            .Where(e => e.HopDongId == request.HopDongId)
            .OrderByDescending(e => e.NgayKy)
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
            .ToListAsync(cancellationToken);

        return result;
    }
}