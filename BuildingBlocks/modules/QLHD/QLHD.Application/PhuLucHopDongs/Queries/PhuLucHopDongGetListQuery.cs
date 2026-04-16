using BuildingBlocks.Domain.DTOs;
using QLHD.Application.PhuLucHopDongs.DTOs;

namespace QLHD.Application.PhuLucHopDongs.Queries;

/// <summary>
/// Query lấy danh sách hợp đồng có phụ lục hợp đồng
/// </summary>
public record PhuLucHopDongGetListQuery(AggregateRootSearch SearchModel) : IRequest<PaginatedList<HopDongCoPhuLucDto>>;

internal class PhuLucHopDongGetListQueryHandler : IRequestHandler<PhuLucHopDongGetListQuery, PaginatedList<HopDongCoPhuLucDto>>
{
    private readonly IRepository<HopDong, Guid> _repository;

    public PhuLucHopDongGetListQueryHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
    }

    public async Task<PaginatedList<HopDongCoPhuLucDto>> Handle(PhuLucHopDongGetListQuery request, CancellationToken cancellationToken)
    {
        var model = request.SearchModel;
        var query = _repository.GetQueryableSet()
            .Select(e => new HopDongCoPhuLucDto
            {
                Id = e.Id,
                SoHopDong = e.SoHopDong,
                Ten = e.Ten,
                TenKhachHang = e.KhachHang!.Ten,
                TenDuAn = e.DuAn!.Ten,
                SoPhuLucCount = e.PhuLucHopDongs!.Count(p => !p.IsDeleted)
            });

        return await query.PaginatedListAsync(model.Skip(), model.Take(), cancellationToken: cancellationToken);
    }
}

/// <summary>
/// DTO cho danh sách hợp đồng có phụ lục
/// </summary>
public class HopDongCoPhuLucDto : IHasKey<Guid>
{
    public Guid Id { get; set; }
    public string SoHopDong { get; set; } = string.Empty;
    public string Ten { get; set; } = string.Empty;
    public string? TenKhachHang { get; set; }
    public string? TenDuAn { get; set; }
    public int SoPhuLucCount { get; set; }
}