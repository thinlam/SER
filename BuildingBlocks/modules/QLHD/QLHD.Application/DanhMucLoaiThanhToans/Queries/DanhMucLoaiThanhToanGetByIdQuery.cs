using QLHD.Application.DanhMucLoaiThanhToans.DTOs;

namespace QLHD.Application.DanhMucLoaiThanhToans.Queries;

public record DanhMucLoaiThanhToanGetByIdQuery(int Id) : IRequest<DanhMucLoaiThanhToanDto>;

internal class DanhMucLoaiThanhToanGetByIdQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucLoaiThanhToanGetByIdQuery, DanhMucLoaiThanhToanDto>
{
    private readonly IRepository<DanhMucLoaiThanhToan, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiThanhToan, int>>();

    public async Task<DanhMucLoaiThanhToanDto> Handle(DanhMucLoaiThanhToanGetByIdQuery request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .Where(e => e.Id == request.Id)
            .Select(e => new DanhMucLoaiThanhToanDto
            {
                Id = e.Id,
                Ma = e.Ma,
                Ten = e.Ten,
                MoTa = e.MoTa,
                Used = e.Used,
                IsDefault = e.IsDefault
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new KeyNotFoundException($"Không tìm thấy bản ghi với ID: {request.Id}");

        return entity;
    }
}