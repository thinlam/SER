using QLHD.Application.DanhMucLoaiHopDongs.DTOs;

namespace QLHD.Application.DanhMucLoaiHopDongs.Queries;

public record DanhMucLoaiHopDongGetByIdQuery(int Id) : IRequest<DanhMucLoaiHopDongDto>;

internal class DanhMucLoaiHopDongGetByIdQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucLoaiHopDongGetByIdQuery, DanhMucLoaiHopDongDto>
{
    private readonly IRepository<DanhMucLoaiHopDong, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiHopDong, int>>();

    public async Task<DanhMucLoaiHopDongDto> Handle(DanhMucLoaiHopDongGetByIdQuery request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .Where(e => e.Id == request.Id)
            .Select(e => new DanhMucLoaiHopDongDto
            {
                Id = e.Id,
                Ma = e.Ma,
                Ten = e.Ten,
                MoTa = e.MoTa,
                Used = e.Used,
                Symbol = e.Symbol,
                Prefix = e.Prefix,
                IsDefault = e.IsDefault
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new KeyNotFoundException($"Không tìm thấy bản ghi với ID: {request.Id}");

        return entity;
    }
}